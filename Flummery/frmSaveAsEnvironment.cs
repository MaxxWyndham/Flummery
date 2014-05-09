using System;
using System.IO;
using System.Windows.Forms;
using Flummery.ContentPipeline.Stainless;
using OpenTK;

namespace Flummery
{
    public partial class frmSaveAsEnvironment : Form
    {
        FlumpFile flump;
        string environment;

        public frmSaveAsEnvironment()
        {
            InitializeComponent();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (fbdBrowse.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(fbdBrowse.SelectedPath)) { Directory.CreateDirectory(fbdBrowse.SelectedPath); }
                txtPath.Text = fbdBrowse.SelectedPath + "\\";

                environment = Path.GetFileName(Path.GetDirectoryName(txtPath.Text));
                lblEnvironment.Text = lblEnvironment.Tag.ToString().Replace("%%environment%%", environment.ToLower());

                flump = FlumpFile.Load(txtPath.Text + "environment.flump");

                if (flump.Settings.ContainsKey("environment.level"))
                {
                    txtLevel.Text = flump.Settings["environment.level"];
                    updateLabels(txtLevel.Text);
                }

                if (flump.Settings.ContainsKey("environment.name")) { txtEnvironment.Text = flump.Settings["environment.name"]; }
                if (flump.Settings.ContainsKey("environment.level.name")) { txtRace1Name.Text = flump.Settings["environment.level.name"]; }
                if (flump.Settings.ContainsKey("environment.level.description")) { txtRace1Writeup.Text = flump.Settings["environment.level.description"]; }
            }
        }

        private void txtLevel_TextChanged(object sender, EventArgs e)
        {
            updateLabels(txtLevel.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string racePath = txtPath.Text + "levels\\" + txtLevel.Text + "\\";
            if (!Directory.Exists(racePath)) { Directory.CreateDirectory(racePath); }

            flump.Settings["environment"] = environment;
            flump.Settings["environment.name"] = txtEnvironment.Text;
            flump.Settings["environment.level"] = txtLevel.Text;
            flump.Settings["environment.level.name"] = txtRace1Name.Text;
            flump.Settings["environment.level.description"] = txtRace1Writeup.Text;

            using (StreamWriter w = File.CreateText(txtPath.Text + "\\environment.lol"))
            {
                w.WriteLine("module((...), environment_config, package.seeall)");
                w.WriteLine("txt[\"" + lblEnvironment.Text + "\"] = \"" + txtLevel.Text + "\"");
                w.WriteLine("txt[\"" + lblRace1Name.Text + "\"] = \"" + txtRace1Name.Text + "\"");
                w.WriteLine("txt[\"" + lblRace1Writeup.Text + "\"] = \"" + txtRace1Writeup.Text + "\"");
                w.WriteLine("name = txt." + lblEnvironment.Text);
            }

            using (StreamWriter w = File.CreateText(racePath + "level.txt"))
            {
                w.WriteLine("[LUMP]");
                w.WriteLine("level");
                w.WriteLine();
                w.WriteLine("[RACE_NAMES]");
                w.WriteLine("txt." + lblRace1Name.Text);
                w.WriteLine();
                w.WriteLine("[RACE_WRITEUP]");
                w.WriteLine("txt." + lblRace1Writeup.Text);
                w.WriteLine();
                w.WriteLine("[RACE_IMAGES]");
                w.WriteLine("race\\" + environment + "_" + txtLevel.Text + "_race_01");
                w.WriteLine();
                w.WriteLine("[RACE_BACKGROUNDS]");
                w.WriteLine("background_list\\" + environment + "_" + txtLevel.Text + "_race_01");
                w.WriteLine();
                w.WriteLine("[VERSION]");
                w.WriteLine("2.500000");
                w.WriteLine();
                w.WriteLine("[RACE_LAYERS]");
                w.WriteLine("race01");
                w.WriteLine();
                w.WriteLine("[LUA_SCRIPTS]");
                w.WriteLine("setup.lua");
                w.WriteLine();
            }

            if (chkMaterials.Checked)
            {
                foreach (var material in SceneManager.Scene.Textures)
                {
                    var tx = new TDXExporter();
                    tx.SetExportOptions(new { Format = ToxicRagers.Helpers.D3DFormat.DXT5 });
                    tx.Export(material, racePath);
                }
            }

            var cx = new CNTExporter();
            cx.SetExportOptions(new { Scale = new Vector3(6.9f, 6.9f, -6.9f) });
            cx.Export(SceneManager.Scene.Models[0], racePath + "level.cnt");

            var mx = new MDLExporter();
            mx.SetExportOptions(new { Transform = Matrix4.CreateScale(6.9f, 6.9f, -6.9f) });
            mx.Export(SceneManager.Scene.Models[0], racePath);

            if (SceneManager.Scene.Entities.Count > 0)
            {
                using (StreamWriter wpup = File.CreateText(racePath + "powerups.lol"))
                {
                    using (StreamWriter wacc = File.CreateText(racePath + "level.lol"))
                    {
                        wpup.WriteLine("module((...), level_powerup_setup)");
                        wpup.WriteLine("accessories = {");

                        wacc.WriteLine("module((...), level_accessory_setup)");
                        wacc.WriteLine("accessories = {");

                        for (int i = 0; i < SceneManager.Scene.Entities.Count; i++)
                        {
                            var entity = SceneManager.Scene.Entities[i];
                            var w = (entity.EntityType == EntityType.Accessory ? wacc : wpup);

                            w.WriteLine("\t" + entity.UniqueIdentifier + " = {");
                            w.WriteLine("\t\ttype = \"" + entity.Name + "\",");
                            if (entity.EntityType == EntityType.Powerup) { w.WriteLine("\t\tname = \"" + entity.Tag + "\","); }
                            w.WriteLine("\t\tlayer = \"race01\",");
                            w.WriteLine("\t\ttransform = {");
                            w.WriteLine("\t\t\t{" + entity.Transform.M11 + "," + entity.Transform.M21 + "," + entity.Transform.M31 + "},");
                            w.WriteLine("\t\t\t{" + entity.Transform.M12 + "," + entity.Transform.M22 + "," + entity.Transform.M32 + "},");
                            w.WriteLine("\t\t\t{" + entity.Transform.M13 + "," + entity.Transform.M23 + "," + entity.Transform.M33 + "},");
                            w.WriteLine("\t\t\t{" + entity.Transform.M41 * 6.9f + "," + entity.Transform.M42 * 6.9f + "," + entity.Transform.M43 * -6.9f + "}");
                            w.WriteLine("\t\t},");
                            w.WriteLine("\t\tcolour = { 255, 255, 255 }");
                            w.Write("\t}");
                            w.WriteLine((i + 1 < SceneManager.Scene.Entities.Count ? "," : ""));
                        }

                        wacc.WriteLine("}");
                        wpup.WriteLine("}");
                    }
                }
            }

            flump.Save(txtPath.Text + "environment.flump");
            this.Close();
        }

        void updateLabels(string level)
        {
            lblRace1Name.Text = lblRace1Name.Tag.ToString().Replace("%%level%%", level).ToLower();
            lblRace1Writeup.Text = lblRace1Writeup.Tag.ToString().Replace("%%level%%", level).ToLower();
        }
    }
}
