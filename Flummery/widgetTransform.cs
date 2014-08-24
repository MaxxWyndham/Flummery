using System;

using OpenTK;
using ToxicRagers.Helpers;
using WeifenLuo.WinFormsUI.Docking;

namespace Flummery
{
    public partial class widgetTransform : DockContent
    {
        public enum Relativity
        {
            Relative,
            Absolute
        }

        Matrix4 bone;
        int defaultWidth = 190;
        Relativity relativity = Relativity.Relative;

        public int DefaultWidth { get { return defaultWidth; } }

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

            if (b != null)
            { 
                bone = b.Transform;
                resetWidget();
            }
        }

        private void btnFreeze_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var mS = Matrix4.CreateScale(txtScaleX.Text.ToSingle() / 100.0f, txtScaleY.Text.ToSingle() / 100.0f, txtScaleZ.Text.ToSingle() / 100.0f);
            var mRx = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(txtRotationX.Text.ToSingle()));
            var mRy = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(txtRotationY.Text.ToSingle()));
            var mRz = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(txtRotationZ.Text.ToSingle()));
            var vP = new OpenTK.Vector3(txtPositionX.Text.ToSingle(), txtPositionY.Text.ToSingle(), txtPositionZ.Text.ToSingle());

            var transform = mS * mRx * mRy * mRz;
            transform.M41 = vP.X;
            transform.M42 = vP.Y;
            transform.M43 = vP.Z;

            bone *= transform;

            SceneManager.Current.Models[0].SetTransform(bone, SceneManager.Current.SelectedBoneIndex);
            SceneManager.Current.Change(ChangeType.Transform, SceneManager.Current.SelectedBoneIndex);

            resetWidget();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            var mS = Matrix4.CreateScale(txtScaleX.Text.ToSingle(), txtScaleY.Text.ToSingle(), txtScaleZ.Text.ToSingle());
            var mRx = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(txtRotationX.Text.ToSingle()));
            var mRy = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(txtRotationY.Text.ToSingle()));
            var mRz = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(txtRotationZ.Text.ToSingle()));
            var vP = new OpenTK.Vector3(txtPositionX.Text.ToSingle(), txtPositionY.Text.ToSingle(), txtPositionZ.Text.ToSingle());

            var transform = mS * mRx * mRy * mRz;
            transform.M41 = vP.X;
            transform.M42 = vP.Y;
            transform.M43 = vP.Z;

            bone = transform;

            SceneManager.Current.Models[0].SetTransform(bone, SceneManager.Current.SelectedBoneIndex);
            SceneManager.Current.Change(ChangeType.Transform, SceneManager.Current.SelectedBoneIndex);
        }

        private void resetWidget()
        {
            if (relativity == Relativity.Relative)
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
            else
            {
                var p = bone.ExtractTranslation();
                var r = bone.ExtractRotation().ToAxisAngle();
                var s = bone.ExtractScale();

                if (Math.Abs(r.X) < 0.0001f) { r.X = 0; }
                if (Math.Abs(r.Y) < 0.0001f) { r.Y = 0; }
                if (Math.Abs(r.Z) < 0.0001f) { r.Z = 0; }

                r.X *= MathHelper.RadiansToDegrees(r.W);
                r.Y *= MathHelper.RadiansToDegrees(r.W);
                r.Z *= MathHelper.RadiansToDegrees(r.W);

                txtPositionX.Text = p.X.ToString();
                txtPositionY.Text = p.Y.ToString();
                txtPositionZ.Text = p.Z.ToString();
                txtRotationX.Text = r.X.ToString();
                txtRotationY.Text = r.Y.ToString();
                txtRotationZ.Text = r.Z.ToString();
                txtScaleX.Text = s.X.ToString();
                txtScaleY.Text = s.Y.ToString();
                txtScaleZ.Text = s.Z.ToString();
            }
        }

        private void rdoRelativity_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRelative.Checked)
            {
                relativity = Relativity.Relative;
                btnSet.Visible = false;
                btnAdd.Visible = true;
                btnFreeze.Visible = true;
                btnReset.Visible = true;
                btnZero.Visible = true;
            }
            else
            {
                relativity = Relativity.Absolute;
                btnSet.Visible = true;
                btnAdd.Visible = false;
                btnFreeze.Visible = false;
                btnReset.Visible = false;
                btnZero.Visible = false;
            }

            resetWidget();
        }
    }
}
