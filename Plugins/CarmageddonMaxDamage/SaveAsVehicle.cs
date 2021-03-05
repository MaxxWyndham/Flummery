using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Flummery.Core;
using Flummery.Plugin.CarmageddonMaxDamage.ContentPipeline;

using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.CarmageddonReincarnation.Formats.Materials;
using ToxicRagers.Stainless.Formats;

namespace Flummery.Plugin.CarmageddonMaxDamage
{
    public partial class SaveAsVehicle : Form
    {
        FlumpFile flump;
        string car;

        Label lblInfo = null;
        Label lblProgress = null;
        System.Timers.Timer timer = new System.Timers.Timer(200);
        string[] frames = new string[] { "◐", "◓", "◑", "◒" };
        int progressMax = 0;

        public SaveAsVehicle()
        {
            InitializeComponent();

            timer.AutoReset = true;
            timer.SynchronizingObject = this;
            timer.Elapsed += timer_Elapsed;

            //txtPath.Text = Properties.Settings.Default.SaveAsVehiclePath;
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

                //Properties.Settings.Default.SaveAsVehiclePath = txtPath.Text;
                //Properties.Settings.Default.Save();
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

            flump = FlumpFile.Load(Path.Combine(txtPath.Text, "car.flump"));
            if (flump.Settings.ContainsKey("pretty.name")) { txtPrettyCarName.Text = flump.Settings["pretty.name"]; }

            car = Path.GetFileName(Path.GetDirectoryName(txtPath.Text));
            txtCarName.Text = car;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SceneManager.Current.OnProgress += scene_OnProgress;

            btnOK.Visible = false;
            btnCancel.Visible = false;

            gbProgress.Visible = true;
            pbProgress.Visible = true;

            Application.DoEvents();
            timer.Start();

            if (!Directory.Exists(txtPath.Text)) { Directory.CreateDirectory(txtPath.Text); }

            flump.Settings["car"] = car;
            flump.Settings["pretty.name"] = txtPrettyCarName.Text;

            lblInfo = lblInfoMeshes;
            lblProgress = lblProgressMeshes;
            lblProgress.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            progressMax = 30;

            new CNTExporter().Export(SceneManager.Current.Models[0], Path.Combine(txtPath.Text, "car.cnt"));
            new MDLExporter().Export(SceneManager.Current.Models[0], txtPath.Text);

            lblProgress.Text = "✓";
            lblProgress.ForeColor = Color.Green;
            lblInfo.Text = "Meshes";
            pbProgress.Value = progressMax;

            Application.DoEvents();

            lblInfo = lblInfoTextures;
            lblProgress = lblProgressTextures;
            lblProgress.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            progressMax = 50;

            List<string> textures = new List<string>();

            foreach (Material material in SceneManager.Current.Materials)
            {
                foreach (Texture texture in material.Textures)
                {
                    if (texture.FileName == null) { continue; }

                    string fileName = Path.Combine(txtPath.Text, texture.FileName);

                    if (!textures.Contains(fileName))
                    {
                        if (!File.Exists($"{fileName}.tdx"))
                        {
                            TDXExporter tx = new TDXExporter();
                            tx.ExportSettings.AddSetting("Format", ToxicRagers.Helpers.D3DFormat.DXT5);
                            tx.Export(texture, $"{fileName}.tdx");
                        }

                        textures.Add(texture.FileName);
                    }
                }
            }

            lblProgress.Text = "✓";
            lblProgress.ForeColor = Color.Green;
            lblInfo.Text = "Textures";
            pbProgress.Value = progressMax;

            Application.DoEvents();

            lblInfo = lblInfoMaterials;
            lblProgress = lblProgressMaterials;
            lblProgress.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            progressMax = 60;

            foreach (Material material in SceneManager.Current.Materials)
            {
                string fileName = Path.Combine(txtPath.Text, $"{material.Name}.mt2");

                if (material.SupportingDocuments.ContainsKey("Source"))
                {
                    (material.SupportingDocuments["Source"] as MT2).Save(fileName);
                }
                else
                {
                    if (!File.Exists(fileName) && material.Textures.Count > 0)
                    {
                        simple_base simple = new simple_base
                        {
                            DiffuseColour = material.Texture.Name
                        };

                        simple.Save(fileName);
                    }
                }
            }

            lblProgress.Text = "✓";
            lblProgress.ForeColor = Color.Green;
            lblInfo.Text = "Materials";
            pbProgress.Value = progressMax;

            Application.DoEvents();

            lblInfo = lblInfoPaperwork;
            lblProgress = lblProgressPaperwork;
            lblProgress.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            progressMax = 75;

            if (!File.Exists(Path.Combine(txtPath.Text, "setup.lol")))
            {
                Setup setup;

                if (!SceneManager.Current.Models[0].SupportingDocuments.ContainsKey("Setup"))
                {
                    setup = new Setup(SetupContext.Vehicle);

                    setup.Settings.SetParameterForMethod("PowerMultiplier", "Value", 1.35f);
                    setup.Settings.SetParameterForMethod("TractionFactor", "Factor", 1.2f);
                    setup.Settings.SetParameterForMethod("FinalDrive", "Factor", 0.8f);
                    setup.Settings.SetParameterForMethod("RearGrip", "Value", 1.68f);
                    setup.Settings.SetParameterForMethod("FrontGrip", "Value", 1.85f);
                    setup.Settings.SetParameterForMethod("CMPosY", "Value", 0.4f);
                    setup.Settings.SetParameterForMethod("FrontRoll", "Value", 0.45f);
                    setup.Settings.SetParameterForMethod("RearRoll", "Value", 0.4f);
                    setup.Settings.SetParameterForMethod("FrontSuspGive", "Value", 0.0667f);
                    setup.Settings.SetParameterForMethod("RearSuspGive", "Value", 0.0667f);
                    setup.Settings.SetParameterForMethod("SteerCentreMultiplier", "Value", 2);
                    setup.Settings.SetParameterForMethod("BrakeForce", "Value", 75);
                    setup.Settings.SetParameterForMethod("HandBrakeStrength", "Value", 20);
                    setup.Settings.SetParameterForMethod("DragCoefficient", "Value", 0.2f);
                    setup.Settings.SetParameterForMethod("Mass", "Value", 1300);
                    setup.Settings.SetParameterForMethod("TorqueCurve", "1", 160);
                    setup.Settings.SetParameterForMethod("TorqueCurve", "2", 232);
                    setup.Settings.SetParameterForMethod("TorqueCurve", "3", 280);
                    setup.Settings.SetParameterForMethod("TorqueCurve", "4", 312);
                    setup.Settings.SetParameterForMethod("TorqueCurve", "5", 280);
                }
                else
                {
                    setup = SceneManager.Current.Models[0].GetSupportingDocument<Setup>("Setup");
                }

                SceneManager.Current.Models[0].SupportingDocuments["Setup"] = setup;

                SetupLOLExporter sx = new SetupLOLExporter();
                sx.ExportSettings.AddSetting("Context", SetupContext.Vehicle);
                sx.Export(SceneManager.Current.Models[0], txtPath.Text);
            }

            if (!File.Exists(Path.Combine(txtPath.Text, "Structure.xml")))
            {
                new StructureXMLExporter().Export(SceneManager.Current.Models[0], txtPath.Text);
            }

            if (!File.Exists(Path.Combine(txtPath.Text, "SystemsDamage.xml")))
            {
                new SystemsDamageXMLExporter().Export(SceneManager.Current.Models[0], txtPath.Text);
            }

            if (!File.Exists(Path.Combine(txtPath.Text, "vehicle_setup.cfg")))
            {
                VehicleSetupCFGExporter cfgx = new VehicleSetupCFGExporter();
                cfgx.ExportSettings.AddSetting("VehicleName", txtCarName.Text);
                cfgx.Export(SceneManager.Current.Models[0], txtPath.Text);
            }

            if (!File.Exists(Path.Combine(txtPath.Text, "vehicle_setup.lol")))
            {
                new VehicleSetupLOLExporter().Export(SceneManager.Current.Models[0], txtPath.Text);
            }

            if (SceneManager.Current.Models[0].SupportingDocuments.ContainsKey("VFXAnchors"))
            {
                SceneManager.Current.Models[0].GetSupportingDocument<VFXAnchors>("VFXAnchors").Save(txtPath.Text);
            }

            if (SceneManager.Current.Models[0].SupportingDocuments.ContainsKey("Collision"))
            {
                new CNTExporter().Export(SceneManager.Current.Models[0].GetSupportingDocument<Model>("Collision"), Path.Combine(txtPath.Text, "collision.cnt"));
                new MDLExporter().Export(SceneManager.Current.Models[0].GetSupportingDocument<Model>("Collision"), txtPath.Text);
            }

            if (SceneManager.Current.Models[0].SupportingDocuments.ContainsKey("OpponentCollision"))
            {
                new CNTExporter().Export(SceneManager.Current.Models[0].GetSupportingDocument<Model>("OpponentCollision"), Path.Combine(txtPath.Text, "opponent_collision.cnt"));
                new MDLExporter().Export(SceneManager.Current.Models[0].GetSupportingDocument<Model>("OpponentCollision"), txtPath.Text);
            }

            lblProgress.Text = "✓";
            lblProgress.ForeColor = Color.Green;
            lblInfo.Text = "Paperwork";
            pbProgress.Value = progressMax;

            Application.DoEvents();

            lblInfo = lblInfoZAD;
            lblProgress = lblProgressZAD;
            lblProgress.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            progressMax = 100;

            MINGE minge = new MINGE
            {
                Name = txtPrettyCarName.Text,
                //Author = Properties.Settings.Default.PersonalAuthor,
                //Website = Properties.Settings.Default.PersonalWebsite,
                Type = MINGE.ModType.Vehicle
            };

            minge.Save(Path.Combine(txtPath.Text, $"{txtCarName.Text}.minge"));

            ZAD zad = ZAD.Create(Path.Combine(txtPath.Text, $"{txtCarName.Text}.zip"));
            zad.AddDirectory(Path.GetDirectoryName(txtPath.Text));

            lblProgress.Text = "✓";
            lblProgress.ForeColor = Color.Green;
            lblInfo.Text = "CarMODgeddon ZIP file";
            pbProgress.Value = progressMax;

            flump.Save(Path.Combine(txtPath.Text, "car.flump"));

            timer.Stop();
            SceneManager.Current.OnProgress -= scene_OnProgress;

            btnClose.Visible = true;

            Application.DoEvents();

            SceneManager.Current.UpdateProgress($"Vehicle '{car}' saved successfully!");
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (lblProgress != null && lblProgress.Text != "✓")
            {
                int frame = (lblProgress.Tag == null ? 0 : int.Parse(lblProgress.Tag.ToString()));

                lblProgress.Text = frames[frame++];

                if (frame == 4) { frame = 0; }

                lblProgress.Tag = frame;
            }

            if (pbProgress.Value < progressMax) { pbProgress.Value += Math.Max(1, (int)((progressMax - pbProgress.Value) * 0.01f)); }
        }

        void scene_OnProgress(object sender, ProgressEventArgs e)
        {
            if (lblInfo != null) { lblInfo.Text = e.Status; }
        }
    }
}