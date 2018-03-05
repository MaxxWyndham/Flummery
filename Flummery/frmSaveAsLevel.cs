using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Flummery.ContentPipeline.NuCarma;

using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.CarmageddonReincarnation.Formats.Materials;
using ToxicRagers.Stainless.Formats;

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
                txtPath.Text = fbdBrowse.SelectedPath;

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

            flump = FlumpFile.Load(Path.Combine(txtPath.Text, "level.flump"));
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

            (new CNTExporter()).Export(SceneManager.Current.Models[0], Path.Combine(txtPath.Text, "level.cnt"));
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

            List<string> textures = new List<string>();

            foreach (Material material in SceneManager.Current.Materials)
            {
                string fileName = Path.Combine(txtPath.Text, "NON_VT", material.Texture.Name);

                if (!textures.Contains(material.Texture.Name))
                {
                    if (!File.Exists($"{fileName}.tdx"))
                    {
                        TDXExporter tx = new TDXExporter();
                        tx.ExportSettings.AddSetting("Format", ToxicRagers.Helpers.D3DFormat.DXT5);
                        tx.Export(material.Texture, Path.Combine(txtPath.Text, "NON_VT"));
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

            foreach (Material material in SceneManager.Current.Materials)
            {
                string fileName = Path.Combine(txtPath.Text, $"{material.Name}.mt2");

                if (!File.Exists(fileName))
                {
                    simple_base simple = new simple_base
                    {
                        DiffuseColour = material.Texture.Name,
                        Walkable = Troolean.True
                    };

                    simple.Save(fileName);
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
                w.WriteLine($@"txt[""fe_environment_{txtLevel.Text.ToLower()}""] = ""{txtPrettyLevelName.Text}""");
                w.WriteLine($"name = txt.fe_environment_{txtLevel.Text.ToLower()}");
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
                w.WriteLine($"race\\{level}_01");
                w.WriteLine();
                w.WriteLine("[RACE_BACKGROUNDS]");
                w.WriteLine($"race\\{level}_01");
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
                            Entity entity = SceneManager.Current.Entities[i];
                            StreamWriter w = (entity.EntityType == EntityType.Accessory || entity.EntityType == EntityType.Grid ? wacc : wpup);

                            w.WriteLine($"\t{(entity.UniqueIdentifier ?? $"entity{i.ToString("0000")}")} = {{");
                            w.WriteLine($"\t\ttype = \"{entity.Name}\",");
                            if (entity.EntityType == EntityType.Powerup) { w.WriteLine($"\t\tname = \"{entity.Tag}\","); }
                            w.WriteLine("\t\tlayer = \"race01\",");
                            w.WriteLine("\t\ttransform = {");
                            w.WriteLine($"\t\t\t{{{entity.Transform.M11},{entity.Transform.M21},{entity.Transform.M31}}},");
                            w.WriteLine($"\t\t\t{{{entity.Transform.M12},{entity.Transform.M22},{entity.Transform.M32}}},");
                            w.WriteLine($"\t\t\t{{{entity.Transform.M13},{entity.Transform.M23},{entity.Transform.M33}}},");
                            w.WriteLine($"\t\t\t{{{entity.Transform.M41},{entity.Transform.M42},{entity.Transform.M43}}},");
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
                w.WriteLine($"view:loadPostFX(\"post_process.{txtLevel.Text.ToLower().Replace(" ", "_")}\")");
                //w.WriteLine("view:loadShProbes(\"Reprocessor\")");
                w.WriteLine(@"
                    if view.setBigShadowMapAutoFitEnabled ~= nil then
                      view:setBigShadowMapAutoFitEnabled(false)
                      view:setBigShadowMapResolution(2048, 2048)
                      view:setUseBigShadowMapBeyondShadowEnd(true)
                    end
                    view.VehicleAmbientShadowStrength = {
                      1,
                      1,
                      1
                    }
                    view.DynamicCubeMapClippingPlanes = {0.1, 120}
                    view.ClippingPlanes = {0.3, 700}
                    view.Ambient = {
                      28,
                      22,
                      16
                    }
                    view.SphericalHarmonicsScale = 0.25
                    view.FogEnabled = true
                    view.FogColour = {
                      120,
                      130,
                      150
                    }
                    view.FogStart = 0
                    view.FogEnd = 900
                    view.FogAlphaStart = 0
                    view.FogAlphaEnd = 0
                    view.UnderwaterAmbient = {
                      51,
                      102,
                      204
                    }
                    view.UnderwaterFogEnabled = true
                    view.UnderwaterFogColour = {
                      32,
                      96,
                      128
                    }
                    view.UnderwaterFogStart = 0
                    view.UnderwaterFogEnd = 120
                    view.UnderwaterFogAlphaStart = 0
                    view.UnderwaterFogAlphaEnd = 0
                    view.AOSampleOffset = 0.5
                    view.AOBlur = true
                    view.AOBilateralSensitivity = 8
                    view.AOBias = 0.01
                    view.AOScale = 0.5
                    view.AOPowerExponent = 6
                    view.ShadowBias = 0.0001
                    view.ShadowSlopeBias = 2
                    view.NumShadowMaps = 4
                    view.ShadowMapPoolStats = ""1:1024:1024:8""
                    view.ShadowSplitResolution = { 1024, 1024}
                    view.ShadowSplitManualUse = false
                    view.ShadowSplitDistribution = 0.8
                    view.ShadowEnd = 160
                    view.SunPos = {
                      0,
                      3536,
                      -3536
                    }
                    track:setSubstanceTyreParticles(""ROAD_TARMAC"", ""Effect"", ""w_kick_dusty_dirt_track"")
                    track:setSubstanceTyreParticles(""RACE_TARMAC"", ""Effect"", ""w_kick_dusty_dirt_track"")
                    track:setSplashColour("""", 255, 255, 255, 255)
                ");
            }

            if (!File.Exists(Path.Combine(txtPath.Text, "sun.light")))
            {
                LIGHT sun = new LIGHT
                {
                    Type = LIGHT.LightType.Directional,
                    Range = 100,
                    Inner = 22.5f,
                    Outer = 45,
                    R = 234 / 255.0f,
                    G = 202 / 255.0f,
                    B = 149 / 255.0f,
                    Intensity = 1.0f,
                    Flags = LIGHT.LightFlags.CastShadow | LIGHT.LightFlags.Unknown8,
                    SplitCount = 4,
                    SplitDistribution = 0.8f,
                    ShadowResolutionX = 1024,
                    ShadowResolutionY = 1024,
                    ShadowIntensity = 1,
                    GoboScaleX = 1,
                    GoboScaleY = 1,
                    ShadowBias = 0.00001f,
                    LightNearClip = 1,
                    ShadowDistance = 160,
                    UseEdgeColour = true,
                    EdgeColourR = 121,
                    EdgeColourG = 121,
                    EdgeColourB = 121
                };

                sun.Save(Path.Combine(txtPath.Text, "sun.light"));
            }

            if (!File.Exists(Path.Combine(txtPath.Text, "sun.cnt")))
            {
                CNT cnt = new CNT
                {
                    Name = "sun",
                    Transform = ToxicRagers.Helpers.Matrix3D.CreateRotationZ(-119.520f) *
                                ToxicRagers.Helpers.Matrix3D.CreateRotationY(46.042f) *
                                ToxicRagers.Helpers.Matrix3D.CreateRotationX(112.176f),
                    Section = CNT.NodeType.LITg,
                    EmbeddedLight = false,
                    LightName = "sun"
                };

                cnt.Save(Path.Combine(txtPath.Text, "sun.cnt"));
            }

            if (!Directory.Exists(Path.Combine(txtPath.Text, "post_process")))
            {
                Directory.CreateDirectory(Path.Combine(txtPath.Text, "post_process"));
            }

            if (!File.Exists(Path.Combine(txtPath.Text, "post_process", $"{txtLevel.Text.ToLower().Replace(" ", "_")}.lol")))
            {
                PostFX postFX = new PostFX();
                postFX.Save(Path.Combine(txtPath.Text, "post_process", $"{txtLevel.Text.ToLower().Replace(" ", "_")}.lol"));
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
                Name = txtPrettyLevelName.Text,
                Author = Properties.Settings.Default.PersonalAuthor,
                Website = Properties.Settings.Default.PersonalWebsite,
                Type = MINGE.ModType.Level
            };

            minge.Save(Path.Combine(txtPath.Text, $"{txtLevel.Text}.minge"));

            ZAD zad = ZAD.Create(Path.Combine(txtPath.Text, $"{txtLevel.Text}.zip"));
            zad.AddDirectory(Path.GetDirectoryName(txtPath.Text));

            lblProgress.Text = "✓";
            lblProgress.ForeColor = Color.Green;
            lblInfo.Text = "CarMODgeddon ZIP file";
            pbProgress.Value = progressMax;

            flump.Save(Path.Combine(txtPath.Text, "level.flump"));

            timer.Stop();
            SceneManager.Current.OnProgress -= scene_OnProgress;

            btnClose.Visible = true;

            Application.DoEvents();

            SceneManager.Current.UpdateProgress($"Level '{level}' saved successfully!");
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