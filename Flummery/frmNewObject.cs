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
        int parentBoneIndex;
        int newBoneIndex;

        public int NewBoneIndex { get { return newBoneIndex; } }

        public frmNewObject()
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
            newBoneIndex = model.AddMesh(null, parentBoneIndex);
            model.SetName(txtName.Text, newBoneIndex);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
