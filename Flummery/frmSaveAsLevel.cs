using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Flummery.ContentPipeline.Stainless;

using ToxicRagers.CarmageddonReincarnation.Formats;

using OpenTK;

namespace Flummery
{
    public partial class frmSaveAsLevel : Form
    {
        FlumpFile flump;
        string level;

        Label lblInfo = null;
        Label lblProgress = null;
        System.Timers.Timer timer = new System.Timers.Timer(200);
        string[] frames = new string[] { "◐", "◓", "◑", "◒" };
        int progressMax = 0;

        public frmSaveAsLevel()
        {
            InitializeComponent();

            timer.AutoReset = true;
            timer.SynchronizingObject = this;
            timer.Elapsed += timer_Elapsed;

            txtPath.Text = (Directory.Exists(Properties.Settings.Default.SaveAsLevelPath) ? Properties.Settings.Default.SaveAsLevelPath : "");
            setLevel();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            fbdBrowse.SelectedPath = txtPath.Text;

            if (fbdBrowse.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(fbdBrowse.SelectedPath)) { Directory.CreateDirectory(fbdBrowse.SelectedPath); }
                txtPath.Text = fbdBrowse.SelectedPath + "\\";

                setLevel();

                Properties.Settings.Default.SaveAsLevelPath = txtPath.Text;
                Properties.Settings.Default.Save();
            }
        }

        void setLevel()
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

            flump = FlumpFile.Load(txtPath.Text + "level.flump");
            txtPrettyLevelName.Text = (flump.Settings.ContainsKey("level.pretty.name") ? flump.Settings["level.pretty.name"] : "");
            txtRaceName.Text = (flump.Settings.ContainsKey("level.race.name") ? flump.Settings["level.race.name"] : "");

            level = Path.GetFileName(Path.GetDirectoryName(txtPath.Text));
            txtLevel.Text = level;
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

            flump.Settings["level"] = level;
            flump.Settings["level.pretty.name"] = txtPrettyLevelName.Text;
            flump.Settings["level.race.name"] = txtRaceName.Text;

            lblInfo = lblInfoMeshes;
            lblProgress = lblProgressMeshes;
            lblProgress.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            progressMax = 30;

            (new CNTExporter()).Export(SceneManager.Current.Models[0], txtPath.Text + "level.cnt");
            (new MDLExporter()).Export(SceneManager.Current.Models[0], txtPath.Text);

            lblProgress.Text = "✓";
            lblProgress.ForeColor = Color.Green;
            lblInfo.Text = "Meshes";
            pbProgress.Value = progressMax;

            Application.DoEvents();

            lblInfo = lblInfoTextures;
            lblProgress = lblProgressTextures;
            lblProgress.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            progressMax = 50;

            var textures = new List<string>();

