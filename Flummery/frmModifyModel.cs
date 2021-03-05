using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ToxicRagers.Helpers;

using Flummery.Core;

namespace Flummery
{
    public partial class frmModifyModel : Form
    {
        int modelIndex;
        int boneIndex;

        public frmModifyModel()
        {
            InitializeComponent();
        }

        public void SetParentNode(int modelID, int boneID)
        {
            modelIndex = modelID;
            boneIndex = boneID;
        }

        private void frmModifyModel_Load(object sender, EventArgs e)
        {
            cboInvertAxis.SelectedIndex = 0;
        }

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            string name = ((RadioButton)sender).Name.Substring(3);

            foreach (Control c in Controls)
            {
                if (c is GroupBox) { c.Visible = false; }
            }

            Control[] groupBox = Controls.Find($"gb{name}", true);
            if (groupBox.Length > 0) { groupBox[0].Visible = !groupBox[0].Visible; }
        }

        // Scale START
        private void rdoScale_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in gbScaling.Controls) { if (c is TextBox) { c.Enabled = false; } }

            switch (((RadioButton)sender).Name)
            {
                case "rdoScaleWholeModel":
                    txtScaleWholeModel.Enabled = true;
                    break;

                case "rdoScaleByAxis":
                    txtScaleAxisX.Enabled = true;
                    txtScaleAxisY.Enabled = true;
                    txtScaleAxisZ.Enabled = true;
                    break;

                case "rdoScaleRadius":
                    txtScaleRadius.Enabled = true;
                    break;
            }
        }
        // Scale END

        private void btnOK_Click(object sender, EventArgs e)
        {
            applyTransforms();
            Close();
        }

        private void applyTransforms()
        {
            ModelBoneCollection bones = (chkHierarchy.Checked ? SceneManager.Current.Models[modelIndex].Bones[boneIndex].AllChildren() : new ModelBoneCollection { SceneManager.Current.Models[modelIndex].Bones[boneIndex] });

            if (rdoScaling.Checked)
            {
                Matrix4D scaleMatrix = Matrix4D.Identity;

                if (rdoScaleWholeModel.Checked)
                {
                    scaleMatrix = Matrix4D.CreateScale(
                        txtScaleWholeModel.Text.ToSingle(), 
                        txtScaleWholeModel.Text.ToSingle(), 
                        txtScaleWholeModel.Text.ToSingle()
                    );
                }
                else if (rdoScaleByAxis.Checked)
                {
                    scaleMatrix = Matrix4D.CreateScale(
                        txtScaleAxisX.Text.ToSingle(), 
                        txtScaleAxisY.Text.ToSingle(), 
                        txtScaleAxisZ.Text.ToSingle()
                    );
                }

                ModelManipulator.Scale(bones, scaleMatrix, chkHierarchy.Checked);
            }
            else if (rdoMunging.Checked)
            {
                if (rdoInvert.Checked)
                {
                    //ModelManipulator.FlipAxis(SceneManager.Current.Models[modelIndex].Bones[boneIndex].Mesh, cboInvertAxis.SelectedItem.ToString().ToEnum<Axis>(), chkHierarchy.Checked);
                }
                else if (rdoMeshBoneSwap.Checked)
                {
                    ModelManipulator.MungeMeshWithBone(bones);
                }
                else if (rdoFlipWindingOrder.Checked)
                {
                    ModelManipulator.FlipFaces(bones, chkHierarchy.Checked);
                }
            }
        }
    }
}
