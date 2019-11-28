﻿using System;
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

		bool CreateMeeting(Meeting newMeeting);

		bool JoinMeeting(string username, string meetingTopic, List<Slot> slotsPicked);

		Meeting CloseMeeting(string username, string meetingTopic);

        void AddRoom(String location, String roomName, int capacity);

        void registerNewServer(String serverId, String serverURL);

        void registerNewClient(String clientId, String clientURL);

        List<String> getOtherServerAddresses();

        HashSet<String> getMyClientsSubset();

        HashSet<String> getAgregatedClientsSubset();
    }
}