            foreach (var material in SceneManager.Current.Materials)
            {
                string fileName = txtPath.Text + "\\" + material.Texture.Name;

                if (!textures.Contains(material.Texture.Name))
                {
                    if (!File.Exists(fileName + ".tdx"))
                    {
                        var tx = new TDXExporter();
                        tx.ExportSettings.AddSetting("Format", ToxicRagers.Helpers.D3DFormat.DXT5);
                        tx.Export(material.Texture, txtPath.Text);
                    }

                    if (!File.Exists(fileName + ".img"))
                    {
                        var tx = new IMGExporter();
                        tx.Export(material.Texture, txtPath.Text);
                    }

                    textures.Add(material.Texture.Name);
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

            foreach (var material in SceneManager.Current.Materials)
            {
                string fileName = txtPath.Text + "\\" + material.Name + ".mt2";

                if (!File.Exists(fileName))
                {
                    using (StreamWriter w = File.CreateText(txtPath.Text + "\\" + material.Name + ".mt2"))
                    {
                        w.WriteLine("<?xml version=\"1.0\"?>");
                        w.WriteLine("<Material>");
                        w.WriteLine("\t<BasedOffOf Name=\"simple_base\"/>");
                        w.WriteLine("\t<Walkable Value=\"TRUE\" />");
                        w.WriteLine("\t<Pass Number=\"0\">");
                        w.WriteLine("\t\t<Texture Alias=\"DiffuseColour\" FileName=\"" + material.Texture.Name.Replace("&", "&amp;") + "\"/>");
                        w.WriteLine("\t</Pass>");
                        w.WriteLine("</Material>");
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

            using (StreamWriter w = File.CreateText(Path.Combine(txtPath.Text, "audio.lol")))
            {
                w.WriteLine("audio:load(\"audio.sounds_peds_impact\")");
                w.WriteLine("audio:load(\"audio.sounds_impacts\")");
                w.WriteLine("audio:load(\"audio.sounds_misc\")");
                w.WriteLine("audio:load(\"audio.sounds_announcer\")");
                w.WriteLine("audio:load(\"audio.sounds_powerups\")");
                w.WriteLine("audio:load(\"audio.sounds_vehicles\")");
            }

            using (StreamWriter w = File.CreateText(Path.Combine(txtPath.Text, "environment.lol")))
            {
                w.WriteLine("module((...), environment_config, package.seeall)");
                w.WriteLine(string.Format(@"txt[""fe_environment_{0}""] = ""{1}""", txtLevel.Text.ToLower(), txtPrettyLevelName.Text));
                w.WriteLine(string.Format("name = txt.fe_environment_{0}", txtLevel.Text.ToLower()));
            }

            using (StreamWriter w = File.CreateText(Path.Combine(txtPath.Text, "environment.txt")))
            {
                w.WriteLine("[LUMP]");
                w.WriteLine("environment");
            }

            using (StreamWriter w = File.CreateText(Path.Combine(txtPath.Text, "level.txt")))
            {
                w.WriteLine("[LUMP]");
                w.WriteLine("level");
                w.WriteLine();
                w.WriteLine("[ENVIRONMENT]");
                w.WriteLine(txtLevel.Text.ToLower().Replace(" ", "_"));
                w.WriteLine();
                w.WriteLine("[RACE_NAMES]");
                w.WriteLine(txtRaceName.Text);
                w.WriteLine();
                w.WriteLine("[RACE_WRITEUP]");
                w.WriteLine("Pretty sure this doesn't show up in the UI anymore");
                w.WriteLine();
                w.WriteLine("[RACE_IMAGES]");
                w.WriteLine("race\\" + level + "_01");
                w.WriteLine();
                w.WriteLine("[RACE_BACKGROUNDS]");
                w.WriteLine("race\\" + level + "_01");
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

            if (SceneManager.Current.Entities.Count > 0)
            {
                using (StreamWriter wpup = File.CreateText(Path.Combine(txtPath.Text, "powerups.lol")))
                {
                    using (StreamWriter wacc = File.CreateText(Path.Combine(txtPath.Text, "level.lol")))
                    {
                        wpup.WriteLine("module((...), level_powerup_setup)");
                        wpup.WriteLine("accessories = {");

                        wacc.WriteLine("module((...), level_accessory_setup)");
                        wacc.WriteLine("accessories = {");

                        for (int i = 0; i < SceneManager.Current.Entities.Count; i++)
                        {
                            var entity = SceneManager.Current.Entities[i];
                            var w = (entity.EntityType == EntityType.Accessory ? wacc : wpup);

                            w.WriteLine("\t" + (entity.UniqueIdentifier != null ? entity.UniqueIdentifier : "entity" + i.ToString("0000")) + " = {");
                            w.WriteLine("\t\ttype = \"" + entity.Name + "\",");
                            if (entity.EntityType == EntityType.Powerup) { w.WriteLine("\t\tname = \"" + entity.Tag + "\","); }
                            w.WriteLine("\t\tlayer = \"race01\",");
                            w.WriteLine("\t\ttransform = {");
                            w.WriteLine("\t\t\t{" + entity.Transform.M11 + "," + entity.Transform.M21 + "," + entity.Transform.M31 + "},");
                            w.WriteLine("\t\t\t{" + entity.Transform.M12 + "," + entity.Transform.M22 + "," + entity.Transform.M32 + "},");
                            w.WriteLine("\t\t\t{" + entity.Transform.M13 + "," + entity.Transform.M23 + "," + entity.Transform.M33 + "},");
                            w.WriteLine("\t\t\t{" + entity.Transform.M41 + "," + entity.Transform.M42 + "," + entity.Transform.M43 + "}");
                            w.WriteLine("\t\t},");
                            w.WriteLine("\t\tcolour = { 255, 255, 255 }");
                            w.Write("\t}");
                            w.WriteLine((i + 1 < SceneManager.Current.Entities.Count ? "," : ""));
                        }

                        wacc.WriteLine("}");
                        wpup.WriteLine("}");
                    }
                }
            }

            using (StreamWriter w = File.CreateText(Path.Combine(txtPath.Text, "minimap_definition.lol")))
            {
                w.WriteLine("module((...), minimap_definition)");
                w.WriteLine("bounds = {");
                w.WriteLine("  min_bound = {-640, -270},");
                w.WriteLine("  max_bound = {640, 450}");
                w.WriteLine("}");
                w.WriteLine("minimap_area = 200");
                w.WriteLine("max_minimap_area = 400");
                w.WriteLine("speed_for_max_minimap_area = 60");
            }

            using (StreamWriter w = File.CreateText(Path.Combine(txtPath.Text, "setup.lol")))
            {
                w.WriteLine("view:loadSky(\"sky\")");
                w.WriteLine("view:loadLight(\"sun\")");
                w.WriteLine("view:loadPostFX(\"post_process." + txtLevel.Text.ToLower().Replace(" ", "_") + "\")");
                //w.WriteLine("view:loadShProbes(\"Reprocessor\")");
                w.WriteLine("if view.setBigShadowMapAutoFitEnabled ~= nil then");
                w.WriteLine("  view:setBigShadowMapAutoFitEnabled(false)");
                w.WriteLine("  view:setBigShadowMapResolution(2048, 2048)");
                w.WriteLine("  view:setUseBigShadowMapBeyondShadowEnd(true)");
                w.WriteLine("end");
                w.WriteLine("view:setVehicleAmbientShadowStrength(0.6, 0.6, 0.6)");
                w.WriteLine("view:setDynamicCubeMapClippingPlanes(0.1, 60)");
                w.WriteLine("view:setClippingPlanes(0.3, 1300)");
                w.WriteLine("view:setAmbient(100, 70, 50)");
                w.WriteLine("view:setSphericalHarmonicsScale(1)");
                w.WriteLine("view:setFogEnabled(true)");
                w.WriteLine("view:setFogColour(240, 240, 300)");
                w.WriteLine("view:setFogStart(0)");
                w.WriteLine("view:setFogEnd(500)");
                w.WriteLine("view:setFogAlphaStart(0)");
                w.WriteLine("view:setFogAlphaEnd(200)");
                w.WriteLine("view:setUnderwaterAmbient(50, 60, 60)");
                w.WriteLine("view:setUnderwaterFogEnabled(true)");
                w.WriteLine("view:setUnderwaterFogColour(80, 90, 120)");
                w.WriteLine("view:setUnderwaterFogStart(0)");
                w.WriteLine("view:setUnderwaterFogEnd(16)");
                w.WriteLine("view:setUnderwaterFogAlphaStart(0)");
                w.WriteLine("view:setUnderwaterFogAlphaEnd(200)");
                w.WriteLine("view:setAOSampleOffset(1)");
                w.WriteLine("view:setAOBlur(true)");
                w.WriteLine("view:setAOBilateralSensitivity(100)");
                w.WriteLine("view:setAOBias(0.5)");
                w.WriteLine("view:setAOPowerExponent(2)");
                w.WriteLine("view:setShadowBias(1E-06)");
                w.WriteLine("view:setShadowSlopeBias(2)");
                w.WriteLine("view:setShadowMapCount(4)");
                w.WriteLine("view:setShadowMapPoolStats(\"1:1024:1024:8\")");
                w.WriteLine("view:setShadowMapPoolAllocateBestAvailable(false)");
                w.WriteLine("view:setShadowSplitResolution(1024, 1024)");
                w.WriteLine("view:setShadowSplitManualUse(false)");
                w.WriteLine("view:setShadowSplitDistribution(0.8)");
                w.WriteLine("view:setShadowEnd(200)");
                w.WriteLine("track:setSplashColour(\"\", 255, 255, 255, 102)");
            }

            if (!File.Exists(Path.Combine(txtPath.Text, "sun.light")))
            {
                var sun = new ToxicRagers.CarmageddonReincarnation.Formats.LIGHT();

                sun.Type = LIGHT.LightType.Directional;
                sun.Range = 100;
                sun.Inner = 22.5f;
                sun.Outer = 45;
                sun.R = 234 / 255.0f;
                sun.G = 202 / 255.0f;
                sun.B = 149 / 255.0f;
                sun.Intensity = 1.0f;
                sun.Flags = LIGHT.LightFlags.CastShadow;
                sun.SplitCount = 4;
                sun.SplitDistribution = 0.8f;
                sun.ShadowResolutionX = 1024;
                sun.ShadowResolutionY = 1024;
                sun.ShadowIntensity = 1;
                sun.GoboScaleX = 1;
                sun.GoboScaleY = 1;
                sun.ShadowBias = 0.00001f;
                sun.LightNearClip = 1;
                sun.ShadowDistance = 160;
                sun.UseEdgeColour = true;
                sun.EdgeColourR = 121;
                sun.EdgeColourG = 121;
                sun.EdgeColourB = 121;

                sun.Save(Path.Combine(txtPath.Text, "sun.light"));
            }

            if (!File.Exists(Path.Combine(txtPath.Text, "sun.cnt")))
            {
                var cnt = new ToxicRagers.Stainless.Formats.CNT();

                cnt.Name = "sun";
                cnt.Transform = ToxicRagers.Helpers.Matrix3D.CreateRotationZ(-119.520f) *
                                ToxicRagers.Helpers.Matrix3D.CreateRotationY(  46.042f) *
                                ToxicRagers.Helpers.Matrix3D.CreateRotationX( 112.176f);
                cnt.Section = ToxicRagers.Stainless.Formats.CNT.NodeType.LITg;
                cnt.EmbeddedLight = false;
                cnt.LightName = "sun";

                cnt.Save(Path.Combine(txtPath.Text, "sun.cnt"));
            }

            if (!Directory.Exists(Path.Combine(txtPath.Text, "post_process")))
            {
                Directory.CreateDirectory(Path.Combine(txtPath.Text, "post_process"));
            }

            if (!File.Exists(Path.Combine(txtPath.Text, "post_process", txtLevel.Text.ToLower().Replace(" ", "_") + ".lol")))
            {
                var postFX = new ToxicRagers.CarmageddonReincarnation.Formats.PostFX();
                postFX.Save(Path.Combine(txtPath.Text, "post_process", txtLevel.Text.ToLower().Replace(" ", "_") + ".lol"));
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

            var minge = new ToxicRagers.CarmageddonReincarnation.Formats.MINGE();
            minge.Name = txtPrettyLevelName.Text;
            minge.Author = Properties.Settings.Default.PersonalAuthor;
            minge.Website = Properties.Settings.Default.PersonalWebsite;
            minge.Type = MINGE.ModType.Level;
            minge.Save(Path.Combine(txtPath.Text, txtLevel.Text + ".minge"));

            var zad = ToxicRagers.Stainless.Formats.ZAD.Create(Path.Combine(txtPath.Text, txtLevel.Text + ".zad"));
            zad.AddDirectory(Path.GetDirectoryName(txtPath.Text));

            lblProgress.Text = "✓";
            lblProgress.ForeColor = Color.Green;
            lblInfo.Text = "CarMODgeddon ZAD file";
            pbProgress.Value = progressMax;

            flump.Save(txtPath.Text + "level.flump");

            timer.Stop();
            SceneManager.Current.OnProgress -= scene_OnProgress;

            btnClose.Visible = true;

            Application.DoEvents();

            SceneManager.Current.UpdateProgress(string.Format("Level '{0}' saved successfully!", level));
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
