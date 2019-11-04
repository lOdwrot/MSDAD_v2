using System;
using System.Collections.Generic;
using System.Text;

namespace CommonTypes
{
    public class ServerInstance
    {
        public string getStatus()
        {
            throw new NotImplementedException();
        }

		public void RegisterNewClient(string username, string clientUrl)
		{
			throw new NotImplementedException();
		}

		public List<Meeting> GetMeetings()
		{
			throw new NotImplementedException();
		}

		public bool CreateMeeting(Meeting newMeeting)
		{
			throw new NotImplementedException();
		}

		public bool JoinMeeting(string username, int meetingId, Slot slotPicked)
		{
			throw new NotImplementedException();
		}
	}
}
