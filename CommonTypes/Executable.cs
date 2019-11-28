using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonTypes
{
    [Serializable]
    public class Executable
	{
        public String action { get; set; }
        public String username { get; set; }
        public String meetingTopic { get; set; }
        public Slot slotPicked { get; set; }
        public Meeting newMeeting { get; set; }
        public int clock { get; set; }
        public String serverId { get; set; }
        public Boolean toDeliver { get; set; } = false;
        public int to_sn { get; set; }
        public Executable()
        {
        }		

	}
}
