using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonTypes;

namespace PuppetMaster
{
    
    public partial class Form1 : Form
    {
        private Dictionary<String, ClientInstance> clients;
        private static string CLIENT_EXECUTABLE_PATH = "../../../WindowsFormsApp1/bin/Debug/Client.exe";
        private static string SERVER_EXECUTABLE_PATH = "xxx";
        public Form1()
        {
            InitializeComponent();
            clients = new Dictionary<String, ClientInstance>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonInstantiateServer_Click(object sender, EventArgs e)
        {
            String sId = serverId.Text;
            String sURL = serverURL.Text;
            String sMaxFaults = serverMaxFaults.Text;
            String sMinDelay = serverMinDelay.Text;
            String sMaxDelay = serverMaxDelay.Text;

            String args = sId + " " + sURL + " " + sMaxFaults + " " + sMinDelay + " " + sMaxDelay;
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = SERVER_EXECUTABLE_PATH,
                        Arguments = args,
                        UseShellExecute = false,
                        RedirectStandardOutput = false,
                        CreateNoWindow = false
                    }
                };

                process.Start();

                process.WaitForExit();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void buttonInstantiateClient_Click(object sender, EventArgs e)
        {
            String cUserName = clientUsername.Text;
            String cClientURL = clientURL.Text;
            String cURL = clientServerURL.Text;
            String cScriptFile = clientScriptFile.Text;

            String args = cUserName + " " + cClientURL + " " + cURL + " " + cScriptFile;
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = CLIENT_EXECUTABLE_PATH,
                        Arguments = args,
                        UseShellExecute = false,
                        RedirectStandardOutput = false,
                        CreateNoWindow = false
                    }
                };

                process.Start();

                clients.Add(
                    cUserName,
                    (ClientInstance)Activator.GetObject(
                        typeof(ClientInstance),
                        cClientURL
                    )
                );

                process.WaitForExit();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void buttonStatus_Click(object sender, EventArgs e)
        {
            //foreach (ClientInstance c in clients.Values)
            //{
            //    IAsyncResult RemAr = RemoteDel.BeginInvoke(RemoteCallback, null);
            //}
        }

        private void buttonExecuteScript_Click(object sender, EventArgs e)
        {
            List<Command> commands = new List<Command>();

            try
            {
                commands = new ScriptParser().parseFile(script.Text);
            }
            catch(System.IO.FileNotFoundException err)
            {
                MessageBox.Show(err.Message);
                return;
            }

             

            foreach(Command cmd in commands)
            {
                logs.Text += ("Exec: " + cmd.CommandName + " | " + cmd.getArgsAsString() + "\n");
                switch(cmd.CommandName)
                {

                    default:
                        logs.Text += "Command Not Implemented\n";
                        break;
                }
            }
        }
    }
}