using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Flummery.Core;

namespace Flummery
{
    public partial class frmNewObject : Form
    {
        int modelIndex;
        int boneIndex;
        int newBoneKey;

        public int NewBoneKey => newBoneKey;

        public frmNewObject()
        {
            InitializeComponent();

            txtName.Select();
            txtName.SelectAll();
        }

        public void SetParentNode(int modelID, int boneID)
        {
            modelIndex = modelID;
            boneIndex = boneID;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Model model = (SceneManager.Current.Models.Count > 0 ? SceneManager.Current.Models[modelIndex] : (Model)SceneManager.Current.Add(new Model()));
            newBoneKey = model.AddMesh(null, boneIndex);
            model.SetName(txtName.Text, newBoneKey);
            newBoneKey = ModelBone.GetModelBoneKey(modelIndex, newBoneKey);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
