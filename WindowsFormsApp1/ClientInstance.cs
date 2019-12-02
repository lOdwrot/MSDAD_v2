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
		public Dictionary<string, string> KnownClients;
		public List<string> KnownServers;

		private ClientForm.AddNewMeeting addMeetingMethod;
		private readonly int GossipNumberOfClients = 2;

		public ClientInstance(String URL, ClientForm.AddNewMeeting addNewMeeting)
		{
			this.addMeetingMethod = addNewMeeting;
			ClientURL = URL;
			KnownClients = new Dictionary<string, string>();
			KnownServers = new List<string>();
		}

		public string getStatus()
		{
			return "Up And Running";
		}

		public void appendNewClient(string username, string clientURL)
		{
			KnownClients.Add(username, clientURL);
		}

		public void GossipSpreadMeeting(Meeting newMeeting)
		{
			var clientNum = Math.Min(this.GossipNumberOfClients, this.KnownClients.Count);
			var rand = new Random();
			var clientDict = this.KnownClients.OrderBy(item => rand.Next()).ToList();

			if (newMeeting.invited.Count > 0)
				clientDict = clientDict.Where(c => newMeeting.invited.Contains(c.Key)).ToList();

			var clientList = clientDict.Select(c => c.Value).Take(clientNum).ToList();
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
