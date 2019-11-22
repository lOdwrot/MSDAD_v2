using CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
	public class ClientInstance : MarshalByRefObject, IClient
	{
		private string clientURL;
		private HashSet<String> knownClients;
		public string ClientURL { get => clientURL; }
		public HashSet<string> KnownClients { get => knownClients; set => knownClients = value; }

		private ClientForm.AddNewMeeting addMeetingMethod;
		private readonly int GossipNumberOfClients = 2;

		public ClientInstance(String URL, ClientForm.AddNewMeeting addNewMeeting)
		{
			this.addMeetingMethod = addNewMeeting;
			clientURL = URL;
			knownClients = new HashSet<string>();
		}

		public string getStatus()
		{
			return "Up And Runing";
		}

		public void appendNewClient(string clientURL)
		{
			KnownClients.Add(clientURL);
		}
		
		public void GossipSpreadMeeting(Meeting newMeeting)
		{
			var clientNum = Math.Min(this.GossipNumberOfClients, this.knownClients.Count);
			var rand = new Random();
			var clientList = this.knownClients.OrderBy(item => rand.Next()).ToList();
			for (int i = 0; i < clientNum; i++)
			{
				((ClientInstance)Activator.GetObject(
						typeof(ClientInstance),
						clientList[i]
					)).GossipAddMeeting(newMeeting);
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
