using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CommonTypes
{
    public interface IServer : IRemoteMachine
	{
		void test();

		void freeze();

		void unfreeze();

		void crash();



		List<Meeting> GetMeetings();

		bool CreateMeeting(Meeting newMeeting);

		bool JoinMeeting(string username, string meetingTopic, Slot slotPicked);

		Meeting CloseMeeting(string username, string meetingTopic);
	}
}
