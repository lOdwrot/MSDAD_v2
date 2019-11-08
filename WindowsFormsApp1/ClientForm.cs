using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text.RegularExpressions;
using CommonTypes;
using System.IO;
using System.Threading;

namespace Client
{
	public partial class ClientForm : Form
	{
		private string defaultPort = "";
		private string defaultServiceName = "";
		private string preferredServer = "";

		private List<string> scriptCommands;

		private List<Meeting> meetingsList = new List<Meeting>();
		
		public ClientForm(string[] param = null)
		{
			// initialize form
			InitializeComponent();

			// bind meetings to GUI list
			this.meetingsListBox.DataSource = this.meetingsList;

			// read config file
			var appSettings = ConfigurationManager.AppSettings;
			this.defaultPort = appSettings["defaultPort"];
			this.defaultServiceName = appSettings["defaultServiceName"];
			this.preferredServer = appSettings["preferredServer"];

			// if command line parameters were given by PuppetMaster
			if (param != null)
			{
				// get parameters
				string username = param[0];
				string clientUrl = param[1];
				string serverUrl = param[2];
				string scriptFile = param[3];

				// get port and service name via client url
				// TODO: how can we launch the service on an IP other than the machine's?
				string[] splitClientUrl = Regex.Split(clientUrl, "[:/]");
				string serviceName = splitClientUrl[splitClientUrl.Length - 1];
				string port = splitClientUrl[splitClientUrl.Length - 2];

				// fill in visual details
				usernameBox.Text = username;
				portBox.Text = port;
				usernameBox.Enabled = false;
				portBox.Enabled = false;
				registerButton.Enabled = false;
				debugBox.Enabled = true;

				// set preferred server
				this.preferredServer = serverUrl;

				// create client remote object
				this.CreateRemoteService(port, serviceName);

				// run script file
				this.ReadScriptFile(scriptFile);
			}
		}

		// Form Event Handlers

		private void usernameBox_TextChanged(object sender, EventArgs e)
		{
			registerButton.Enabled = usernameBox.TextLength > 0 && portBox.Value > 0 && portBox.Value < 65536;
		}

		private void portBox_ValueChanged(object sender, EventArgs e)
		{
			registerButton.Enabled = usernameBox.TextLength > 0 && portBox.Value > 0 && portBox.Value < 65536;
		}

		private void registerButton_Click(object sender, EventArgs e)
		{
			usernameBox.Enabled = false;
			portBox.Enabled = false;
			registerButton.Enabled = false;

			// create client remote object
			this.CreateRemoteService(portBox.Text);
		}

		private void debugButton_Click(object sender, EventArgs e)
		{
			RunNextScript();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			CreateMeetingForm meetingPopup = new CreateMeetingForm();
			DialogResult dialogResult = meetingPopup.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				CreateNewMeeting(this.usernameBox.Text,
						meetingPopup.getTopic(), meetingPopup.getMinimumParticipants(),
						meetingPopup.getProposals(), meetingPopup.getInvitedParticipants());
			}
		}

		private void refreshList_Click(object sender, EventArgs e)
		{
			GetMeetingsList();
		}

		// Network Functions

		private void CreateRemoteService(string port = null, string serviceName = null)
		{
			port = port ?? defaultPort;
			serviceName = serviceName ?? defaultServiceName;

			try
			{
				// reserve port
				TcpChannel channel = new TcpChannel(int.Parse(port));
				ChannelServices.RegisterChannel(channel, false);

				// register client remote object
				RemotingConfiguration.RegisterWellKnownServiceType(
					typeof(ClientInstance),
					serviceName,
					WellKnownObjectMode.Singleton);

				// give access to the rest of the GUI
				this.schedulerGroupBox.Enabled = true;
			}
			catch (Exception e)
			{
				ThrowErrorPopup(e);
			}
		}

		private void GetMeetingsList()
		{
			try
			{
				// contact server
				ServerInstance obj = (ServerInstance)Activator.GetObject(
					typeof(ServerInstance),
					preferredServer);

				// ask server about current meetings
				var updatedMeetings = obj.GetMeetings();

				// update local meetings
				this.meetingsList = updatedMeetings;
				this.meetingsListBox.DataSource = this.meetingsList;
			}
			catch (RemotingException e)
			{
				ThrowErrorPopup(e);
			}
		}

