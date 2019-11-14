using CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicesCreator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            

            string[] args = Environment.GetCommandLineArgs();
            string port = "5500";
            string remoteObjectName = "ServiceCreator";

            if (args != null && args.Length >= 2)
            {
                port = args[1];
                remoteObjectName = args[2];
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(port, remoteObjectName));
        }
    }
}
