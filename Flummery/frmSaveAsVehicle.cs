using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Flummery.ContentPipeline.Stainless;
using ToxicRagers.CarmageddonReincarnation.Formats;
using OpenTK;

namespace Flummery
{
    public partial class frmSaveAsVehicle : Form
    {
        FlumpFile flump;
        string car;

        public frmSaveAsVehicle()
        {
            InitializeComponent();

            txtPath.Text = Properties.Settings.Default.SaveAsVehiclePath;
            setCar();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            fbdBrowse.SelectedPath = txtPath.Text;

            if (fbdBrowse.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(fbdBrowse.SelectedPath)) { Directory.CreateDirectory(fbdBrowse.SelectedPath); }
                txtPath.Text = fbdBrowse.SelectedPath + "\\";

                setCar();

                Properties.Settings.Default.SaveAsVehiclePath = txtPath.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void setCar()
        {
            if (txtPath.Text.Length == 0)
            {
                btnOK.Enabled = false;
                return;
            }
            else
            {
                btnOK.Enabled = true;
            }

            flump = FlumpFile.Load(txtPath.Text + "car.flump");

            car = Path.GetFileName(Path.GetDirectoryName(txtPath.Text));
            txtCarName.Text = car;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            btnOK.Enabled = false;

            if (!Directory.Exists(txtPath.Text)) { Directory.CreateDirectory(txtPath.Text); }

            flump.Settings["car"] = car;

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

            new CNTExporter().Export(SceneManager.Current.Models[0], txtPath.Text + "car.cnt");
            new MDLExporter().Export(SceneManager.Current.Models[0], txtPath.Text);

            if (!File.Exists(txtPath.Text + "setup.lol"))
            {
                var sx = new SetupLOLExporter();
                sx.ExportSettings.AddSetting("Context", SetupContext.Vehicle);
                sx.Export(SceneManager.Current.Models[0], txtPath.Text);
            }

            if (!File.Exists(txtPath.Text + "Structure.xml"))
            {
                new StructureXMLExporter().Export(SceneManager.Current.Models[0], txtPath.Text);
            }

            if (!File.Exists(txtPath.Text + "SystemsDamage.xml"))
            {
                new SystemsDamageXMLExporter().Export(SceneManager.Current.Models[0], txtPath.Text);
            }

            if (!File.Exists(txtPath.Text + "vehicle_setup.cfg"))
            {
                var cfgx = new VehicleSetupCFGExporter();
                cfgx.ExportSettings.AddSetting("VehicleName", txtCarName.Text);
                cfgx.Export(SceneManager.Current.Models[0], txtPath.Text);
            }

            flump.Save(txtPath.Text + "car.flump");

            SceneManager.Current.UpdateProgress(string.Format("Vehicle '{0}' saved successfully!", car));

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
