using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
	static class Client
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// get command line arguments
			string[] args = Environment.GetCommandLineArgs();
			string[] param = null;
			if (args.Length == 4 + 1) // count with first argument, which is the process' name
			{
				// in order: username, clientUrl, serverUrl and script file
				param = new string[] { args[1], args[2], args[3], args[4] };
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new ClientForm(param));
		}
	}
}
