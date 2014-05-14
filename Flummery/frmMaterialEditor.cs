using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Flummery.ContentPipeline.Core;

namespace Flummery
{
    public partial class frmMaterialEditor : Form
    {
        MaterialItem mi;
        Material m;

        public frmMaterialEditor(MaterialItem mi, Material M)
        {
            InitializeComponent();

            this.mi = mi;

            SetMaterial(M);

            this.Width = 440;
            gbPropColour.Left = 12;
            gbPropLighting.Left = 12;
            gbPropFlags.Left = 12;
            gbPropData.Left = 12;
        }

        public void SetMaterial(Material M)
        {
            m = M;

            txtName.Text = M.Name;
            SetTexture(M.Texture);

            foreach (Control c in gbPropFlags.Controls)
            {
                //if (c is CheckBox) { ((CheckBox)c).Checked = M.GetFlag(Int32.Parse(c.Name.Substring(3))); }
            }
        }

        private void SetTexture(Texture t)
        {
            txtTexture.Text = t.Name;
            pbPreview.Image = t.GetThumbnail();
            mi.SetThumbnail((Bitmap)pbPreview.Image);
        }

        void rdoProperties_CheckedChanged(object sender, System.EventArgs e)
        {
            RadioButton rdo = sender as RadioButton;

            if (!rdo.Checked) { return; }

            gbPropColour.Visible = false;
            gbPropLighting.Visible = false;
            gbPropFlags.Visible = false;
            gbPropData.Visible = false;

            switch (rdo.Text)
            {
                case "Colour":
                    gbPropColour.Visible = true;
                    break;
                case "Lighting":
                    gbPropLighting.Visible = true;
                    break;
                case "Flags":
                    gbPropFlags.Visible = true;
                    break;
                case "Data":
                    gbPropData.Visible = true;
                    break;
                default:
                    MessageBox.Show(rdo.Text);
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkFlags_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            int flag = Int32.Parse(chk.Name.Substring(3));
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ofdBrowse.Filter = "TIF (*.tif)|*.tif";

            if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
            {
                m.Texture = SceneManager.Current.Content.Load<Texture, TIFImporter>(Path.GetFileName(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName));
                SetTexture(m.Texture);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        protected void ApplySettings()
        {
            m.Name = txtName.Text;
            mi.MaterialName = txtName.Text;
            mi.SetThumbnail((Bitmap)pbPreview.Image);
        }
    }
}
