using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Flummery
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void lblEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = string.Format("mailto:errol@toxic-ragers.co.uk?subject=Flummery v{0}", Flummery.Version);
            proc.Start();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "v" + Flummery.Version;
        }

        private void btnUpdateCheck_Click(object sender, EventArgs e)
        {
            frmUpdater updateForm = new frmUpdater();
            updateForm.checkUpdate();
            updateForm.ShowDialog(this);
        }
    }
}
