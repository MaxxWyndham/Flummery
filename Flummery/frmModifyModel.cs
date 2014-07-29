using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Flummery
{
    public partial class frmModifyModel : Form
    {
        int parentBoneIndex;

        public frmModifyModel()
        {
            InitializeComponent();
        }

        public void SetParentNode(int boneID)
        {
            parentBoneIndex = boneID;
        }

        private void frmModifyModel_Load(object sender, EventArgs e)
        {
            cboInvertAxis.SelectedIndex = 0;
        }

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            string name = ((RadioButton)sender).Name.Substring(3);
            var groupBox = this.Controls.Find("gb" + name, true);
            if (groupBox.Length > 0) { groupBox[0].Visible = !groupBox[0].Visible; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            applyTransforms();
            this.Close();
        }

        private void applyTransforms()
        {
            if (rdoMunging.Checked)
            {
                if (rdoInvert.Checked)
                {
                    while (true)
                    {
                        var bone = SceneManager.Current.Models[0].Bones[parentBoneIndex];
                        var mesh = (ModelMesh)bone.Tag;

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

                        break;
                    }
                }
            }
        }
    }
}
