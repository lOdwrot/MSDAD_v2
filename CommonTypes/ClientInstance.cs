using System;
using System.Collections.Generic;
using System.Text;

namespace CommonTypes
{
    public class ClientInstance : MarshalByRefObject, IRemoteMachine
    {
        private string clientURL;
        private HashSet<String> knowknClients;
        public string ClientURL { get => clientURL; }
        public HashSet<string> KnownClients { get => knowknClients; set => knowknClients = value; }

        public ClientInstance(String URL)
        {
            clientURL = URL;
            knowknClients = new HashSet<string>();
        }

        public string getStatus()
        {
			return "Up And Runing";
        }

        public void appendNewClient(string clientURL)
        {
            KnownClients.Add(clientURL);
        }

    }
}
