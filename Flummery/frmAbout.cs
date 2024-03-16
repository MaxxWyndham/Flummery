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
            Process.Start(new ProcessStartInfo($"mailto:errol@toxic-ragers.co.uk?subject=Flummery v{FlummeryApplication.Version}") { UseShellExecute = true });
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "v" + FlummeryApplication.Version;
        }

        private void btnUpdateCheck_Click(object sender, EventArgs e)
        {
            frmUpdater updateForm = new frmUpdater();
            updateForm.CheckUpdate();
            updateForm.ShowDialog(this);
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.paypal.me/errolerrolson/") { UseShellExecute = true });
        }
    }
}
