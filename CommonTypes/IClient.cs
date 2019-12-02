using System;
using System.Collections.Generic;
using System.Text;

namespace CommonTypes
{
	public interface IClient : IRemoteMachine
	{
		void appendNewClient(string username, string clientURL);

		void GossipSpreadMeeting(Meeting newMeeting);
		void GossipAddMeeting(Meeting newMeeting);
	}
	
}
