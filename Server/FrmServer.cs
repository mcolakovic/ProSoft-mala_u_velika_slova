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
using Timer = System.Windows.Forms.Timer;

namespace Server
{
    public partial class FrmServer : Form
    {
        Server server = new Server();

        public FrmServer()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblBrojac.Text = server.Clients.Count.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            server.Start();
            Thread serverskaNit = new Thread(server.HandleClients);
            serverskaNit.IsBackground = true;
            serverskaNit.Start();
            MessageBox.Show("Server je startovan");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            server.Stop();
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void lblBrojac_Click(object sender, EventArgs e)
        {

        }
    }
}
