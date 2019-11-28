using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
	public class NoServersAvailableException : Exception { }

	public class MeetingNotCreatedException : Exception { }
	public class MeetingNotJoinedException : Exception { }
	public class MeetingNotClosedException : Exception { }
}
