using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using CommonTypes;

namespace PuppetMaster
{
    public partial class Form1 : Form
    {
        const int PORT = 5020;

        private Dictionary<String, IClient> clients;
        private Dictionary<String, IServer> servers;
        private Dictionary<String, String> serverURLs;

        private ServiceCreator serviceCreator;
        private List<Room> rooms;

        public delegate string RemoteStatusDelegate();
        public Form1()
        {
            InitializeComponent();
            clients = new Dictionary<String, IClient>();
            servers = new Dictionary<String, IServer>();
            rooms = new List<Room>();
            TcpChannel channel = new TcpChannel(PORT);
            ChannelServices.RegisterChannel(channel, true);
            serviceCreator = new ServiceCreator();
            RemotingServices.Marshal(serviceCreator, "ServiceCreator", typeof(ServiceCreator));
            serverURLs = new Dictionary<String, String>();
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

            instantiateServer(sId, sURL, sMaxFaults, sMinDelay, sMaxDelay);
        }

        private void buttonInstantiateClient_Click(object sender, EventArgs e)
        {
            instantiateClient(clientUsername.Text, clientURL.Text, clientServerURL.Text, clientScriptFile.Text);
        }

        private void buttonStatus_Click(object sender, EventArgs e)
        {
            showStatus();
        }

        private void showStatus()
        {
            foreach (String key in servers.Keys)
            {
                try
                {
                    handleStatusPrint("Server " + key, servers[key]);
                }
                catch (Exception e)
                {
                    appendMessage("Server " + key + " unreachable");
                }
            };

            foreach (String key in clients.Keys)
            {
                try
                {
                    handleStatusPrint("Client " + key, clients[key]);
                } catch(Exception e)
                {
                    appendMessage("Client " + key + " unreachable");
                }
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
                        instantiateServer(args[0], args[1], args[2], args[3], args[4]);
                        break;
                    case "Wait":
                        System.Threading.Thread.Sleep(Int32.Parse(args[0]));
                        break;
                    case "AddRoom":
                        addRoom(args[0], args[1], args[2]);
                        break;
                    case "Status":
                        showStatus();
                        break;
                    case "Crash":
                        IServer affectedServer = servers[args[0]];
                        affectedServer.crash();
                        appendMessage("Server crashed");
                        break;
                    case "PSC":
                        serviceCreator = (ServiceCreator)Activator.GetObject(
                            typeof(ServiceCreator),
                            args[0]
                        );
                        break;
                    default:
                        appendMessage("Command Not Implemented" + cmd.CommandName + "\n");
                        break;
                }

            }
        }

        private void addRoom(String location, String capacity, String room)
        {
            int cp = Int32.Parse(capacity);
            rooms.Add(new Room(room, location, cp));
            foreach (String key in servers.Keys)
            {
                IServer s = servers[key];

                Thread thread = new Thread(() => {
                    try
                    {
                        s.AddRoom(location, room, cp);
                    }
                    catch (Exception e)
                    {
                        appendMessage("Can not notify server about new room: " + key);
                    }
                });
                thread.Start();
            }
        }

        private void appendMessage(String str)
        {
            this.Invoke(new Action(() => logs.AppendText(str + "\r\n")));
        }

        private void instantiateClient(String cUserName, String cClientURL, String cURL, String cScriptFile)
        {
            var args = cUserName + " " + cClientURL + " " + cURL + " " + cScriptFile;
            var creationResult = serviceCreator.createClientInstance(args);
            logs.Text += (creationResult + "\n");

			IClient c = (IClient)Activator.GetObject(
                typeof(IClient),
                cClientURL
            );

            clients.TryGetValue(cUserName, out IClient clientInstance);
            if (clientInstance != null)
            {
                appendMessage("Client " + cUserName + " already exists, replacing by new instance");
                clients[cUserName] = clientInstance;
                return;
            }
            else
            {
                clients.Add(cUserName, c);
            } 
        }

        private void instantiateServer(String sId, String sURL, String sMaxFaults, String sMinDelay, String sMaxDelay)
        {
            String args = sId + " " + sURL + " " + sMaxFaults + " " + sMinDelay + " " + sMaxDelay;
            var creationResult = serviceCreator.createServerInstance(args);
            logs.Text += (creationResult + "\n");

            IServer s = (IServer)Activator.GetObject(
                typeof(IServer),
                sURL
            );

            //Inform new servers about created ones
            foreach (String key in serverURLs.Keys)
            {
                s.registerNewServer(key, serverURLs[key]);
            }

            //Inform other servers about new one
            foreach (IServer server in servers.Values) {
                server.registerNewServer(sId, sURL);
            }

            foreach(Room r in rooms)
            {
                s.AddRoom(r.location, r.name, r.capacity);
            }

            servers.Add(sId, s);
            serverURLs.Add(sId, sURL);
        }

        private void buttonCrashServer_Click(object sender, EventArgs e)
        {
            IServer affectedServer = servers[affectedServerId.Text];
            affectedServer.crash();
            appendMessage("Server crashed");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            IServer server = (IServer)servers["Server1"];
            TestRemoteDelegate remoteDelegate = new TestRemoteDelegate(server.testAsync);
            AsyncCallback callback = new AsyncCallback(CompleteCall);
            remoteDelegate.BeginInvoke("Client Message", callback, null);
        }

        private void CompleteCall(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar;
            TestRemoteDelegate del = (TestRemoteDelegate)result.AsyncDelegate;
            String retrivedMessage = del.EndInvoke(ar);
            appendMessage(retrivedMessage);
        }

        private void setServiceCreatorButton_Click(object sender, EventArgs e)
        {
            serviceCreator = (ServiceCreator)Activator.GetObject(
                typeof(ServiceCreator),
                ServiceCreatorTextBox.Text
            );
        }

        private void buttonFreezeServer_Click(object sender, EventArgs e)
        {
            IServer affectedServer = servers[affectedServerId.Text];
            affectedServer.freeze();
            appendMessage("Server freezed");
        }

        private void buttonUnfreezeServer_Click(object sender, EventArgs e)
        {
            IServer affectedServer = servers[affectedServerId.Text];
            affectedServer.unfreeze();
            appendMessage("Server unfreezed");
        }

        private void buttonListLocations_Click(object sender, EventArgs e)
        {
            foreach(Room r in rooms)
            {
                appendMessage(r.getInfo());
            }
        }

        private void buttonAddRoom_Click(object sender, EventArgs e)
        {
            this.addRoom(locationLocation.Text, locationCapacity.Text, locationRoom.Text);
        }
    }
}