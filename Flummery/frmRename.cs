using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;

namespace Flummery
{
    public partial class frmRename : Form
    {
        public frmRename()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var t = Matrix4.CreateScale(3.6f, 3.6f, -3.6f);
            var sout = "";

            foreach (string s in textBox1.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                var p = s.Replace(" ", "").Split(',');
                var v = new Vector3(Convert.ToSingle(p[0]), Convert.ToSingle(p[1]), Convert.ToSingle(p[2]));
                var tv = Vector3.TransformVector(v, t);
                sout += tv.X + ", " + tv.Y + ", " + tv.Z + "\r\n";
            }

            textBox1.Text = sout.Substring(0, sout.Length - 2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }
    }
}
