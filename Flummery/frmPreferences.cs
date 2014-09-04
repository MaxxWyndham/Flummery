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
            txtC1Path.Text = Properties.Settings.Default.PathCarmageddon1;
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

        private void btnC1Path_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtC1Path.Text)) { fbdBrowse.SelectedPath = txtC1Path.Text; }

            if (fbdBrowse.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fbdBrowse.SelectedPath + "\\CARMA.exe"))
                {
                    txtC1Path.Text = fbdBrowse.SelectedPath + (fbdBrowse.SelectedPath.EndsWith("\\") ? "" : "\\");
                }
                else
                {
                    MessageBox.Show("CARMA.exe not found.  Are you sure you've selected the right folder?");
                }
            }
        }
        
        private void applySettings()
        {
            Properties.Settings.Default.PathCarmageddonReincarnation = txtCRPath.Text;
            Properties.Settings.Default.PathCarmageddon2 = txtC2Path.Text;
            Properties.Settings.Default.PathCarmageddon1 = txtC1Path.Text;
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

        private void txtKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            var label = this.Controls.Find(((Control)sender).Name.Replace("txtKey", "lblPickedKey"), true)[0];

            if (char.ToUpper(e.KeyChar) >= 65 && char.ToUpper(e.KeyChar) <= 90)
            {
                label.Text = char.ToUpper(e.KeyChar).ToString();
            }

            e.Handled = true;
        }
    }
}
