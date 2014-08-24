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
    public partial class frmRemoveObject : Form
    {
        int parentBoneIndex;
        bool bRemovedBone;

        public bool RemovedBone { get { return bRemovedBone; } }

        public frmRemoveObject()
        {
            InitializeComponent();
        }

        public void SetParentNode(int boneID)
        {
            parentBoneIndex = boneID;
        }

        private void chkBone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBone.Checked)
            {
                chkModel.Checked = true;
                chkModel.Enabled = false;
            }
            else
            {
                chkModel.Enabled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkModel.Checked) { SceneManager.Current.Models[0].ClearMesh(parentBoneIndex); bRemovedBone = false; }
            if (chkBone.Checked) { SceneManager.Current.Models[0].RemoveBone(parentBoneIndex); bRemovedBone = true; }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
