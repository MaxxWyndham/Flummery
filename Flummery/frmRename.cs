using System;
using System.Windows.Forms;

namespace Flummery
{
    public partial class frmRename : Form
    {
        int parentBoneIndex;
        string newName;

        public string NewName { get { return newName; } }

        public frmRename()
        {
            InitializeComponent();
        }

        public void SetParentNode(int boneID)
        {
            parentBoneIndex = boneID;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var model = SceneManager.Current.Models[0];

            if (chkActors.Checked) { model.SetName(txtName.Text, parentBoneIndex); }
            if (chkModels.Checked && model.Bones[parentBoneIndex].Tag != null) { ((ModelMesh)model.Bones[parentBoneIndex].Tag).Name = txtName.Text; }

            newName = txtName.Text;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
