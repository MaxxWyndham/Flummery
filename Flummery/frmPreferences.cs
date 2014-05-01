using System;
using System.IO;
using System.Windows.Forms;

namespace Flummery
{
    public partial class frmPreferences : Form
    {
        public frmPreferences()
        {
            InitializeComponent();

            txtCRPath.Text = Properties.Settings.Default.PathCarmageddonReincarnation;
            txtC2Path.Text = Properties.Settings.Default.PathCarmageddon2;
        }

        private void btnCRPath_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtCRPath.Text)) { fbdBrowse.SelectedPath = txtCRPath.Text; }

            if (fbdBrowse.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fbdBrowse.SelectedPath + "\\config.lua"))
                {
                    txtCRPath.Text = fbdBrowse.SelectedPath + (fbdBrowse.SelectedPath.EndsWith("\\") ? "" : "\\");
                }
                else
                {
                    MessageBox.Show("config.lua not found.  Are you sure you've selected the right folder?");
                }
            }
        }

        private void btnC2Path_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtC2Path.Text)) { fbdBrowse.SelectedPath = txtC2Path.Text; }

            if (fbdBrowse.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fbdBrowse.SelectedPath + "\\CARMA2_HW.exe"))
                {
                    txtC2Path.Text = fbdBrowse.SelectedPath + (fbdBrowse.SelectedPath.EndsWith("\\") ? "" : "\\");
                }
                else
                {
                    MessageBox.Show("CARMA2_HW.exe not found.  Are you sure you've selected the right folder?");
                }
            }
        }

        private void applySettings()
        {
            Properties.Settings.Default.PathCarmageddonReincarnation = txtCRPath.Text;
            Properties.Settings.Default.PathCarmageddon2 = txtC2Path.Text;
            Properties.Settings.Default.Save();
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            applySettings();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            applySettings();
            this.Close();
        }
    }
}
