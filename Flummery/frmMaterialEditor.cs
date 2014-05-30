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
            ofdBrowse.Filter = "All supported files|*.jpg;*.png;*.tif;*.tga|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIF (*.tif)|*.tif|TGA (*.tga)|*.tga";

            if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
            {
                loadTexture(ofdBrowse.FileName);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (File.Exists(m.Texture.FileName)) { loadTexture(m.Texture.FileName); }
        }

        private void loadTexture(string path)
        {
            var fi = new FileInfo(path);

            switch (fi.Extension)
            {
                case ".jpg":
                    m.Texture = SceneManager.Current.Content.Load<Texture, JPGImporter>(Path.GetFileName(path), Path.GetDirectoryName(path));
                    break;

                case ".png":
                    m.Texture = SceneManager.Current.Content.Load<Texture, PNGImporter>(Path.GetFileName(path), Path.GetDirectoryName(path));
                    break;

                case ".tif":
                    m.Texture = SceneManager.Current.Content.Load<Texture, TIFImporter>(Path.GetFileName(path), Path.GetDirectoryName(path));
                    break;

                case ".tga":
                    m.Texture = SceneManager.Current.Content.Load<Texture, TGAImporter>(Path.GetFileName(path), Path.GetDirectoryName(path));
                    break;
            }

            SetTexture(m.Texture);
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplySettings();
            this.Close();
        }

        private void pbPreview_Click(object sender, EventArgs e)
        {
            var preview = new pnlTexturePreview();
            preview.SetImage(m.Texture.GetBitmap());
            preview.Show(Flummery.UI.DockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Float);
        }
    }
}
