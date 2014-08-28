using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Flummery.ContentPipeline.Stainless;
using OpenTK;

namespace Flummery
{
    public partial class frmSaveAsVehicle : Form
    {
        public frmSaveAsVehicle()
        {
            InitializeComponent();

            txtPath.Text = Properties.Settings.Default.SaveAsVehiclePath;
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            fbdBrowse.SelectedPath = txtPath.Text;

            if (fbdBrowse.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(fbdBrowse.SelectedPath)) { Directory.CreateDirectory(fbdBrowse.SelectedPath); }
                txtPath.Text = fbdBrowse.SelectedPath + "\\";

                Properties.Settings.Default.SaveAsVehiclePath = txtPath.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtPath.Text)) { Directory.CreateDirectory(txtPath.Text); }

            if (chkMaterials.Checked)
            {
                var textures = new List<string>();

                foreach (var material in SceneManager.Current.Materials)
                {
                    using (StreamWriter w = File.CreateText(txtPath.Text + "\\" + material.Name + ".mt2"))
                    {
                        w.WriteLine("<?xml version=\"1.0\"?>");
                        w.WriteLine("<Material>");
                        w.WriteLine("\t<BasedOffOf Name=\"simple_base\"/>");
                        w.WriteLine("\t<Pass Number=\"0\">");
                        w.WriteLine("\t\t<Texture Alias=\"DiffuseColour\" FileName=\"" + material.Texture.Name + "\"/>");
                        w.WriteLine("\t</Pass>");
                        w.WriteLine("</Material>");
                    }

                    if (!textures.Contains(material.Texture.Name))
                    {
                        var tx = new TDXExporter();
                        tx.ExportSettings.AddSetting("Format", ToxicRagers.Helpers.D3DFormat.DXT5);
                        tx.Export(material.Texture, txtPath.Text);

                        textures.Add(material.Texture.Name);
                    }
                }
            }

            var cx = new CNTExporter();
            cx.Export(SceneManager.Current.Models[0], txtPath.Text + "car.cnt");

            var mx = new MDLExporter();
            //mx.ExportSettings.AddSetting("Handed", Model.CoordinateSystem.RightHanded);
            mx.Export(SceneManager.Current.Models[0], txtPath.Text);
            this.Close();
        }
    }
}
