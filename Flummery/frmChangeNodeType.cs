using System;
using System.IO;
using System.Windows.Forms;

using Flummery.ContentPipeline.Stainless;

using ToxicRagers.Helpers;

namespace Flummery
{
    public partial class frmChangeNodeType : Form
    {
        BoneType type = BoneType.Null;
        string attachment = null;
        string fileToAttach;

        int modelIndex;
        int boneIndex;

        public frmChangeNodeType()
        {
            InitializeComponent();
        }

        public void SetParentNode(int modelID, int boneID)
        {
            ModelBone bone = SceneManager.Current.Models[modelID].Bones[boneID];

            modelIndex = modelID;
            boneIndex = boneID;

            type = bone.Type;

            switch (type)
            {
                case BoneType.Mesh:
                    attachment = (bone.Mesh != null ? bone.Mesh.Name + ".mdl" : null);
                    break;

                case BoneType.Light:
                    attachment = (bone.AttachmentFile != null ? bone.AttachmentFile + ".light" : null);
                    break;

                case BoneType.VFX:
                    attachment = (bone.AttachmentFile != null ? bone.AttachmentFile + ".lol" : null);
                    break;
            }

            ResetUI();
        }

        public void ResetUI()
        {
            switch (type)
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
                    txtPath.Text = attachment;
                    ofdBrowse.Filter = "Stainless MDL files (*.mdl)|*.mdl";
                    break;

                case BoneType.Light:
                    rdoTypeLIGHT.Checked = true;
                    txtPath.Visible = true;
                    btnBrowse.Visible = true;
                    lblOr.Visible = true;
                    chkNewLight.Visible = true;
                    txtPath.Text = attachment;
                    ofdBrowse.Filter = "Stainless LIGHT files (*.light)|*.light";
                    break;

                case BoneType.VFX:
                    rdoTypeVFX.Checked = true;
                    txtPath.Visible = true;
                    btnBrowse.Visible = true;
                    lblOr.Visible = false;
                    chkNewLight.Visible = false;
                    txtPath.Text = attachment;
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
                fileToAttach = ofdBrowse.FileName;
                txtPath.Text = Path.GetFileName(fileToAttach);
            }
        }

        private void rdoType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (sender as RadioButton);

            if (rdo.Checked)
            {
                type = (sender as RadioButton).Tag.ToString().ToEnum<BoneType>();

                ResetUI();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ModelBone oldBone = SceneManager.Current.Models[modelIndex].Bones[boneIndex];

            if (oldBone.Type == BoneType.Mesh && type != BoneType.Mesh)
            {
                SceneManager.Current.Models[modelIndex].ClearMesh(boneIndex);
            }

            switch (type)
            {
                case BoneType.Mesh:
                    SceneManager.Current.Models[modelIndex].SetMesh(SceneManager.Current.Content.Load<Model, MDLImporter>(Path.GetFileNameWithoutExtension(fileToAttach), Path.GetDirectoryName(fileToAttach)).Meshes[0], boneIndex);
                    oldBone.AttachmentFile = null;
                    break;

                case BoneType.Light:
                    oldBone.Type = type;

                    if (chkNewLight.Checked)
                    {
                        oldBone.Attachment = new ToxicRagers.CarmageddonReincarnation.Formats.LIGHT();
                        oldBone.AttachmentFile = null;
                    }
                    else
                    {
                        oldBone.Attachment = SceneManager.Current.Content.Load<Model, LIGHTImporter>(Path.GetFileNameWithoutExtension(fileToAttach), Path.GetDirectoryName(fileToAttach)).Bones[0].Attachment;
                        oldBone.AttachmentFile = Path.GetFileNameWithoutExtension(fileToAttach);
                    }
                    break;

                case BoneType.VFX:
                    oldBone.Type = type;
                    oldBone.Attachment = null;
                    oldBone.AttachmentFile = Path.GetFileNameWithoutExtension(fileToAttach);
                    break;

                case BoneType.Null:
                    oldBone.Type = type;
                    oldBone.Attachment = null;
                    oldBone.AttachmentFile = null;
                    break;
            }
        }
    }
}
