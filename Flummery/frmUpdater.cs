using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Flummery.Util;

namespace Flummery
{
    public partial class frmUpdate : Form
    {
        WebRequest webRequest;

        // 0 = checking for updates
        // 1 = update found
        // 2 = no update found
        private int viewState = 0;

        private string updateUrl = "http://asdasd/FlummeryUpdateService/update.php?client_version={0}";

        private string newUpdateUrl;

        private int ViewState {
            get
            {
                return viewState;
            }

            set
            {
                viewState = value;
                UpdateViewState();
            }
        }

        public string NewUpdateUrl
        {
            get
            {
                return newUpdateUrl;
            }

            set
            {
                if (newUpdateUrl != null)
                {
                    viewState = 2;
                }
                else
                {
                    viewState = 1;
                }
                newUpdateUrl = value;
                UpdateViewState();
            }
        }

        public frmUpdate()
        {
            InitializeComponent();
            UpdateViewState();
        }

        public void checkUpdate() {
            new Updater().Check(Flummery.Version, finishRequest);
        }

        private void finishRequest(bool result, string url)
        {
            Console.WriteLine(url == null);
            if (result == false || url == null)
            {
                Invoke((Action)delegate {
                    viewState = 2;
                    newUpdateUrl = url;
                    UpdateViewState();
                });
            }
            else if(result == true && url != null)
            {
                Invoke((Action)delegate {
                    viewState = 1;
                    newUpdateUrl = url;
                    UpdateViewState();
                });
            }
        }

        private void UpdateViewState() {
            if (viewState == 1)
            {
                label1.Text = "Update found!";
                btnClose.Visible = true;
                btnDownload.Visible = true;
                btnCancel.Visible = false;
            }
            else if (viewState == 2)
            {
                this.label1.Text = "You're running the latest version!";
                this.btnClose.Visible = true;
                this.btnDownload.Visible = false;
                this.btnCancel.Visible = false;
            }
            else
            {
                label1.Text = "Checking for updates...";
                btnClose.Visible = false;
                btnDownload.Visible = false;
                btnCancel.Visible = true;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = newUpdateUrl;
            proc.Start();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
