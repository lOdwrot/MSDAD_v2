using CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
	public class ClientInstance : MarshalByRefObject, IClient
	{
		public string ClientURL;
		public HashSet<string> KnownClients;
		public Dictionary<string, string> KnownServers;

		private ClientForm.AddNewMeeting addMeetingMethod;
		private readonly int GossipNumberOfClients = 2;

		public ClientInstance(String URL, ClientForm.AddNewMeeting addNewMeeting)
		{
			this.addMeetingMethod = addNewMeeting;
			ClientURL = URL;
			KnownClients = new HashSet<string>();
			KnownServers = new Dictionary<string, string>();
		}

		public string getStatus()
		{
			return "Up And Running";
		}

		public void appendNewClient(string clientURL)
		{
			KnownClients.Add(clientURL);
		}

		public void setServerList(Dictionary<string, string> otherServers)
		{
			this.KnownServers = otherServers;
		}

		public void GossipSpreadMeeting(Meeting newMeeting)
		{
			var clientNum = Math.Min(this.GossipNumberOfClients, this.KnownClients.Count);
			var rand = new Random();
			var clientList = this.KnownClients.OrderBy(item => rand.Next()).Take(clientNum);
			foreach (string client in clientList)
			{
				ClientInstance clientObj = (ClientInstance)Activator.GetObject(
					typeof(ClientInstance),
					client
				);
				Thread thread = new Thread(() => clientObj.GossipAddMeeting(newMeeting));
				thread.Start();
			}
		}

		public void GossipAddMeeting(Meeting newMeeting)
		{
			bool success = this.addMeetingMethod(newMeeting);
			if (success)
			{
				// spread it again
				GossipSpreadMeeting(newMeeting);
			}
		}
	}
}
