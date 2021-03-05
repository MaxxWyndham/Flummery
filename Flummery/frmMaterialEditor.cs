using System;
using System.IO;
using System.Windows.Forms;

using Flummery.Controls;
using Flummery.Core;

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
            m = M;

            txtMaterialName.Text = M.Name;

            foreach (Texture texture in M.Textures)
            {
                openFileFor(texture.Type.ToString().Substring(0, 4), texture.FileName);
            }
        }

        private void btnDiffLoad_Click(object sender, EventArgs e)
        {
            loadFileFor("Diff");
        }

        private void btnNormLoad_Click(object sender, EventArgs e)
        {
            loadFileFor("Norm");
        }

        private void btnSpecLoad_Click(object sender, EventArgs e)
        {
            loadFileFor("Spec");
        }

        private void loadFileFor(string context)
        {
            ofdBrowse.Filter = ofdBrowse.Filter = "All supported files|*.jpg;*.png;*.tif;*.tga;*.bmp;*.tdx|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIF (*.tif)|*.tif|TGA (*.tga)|*.tga|BMP (*.bmp)|*.bmp|TDX (*.tdx)|*.tdx";

            if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
            {
                openFileFor(context, ofdBrowse.FileName);
            }
        }

        private void openFileFor(string context, string filename)
        {
            Texture texture = SceneManager.Current.Content.Load(Path.GetFileName(filename), Path.GetDirectoryName(filename));

            Controls.Find($"lbl{context}Path", true)[0].Text = Path.GetFileName(filename);
            (Controls.Find($"pb{context}Preview", true)[0] as PictureBox).Image = texture.GetThumbnail(1024, false);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m.Name = txtMaterialName.Text;
            mi.Name = txtMaterialName.Text;
        }
    }
}