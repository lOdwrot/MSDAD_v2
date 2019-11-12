using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonTypes;

namespace ServicesCreator
{
    public partial class Form1 : Form
    {
        public Form1(string port, string objectName)
        {
            InitializeComponent();
            textBox1.Text = port;
            textBox2.Text = objectName;

            TcpChannel channel = new TcpChannel(Int32.Parse(port));
            ChannelServices.RegisterChannel(channel, true);
            ServiceCreator serviceCreator = new ServiceCreator();
            RemotingServices.Marshal(serviceCreator, objectName, typeof(ServiceCreator));
        }
    }
}
