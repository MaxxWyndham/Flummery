using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

using Flummery.Util;

namespace Flummery
{
    public partial class frmUpdater : Form
    {
        private Updater.Update[] updates;
        private bool complete = false;

        public Updater.Update[] Updates
        {
            get => updates;

            set
            {
                complete = true;
                updates = value;
                updateViewState();
            }
        }

        public frmUpdater()
        {
            InitializeComponent();
        }

        public void CheckUpdate()
        {
            new Updater().Check(FlummeryApplication.Version, finishRequest);
        }

        private void finishRequest(bool result, Updater.Update[] updates)
        {
            Invoke((Action)delegate
            {
                Updates = updates;
            });
        }

        private void updateViewState()
        {
            if (complete == false)
            {
                labelHeader.Text = "Checking for updates...";
                btnClose.Visible = false;
                btnDownload.Visible = false;
                btnCancel.Visible = true;
                txtChangelog.Visible = false;
            }
            else if (updates != null && updates.Count() > 0)
            {
                labelHeader.Text = "Update to version " + updates[updates.Count() - 1].version + " is ready for download!";
                btnClose.Visible = true;
                btnDownload.Visible = true;
                btnCancel.Visible = false;
                txtChangelog.Visible = true;

                updateChangelog();
            }
            else
            {
                labelHeader.Text = "You're running the latest version!";
                btnClose.Visible = true;
                btnDownload.Visible = false;
                btnCancel.Visible = false;
                txtChangelog.Visible = false;
            }

            CenterToScreen();
        }

        private void updateChangelog()
        {
            string changelog = "";

            foreach (Updater.Update update in updates.Reverse())
            {
                changelog += "Update " + update.version + "\r\n" + update.changelog + "\r\n\r\n";
            }

            txtChangelog.Text = changelog;
            txtChangelog.Select(0, 0);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = updates[updates.Count() - 1].update;
            proc.Start();

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUpdate_Shown(object sender, EventArgs e)
        {
            updateViewState();
            CenterToScreen();
        }
    }
}