		private void CreateNewMeeting(string username, string topic, int minParticipants,
			List<Slot> proposals, List<string> participants)
		{
			try
			{
				// create Meeting object from popup form fields
				Meeting newMeeting = new Meeting(username, topic,
					minParticipants, proposals, participants);

				// contact server
				ServerInstance obj = (ServerInstance)Activator.GetObject(
					typeof(ServerInstance),
					preferredServer);

				// tell server to create a new meeting
				bool created = obj.CreateMeeting(newMeeting);

				// TODO: throw custom error if meeting could not be created
				if (!created)
				{
					ThrowErrorPopup(new MeetingNotCreatedException());
				}
				else
				{
					// meeting was created successfully; add to list
					this.meetingsList.Add(newMeeting);
				}
			}
			catch (RemotingException e)
			{
				ThrowErrorPopup(e);
			}
		}

		private void JoinMeeting(string meetingTopic, Slot slot)
		{
			try
			{
				// contact server
				ServerInstance obj = (ServerInstance)Activator.GetObject(
					typeof(ServerInstance),
					preferredServer);

				// tell server you want to join
				bool joined = obj.JoinMeeting(usernameBox.Text, meetingTopic, slot);

				// TODO: throw custom error if meeting could not be joined
				if (!joined)
				{
					ThrowErrorPopup(new MeetingNotJoinedException());
				}
				else
				{
					// joined meeting successfully; reflect changes client-side
					var meeting = this.meetingsList.Find(m => m.topic.Equals(meetingTopic));
					meeting.submitVotes(this.usernameBox.Text, slot);
				}
			}
			catch (RemotingException e)
			{
				ThrowErrorPopup(e);
			}
		}

		private void CloseMeeting(string meetingTopic)
		{

			// TODO: if user is not meeting coordinator, throw error

			try
			{
				// contact server
				ServerInstance obj = (ServerInstance)Activator.GetObject(
					typeof(ServerInstance),
					preferredServer);

				// tell server you want to close the meeting
				Meeting closedMeeting = obj.CloseMeeting(usernameBox.Text, meetingTopic);

				// TODO: throw custom error if meeting could not be closed
				if (closedMeeting is null)
				{
					ThrowErrorPopup(new MeetingNotClosedException());
				}
				else
				{
					// closed meeting successfully; reflect changes client-side
					var meetingIndex = this.meetingsList.FindIndex(m => m.topic.Equals(meetingTopic));
					this.meetingsList[meetingIndex] = closedMeeting;
				}
			}
			catch (RemotingException e)
			{
				ThrowErrorPopup(e);
			}
		}

		// Misc. Functions

		private void ThrowErrorPopup(Exception e)
		{
			ErrorPopupForm popup = new ErrorPopupForm(e.GetType().ToString(), e.Message);
			DialogResult dialogresult = popup.ShowDialog();
			if (dialogresult == DialogResult.OK)
			{

			}
			popup.Dispose();
		}

		private void ReadScriptFile(string fileName)
		{
			try
			{
				this.scriptCommands = new List<string>(File.ReadAllLines(fileName));
			}
			catch (FileNotFoundException e)
			{
				ThrowErrorPopup(e);
			}
		}

		private void RunNextScript()
		{
			// grab the first command and parse it
			string command = this.scriptCommands.First();
			this.scriptCommands.RemoveAt(0);

			string[] commandArgs = command.Split(' ');
			switch (commandArgs[0])
			{
				// list
				case "list":
					GetMeetingsList();
					break;
				// create meeting_topic min_atendees number_of_slots number_of_invitees slot_1 ... slot_n invitee_1 ... invitee_n
				case "create":
					string topic = commandArgs[1];
					int minAtendees = int.Parse(commandArgs[2]);
					int numSlots = int.Parse(commandArgs[3]);
					int numInvitees = int.Parse(commandArgs[4]);
					List<Slot> proposals = new List<Slot>();
					for (int i = 5; i < 5 + numSlots - 1; i++)
					{
						var currSlot = commandArgs[i].Split(',');
						proposals.Add(new Slot(
							currSlot[1],
							currSlot[0]
						));
					}
					List<string> participants = new List<string>();
					for (int i = 5 + numSlots; i < commandArgs.Length; i++)
					{
						participants.Add(commandArgs[i]);
					}
					CreateNewMeeting(this.usernameBox.Text, topic, minAtendees, proposals, participants);
					break;
				// join meeting_topic
				case "join":
					var meetingTopic = commandArgs[1];
					// script does not select any specific slot, so we'll take the first one available
					var slot = this.meetingsList.Find(m => m.topic.Equals(meetingTopic)).proposals.First();
					JoinMeeting(meetingTopic, slot);
					break;
				// close meeting_topic
				case "close":
					CloseMeeting(commandArgs[1]);
					break;
				// wait x
				case "wait":
					Thread.Sleep(int.Parse(commandArgs[1]));
					break;
				// if any other command is given, do nothing
				default:
					// TODO: print info to log
					break;
			}
		}
	}
}
