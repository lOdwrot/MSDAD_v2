using System;
using System.Collections.Generic;
using System.Text;

namespace CommonTypes
{
    public class ClientInstance : MarshalByRefObject, IRemoteMachine
	{
        public string getStatus()
        {
			return "hello";
        }
    }
}
