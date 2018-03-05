using WeifenLuo.WinFormsUI.Docking;

namespace Flummery
{
    // Correspond to Flummery.Widgets
    public enum Panes
    {
        Transform,
        Lighting,
        Skins
    }

    public partial class PnlDetails : DockContent
    {
        public PnlDetails()
        {
            InitializeComponent();

            MouseWheel += (s, e) => pnlPanel.Focus();

            if (SceneManager.Current != null && 
                SceneManager.Current.SelectedModel != null && 
                SceneManager.Current.SelectedModel.Bones[SceneManager.Current.SelectedBoneIndex] != null)
            {
                setSelection(SceneManager.Current.SelectedModel.Bones[SceneManager.Current.SelectedBoneIndex]);
            }
        }

        public void RegisterEventHandlers()
        {
            Lighting.RegisterEventHandlers();
            Transform.RegisterEventHandlers();
            Skins.RegisterEventHandlers();

            SceneManager.Current.OnSelect += scene_OnSelect;
            SceneManager.Current.OnSelectRoot += scene_OnSelectRoot;
            SceneManager.Current.OnReset += scene_OnReset;
        }

        void scene_OnSelect(object sender, SelectEventArgs e)
        {
            setSelection(e.Item as ModelBone);
        }

        void scene_OnSelectRoot(object sender, SelectRootEventArgs e)
        {
            switch (e.Mode)
            {
                case ContextMode.Car:
                    Skins.Visible = true;
                    break;
            }
        }

        private void setSelection(ModelBone bone)
        {
            Transform.Visible = (bone != null);
            Lighting.Visible = (bone.Type == BoneType.Light);
            Skins.Visible = false;
        }

        private void scene_OnReset(object sender, ResetEventArgs e)
        {
            Transform.Visible = false;
            Lighting.Visible = false;
            Skins.Visible = false;
        }
    }
}
