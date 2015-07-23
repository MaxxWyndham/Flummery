using System;
using System.Windows.Forms;

using Flummery.Controls;

using WeifenLuo.WinFormsUI.Docking;

namespace Flummery
{
    // Correspond to Flummery.Widgets
    public enum Panes
    {
        Transform,
        Lighting
    }

    public partial class pnlDetails : DockContent
    {
        public pnlDetails()
        {
            InitializeComponent();

            MouseWheel += (s, e) => pnlPanel.Focus();
        }

        public void RegisterEventHandlers()
        {
            this.Lighting.RegisterEventHandlers();
            this.Transform.RegisterEventHandlers();

            SceneManager.Current.OnSelect += scene_OnSelect;
            SceneManager.Current.OnReset += scene_OnReset;
        }

        void scene_OnSelect(object sender, SelectEventArgs e)
        {
            ModelBone bone = (e.Item as ModelBone);

            this.Transform.Visible = (bone != null);
            this.Lighting.Visible = (bone.Type == BoneType.Light);
        }

        private void scene_OnReset(object sender, ResetEventArgs e)
        {
            this.Transform.Visible = false;
            this.Lighting.Visible = false;
        }
    }
}
