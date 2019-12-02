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
		private readonly string emptyFieldText = "----------------";

		private string defaultPort = "";
		private string defaultServiceName = "";
		private string preferredServer = "";
        private string clientURL = "";
        private string userName = "";
        private ClientInstance client;
        private IServer defaultServerInstance;

        private List<string> scriptCommands;

        private List<Meeting> meetingsList = new List<Meeting>();
		private object meetingsListLock = new object();

		public delegate bool AddNewMeeting(Meeting newMeeting);
		
		public ClientForm(string[] param = null)
		{
			// initialize form
			InitializeComponent();

			// read config file
			var appSettings = ConfigurationManager.AppSettings;
			this.defaultPort = appSettings["defaultPort"];
			this.defaultServiceName = appSettings["defaultServiceName"];
			this.preferredServer = appSettings["preferredServer"];

            // if command line parameters were given by PuppetMaster
            if (param != null)
			{
                // get parameters
                userName = param[0];
                clientURL = param[1];
				string serverUrl = param[2];
				string scriptFile = param[3];

				// get port and service name via client url
				string[] splitClientUrl = Regex.Split(clientURL, "[:/]");
				string serviceName = splitClientUrl[splitClientUrl.Length - 1];
				string port = splitClientUrl[splitClientUrl.Length - 2];

				// fill in visual details
				usernameBox.Text = userName;
				portBox.Text = port;
				usernameBox.Enabled = false;
				portBox.Enabled = false;
				registerButton.Enabled = false;
				debugBox.Enabled = true;

				// set preferred server
				this.preferredServer = serverUrl;

				// create client remote object
				this.CreateRemoteService(port, serviceName);

                //get initial contact list
                client.KnownClients = this.getCommunicationServer().getAgregatedClientsSubset();

                // notify others about my existance
                client.KnownClients.Values.ToList().ForEach(knownClientUrl =>
                {
                    ((ClientInstance)Activator.GetObject(
                        typeof(ClientInstance),
                        knownClientUrl
                    )).appendNewClient(userName, client.ClientURL);
                });

                //notify server about my data and get server list in return
                this.getCommunicationServer().registerNewClient(userName, clientURL);
                this.client.KnownServers = this.getCommunicationServer().getOtherServerAddresses();

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

		private void debugAllButton_Click(object sender, EventArgs e)
		{
			var commandsRemaining = true;
			while (commandsRemaining)
			{
				commandsRemaining = RunNextScript();
			}
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
			UpdateSelectedMeeting();
		}

		private void meetingsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateSelectedMeeting();
		}

		private void UpdateSelectedMeeting()
		{
			var index = this.meetingsListBox.SelectedIndex;
			if (index < 0 || index >= this.meetingsList.Count)
				return;
			var meeting = this.meetingsList[index];
			this.splitContainer2.Panel2.Enabled = true;
			this.topicValueLabel.Text = meeting.topic;
			this.coordinatorValueLabel.Text = meeting.coordinator;
			this.participantsValueLabel.Text = meeting.minimumParticipants.ToString();
			this.statusValueLabel.Text = meeting.status.ToString();

			// if user is coordinator and meeting isn't closed, enable "close meeting" button
			this.closeMeetingButton.Enabled =
				this.usernameBox.Text == meeting.coordinator && meeting.status == MeetingStatus.New;

			// display participants who've already joined
			UpdateListBox(this.participantsListBox, meeting.getCurrentParticipants());

			// display selectable date-location slots
			UpdateListBox(this.slotListBox, meeting.proposals);

			// disable slot list if user already voted
			this.slotListBox.Enabled = meeting.votes.Where(v => v.voterName == this.usernameBox.Text).Count() == 0;
		}

		private void slotListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var meeting = this.meetingsList[this.meetingsListBox.SelectedIndex];

			// if user hasn't already joined the meeting and any meeting was selected, enable "join meeting" button
			this.joinMeetingButton.Enabled = meeting.votes.Where(v => v.voterName == this.usernameBox.Text).Count() == 0
				&& this.slotListBox.SelectedItems.Count > 0;
		}

		private void joinMeetingButton_Click(object sender, EventArgs e)
		{
			var meeting = this.meetingsList[this.meetingsListBox.SelectedIndex];
			var slots = this.slotListBox.SelectedItems;
			JoinMeeting(meeting.topic, slots.Cast<Slot>().ToList());
		}

		private void closeMeetingButton_Click(object sender, EventArgs e)
		{
			var meeting = this.meetingsList[this.meetingsListBox.SelectedIndex];
			CloseMeeting(meeting.topic);
		}

		private void listKnownClientsButton_Click_1(object sender, EventArgs e)
		{
			client.KnownClients.Values.ToList().ForEach(v => appendLog(v));
		}

		private void listServers_Click(object sender, EventArgs e)
		{
			foreach (string s in this.client.KnownServers)
			{
				appendLog(s);
			}
			appendLog("Using: " + preferredServer);
		}

		private void clearLogsButton_Click_1(object sender, EventArgs e)
		{
			logsTextBox.Text = "";
		}

		// Network Functions

		private void CreateRemoteService(string port = null, string serviceName = null)
		{
			port = port ?? defaultPort;
			serviceName = serviceName ?? defaultServiceName;

            TcpChannel channel = new TcpChannel(int.Parse(port));
            ChannelServices.RegisterChannel(channel, true);

            client = new ClientInstance("tcp://localhost:" + port +"/" + serviceName, new AddNewMeeting(AddMeetingToList));
            RemotingServices.Marshal(client, serviceName, typeof(ClientInstance));

			this.schedulerGroupBox.Enabled = true;
        }

        private void GetMeetingsList()
		{
			try
			{
				// ask server about current meetings
				Executable executable = new Executable
				{
					action = "getMeetings"
				};
				List<Meeting> updatedMeetings = null;
				try
				{
					updatedMeetings = (List<Meeting>) TryRequest(executable);
				}
				catch (NoServersAvailableException e)
				{
					ThrowErrorPopup(e);
					return;
				}

				// add meetings to client meeting
				lock (meetingsListLock)
				{
					this.meetingsList = updatedMeetings; 
				}

				// update local meetings
				UpdateListBox(this.meetingsListBox, this.meetingsList);
				UpdateSelectedMeeting();
			}
			catch (Exception e)
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

                // tell server to create a new meeting
                Executable executable = new Executable
                {
                    action = "createMeeting",
                    newMeeting = newMeeting
                };

				int output = 0;
				try
				{
					output = (int)TryRequest(executable);
				}
				catch (NoServersAvailableException e)
				{
					ThrowErrorPopup(e);
					return;
				}

				switch (output) {
					case -1:
						ThrowErrorPopup(new LocationDoesNotExistException());
						break;
					case -2:
						ThrowErrorPopup(new MeetingAlreadyExistsException());
						break;
					default:
						// meeting was created successfully; add to list
						lock (meetingsListLock)
						{
							this.meetingsList.Add(newMeeting); 
						}

						// Gossip: spread meeting
						this.client.GossipSpreadMeeting(newMeeting);

						// update local meetings
						UpdateListBox(this.meetingsListBox, this.meetingsList);
						UpdateSelectedMeeting();
						break;
				}
			}
			catch (RemotingException e)
			{
				ThrowErrorPopup(e);
			}
		}

		private void JoinMeeting(string meetingTopic, List<Slot> slots)
		{
			try
			{
                Executable executable = new Executable
                {
                    action = "joinMeeting",
                    username = usernameBox.Text,
                    meetingTopic = meetingTopic,
                    slotsPicked = slots
                };

				// tell server you want to join
				int output = 0;
				try
				{
					output = (int)TryRequest(executable);
				}
				catch (NoServersAvailableException e)
				{
					ThrowErrorPopup(e);
					return;
				}

				switch (output)
				{
					case -1:
						ThrowErrorPopup(new UnproposedSlotsMeetingException());
						break;
					case -2:
						ThrowErrorPopup(new AlreadyJoinedMeetingException());
						break;
					case -3:
						ThrowErrorPopup(new NotInvitedMeetingException());
						break;
					default:
						// joined meeting successfully; reflect changes client-side
						var meeting = this.meetingsList.Find(m => m.topic.Equals(meetingTopic));
						meeting.submitVotes(this.usernameBox.Text, slots);

						// update local meetings
						UpdateListBox(this.meetingsListBox, this.meetingsList);

						// if meeting was selected one, update GUI
						if (this.meetingsListBox.SelectedIndex == this.meetingsList.IndexOf(meeting))
							UpdateSelectedMeeting();
						break;
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
                // tell server you want to close the meeting
                Executable executable = new Executable
                {
                    action = "closeMeeting",
                    username = usernameBox.Text,
                    meetingTopic = meetingTopic
                };

				// tell server you want to join
				Meeting closedMeeting = null;
				try
				{
					closedMeeting = (Meeting)TryRequest(executable);
				}
				catch (NoServersAvailableException e)
				{
					ThrowErrorPopup(e);
					return;
				}

				// TODO: throw custom error if meeting could not be closed
				if (closedMeeting is null)
				{
					ThrowErrorPopup(new MeetingNotClosedException());
				}
				else
				{
					// closed meeting successfully; reflect changes client-side
					var meetingIndex = this.meetingsList.FindIndex(m => m.topic.Equals(meetingTopic));
					lock (meetingsListLock) {
						this.meetingsList[meetingIndex] = closedMeeting;
					}

					// update local meetings
					UpdateListBox(this.meetingsListBox, this.meetingsList);

					// if meeting was selected one, update GUI
					if (this.meetingsListBox.SelectedIndex == meetingIndex)
						UpdateSelectedMeeting();
				}
			}
			catch (RemotingException e)
			{
				ThrowErrorPopup(e);
			}
		}

		// Misc. Functions
        
		private bool AddMeetingToList(Meeting newMeeting)
		{
			lock(meetingsListLock)
			{
				if (this.meetingsList.Where(m => m.topic.Equals(newMeeting.topic)).Count() > 0)
					return false;
				this.meetingsList.Add(newMeeting);
				UpdateListBox(this.meetingsListBox, this.meetingsList);
				return true;
			}
		}

        // We can also make a test call to server to check whether it's alive
        private IServer getCommunicationServer()
        {
            defaultServerInstance = defaultServerInstance 
                ?? (IServer)Activator.GetObject(
                    typeof(IServer),
                    preferredServer);

            return defaultServerInstance;
        }

		private object TryRequest(Executable executable)
		{
			List<string> servers = this.client.KnownServers;
			int attempts = 1;
			int maxAttempts = servers.Count;

			object response = null;
			bool serverReplied = false;
			while (!serverReplied)
			{
				try
				{
					if (executable.action.Equals("getMeetings"))
						response = getCommunicationServer().GetMeetings();
					else
						response = getCommunicationServer().Request(executable);
					serverReplied = true;
				}
				catch (Exception)
				{
					// server unavailable
					attempts++;
					if (attempts > maxAttempts)
					{
						// no other server was available
						throw new NoServersAvailableException();
					}
					else
					{
						// change preferred server
						
						// clear current server
						this.defaultServerInstance = null;
						
						// set next server as preferred one
						this.preferredServer = servers[(servers.IndexOf(this.preferredServer) + 1) % servers.Count];
					}
				}
			}
			return response;
		}

		public static void UpdateListBox<T>(ListBox listBox, List<T> list)
		{
			listBox.DataSource = null;
			listBox.DataSource = list;
		}

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
				this.debugButton.Enabled = true;
				this.debugAllButton.Enabled = true;
				this.debugLabel.Text = this.scriptCommands[0];
			}
			catch (Exception e)
			{
				// if file does not exist, then just simply run the client as-is
				// no need to throw error
				ThrowErrorPopup(e);
			}
		}

		private bool RunNextScript()
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
					for (int i = 5; i < 5 + numSlots; i++)
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
				// join meeting_topic number_of_slots slot_1 ... slot_n
				case "join":
					var meetingTopic = commandArgs[1];
					var numberSlots = int.Parse(commandArgs[2]);
					var slotList = new List<Slot>();
					for (int i = 3; i < numberSlots + 3; i++)
					{
						var currSlot = commandArgs[i].Split(',');
						slotList.Add(new Slot(
							currSlot[1],
							currSlot[0]
						));
					}
					JoinMeeting(meetingTopic, slotList);
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
			if (this.scriptCommands.Count == 0)
			{
				this.debugLabel.Text = emptyFieldText;
				this.debugButton.Enabled = false;
				this.debugAllButton.Enabled = false;
				return false;
			}
			else
			{
				this.debugLabel.Text = this.scriptCommands[0];
				return true;
			}

		}

		private void appendLog(String str)
		{
			this.Invoke(new Action(() => logsTextBox.AppendText(str + "\r\n")));
		}
	}

}
