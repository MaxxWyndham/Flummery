using System;
using System.Windows.Forms;

namespace Flummery
{
    public partial class frmRename : Form
    {
        int modelIndex;
        int boneIndex;
        string newName;

        public string NewName { get { return newName; } }

        public frmRename()
        {
            InitializeComponent();
        }

        public void SetParentNode(int modelID, int boneID)
        {
            modelIndex = modelID;
            boneIndex = boneID;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var model = SceneManager.Current.Models[modelIndex];

            if (chkActors.Checked) { model.SetName(txtName.Text, boneIndex); }
            if (chkModels.Checked && model.Bones[boneIndex].Tag != null) { ((ModelMesh)model.Bones[boneIndex].Tag).Name = txtName.Text; }

            newName = txtName.Text;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
