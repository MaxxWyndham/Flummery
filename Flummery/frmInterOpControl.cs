using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flummery.InterOp;

namespace Flummery
{
    public partial class frmInterOpControl : Form
    {
        InterOpServer server;
        delegate void UpdateServerStatusDelegate(string Status);
        bool UpdateStatusLog = true;
        public frmInterOpControl()
        {
            InitializeComponent();
            int port = 666;
            int.TryParse(txtPortNumber.Text, out port);
            server = new InterOpServer(port);

            Thread t = new Thread(new ThreadStart(() =>
            {
                while(UpdateStatusLog)
                {
                    UpdateServerStatus(server.IsThreadRunning() ? "Thread Running" : "Thread Stopped");
                    Thread.Sleep(100);
                }
            }));
            t.Start();
        }

        private void UpdateServerStatus(string Status)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UpdateServerStatusDelegate(UpdateServerStatus), new object[] { Status });
                return;
            }
            serverStatus.Text = "Status: " + Status;
            outputLog.Text = server.log.ToString();
        }
        private void butStartServer_Click(object sender, EventArgs e)
        {
            server.StartServer();
        }

        private void butStopServer_Click(object sender, EventArgs e)
        {
            server.StopServer();
        }

        private void frmInterOpControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateStatusLog = false;
            server.StopServer();
        }
    }
}
