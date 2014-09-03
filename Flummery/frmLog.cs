using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Flummery
{
    public partial class frmLog : Form
    {
        private static frmLog instance;

        public frmLog()
        {
            InitializeComponent();

            instance = this;
        }

        public static frmLog getInstance()
        {
            return instance;
        }

        public void Log(string text, Color? color = null)
        {
            AppendText(text + "\r\n", color);           
        }

        public void AppendText(string text, Color? color = null)
        {
            int start = txtLog.TextLength;
            txtLog.AppendText(text);
            int end = txtLog.TextLength;

            if (color == null)
            {
                color = Color.Empty;
            }

            txtLog.Select(start, end - start);
            {
                txtLog.SelectionColor = (Color) color;
            }
            txtLog.SelectionLength = 0; // clear
        }

        private void frmLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
