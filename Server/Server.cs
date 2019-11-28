using CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Server
{
	class Server
	{
		readonly List<string> serverList = new List<string> {
			"Lisbon", "Porto", "Algarve"
		};

		static void Main(string[] args)
		{
			if (args is null || args.Length < 0)
			{
				System.Console.WriteLine(@"""
					Error: please give the correct amount of parameters.
					Server.exe <server_id> <server_url> <max_faults> <min_delay> <max_delay>"""
				);
				return;
			}
			// id, url, fults, delaymin, delaymax
			var serverId = args[0];
			var serverUrl = args[1];
			var maxFaults = int.Parse(args[2]);
			var minDelay = int.Parse(args[3]);
			var maxDelay = int.Parse(args[4]);

			string[] splitUrl = Regex.Split(serverUrl, "[:/]");
			string serviceName = splitUrl[splitUrl.Length - 1];
			int port = int.Parse(splitUrl[splitUrl.Length - 2]);

            // ----------------------------------


            Console.WriteLine("Registering remote object, Port|" + port + "| Remote object name|" + serviceName);
			TcpChannel channel = new TcpChannel(port);
			ChannelServices.RegisterChannel(channel, true);

			ServerInstance server = new ServerInstance(serverId);

			RemotingServices.Marshal(server, serviceName, typeof(ServerInstance));

			//RemotingConfiguration.RegisterWellKnownServiceType(
			//	typeof(ServerInstance),
			//	serviceName,
			//	WellKnownObjectMode.Singleton);

			// ----------------------------------

			System.Console.WriteLine("Server started successfully.");
			System.Console.WriteLine("Press <Enter> to exit...");
			System.Console.ReadLine();
		}
	}
}
