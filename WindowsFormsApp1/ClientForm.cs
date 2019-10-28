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

				// register client in server
				this.RegisterClient(username, clientUrl);

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

			// register client in server
			this.RegisterClient(usernameBox.Text, "tcp://localhost:" + portBox.Text + "/" + defaultServiceName);
		}

		// Network Functions

		private void CreateRemoteService(string port = null, string serviceName = null)
		{
			port = port ?? defaultPort;
			serviceName = serviceName ?? defaultServiceName;

			try
			{
				TcpChannel channel = new TcpChannel(int.Parse(port));
				ChannelServices.RegisterChannel(channel, true);

				RemotingConfiguration.RegisterWellKnownServiceType(
					typeof(ClientInstance),
					serviceName,
					WellKnownObjectMode.Singleton);
			}
			catch (Exception e)
			{
				ThrowErrorPopup(e);
			}
		}

		private void RegisterClient(string username, string clientUrl)
		{
			try
			{
				// contact server
				ServerInstance obj = (ServerInstance)Activator.GetObject(
					typeof(ServerInstance),
					preferredServer);

				// tell server a new client joined
				obj.RegisterNewClient(username, clientUrl);
			}
			catch (RemotingException e)
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
				this.meetingsList = obj.GetMeetings();
			}
			catch (RemotingException e)
			{
				ThrowErrorPopup(e);
			}
		}

		private void CreateNewMeeting()
		{
			// TODO: create new popup, with two buttons: "Create" and "Cancel"

			// if (dialogResult == DialogResult.OK)
			try
			{
				// TODO: create Meeting object from popup form fields
				Meeting newMeeting = null;

				// contact server
				ServerInstance obj = (ServerInstance)Activator.GetObject(
					typeof(ServerInstance),
					preferredServer);

				// tell server to create a new meeting
				bool created = obj.CreateMeeting(newMeeting);

				// TODO: throw custom error if meeting could not be created
				if (!created)
				{

				}
			}
			catch (RemotingException e)
			{
				ThrowErrorPopup(e);
			}
		}

		private void JoinMeeting(int meetingId, Slot slot)
		{
			try
			{
				// contact server
				ServerInstance obj = (ServerInstance)Activator.GetObject(
					typeof(ServerInstance),
					preferredServer);

				// tell server you want to join
				bool joined = obj.JoinMeeting(usernameBox.Text, meetingId, slot);

				// TODO: throw custom error if meeting could not be joined
				if (!joined)
				{

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

					break;
				// create meeting_topic min_atendees number_of_slots number_of_invitees slot_1 ... slot_n invitee_1 ... invitee_n
				case "create":

					break;
				// join meeting_topic
				case "join":

					break;
				// close meeting_topic
				case "close":

					break;
				// wait x
				case "wait":

					break;
				// if any other command is given, do nothing
				default:
					// TODO: print info to log
					break;
			}
		}

	}
}
