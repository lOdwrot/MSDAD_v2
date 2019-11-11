using System;
using System.Collections.Generic;
using System.Text;

namespace CommonTypes
{
    public delegate string TestRemoteDelegate(string param);

    [Serializable]
    public delegate void TestStringDelegate(string param);
}
