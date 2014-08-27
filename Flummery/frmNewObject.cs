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
    public partial class frmNewObject : Form
    {
        int modelIndex;
        int boneIndex;
        int newBoneKey;

        public int NewBoneKey { get { return newBoneKey; } }

        public frmNewObject()
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
            newBoneKey = model.AddMesh(null, boneIndex);
            model.SetName(txtName.Text, newBoneKey);
            newBoneKey = ModelBone.GetModelBoneKey(modelIndex, newBoneKey);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
