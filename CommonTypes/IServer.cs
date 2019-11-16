using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CommonTypes
{
    public interface IServer : IRemoteMachine
	{
		void test();

        string testAsync(string param);

        void freeze();

		void unfreeze();

		void crash();



		List<Meeting> GetMeetings();

        void AddRoom(String location, String roomName, int capacity);

        void registerNewServer(String serverId, String serverURL);

        void registerNewClient(String clientId, String clientURL);

        HashSet<String> getMyClientsSubset();

        HashSet<String> getAgregatedClientsSubset();

        object RB_Deliver(Executable executable, int sequenceNumber);

        object Request(Executable executable);

        int getSequenceNumber();
    }
}
