using System;
using System.IO;
using System.Windows.Forms;

using Flummery.ContentPipeline.Stainless;

using ToxicRagers.Helpers;

namespace Flummery
{
    public partial class frmChangeNodeType : Form
    {
        ModelBone bone;

        int modelIndex;
        int boneIndex;

        public frmChangeNodeType()
        {
            InitializeComponent();
        }

        public void SetParentNode(int modelID, int boneID)
        {
            modelIndex = modelID;
            boneIndex = boneID;

            bone = SceneManager.Current.Models[modelID].Bones[boneID].Clone();

            ResetUI();
        }

        public void ResetUI()
        {
            switch (bone.Type)
            {
                case BoneType.Null:
                    rdoTypeNULL.Checked = true;
                    txtPath.Visible = false;
                    btnBrowse.Visible = false;
                    lblOr.Visible = false;
                    chkNewLight.Visible = false;
                    txtPath.Text = "";
                    break;

                case BoneType.Mesh:
                    rdoTypeMODEL.Checked = true;
                    txtPath.Visible = true;
                    btnBrowse.Visible = true;
                    lblOr.Visible = false;
                    chkNewLight.Visible = false;
                    txtPath.Text = (bone.Mesh != null ? bone.Mesh.Name + ".mdl" : "");
                    ofdBrowse.Filter = "Stainless MDL files (*.mdl)|*.mdl";
                    break;

                case BoneType.Light:
                    rdoTypeLIGHT.Checked = true;
                    txtPath.Visible = true;
                    btnBrowse.Visible = true;
                    lblOr.Visible = true;
                    chkNewLight.Visible = true;
                    txtPath.Text = (bone.AttachmentFile != null ? bone.AttachmentFile + ".light" : "");
                    ofdBrowse.Filter = "Stainless LIGHT files (*.light)|*.light";
                    break;

                case BoneType.VFX:
                    rdoTypeVFX.Checked = true;
                    txtPath.Visible = true;
                    btnBrowse.Visible = true;
                    lblOr.Visible = false;
                    chkNewLight.Visible = false;
                    txtPath.Text = (bone.AttachmentFile != null ? bone.AttachmentFile + ".lol" : "");
                    ofdBrowse.Filter = "Stainless EFFECT files (*.lol)|*.lol";
                    break;
            }
        }

        private void frmChangeNodeType_Load(object sender, EventArgs e)
        {
            lblWarning.Text = "";

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
            {
                switch (bone.Type)
                {
                    case BoneType.Light:
                        bone.AttachmentFile = Path.GetFileNameWithoutExtension(ofdBrowse.FileName);
                        bone.Attachment = SceneManager.Current.Content.Load<Model, LIGHTImporter>(bone.AttachmentFile, Path.GetDirectoryName(ofdBrowse.FileName)).Bones[0].Attachment;
                        break;

                    case BoneType.Mesh:
                        bone.Attachment = SceneManager.Current.Content.Load<Model, MDLImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName)).Meshes[0];
                        break;

                    case BoneType.VFX:
                        bone.AttachmentFile = Path.GetFileNameWithoutExtension(ofdBrowse.FileName);
                        break;
                }

                ResetUI();
            }
        }

        private void rdoType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (sender as RadioButton);

            if (rdo.Checked)
            {
                bone.Type = (sender as RadioButton).Tag.ToString().ToEnum<BoneType>();

                ResetUI();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ModelBone oldBone = SceneManager.Current.Models[modelIndex].Bones[boneIndex];

            if (oldBone.Type == BoneType.Mesh && bone.Type != BoneType.Mesh)
            {
                SceneManager.Current.Models[modelIndex].ClearMesh(boneIndex);
            } 
            
            if (oldBone.Type != BoneType.Mesh && bone.Type == BoneType.Mesh) 
            { 
                SceneManager.Current.Models[modelIndex].SetMesh(bone.Mesh, boneIndex); 
            }
            else if (bone.Type == BoneType.Light)
            {
                if (chkNewLight.Checked)
                {
                    bone.Attachment = new ToxicRagers.CarmageddonReincarnation.Formats.LIGHT();
                    bone.AttachmentFile = null;
                }
            }

            SceneManager.Current.Models[modelIndex].Bones[boneIndex] = bone.Clone();
        }
    }
}
