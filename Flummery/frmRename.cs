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
            var t = Matrix4.CreateScale(6.9f, 6.9f, -6.9f);
            var sout = "";

            foreach (string s in textBox1.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] p;

                switch (s.Substring(0, 1))
                {
                    case "m":
                        float f;
                        if (float.TryParse(s.Substring(1), out f))
                        {
                            sout += (f * 500) + "\r\n";
                        }
                        break;

                    case "i":
                        p = s.Substring(1).Replace(" ", "").Split(',');
                        sout += (Convert.ToSingle(p[0]) * 500 * 6.9f * 6.9f) + ", " + (Convert.ToSingle(p[1]) * 500 * 6.9f * 6.9f) + ", " + (Convert.ToSingle(p[2]) * 500 * 6.9f * 6.9f) + "\r\n";
                        break;

                    default:
                        p = s.Replace(" ", "").Split(',');
                        var v = new Vector3(Convert.ToSingle(p[0]), Convert.ToSingle(p[1]), Convert.ToSingle(p[2]));
                        var tv = Vector3.TransformVector(v, t);
                        sout += tv.X + ", " + tv.Y + ", " + tv.Z + "\r\n";
                        break;
                }
            }

            textBox1.Text = sout.Substring(0, sout.Length - 2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }
    }
}
