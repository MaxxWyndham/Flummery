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
        int modelIndex;
        int boneIndex;
        bool bRemovedBone;

        public bool RemovedBone { get { return bRemovedBone; } }

        public frmRemoveObject()
        {
            InitializeComponent();
        }

        public void SetParentNode(int modelID, int boneID)
        {
            modelIndex = modelID;
            boneIndex = boneID;
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
            if (chkModel.Checked) { SceneManager.Current.Models[modelIndex].ClearMesh(boneIndex); bRemovedBone = false; }
            if (chkBone.Checked) { SceneManager.Current.Models[modelIndex].RemoveBone(boneIndex); bRemovedBone = true; }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
