using System;
using System.IO;
using System.Windows.Forms;

using Flummery.ContentPipeline;
using Flummery.ContentPipeline.Core;
using Flummery.ContentPipeline.Stainless;

namespace Flummery
{
    public partial class frmTDXConvert : Form
    {
        Texture t = null;

        public frmTDXConvert()
        {
            InitializeComponent();
        }


        private void frmTDXConvert_Load(object sender, EventArgs e)
        {
            lblFile.Text = "";
            lblWidth.Text = "";
            lblHeight.Text = "";
            lblFileSize.Text = "";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ofdBrowse.Filter = "All supported files|*.jpg;*.png;*.tif;*.tga;*.bmp;*.tdx|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIF (*.tif)|*.tif|TGA (*.tga)|*.tga|BMP (*.bmp)|*.bmp|TDX (*.tdx)|*.tdx";

            if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
            {
                var fi = new FileInfo(ofdBrowse.FileName);

                switch (fi.Extension.ToLower())
                {
                    case ".bmp":
                        t = SceneManager.Current.Content.Load<Texture, BMPImporter>(fi.Name, fi.DirectoryName);
                        break;

                    case ".jpg":
                        t = SceneManager.Current.Content.Load<Texture, JPGImporter>(fi.Name, fi.DirectoryName);
                        break;

                    case ".png":
                        t = SceneManager.Current.Content.Load<Texture, PNGImporter>(fi.Name, fi.DirectoryName);
                        break;

                    case ".tif":
                        t = SceneManager.Current.Content.Load<Texture, TIFImporter>(fi.Name, fi.DirectoryName);
                        break;

                    case ".tga":
                        t = SceneManager.Current.Content.Load<Texture, TGAImporter>(fi.Name, fi.DirectoryName);
                        break;

                    case ".tdx":
                        t = SceneManager.Current.Content.Load<Texture, TDXImporter>(fi.Name, fi.DirectoryName);
                        break;
                }

                if (t != null)
                {
                    var b = t.GetBitmap();

                    pbPreview.Image = t.GetThumbnail(1024, false);
                    lblFile.Text = string.Format(lblFile.Tag.ToString(), fi.Name);
                    lblWidth.Text = string.Format(lblWidth.Tag.ToString(), b.Width);
                    lblHeight.Text = string.Format(lblHeight.Tag.ToString(), b.Height);
                    lblFileSize.Text = string.Format(lblFileSize.Tag.ToString(), fi.Length);
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ContentExporter cx = null;
            sfdSave.Filter = "TDX (*.tdx)|*.tdx|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIF (*.tif)|*.tif|BMP (*.bmp)|*.bmp";

            if (sfdSave.ShowDialog() == DialogResult.OK)
            {
                switch (Path.GetExtension(sfdSave.FileName))
                {
                    case ".bmp":
                        cx = new BMPExporter();
                        break;

                    case ".jpg":
                        cx = new JPGExporter();
                        break;

                    case ".png":
                        cx = new PNGExporter();
                        break;

                    case ".tif":
                        cx = new TIFExporter();
                        break;

                    case ".tdx":
                        cx = new TDXExporter();
                        cx.ExportSettings.AddSetting("Format", ToxicRagers.Helpers.D3DFormat.DXT5);
                        break;
                }

                if (cx != null)
                {
                    cx.Export(t, sfdSave.FileName);
                    SceneManager.Current.UpdateProgress(string.Format("Saved {0}", sfdSave.FileName));
                }
            }
        }
    }
}
