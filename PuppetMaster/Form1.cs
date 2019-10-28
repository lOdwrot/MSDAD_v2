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

namespace PuppetMaster
{
    
    public partial class Form1 : Form
    {

        private static string CLIENT_EXECUTABLE_PATH = "../../../WindowsFormsApp1/bin/Debug/WindowsFormsApp1.exe";
        private static string SERVER_EXECUTABLE_PATH = "xxx";
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonInstantiateServer_Click(object sender, EventArgs e)
        {
            String sId = serverId.Text;
            String sURL = serverURL.Text;
            int sMaxFaults = Int32.Parse(serverMaxFaults.Text);
            int sMinDelay = Int32.Parse(serverMinDelay.Text);
            int sMaxDelay = Int32.Parse(serverMaxDelay.Text);

            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = SERVER_EXECUTABLE_PATH,
                        Arguments = "behavior query SymlinkEvaluation",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();

                while (!process.StandardOutput.EndOfStream)
                {
                    var line = process.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                }

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
            String cURL = clientServerURL.Text;
            String cScriptFile = clientScriptFile.Text;
            String cClientURL = clientURL.Text;

            String args = cUserName + " " + cURL + " " + cScriptFile;
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

                while (!process.StandardOutput.EndOfStream)
                {
                    var line = process.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                }

                process.WaitForExit();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
