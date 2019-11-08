using System;
using System.Collections.Generic;
using System.Text;

namespace CommonTypes
{
    public class ServerInstance : MarshalByRefObject, IRemoteMachine
	{
        public string getStatus()
        {
            throw new NotImplementedException();
        }

		//public void RegisterNewClient(string username, string clientUrl)
		//{
		//	throw new NotImplementedException();
		//}

		public List<Meeting> GetMeetings()
		{
			throw new NotImplementedException();
		}

		public bool CreateMeeting(Meeting newMeeting)
		{
			throw new NotImplementedException();
		}

		public bool JoinMeeting(string username, string meetingTopic, Slot slotPicked)
		{
			throw new NotImplementedException();
		}

		public bool CloseMeeting(string username, string meetingTopic)
		{
			throw new NotImplementedException();
		}
	}
}
