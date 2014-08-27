using System;
using System.Globalization;
using System.Windows.Forms;
using OpenTK;

namespace Flummery
{
    public partial class frmModifyActor : Form
    {
        int modelIndex;
        int boneIndex;

        public frmModifyActor()
        {
            InitializeComponent();
        }

        public void SetParentNode(int modelID, int boneID)
        {
            modelIndex = modelID;
            boneIndex = boneID;
        }

        private void frmTransformEditor_Load(object sender, EventArgs e)
        {
            var bone = SceneManager.Current.Models[modelIndex].Bones[boneIndex];

            txtM11.Text = bone.Transform.M11.ToString();
            txtM12.Text = bone.Transform.M12.ToString();
            txtM13.Text = bone.Transform.M13.ToString();
            txtM21.Text = bone.Transform.M21.ToString();
            txtM22.Text = bone.Transform.M22.ToString();
            txtM23.Text = bone.Transform.M23.ToString();
            txtM31.Text = bone.Transform.M31.ToString();
            txtM32.Text = bone.Transform.M32.ToString();
            txtM33.Text = bone.Transform.M33.ToString();
            txtM41.Text = bone.Transform.M41.ToString();
            txtM42.Text = bone.Transform.M42.ToString();
            txtM43.Text = bone.Transform.M43.ToString();

            txtIM11.Text = bone.CombinedTransform.M11.ToString();
            txtIM12.Text = bone.CombinedTransform.M12.ToString();
            txtIM13.Text = bone.CombinedTransform.M13.ToString();
            txtIM21.Text = bone.CombinedTransform.M21.ToString();
            txtIM22.Text = bone.CombinedTransform.M22.ToString();
            txtIM23.Text = bone.CombinedTransform.M23.ToString();
            txtIM31.Text = bone.CombinedTransform.M31.ToString();
            txtIM32.Text = bone.CombinedTransform.M32.ToString();
            txtIM33.Text = bone.CombinedTransform.M33.ToString();
            txtIM41.Text = bone.CombinedTransform.M41.ToString();
            txtIM42.Text = bone.CombinedTransform.M42.ToString();
            txtIM43.Text = bone.CombinedTransform.M43.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var culture = new CultureInfo("en-GB");
            var transform = new Matrix4(
                                            Convert.ToSingle(txtM11.Text, culture), Convert.ToSingle(txtM12.Text, culture), Convert.ToSingle(txtM13.Text, culture), 0,
                                            Convert.ToSingle(txtM21.Text, culture), Convert.ToSingle(txtM22.Text, culture), Convert.ToSingle(txtM23.Text, culture), 0,
                                            Convert.ToSingle(txtM31.Text, culture), Convert.ToSingle(txtM32.Text, culture), Convert.ToSingle(txtM33.Text, culture), 0,
                                            Convert.ToSingle(txtM41.Text, culture), Convert.ToSingle(txtM42.Text, culture), Convert.ToSingle(txtM43.Text, culture), 1
                                        );

            SceneManager.Current.Models[modelIndex].SetTransform(transform, boneIndex);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
