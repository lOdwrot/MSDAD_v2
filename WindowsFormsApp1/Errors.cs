using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
	public class NoServersAvailableException : Exception { }

	public class MeetingsNotRetrievedException : Exception { }

	public class MeetingNotCreatedException : Exception { }
	public class LocationDoesNotExistException : MeetingNotCreatedException { }
	public class MeetingAlreadyExistsException : MeetingNotCreatedException { }

	public class MeetingNotJoinedException : Exception { }
	public class UnproposedSlotsMeetingException : MeetingNotJoinedException { }
	public class AlreadyJoinedMeetingException : MeetingNotJoinedException { }
	public class NotInvitedMeetingException : MeetingNotJoinedException { }

    public class NotJoinedMeetingException : MeetingNotJoinedException { }

    public class MeetingNotClosedException : Exception { }
}
