using System;
using OpenTK;
using WeifenLuo.WinFormsUI.Docking;

namespace Flummery
{
    public partial class widgetTransform : DockContent
    {
        Matrix4 bone;

        public widgetTransform()
        {
            InitializeComponent();
        }

        public void RegisterEventHandlers()
        {
            SceneManager.Current.OnSelect += scene_OnSelect;
        }

        void scene_OnSelect(object sender, SelectEventArgs e)
        {
            var b = (e.Item as ModelBone);

            if (b != null) { bone = b.Transform; }
        }

        private void btnFreeze_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var mS = Matrix4.CreateScale(Convert.ToSingle(txtScaleX.Text, Flummery.Culture) / 100.0f, Convert.ToSingle(txtScaleY.Text, Flummery.Culture) / 100.0f, Convert.ToSingle(txtScaleZ.Text, Flummery.Culture) / 100.0f);
            var mRx = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Convert.ToSingle(txtRotationX.Text, Flummery.Culture)));
            var mRy = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Convert.ToSingle(txtRotationY.Text, Flummery.Culture)));
            var mRz = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Convert.ToSingle(txtRotationZ.Text, Flummery.Culture)));
            var vP = new Vector3(Convert.ToSingle(txtPositionX.Text, Flummery.Culture), Convert.ToSingle(txtPositionY.Text, Flummery.Culture), Convert.ToSingle(txtPositionZ.Text, Flummery.Culture));

            var transform = mS * mRx * mRy * mRz;
            transform.M41 = vP.X;
            transform.M42 = vP.Y;
            transform.M43 = vP.Z;

            bone *= transform;

            SceneManager.Current.Models[0].SetTransform(bone, SceneManager.Current.SelectedBoneIndex);
            SceneManager.Current.Change();

            resetWidget();
        }

        private void resetWidget()
        {
            txtPositionX.Text = "0.00";
            txtPositionY.Text = "0.00";
            txtPositionZ.Text = "0.00";
            txtRotationX.Text = "0";
            txtRotationY.Text = "0";
            txtRotationZ.Text = "0";
            txtScaleX.Text = "100";
            txtScaleY.Text = "100";
            txtScaleZ.Text = "100";
        }
    }
}
