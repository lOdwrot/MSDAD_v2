using CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
	class Server
	{
		static void Main(string[] args)
		{
			var port = 5110;
			var remoteObjectName = "Server";

			TcpChannel channel = new TcpChannel(port);
			ChannelServices.RegisterChannel(channel, true);

			ServerInstance server = new ServerInstance();
			RemotingServices.Marshal(server, remoteObjectName, typeof(ServerInstance));
			System.Console.WriteLine("Registered server");

			System.Console.WriteLine("Chat server Lunched");
			System.Console.WriteLine("<enter> para sair...");
			System.Console.ReadLine();
		}
	}
}
