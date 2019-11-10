using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using CommonTypes;

namespace PuppetMaster
{
    public partial class Form1 : Form
    {
        const int PORT = 5091;

        private Dictionary<String, ClientInstance> clients;
        private Dictionary<String, IServer> servers;

        public delegate string RemoteStatusDelegate();
        public Form1()
        {
            InitializeComponent();
            clients = new Dictionary<String, ClientInstance>();
            servers = new Dictionary<String, IServer>();
            TcpChannel channel = new TcpChannel(PORT);
            ChannelServices.RegisterChannel(channel, true);
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
            var creationResult = new ServiceCreator().createServerInstance(args);
            logs.Text += (creationResult + "\n");

            IServer s = (IServer)Activator.GetObject(
                typeof(IServer),
                sURL
            );
            s.test();
            servers.Add(sId, s);
        }

        private void buttonInstantiateClient_Click(object sender, EventArgs e)
        {
            var args = clientUsername.Text + " " + clientURL.Text + " " + clientServerURL.Text + " " + clientScriptFile.Text;
            var creationResult = new ServiceCreator().createClientInstance(args);
            logs.Text += (creationResult + "\n");
  
            ClientInstance c = (ClientInstance)Activator.GetObject(
                typeof(ClientInstance),
                clientURL.Text
            );
            c.getStatus();

            clients.Add(clientUsername.Text, c);
        }

        private void buttonStatus_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Start Invoking server!!!");

            foreach (String key in servers.Keys)
            {
                handleStatusPrint("Srever " + key, servers[key]);
            };

            foreach (String key in clients.Keys)
            {
                handleStatusPrint("Client " + key, clients[key]);
            };
        }

        private void handleStatusPrint(String key, IRemoteMachine machine)
        {
            RemoteStatusDelegate remoteDel = new RemoteStatusDelegate(machine.getStatus);
            AsyncCallback callBack = new AsyncCallback((IAsyncResult ar) =>
            {
                RemoteStatusDelegate del = (RemoteStatusDelegate)((AsyncResult)ar).AsyncDelegate;
                appendMessage("Status for machine: " + key + ": " + del.EndInvoke(ar));
            });
            remoteDel.BeginInvoke(callBack, null);
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
                var args = cmd.Args;
                switch(cmd.CommandName)
                {
                    case "Client":
                        instantiateClient(args[0], args[1], args[2], args[3]);
                        break;
                    case "Server":
                        instantiateClient(args[0], args[1], args[2], args[3]);
                        break;
                    case "Wait":
                        System.Threading.Thread.Sleep(Int32.Parse(args[0]));
                        break;
                    default:
                        logs.Text += "Command Not Implemented\n";
                        break;
                }

            }
        }

        private void appendMessage(String str)
        {
            this.Invoke(new Action(() => logs.AppendText(str + "\r\n")));
        }

        private void instantiateClient(String cUserName, String cClientURL, String cURL, String cScriptFile)
        {

        }

        private void instantiateServer(String cUserName, String cClientURL, String cURL, String cScriptFile)
        {

        }

        private void buttonCrashServer_Click(object sender, EventArgs e)
        {
            IServer affectedServer = servers[affectedServerId.Text];
            affectedServer.freeze();
            appendMessage("Server freezed");
        }
    }
}