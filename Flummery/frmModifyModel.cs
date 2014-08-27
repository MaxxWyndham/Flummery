using System;
using System.Windows.Forms;

using ToxicRagers.Helpers;

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

            foreach (Control c in this.Controls)
            {
                if (c is GroupBox) { c.Visible = false; }
            }

            var groupBox = this.Controls.Find("gb" + name, true);
            if (groupBox.Length > 0) { groupBox[0].Visible = !groupBox[0].Visible; }
        }

        // Scale START
        private void rdoScale_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in this.gbScaling.Controls) { if (c is TextBox) { c.Enabled = false; } }

            switch (((RadioButton)sender).Name)
            {
                case "rdoScaleWholeModel":
                    this.txtScaleWholeModel.Enabled = true;
                    break;

                case "rdoScaleByAxis":
                    this.txtScaleAxisX.Enabled = true;
                    this.txtScaleAxisY.Enabled = true;
                    this.txtScaleAxisZ.Enabled = true;
                    break;

                case "rdoScaleRadius":
                    this.txtScaleRadius.Enabled = true;
                    break;
            }
        }
        // Scale END

        private void btnOK_Click(object sender, EventArgs e)
        {
            applyTransforms();
            this.Close();
        }

        private void applyTransforms()
        {
            var bones = (chkHierarchy.Checked ? SceneManager.Current.Models[modelIndex].Bones[boneIndex].AllChildren() : new ModelBoneCollection { SceneManager.Current.Models[modelIndex].Bones[boneIndex] });

            if (rdoScaling.Checked)
            {
                if (rdoScaleByAxis.Checked)
                {
                    foreach (var bone in bones)
                    {
                        var scaleMatrix = OpenTK.Matrix4.CreateScale(txtScaleAxisX.Text.ToSingle(), txtScaleAxisY.Text.ToSingle(), txtScaleAxisZ.Text.ToSingle());
                        var mesh = (ModelMesh)bone.Tag;

                        if (mesh != null)
                        {
                            foreach (var meshpart in mesh.MeshParts)
                            {
                                for (int i = 0; i < meshpart.VertexCount; i++)
                                {
                                    var position = OpenTK.Vector3.Transform(meshpart.VertexBuffer.Data[i].Position, scaleMatrix);
                                    meshpart.VertexBuffer.ModifyVertexPosition(i, position);
                                }

                                meshpart.VertexBuffer.Initialise();
                            }
                        }
                    }
                }
            }
            else if (rdoMunging.Checked)
            {
                if (rdoInvert.Checked)
                {
                    foreach (var bone in bones)
                    {
                        var mesh = (ModelMesh)bone.Tag;

                        if (mesh != null)
                        {
                            foreach (var meshpart in mesh.MeshParts)
                            {
                                for (int i = 0; i < meshpart.VertexCount; i++)
                                {
                                    var position = meshpart.VertexBuffer.Data[i].Position;

                                    switch (cboInvertAxis.SelectedItem.ToString())
                                    {
                                        case "X":
                                            position.X = -position.X;
                                            break;

                                        case "Y":
                                            position.Y = -position.Y;
                                            break;

                                        case "Z":
                                            position.Z = -position.Z;
                                            break;

                                    }

                                    meshpart.VertexBuffer.ModifyVertexPosition(i, position);
                                }

                                for (int i = 0; i < meshpart.IndexBuffer.Data.Count; i += 3)
                                {
                                    meshpart.IndexBuffer.SwapIndices(i + 1, i + 2);
                                }

                                meshpart.IndexBuffer.Initialise();
                                meshpart.VertexBuffer.Initialise();
                            }

                            mesh.BoundingBox.Calculate(mesh);
                        }
                    }
                }

                if (rdoMeshBoneSwap.Checked)
                {
                    var offset = bones[0].Parent.Transform.ExtractTranslation();

                    foreach (var bone in bones)
                    {
                        var mesh = (ModelMesh)bone.Tag;

                        if (mesh != null)
                        {
                            var meshoffset = mesh.BoundingBox.Centre;

                            foreach (var meshpart in mesh.MeshParts)
                            {
                                for (int i = 0; i < meshpart.VertexCount; i++) { meshpart.VertexBuffer.ModifyVertexPosition(i, meshpart.VertexBuffer.Data[i].Position - meshoffset); }
                                meshpart.VertexBuffer.Initialise();
                            }
                            mesh.BoundingBox.Calculate(mesh);

                            var moffset = meshoffset - offset;
                            offset = meshoffset;

                            var m = bone.Transform;
                            m.M41 += moffset.X;
                            m.M42 += moffset.Y;
                            m.M43 += moffset.Z;
                            bone.Transform = m;
                        }

                        //offset = bone.CombinedTransform.ExtractTranslation();
                    }
                }
            }
        }
    }
}
