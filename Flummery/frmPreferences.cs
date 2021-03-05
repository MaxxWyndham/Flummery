using System;
using System.Windows.Forms;

using Flummery.Core;

namespace Flummery
{
    public partial class frmPreferences : Form
    {
        public frmPreferences()
        {
            InitializeComponent();

            //txtCRPath.Text = Properties.Settings.Default.PathCarmageddonReincarnation;
            //txtCMDPath.Text = Properties.Settings.Default.PathCarmageddonMaxDamage;
            //txtC2Path.Text = Properties.Settings.Default.PathCarmageddon2;
            //txtC1Path.Text = Properties.Settings.Default.PathCarmageddon1;
            rdoWorkingDirFlummery.Checked = FlummeryApplication.Settings.UseFlummeryWorkingDirectory;
            rdoWorkingDirTemp.Checked = !rdoWorkingDirFlummery.Checked;

            //pgShortcuts.SelectedObject = InputManager.Current.GetKeyboardShortcuts();

            chkCheckForUpdates.Checked = FlummeryApplication.Settings.CheckForUpdates;

            txtAuthor.Text = FlummeryApplication.Settings.PersonalAuthor;
            txtWebsite.Text = FlummeryApplication.Settings.PersonalWebsite;
        }
        
        private void applySettings()
        {
            // Paths
            //Properties.Settings.Default.PathCarmageddonMaxDamage = txtCMDPath.Text;
            //Properties.Settings.Default.PathCarmageddonReincarnation = txtCRPath.Text;
            //Properties.Settings.Default.PathCarmageddon2 = txtC2Path.Text;
            //Properties.Settings.Default.PathCarmageddon1 = txtC1Path.Text;
            FlummeryApplication.Settings.UseFlummeryWorkingDirectory = rdoWorkingDirFlummery.Checked;

            // Keys
            // automatic

            // Misc
            FlummeryApplication.Settings.PersonalAuthor = txtAuthor.Text;
            FlummeryApplication.Settings.PersonalWebsite = txtWebsite.Text;
            FlummeryApplication.Settings.CheckForUpdates = chkCheckForUpdates.Checked;

            FlummeryApplication.Settings.Save();
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            applySettings();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            applySettings();
        }

        private void pgShortcuts_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (!InputManager.Current.UpdateBinding((char)e.OldValue, (char)e.ChangedItem.Value))
            {
                //e.ChangedItem.
            }

            pgShortcuts.Refresh();
        }
    }
}
