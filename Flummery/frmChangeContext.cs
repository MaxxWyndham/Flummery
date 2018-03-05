using System;
using System.Windows.Forms;

using ToxicRagers.Helpers;


namespace Flummery
{
    public partial class frmChangeContext : Form
    {
        public frmChangeContext()
        {
            InitializeComponent();

            foreach (ContextGame game in Enum.GetValues(typeof(ContextGame)))
            {
                int index = cboGameContext.Items.Add(game.ToString().Replace("_", " "));
                if (game == SceneManager.Current.Game) { cboGameContext.SelectedIndex = index; }
            }

            foreach (ContextMode mode in Enum.GetValues(typeof(ContextMode)))
            {
                int index = cboModeContext.Items.Add(mode);
                if (mode == SceneManager.Current.Mode) { cboModeContext.SelectedIndex = index; }
            }
        }

        private void applyChanges()
        {
            SceneManager.Current.SetContext(cboGameContext.Text.Replace(" ", "_").ToEnum<ContextGame>(), cboModeContext.Text.ToEnum<ContextMode>());
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            applyChanges();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            applyChanges();
        }
    }
}
