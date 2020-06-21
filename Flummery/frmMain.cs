using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Flummery.ContentPipeline.Core;
using Flummery.ContentPipeline.CarmaClassic;
using Flummery.ContentPipeline.NuCarma;
using Flummery.Plugin;
using Flummery.Util;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using ToxicRagers.Carmageddon2.Formats;
using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.CarmageddonReincarnation.Helpers;

using WeifenLuo.WinFormsUI.Docking;
using ToxicRagers.Stainless.Formats;

namespace Flummery
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public DockPanel DockPanel => dockPanel;
        public PluginHandler pluginHandler = new PluginHandler();

        private void frmMain_Load(object sender, EventArgs e)
        {
            CultureInfo.DefaultThreadCurrentCulture = FlummeryApplication.Culture;
            CultureInfo.DefaultThreadCurrentUICulture = FlummeryApplication.Culture;

            Toolkit.Init();

            Text += " v" + FlummeryApplication.Version;

            InputManager inputManager = new InputManager();

            pnlOverview overview = new pnlOverview();
            PnlViewport viewport = new PnlViewport();
            pnlMaterialList materials = new pnlMaterialList();
            PnlDetails details = new PnlDetails();

            pluginHandler.InitialiseModules();

            viewport.Show(dockPanel, DockState.Document);
            materials.Show(dockPanel, DockState.DockBottom);
            overview.Show(dockPanel, DockState.DockLeft);
            details.Show(dockPanel, DockState.DockRight);

            List<string> extensions = new List<string>(GL.GetString(StringName.Extensions).Split(' '));
            SceneManager.Create(extensions.Contains("GL_ARB_vertex_buffer_object"));

            dockPanel.DockLeftPortion = 300;
            dockPanel.DockRightPortion = 315;
            dockPanel.DockBottomPortion = 105;

            viewport.RegisterEventHandlers();
            overview.RegisterEventHandlers();
            materials.RegisterEventHandlers();
            details.RegisterEventHandlers();

            ToxicRagers.Helpers.Logger.ResetLog();

            SetActionScalingText("Action Scaling: 1.000");

            KeyPreview = true;
            KeyPress += new KeyPressEventHandler(frmMain_KeyPress);

            SceneManager.Current.OnProgress += scene_OnProgress;
            SceneManager.Current.OnError += scene_OnError;
            SceneManager.Current.SetCoordinateSystem(SceneManager.CoordinateSystem.LeftHanded);

            //SceneManager.Current.SetContext(ContextGame.CarmageddonReincarnation, ContextMode.Car);

            foreach (Lazy<IMenu, IPluginAttribute> menu in pluginHandler.Menus)
            {
                if (menu.Value.PluginMenu == null) { continue; }

                this.menu.Items.Add(menu.Value.PluginMenu);
            }

            FlummeryApplication.UI = this;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CheckForUpdates)
            {
                void finishRequest(bool result, Updater.Update[] updates)
                {
                    if (result == true && updates.Count() > 0)
                    {
                        frmUpdater updateForm = new frmUpdater() { Updates = updates };
                        updateForm.ShowDialog();
                    }
                }

                new Updater().Check(FlummeryApplication.Version, finishRequest);
            }

            //(new frmMaterialEditor()).Show();

            //(VFXAnchors.Load(@"H:\Carmageddon\MaxDamage\Vehicles\default_vfx_anchors.lol")).Save(@"H:\");

            //Map.Load(@"H:\Backups\D\Carmageddon Installations\Carmageddon 2 - 2009 dickery\data\RACES\timber1\timber1.txt");

            //ToxicRagers.Helpers.IO.LoopDirectoriesIn(@"H:\Carmageddon\MaxDamage\Peds\", (d) =>
            //{
            //    foreach (FileInfo fi in d.GetFiles("*.lol"))
            //    {
            //        LOL lol = LOL.Load(fi.FullName);
            //        File.WriteAllText(fi.FullName, lol.Document);

            //        Application.DoEvents();
            //    }
            //}
            //);

            //foreach (string folder in Directory.GetDirectories(@"H:\Carmageddon\MaxDamage\Vehicles\"))
            //{
            //    foreach (string file in Directory.GetFiles(folder))
            //    {
            //        if (string.Compare(Path.GetExtension(file), ".lol") == 0)
            //        {
            //            LOL lol = LOL.Load(file);

            //            File.WriteAllText(file, lol.Document);
            //        }
            //    }
            //}

            //Model m = new Model();
            //m.AddMesh(new Sphere(0.5f, 25, 25));
            //SceneManager.Current.Models.Add(m);

            //SceneManager.Current.Change(ChangeType.Munge, -1);

            //var car = new ToxicRagers.Carmageddon.Helpers.DocumentParser(@"D:\Carmageddon Installations\Carmageddon\CARMA\DATA\32X20X8\CARS\ANNIECAR.TXT");

            //TDX tdx = TDX.Load(@"E:\Carmageddon_Reincarnation\Data_Core\Content\Environments\island\Diffuse_D.tdx");

            //ToxicRagers.Stainless.Formats.ZAD zad;

            //for (int i = 0; i < 16; i++)
            //{
            //    zad = ToxicRagers.Stainless.Formats.ZAD.Load(string.Format(@"E:\Carmageddon_Reincarnation\ZAD_VT\island\Pages_{0:x1}.zad", i));
            //    foreach (var entry in zad.Contents.OrderBy(ex => ex.Offset))
            //    {
            //        zad.Extract(entry, string.Format(@"E:\island\{0:x1}\", i));
            //    }

            //    zad = ToxicRagers.Stainless.Formats.ZAD.Create(string.Format(@"E:\island\Pages_{0:x1}.zad", i), ToxicRagers.Stainless.Formats.ZADType.VirtualTexture);
            //    foreach (string directory in Directory.GetDirectories(string.Format(@"E:\island\{0:x1}\", i))) { zad.AddDirectory(directory); }

            //    zad = ToxicRagers.Stainless.Formats.ZAD.Load(string.Format(@"E:\island\Pages_{0:x1}.zad", i));
            //    foreach (var entry in zad.Contents)
            //    {
            //        zad.Extract(entry, string.Format(@"E:\island\_{0:x1}\", i));
            //    }
            //}

            //ToxicRagers.Helpers.IO.LoopDirectoriesIn(@"H:\Carmageddon\MaxDamage\ZADVT\", (d) =>
            //{
            //    foreach (FileInfo fi in d.GetFiles("*.tdx"))
            //    {
            //        TDX result = TDX.Load(fi.FullName);
            //        Application.DoEvents();
            //    }
            //}
            //);

            //var wad = ToxicRagers.Stainless.Formats.WAD.Load(@"H:\Carmageddon\Carmageddon_Android_1384560647\assets\DATA_ANDROID.WAD");

            //foreach (var entry in wad.Contents)
            //{
            //    wad.Extract(entry, @"H:\Carmageddon\Carmageddon_Android_1384560647\assets\butts\");
            //}

            //foreach (var x in Directory.GetFiles(@"C:\Users\errol\Downloads\Data_IOS\DATA\CONTENT\TEXTURES", "*.tdx", SearchOption.TopDirectoryOnly)) {
            //    ToxicRagers.CarmageddoniOS.Formats.TDX.ProcessTDX(x, @"C:\Users\errol\Downloads\Data_IOS\DATA\CONTENT\TEXTURES\converted_files");
            //}

            ////ToxicRagers.Helpers.Logger.LogToFile(ToxicRagers.Helpers.Logger.LogLevel.All, "--------------------");
            //var cnt = ToxicRagers.Stainless.Formats.CNT.Load(@"C:\Users\errol\Downloads\LEVELS\CITY_A\LEVEL.CNT");
            //var stop = new Stopwatch();
            //stop.Start();
            //var mdl = ToxicRagers.Stainless.Formats.MDL.Load(@"C:\Users\errol\Downloads\LEVELS\CITY_A\MODEL0.MDL");
            //var oct = ToxicRagers.Helpers.Octree.CreateFromModel(mdl);
            //stop.Stop();
            //Console.WriteLine(stop.Elapsed.Duration().ToString());
            //oct.Save(@"f:\oct.ree");

            //var viv = ToxicRagers.NFSHotPursuit.Formats.VIV.Load(@"C:\Users\errol\Downloads\Parkland\persist.viv");

            //foreach (var entry in viv.Contents)
            //{
            //    viv.Extract(entry, @"H:\NFS\");
            //}

            //var fsh = ToxicRagers.NFSHotPursuit.Formats.FSH.Load(@"H:\NFS\track.fsh");
            //foreach (var entry in fsh.Contents)
            //{
            //    fsh.Extract(entry, @"H:\NFS\Texture\");
            //}

            //var o = ToxicRagers.NFSHotPursuit.Formats.O.Load(@"H:\NFS\trackg.o");

            //var o = ToxicRagers.TDR2000.Formats.FUNC.Load(@"D:\Carmageddon Installations\SCi\Carmageddon TDR2000\ASSETS\Cars\Blood&Bone\blood_bonesconvsoft_null\blood&BoneCamberGrip.func");

            //foreach (string car in new string[] { "2CV", "APC", "BigAPC", "Bratt", "Buster", "Charger", "Dumpster", "Eagle", "EdHunter", "Grim", "Harry", "Hawk", "Hazard", "Hotrod", "Jeep", "Junior", "Kutter", "Mini", "Otis", "Pickup", "Pitbull", "Pork", "Screwie", "Starsky", "Stella", "Tartlet", "Van", "Viper", "Vlad2", "XJ220" })
            //{
            //    ToxicRagers.CarmageddonPSX.Helpers.ProcessCar(car.ToUpper(), car, @"D:\\WIP\\ToPort\\CarmaPSX\\", @"H:\\PSX\\Cars\\");
            //}

            //ToxicRagers.PSX.Formats.TIM.Load(@"D:\\WIP\\ToPort\\CarmaPSX\\LEVELS\\DESERT\\1\\DESERT1.TIM").GetBitmap().Save(@"H:\\PSX\\DESERT1.png", System.Drawing.Imaging.ImageFormat.Png);

            //foreach (string file in Directory.GetFiles(@"D:\\WIP\\ToPort\\CarmaPSX\\HUD\\", "*.tim"))
            //{
            //    ToxicRagers.PSX.Formats.TIM.Load(file).GetBitmap().Save(Path.Combine(@"H:\\PSX", $"{Path.GetFileNameWithoutExtension(file)}.png"), System.Drawing.Imaging.ImageFormat.Png);
            //}

            //var tpc = ToxicRagers.TwistedMetal2.Formats.TPC.Load(@"C:\\Users\\errol\\Downloads\\Twisted-Metal-2_Win_EN_ISO-Version\\Twisted_Metal_2_ISO\\TH.TPC");
            //int i = 0;
            //foreach (var tim in tpc.Textures)
            //{
            //    tim.GetBitmap().Save($@"H:\\PSX\\TH{i++}.png", System.Drawing.Imaging.ImageFormat.Png);
            //}

            //ToxicRagers.PSX.Formats.TIM.Load(@"C:\\Users\\errol\\Downloads\\Twisted-Metal-2_Win_EN_ISO-Version\\Twisted_Metal_2_ISO\\THINFO.TIM").GetBitmap().Save(@"H:\\PSX\\THINFO.png", System.Drawing.Imaging.ImageFormat.Png);

            //var dpc = ToxicRagers.TwistedMetal2.Formats.DPC.Load(@"C:\\Users\\errol\\Downloads\\Twisted-Metal-2_Win_EN_ISO-Version\\Twisted_Metal_2_ISO\\TH.DPC");

            //foreach (string file in Directory.GetFiles(@"D:\Carmageddon Installations\Carmageddon 2 - 2009 dickery\data\RACES\", "*.txt", SearchOption.AllDirectories))
            //{
            //    var txt = ToxicRagers.Carmageddon2.Formats.Map.Load(file);
            //    if (txt != null) { txt.Save(Path.Combine(Path.GetDirectoryName(file), $"{Path.GetFileNameWithoutExtension(file)}.new.txt")); }
            //}

            //Application.Exit();
        }

        void scene_OnProgress(object sender, ProgressEventArgs e)
        {
            tsslProgress.Text = e.Status;
            tsslProgress.Owner.Refresh();
            Application.DoEvents();
        }

        void scene_OnError(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        void frmMain_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = InputManager.Current.HandleInput(sender, e);
        }

        private void menuClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            switch (mi.Text)
            {
                case " & New":
                    SceneManager.Current.Reset();
                    break;

                case "E&xit":
                    Application.Exit();
                    break;

                case "About Flummery":
                    (new frmAbout()).ShowDialog();
                    break;
            }
        }

        private void menuImportClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            switch (mi.Text)
            {
                case "Autodesk FBX File...":
                    ofdBrowse.Filter = "Autodesk FBX files (*.fbx)|*.fbx";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        SceneManager.Current.SetCoordinateSystem(SceneManager.CoordinateSystem.LeftHanded);
                        Model _ = SceneManager.Current.Content.Load<Model, FBXImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);

                        SceneManager.Current.UpdateProgress($"Imported {Path.GetFileName(ofdBrowse.FileName)}");
                    }
                    break;

                case "BRender ACT File...":
                    ofdBrowse.Filter = "BRender ACT files (*.act)|*.act";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        SceneManager.Current.Content.Load<Model, ACTImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);

                        SceneManager.Current.UpdateProgress(string.Format("Imported {0}", Path.GetFileName(ofdBrowse.FileName)));
                    }
                    break;

                case "BRender DAT File...":
                    ofdBrowse.Filter = "BRender DAT files (*.dat)|*.dat";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        SceneManager.Current.Content.Load<Model, DATImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);

                        SceneManager.Current.UpdateProgress(string.Format("Imported {0}", Path.GetFileName(ofdBrowse.FileName)));
                    }
                    break;

                case "Stainless CNT File...":
                    ofdBrowse.Filter = "Stainless CNT files (*.cnt)|*.cnt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        SceneManager.Current.Content.Load<Model, CNTImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);

                        SceneManager.Current.UpdateProgress(string.Format("Imported {0}", Path.GetFileName(ofdBrowse.FileName)));
                    }
                    break;

                case "Stainless MDL File...":
                    ofdBrowse.Filter = "Stainless MDL files (*.mdl)|*.mdl";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        SceneManager.Current.Content.Load<Model, MDLImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);

                        SceneManager.Current.UpdateProgress(string.Format("Imported {0}", Path.GetFileName(ofdBrowse.FileName)));
                    }
                    break;

                case "Stainless LIGHT File...":
                    ofdBrowse.Filter = "Stainless LIGHT files (*.light)|*.light";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        SceneManager.Current.Content.Load<Model, LIGHTImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);

                        SceneManager.Current.UpdateProgress(string.Format("Imported {0}", Path.GetFileName(ofdBrowse.FileName)));
                    }
                    break;

                case "Torus MSHS File...":
                    ofdBrowse.Filter = "Torus MSHS files (*.mshs)|*.mshs";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        SceneManager.Current.Content.Load<Model, ContentPipeline.TDR2000.MSHSImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);

                        SceneManager.Current.UpdateProgress(string.Format("Imported {0}", Path.GetFileName(ofdBrowse.FileName)));
                    }
                    break;
            }
        }

        private void menuExportClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            switch (mi.Text)
            {
                case "Autodesk FBX File...":
                    sfdBrowse.Filter = "Autodesk FBX files (*.fbx)|*.fbx";
                    if (sfdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        FBXExporter fx = new FBXExporter();
                        fx.ExportSettings.AddSetting("NeedsFlipping", SceneManager.Current.CoordSystem == SceneManager.CoordinateSystem.LeftHanded);
                        fx.Export(SceneManager.Current.Models[0], sfdBrowse.FileName);
                        SceneManager.Current.UpdateProgress(string.Format("Saved {0}", Path.GetFileName(sfdBrowse.FileName)));
                    }
                    break;

                case "Stainless CNT File...":
                    sfdBrowse.Filter = "Stainless CNT files (*.cnt)|*.cnt";
                    if (sfdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        CNTExporter cx = new CNTExporter();
                        cx.Export(SceneManager.Current.Models[0], sfdBrowse.FileName);
                        SceneManager.Current.UpdateProgress(string.Format("Saved {0}", Path.GetFileName(sfdBrowse.FileName)));
                    }
                    break;
            }
        }

        private void menuCarmageddonClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            SceneManager.Current.SetCoordinateSystem(SceneManager.CoordinateSystem.RightHanded);

            switch (mi.Text)
            {
                case "Actor":
                    ofdBrowse.Filter = "Carmageddon ACTOR (*.act)|*.act";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        SceneManager.Current.Content.Load<Model, ACTImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);

                        SceneManager.Current.SetContext(ContextGame.Carmageddon1, ContextMode.Generic);
                    }
                    break;

                case "Car":
                    ofdBrowse.Filter = "Carmageddon CAR (*.txt)|*.txt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        SceneManager.Current.Content.Load<Model, C1CarImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);

                        SceneManager.Current.SetContext(ContextGame.Carmageddon1, ContextMode.Car);

                        if (false && SceneManager.Current.SelectedModel.SupportingDocuments.ContainsKey("Car"))
                        {
                            var car = SceneManager.Current.SelectedModel.GetSupportingDocument<ToxicRagers.Carmageddon.Formats.Car>("Car");
                            var dat = SceneManager.Current.SelectedModel.GetSupportingDocument<DAT>("Source");

                            string rootMesh = SceneManager.Current.SelectedModel.Root.Mesh.Name;

                            HashSet<int> points = new HashSet<int>();
                            int meshIndex = dat.DatMeshes.FindIndex(dm => dm.Name == rootMesh);

                            int testVertIndex = -1;
                            bool allTheVerts = true;

                            foreach (var point in car.Crushes[1].Points)
                            {
                                var vert = dat.DatMeshes[meshIndex].Mesh.Verts[point.VertexIndex];

                                points.Add(point.VertexIndex);

                                Entity entity = new Entity
                                {
                                    EntityType = EntityType.Crush,
                                    AssetType = AssetType.Sprite,
                                    Transform = Matrix4.CreateTranslation(vert.X, vert.Y, vert.Z) * SceneManager.Current.SelectedModel.Bones[0].Transform,
                                    Lollipop = true
                                };

                                if (point.VertexIndex == testVertIndex || allTheVerts)
                                {
                                    float dX = vert.X;
                                    float dY = vert.Y;
                                    float dZ = vert.Z;

                                    float distance = (float)Math.Sqrt(dX * dX + dY * dY + dZ * dZ);

                                    //Console.WriteLine($"{point.VertexIndex}\t{vert.X}\t{vert.Y}\t{vert.Z}\t{point.LimitMin.X}\t{point.LimitMax.X}\t{point.LimitMin.Y}\t{point.LimitMax.Y}\t{point.LimitMin.Z}\t{point.LimitMax.Z}\t{point.SoftnessNeg.X}\t{point.SoftnessPos.X}\t{point.SoftnessNeg.Y}\t{point.SoftnessPos.Y}\t{point.SoftnessNeg.Z}\t{point.SoftnessPos.Z}");

                                    SceneManager.Current.Entities.Add(entity);
                                }

                                int neighbour_index = -1;

                                foreach (var neighbour in point.Neighbours)
                                {
                                    if (neighbour.VertexIndex == 0)
                                    {
                                        neighbour_index += (int)neighbour.Factor;
                                        continue;
                                    }

                                    neighbour_index += neighbour.VertexIndex;

                                    points.Add(neighbour_index);

                                    var neighVert = dat.DatMeshes[meshIndex].Mesh.Verts[neighbour_index];

                                    Entity neighbourEntity = new Entity
                                    {
                                        EntityType = EntityType.Wheel,
                                        AssetType = AssetType.Sprite,
                                        Transform = Matrix4.CreateTranslation(neighVert.X, neighVert.Y, neighVert.Z) * SceneManager.Current.SelectedModel.Bones[0].Transform,
                                        Lollipop = true
                                    };

                                    SceneManager.Current.Entities.Add(neighbourEntity);

                                    //Console.WriteLine(neighbour.Factor);
                                    //Console.WriteLine($"\tNeighbour vert {neighbour_index} ({neighbour.VertexIndex})");
                                }
                            }

                            //Console.WriteLine(string.Join(", ", points.OrderBy(p => p)));

                            for (int i = 0; i < dat.DatMeshes[meshIndex].Mesh.Verts.Count; i++)
                            {
                                if (points.Add(i))
                                {
                                    Console.WriteLine($"{i}: {dat.DatMeshes[meshIndex].Mesh.Verts[i].X}, {dat.DatMeshes[meshIndex].Mesh.Verts[i].Y}, {dat.DatMeshes[meshIndex].Mesh.Verts[i].Z}");

                                    Entity neighbourEntity = new Entity
                                    {
                                        EntityType = EntityType.Wheel,
                                        AssetType = AssetType.Sprite,
                                        Transform = Matrix4.CreateTranslation(dat.DatMeshes[meshIndex].Mesh.Verts[i].X, dat.DatMeshes[meshIndex].Mesh.Verts[i].Y, dat.DatMeshes[meshIndex].Mesh.Verts[i].Z) * SceneManager.Current.SelectedModel.Bones[0].Transform,
                                        Lollipop = true
                                    };

                                    SceneManager.Current.Entities.Add(neighbourEntity);
                                }
                            }

                            //for (int i = 0; i < dat.DatMeshes[0].Mesh.Verts.Count; i++)
                            //{
                            //    if (i == testVertIndex) { continue; }

                            //    var x = dat.DatMeshes[0].Mesh.Verts[i];
                            //    var y = dat.DatMeshes[0].Mesh.Verts[testVertIndex];

                            //    float dX = y.X - x.X;
                            //    float dY = y.Y - x.Y;
                            //    float dZ = y.Z - x.Z;

                            //    float distance = (float)Math.Sqrt(dX * dX + dY * dY + dZ * dZ);

                            //    Console.WriteLine($"{i}\t{testVertIndex}\t{distance}");
                            //}
                        }
                    }
                    break;

                case "TXT files (C1 Car)":
                    processAll(mi.Text);
                    break;
            }
        }

        private void menuCarmageddon2Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            SceneManager.Current.SetCoordinateSystem(SceneManager.CoordinateSystem.RightHanded);

            switch (mi.Text)
            {
                case "Actor":
                    ofdBrowse.Filter = "Carmageddon 2 ACTOR (*.act)|*.act";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        SceneManager.Current.Content.Load<Model, ACTImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);

                        SceneManager.Current.SetContext(ContextGame.Carmageddon2, ContextMode.Generic);
                    }
                    break;

                case "Race":
                    ofdBrowse.Filter = "Carmageddon 2 Race (*.act)|*.act";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        string txtFile = Path.Combine(Path.GetDirectoryName(ofdBrowse.FileName), Path.GetFileNameWithoutExtension(ofdBrowse.FileName) + ".txt");

                        Model race = SceneManager.Current.Content.Load<Model, ACTImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);
                        if (File.Exists(txtFile)) { race.SupportingDocuments["TXT"] = Map.Load(txtFile); }

                        SceneManager.Current.SetContext(ContextGame.Carmageddon2, ContextMode.Level);
                    }
                    break;

                case "Process Car for Carmageddon Reincarnation":
                    {
                        if (SceneManager.Current.Models.Count == 0) { return; }

                        Model model = SceneManager.Current.Models[0];
                        ModelBoneCollection bones = SceneManager.Current.Models[0].Bones[0].AllChildren();

                        SceneManager.Current.UpdateProgress("Applying Carmageddon Reincarnation scale");

                        ModelManipulator.Scale(bones, Matrix4.CreateScale(6.9f, 6.9f, -6.9f), true);
                        ModelManipulator.FlipFaces(bones, true);

                        SceneManager.Current.UpdateProgress("Fixing material names");

                        foreach (Material material in SceneManager.Current.Materials)
                        {
                            if (material.Name.Contains(".")) { material.Name = material.Name.Substring(0, material.Name.IndexOf(".")); }
                            material.Name = material.Name.Replace("\\", "");
                        }

                        SceneManager.Current.UpdateProgress("Munging parts and fixing wheels");

                        float scale;

                        for (int i = 0; i < bones.Count; i++)
                        {
                            ModelBone bone = bones[i];

                            if (i == 0)
                            {
                                bone.Name = "c_Body";
                                bone.Mesh.Name = "c_Body";
                            }
                            else
                            {
                                bone.Name = Path.GetFileNameWithoutExtension(bone.Name);
                            }

                            switch (bone.Name.ToUpper())
                            {
                                case "C_BODY":
                                    break;

                                case "FLPIVOT":
                                case "FRPIVOT":
                                    bone.Name = "Hub_" + bone.Name.ToUpper().Substring(0, 2);

                                    if (bone.Transform.Position() == Vector3.Zero)
                                    {
                                        ModelManipulator.MungeMeshWithBone(bone.Children[0].Mesh, false);

                                        Matrix4 m = bone.Transform;
                                        m.Row3 = bone.Children[0].Transform.Row3;
                                        bone.Transform = m;

                                        model.SetTransform(Matrix4.Identity, bone.Children[0].Index);
                                    }
                                    break;

                                case "FLWHEEL":
                                    scale = bone.CombinedTransform.ExtractTranslation().Y / 0.35f;

                                    bone.Name = "Wheel_FL";
                                    model.ClearMesh(bone.Index);
                                    model.SetTransform(Matrix4.CreateScale(scale) * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(180)), bone.Index);
                                    break;

                                case "FRWHEEL":
                                    scale = bone.CombinedTransform.ExtractTranslation().Y / 0.35f;

                                    bone.Name = "Wheel_FR";
                                    model.ClearMesh(bone.Index);
                                    model.SetTransform(Matrix4.CreateScale(scale), bone.Index);
                                    break;

                                case "RLWHEEL":
                                case "RRWHEEL":
                                    string suffix = bone.Name.ToUpper().Substring(0, 2);

                                    bone.Name = "Hub_" + suffix;

                                    if (bone.Transform.Position() == Vector3.Zero) { ModelManipulator.MungeMeshWithBone(bone.Mesh, false); }
                                    model.ClearMesh(bone.Index);

                                    scale = bone.CombinedTransform.ExtractTranslation().Y / 0.35f;

                                    int newBone = model.AddMesh(null, bone.Index);
                                    model.SetName("Wheel_" + suffix, newBone);
                                    model.SetTransform(Matrix4.CreateScale(scale) * (suffix == "RL" ? Matrix4.CreateRotationY(MathHelper.DegreesToRadians(180)) : Matrix4.Identity), newBone);
                                    break;

                                case "DRIVER":
                                    bone.Name = "Dryver";
                                    goto default;

                                default:
                                    if (bone.Type == BoneType.Mesh) { ModelManipulator.MungeMeshWithBone(bone.Mesh, false); }
                                    break;
                            }
                        }

                        SceneManager.Current.UpdateProgress("Processing complete!");

                        SceneManager.Current.SetCoordinateSystem(SceneManager.CoordinateSystem.LeftHanded);

                        SceneManager.Current.Change(ChangeType.Munge, ChangeContext.Model, -1);

                        SceneManager.Current.SetContext(ContextGame.CarmageddonReincarnation, ContextMode.Car);
                    }
                    break;
            }
        }

        private void menuCarmageddonMobileClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            switch (mi.Text)
            {
                case "Vehicle":
                    openContent("Carmageddon Mobile Vehicles (carbody.cnt)|carbody.cnt");
                    break;
            }
        }

        private void openContent(string filter)
        {
            ofdBrowse.Filter = filter;

            if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
            {
                SceneManager.Current.Reset();
                SceneManager.Current.Content.Load<Model, CNTImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);
            }
        }

        private void menuCarmageddonReincarnationClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            SceneManager.Current.SetCoordinateSystem(SceneManager.CoordinateSystem.LeftHanded);

            switch (mi.Text)
            {
                case "Accessory":
                    ofdBrowse.Filter = "Carmageddon ReinCARnation Accessory files (accessory.cnt)|accessory.cnt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        SceneManager.Current.Reset();
                        Asset accessory = SceneManager.Current.Add(SceneManager.Current.Content.Load<Model, CNTImporter>(Path.GetFileName(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName)));

                        string accessorytxt = ofdBrowse.FileName.Replace(".cnt", ".txt", StringComparison.OrdinalIgnoreCase);

                        if (File.Exists(accessorytxt))
                        {
                            accessory.SupportingDocuments["Accessory"] = Accessory.Load(accessorytxt);
                        }

                        SceneManager.Current.SetContext(ContextGame.CarmageddonReincarnation, ContextMode.Accessory);
                    }
                    break;

                case "Environment":
                    openContent("Carmageddon ReinCARnation Environment files (level.cnt)|level.cnt");
                    SceneManager.Current.SetContext(ContextGame.CarmageddonReincarnation, ContextMode.Level);
                    break;

                case "Pedestrian":
                    openContent("Carmageddon ReinCARnation Pedestrians (bodyform.cnt)|bodyform.cnt");
                    SceneManager.Current.SetContext(ContextGame.CarmageddonReincarnation, ContextMode.Ped);
                    break;

                case "Vehicle":
                    ofdBrowse.Filter = "Carmageddon ReinCARnation Vehicles (car.cnt)|car.cnt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        SceneManager.Current.Reset();

                        string assetFolder = Path.GetDirectoryName(ofdBrowse.FileName) + "\\";

                        Model vehicle = (Model)SceneManager.Current.Add(SceneManager.Current.Content.Load<Model, CNTImporter>(Path.GetFileName(ofdBrowse.FileName), assetFolder));

                        // Load supporting documents
                        if (File.Exists(assetFolder + "setup.lol")) { vehicle.SupportingDocuments["Setup"] = Setup.Load(assetFolder + "setup.lol"); }
                        if (File.Exists(assetFolder + "Structure.xml"))
                        {
                            List<string> findMaterials(StructurePart part)
                            {
                                List<string> materials = new List<string>();

                                materials.AddRange(part.DamageSettings.Methods.Where(m => m.Name == "CrushDamageMaterial" && m.HasBeenSet).Select(m => m.Parameters[2].Value.ToString()));

                                foreach (StructurePart child in part.Parts)
                                {
                                    materials.AddRange(findMaterials(child));
                                }

                                return materials;
                            }

                            Structure structure = Structure.Load(assetFolder + "Structure.xml");

                            foreach (string material in findMaterials(structure.Root))
                            {
                                SceneManager.Current.Content.Load<Material, MT2Importer>(material, assetFolder, true);
                            }

                            vehicle.SupportingDocuments["Structure"] = structure;
                        }

                        if (File.Exists(assetFolder + "SystemsDamage.xml")) { vehicle.SupportingDocuments["SystemsDamage"] = SystemsDamage.Load(assetFolder + "SystemsDamage.xml"); }

                        if (File.Exists(assetFolder + "vehicle_setup.cfg"))
                        {
                            vehicle.SupportingDocuments["VehicleSetupConfig"] = VehicleSetupConfig.Load(assetFolder + "vehicle_setup.cfg");

                            foreach (VehicleMaterialMap materialMap in vehicle.GetSupportingDocument<VehicleSetupConfig>("VehicleSetupConfig").MaterialMaps)
                            {
                                foreach (KeyValuePair<string, string> kvp in materialMap.Substitutions)
                                {
                                    SceneManager.Current.Content.Load<Material, MT2Importer>(kvp.Value, assetFolder, true);
                                }
                            }
                        }

                        if (File.Exists(assetFolder + "vehicle_setup.lol")) { vehicle.SupportingDocuments["VehicleSetup"] = VehicleSetup.Load(assetFolder + "vehicle_setup.lol"); }
                        if (File.Exists(assetFolder + "vfx_anchors.lol")) { vehicle.SupportingDocuments["VFXAnchors"] = VFXAnchors.Load(assetFolder + "vfx_anchors.lol"); }

                        if (File.Exists(assetFolder + "collision.cnt")) { vehicle.SupportingDocuments["Collision"] = SceneManager.Current.Content.Load<Model, CNTImporter>("collision.cnt", assetFolder); }
                        if (File.Exists(assetFolder + "opponent_collision.cnt")) { vehicle.SupportingDocuments["OpponentCollision"] = SceneManager.Current.Content.Load<Model, CNTImporter>("opponent_collision.cnt", assetFolder); }

                        //if (File.Exists(assetFolder + "CrashSoundsConfig_Car.xml")) { vehicle.SupportingDocuments["SystemsDamage"] = SystemsDamage.Load(assetFolder + "SystemsDamage.xml"); }

                        foreach (ModelBone bone in vehicle.Bones)
                        {
                            string boneName = bone.Name.ToLower();

                            if (boneName.StartsWith("wheel_") || boneName.StartsWith("vfx_") || boneName.StartsWith("driver"))
                            {
                                Entity entity = new Entity
                                {
                                    Name = bone.Name,
                                    EntityType = (boneName.StartsWith("driver") ? EntityType.Driver : (boneName.StartsWith("wheel_") ? EntityType.Wheel : EntityType.VFX)),
                                    AssetType = AssetType.Sprite
                                };
                                entity.LinkWith(bone);

                                SceneManager.Current.Entities.Add(entity);
                            }
                        }

                        SceneManager.Current.SetContext(ContextGame.CarmageddonReincarnation, ContextMode.Car);
                    }
                    break;

                case "CNT files":
                case "MDL files":
                case "MT2 files":
                case "TDX files":
                case "LIGHT files":
                case "Accessory.txt files":
                case "Routes.txt files":
                case "vehicle_setup.cfg files":
                case "vehicle_setup.lol files":
                case "Structure.xml files":
                case "SystemsDamage.xml files":
                case "Setup.lol files":
                case "ZAD files":
                    processAll(mi.Text);
                    break;

                case "Wheel Preview":
                    frmReincarnationWheelPreview preview = new frmReincarnationWheelPreview();

                    DialogResult result = preview.ShowDialog();

                    switch (result)
                    {
                        case DialogResult.OK:
                        case DialogResult.Abort:
                            foreach (Entity entity in SceneManager.Current.Entities)
                            {
                                if (entity.EntityType == EntityType.Wheel)
                                {
                                    entity.Asset = (result == DialogResult.OK ? preview.Wheel : null);
                                    entity.AssetType = (result == DialogResult.OK ? AssetType.Model : AssetType.Sprite);
                                }
                            }
                            break;
                    }
                    break;

                case "Bulk UnZAD":
                    if (MessageBox.Show(string.Format("Are you entirely sure?  This will extra ALL ZAD files in and under\r\n{0}\r\nThis will require at least 30gb of free space", Properties.Settings.Default.PathCarmageddonReincarnation), "Totes sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (Directory.Exists(Properties.Settings.Default.PathCarmageddonReincarnation))
                        {
                            int success = 0;
                            int fail = 0;

                            ToxicRagers.Helpers.IO.LoopDirectoriesIn(Properties.Settings.Default.PathCarmageddonReincarnation, (d) =>
                            {
                                foreach (FileInfo fi in d.GetFiles("*.zad"))
                                {
                                    ToxicRagers.Stainless.Formats.ZAD zad = ToxicRagers.Stainless.Formats.ZAD.Load(fi.FullName);
                                    int i = 0;

                                    if (zad != null)
                                    {
                                        if (!zad.IsVT)
                                        {
                                            foreach (ToxicRagers.Stainless.Formats.ZADEntry entry in zad.Contents)
                                            {
                                                i++;

                                                zad.Extract(entry, Properties.Settings.Default.PathCarmageddonReincarnation);

                                                if (i % 25 == 0)
                                                {
                                                    tsslProgress.Text = string.Format("[{0}/{1}] {2} -> {3}", success, fail, fi.Name, entry.Name);
                                                    Application.DoEvents();
                                                }
                                            }

                                            success++;
                                        }
                                    }
                                    else
                                    {
                                        fail++;
                                    }

                                    tsslProgress.Text = string.Format("[{0}/{1}] {2}", success, fail, fi.FullName.Replace(Properties.Settings.Default.PathCarmageddonReincarnation, ""));
                                    Application.DoEvents();
                                }
                            }
                            );

                            tsslProgress.Text = string.Format("unZADing complete. {0} success {1} fail", success, fail);
                        }
                    }
                    break;
            }
        }

        private void menuCarmageddonMaxDamageClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            SceneManager.Current.SetCoordinateSystem(SceneManager.CoordinateSystem.LeftHanded);

            switch (mi.Text)
            {
                case "Bulk UnZAD":
                    fbdBrowse.SelectedPath = (Properties.Settings.Default.LastBrowsedFolder ?? Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));

                    if (MessageBox.Show(string.Format("Are you entirely sure?  This will extra ALL ZAD files in and under\r\n{0}\r\nThis will require at least 30gb of free space", Properties.Settings.Default.PathCarmageddonMaxDamage), "Totes sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (fbdBrowse.ShowDialog() == DialogResult.OK && Directory.Exists(fbdBrowse.SelectedPath))
                        {
                            if (Directory.Exists(Properties.Settings.Default.PathCarmageddonMaxDamage))
                            {
                                int success = 0;
                                int fail = 0;

                                ToxicRagers.Helpers.IO.LoopDirectoriesIn(Properties.Settings.Default.PathCarmageddonMaxDamage, (d) =>
                                {
                                    foreach (FileInfo fi in d.GetFiles("*.zad"))
                                    {
                                        ToxicRagers.Stainless.Formats.ZAD zad = ToxicRagers.Stainless.Formats.ZAD.Load(fi.FullName);
                                        int i = 0;

                                        if (zad != null)
                                        {
                                            if (!zad.IsVT)
                                            {
                                                foreach (ToxicRagers.Stainless.Formats.ZADEntry entry in zad.Contents)
                                                {
                                                    i++;

                                                    zad.Extract(entry, fbdBrowse.SelectedPath + "\\");

                                                    if (i % 25 == 0)
                                                    {
                                                        tsslProgress.Text = string.Format("[{0}/{1}] {2} -> {3}", success, fail, fi.Name, entry.Name);
                                                        Application.DoEvents();
                                                    }
                                                }

                                                success++;
                                            }
                                        }
                                        else
                                        {
                                            fail++;
                                        }

                                        tsslProgress.Text = string.Format("[{0}/{1}] {2}", success, fail, fi.FullName.Replace(Properties.Settings.Default.PathCarmageddonMaxDamage, ""));
                                        Application.DoEvents();
                                    }
                                }
                                );

                                tsslProgress.Text = string.Format("unZADing complete. {0} success {1} fail", success, fail);
                            }
                        }
                    }
                    break;
            }
        }

        private void menuNovadromeClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            switch (mi.Text)
            {
                case "Environment":
                    openContent("Novadrome Environments (level-*.cnt)|level-*.cnt");
                    break;

                case "Vehicle":
                    openContent("Novadrome Vehicles (carbody.cnt)|carbody.cnt");
                    break;

                case "XT2 files":
                    processAll(mi.Text);
                    break;
            }
        }

        private void processAll(string fileType)
        {
            string extension = fileType.Substring(0, fileType.IndexOf(' ')).ToLower();
            fbdBrowse.SelectedPath = (Properties.Settings.Default.LastBrowsedFolder ?? Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));

            int success = 0;
            int fail = 0;

            if (fbdBrowse.ShowDialog() == DialogResult.OK && Directory.Exists(fbdBrowse.SelectedPath))
            {
                Properties.Settings.Default.LastBrowsedFolder = fbdBrowse.SelectedPath;
                Properties.Settings.Default.Save();

                ToxicRagers.Helpers.IO.LoopDirectoriesIn(fbdBrowse.SelectedPath, (d) =>
                {
                    foreach (FileInfo fi in d.GetFiles((extension.Contains(".") ? extension : "*." + extension)))
                    {
                        object result = null;

                        switch (extension)
                        {
                            case "anm":
                                // Content\Peds\animations
                                break;

                            case "bin":
                                // Content\UI\assets\h1080_default\animation_binaries
                                // Content\Vehicles\*\ui_assets
                                break;

                            case "bzn":
                                // Content\Environments\
                                break;

                            case "rba":
                                break;

                            case "shp":
                                break;

                            case "cnt":
                                result = ToxicRagers.Stainless.Formats.CNT.Load(fi.FullName);
                                break;

                            case "mdl":
                                result = ToxicRagers.Stainless.Formats.MDL.Load(fi.FullName);
                                break;

                            case "mt2":
                                result = MT2.Load(fi.FullName);
                                break;

                            case "tdx":
                                result = TDX.Load(fi.FullName);
                                break;

                            case "light":
                                result = LIGHT.Load(fi.FullName);
                                break;

                            case "xt2":
                                result = ToxicRagers.Novadrome.Formats.XT2.Load(fi.FullName);
                                break;

                            case "accessory.txt":
                                result = Accessory.Load(fi.FullName);
                                break;

                            case "routes.txt":
                                result = Routes.Load(fi.FullName);
                                break;

                            case "vehicle_setup.cfg":
                                result = VehicleSetupConfig.Load(fi.FullName);
                                break;

                            case "vehicle_setup.lol":
                                result = VehicleSetup.Load(fi.FullName);
                                break;

                            case "structure.xml":
                                result = Structure.Load(fi.FullName);
                                break;

                            case "systemsdamage.xml":
                                result = SystemsDamage.Load(fi.FullName);
                                break;

                            case "setup.lol":
                                result = Setup.Load(fi.FullName);
                                break;

                            case "txt":
                                result = ToxicRagers.Carmageddon.Formats.Car.Load(fi.FullName);
                                break;

                            case "zad":
                                result = ToxicRagers.Stainless.Formats.ZAD.Load(fi.FullName);
                                break;

                            case "msh":
                            case "mshs":
                                result = ToxicRagers.TDR2000.Formats.MSHS.Load(fi.FullName);
                                break;

                            case "dcol":
                                result = ToxicRagers.TDR2000.Formats.DCOL.Load(fi.FullName);
                                break;
                        }

                        if (result != null) { success++; } else { fail++; }

                        tsslProgress.Text = string.Format("[{0}/{1}] {2}", success, fail, fi.FullName.Replace(fbdBrowse.SelectedPath, ""));
                        Application.DoEvents();
                    }
                }
                );

                tsslProgress.Text = string.Format("{0} processing complete. {1} success {2} fail", extension, success, fail);
            }
        }

        private void menuTDR2000Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            switch (mi.Text)
            {
                case "Hierarchy":
                    ofdBrowse.Filter = "TDR2000 Hierarchy (*.hie)|*.hie";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        SceneManager.Current.Reset();
                        SceneManager.Current.Content.Load<Model, ContentPipeline.TDR2000.HIEImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);
                        SceneManager.Current.SetContext(ContextGame.CarmageddonTDR2000, ContextMode.Generic);
                    }
                    break;

                case "Remove LOD from Vehicle":
                    if (SceneManager.Current.Models.Count == 0) { return; }

                    for (int i = SceneManager.Current.Models[0].Bones.Count - 1; i >= 0; i--)
                    {
                        ModelBone bone = SceneManager.Current.Models[0].Bones[i];

                        if (bone.Name.Contains("LOD"))
                        {
                            string name = bone.Name.Replace("_", "");
                            if (name.Substring(name.IndexOf("LOD") + 3, 1) != "1")
                            {
                                SceneManager.Current.Models[0].RemoveBone(bone.Index);
                            }
                        }
                    }

                    SceneManager.Current.Change(ChangeType.Munge, ChangeContext.Model, -1);
                    break;

                case "DCOL files":
                case "MSH files":
                    processAll(mi.Text);
                    break;
            }
        }

        private void menuSaveForClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            switch (mi.Text)
            {
                case "Carmageddon 2":
                    sfdBrowse.Filter = "BRender ACT files (*.act)|*.act";

                    if (sfdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        string directory = Path.GetDirectoryName(sfdBrowse.FileName) + "\\";
                        HashSet<string> textures = new HashSet<string>();
                        if (!Directory.Exists(directory + "tiffrgb")) { Directory.CreateDirectory(directory + "tiffrgb"); }

                        ACTExporter ax = new ACTExporter();
                        ax.Export(SceneManager.Current.Models[0], sfdBrowse.FileName);

                        DATExporter dx = new DATExporter();
                        dx.Export(SceneManager.Current.Models[0], directory + Path.GetFileNameWithoutExtension(sfdBrowse.FileName) + ".dat");

                        MATExporter mx = new MATExporter();
                        mx.Export(SceneManager.Current.Materials, directory + Path.GetFileNameWithoutExtension(sfdBrowse.FileName) + ".mat");

                        foreach (Material material in SceneManager.Current.Materials)
                        {
                            if (material == null) { continue; }

                            if (material.Texture.Name != null && textures.Add(material.Texture.Name))
                            {
                                TIFExporter tx = new TIFExporter();
                                tx.Export(material.Texture, directory + "tiffrgb\\" + material.Texture.Name + ".tif");
                            }
                        }

                        SceneManager.Current.UpdateProgress(Path.GetFileName(sfdBrowse.FileName) + " saved successfully");
                    }
                    break;

                case "Carmageddon Reincarnation":
                    sfdBrowse.Filter = "Stainless CNT files (*.cnt)|*.cnt";
                    if (sfdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        CNTExporter cx = new CNTExporter();
                        cx.Export(SceneManager.Current.Models[0], sfdBrowse.FileName);

                        MDLExporter mx = new MDLExporter();
                        mx.Export(SceneManager.Current.Models[0], Path.GetDirectoryName(sfdBrowse.FileName) + "\\");
                    }
                    break;
            }
        }

        private void menuSaveAsClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            switch (mi.Text)
            {
                case "Level":
                    (new frmSaveAsLevel()).ShowDialog(this);
                    break;

                case "Vehicle":
                    (new frmSaveAsVehicle()).ShowDialog(this);
                    break;
            }
        }

        private void menuViewClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            switch (mi.Text)
            {
                case "Preferences":
                    if (new frmPreferences().ShowDialog(this) == DialogResult.OK)
                    {
                        InputManager.Current.ReloadBindings();
                    }
                    break;

                case "Details":
                    if (!dockPanel.Contents.Any(p => (p as DockContent).Text == mi.Text))
                    {
                        PnlDetails details = new PnlDetails();
                        details.Show(dockPanel, DockState.DockRight);
                        details.RegisterEventHandlers();

                    }
                    break;

                case "Material List":
                    if (!dockPanel.Contents.Any(p => (p as DockContent).Text == mi.Text))
                    {
                        pnlMaterialList materials = new pnlMaterialList();
                        materials.Show(dockPanel, DockState.DockBottom);
                        materials.RegisterEventHandlers();

                    }
                    break;

                case "Overview":
                    if (!dockPanel.Contents.Any(p => (p as DockContent).Text == mi.Text))
                    {
                        pnlOverview overview = new pnlOverview();
                        overview.Show(dockPanel, DockState.DockLeft);
                        overview.RegisterEventHandlers();
                    }
                    break;
            }
        }

        private void menuObjectClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            int boneIndex = SceneManager.Current.SelectedBoneIndex;
            int modelIndex = SceneManager.Current.SelectedModelIndex;
            int modelBoneKey = ModelBone.GetModelBoneKey(modelIndex, boneIndex);

            switch (mi.Text)
            {
                case "New...":
                    frmNewObject addNew = new frmNewObject();
                    addNew.SetParentNode(modelIndex, boneIndex);

                    if (addNew.ShowDialog(this) == DialogResult.OK)
                    {
                        SceneManager.Current.Change(ChangeType.Add, ChangeContext.Model, addNew.NewBoneKey, modelBoneKey);
                    }
                    break;

                case "Remove...":
                    frmRemoveObject removeObject = new frmRemoveObject();
                    removeObject.SetParentNode(modelIndex, boneIndex);

                    if (removeObject.ShowDialog(this) == DialogResult.OK)
                    {
                        SceneManager.Current.Change(ChangeType.Delete, ChangeContext.Model, modelBoneKey, removeObject.RemovedBone);
                    }
                    break;

                case "Modify geometry...":
                    frmModifyModel geometry = new frmModifyModel();
                    geometry.SetParentNode(modelIndex, boneIndex);

                    if (geometry.ShowDialog(this) == DialogResult.OK)
                    {
                        SceneManager.Current.Change(ChangeType.Transform, ChangeContext.Model, modelBoneKey);
                    }
                    break;

                case "Modify actor...":
                    frmModifyActor transform = new frmModifyActor();
                    transform.SetParentNode(modelIndex, boneIndex);

                    if (transform.ShowDialog(this) == DialogResult.OK)
                    {
                        SceneManager.Current.Change(ChangeType.Transform, ChangeContext.Model, modelBoneKey);
                    }
                    break;

                case "Rename":
                    frmRename rename = new frmRename();
                    rename.SetParentNode(modelIndex, boneIndex);

                    if (rename.ShowDialog(this) == DialogResult.OK)
                    {
                        SceneManager.Current.Change(ChangeType.Rename, ChangeContext.Model, modelBoneKey, rename.NewName);
                    }
                    break;

                case "Add/Change Type...":
                    frmChangeNodeType changeType = new frmChangeNodeType();
                    changeType.SetParentNode(modelIndex, boneIndex);

                    if (changeType.ShowDialog(this) == DialogResult.OK)
                    {
                        SceneManager.Current.Change(ChangeType.ChangeType, ChangeContext.Model, modelBoneKey);
                    }
                    break;

                case "Remove":
                    break;

                case "Optimise":
                    foreach (ModelMesh mesh in SceneManager.Current.SelectedModel.Meshes)
                    {
                        foreach (ModelMeshPart part in mesh.MeshParts)
                        {
                            part.Optimise();
                        }
                    }
                    break;

                case "Flatten hierarchy...":
                    SceneManager.Current.UpdateProgress("TODO: Code \"Flatten hierarchy...\"");
                    break;

                case "Invert texture 'v' coordinates":
                    ModelManipulator.FlipUVs(SceneManager.Current.SelectedModel.Bones[SceneManager.Current.SelectedBoneIndex].Mesh);
                    break;
            }
        }

        private void menuToolsClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            switch (mi.Text)
            {
                case "TDX Convertor":
                    frmTDXConvert tdx = new frmTDXConvert();
                    tdx.Show(this);
                    break;
            }
        }

        public void SetActionScalingText(string scale)
        {
            tsslActionScaling.Text = scale;
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            FlummeryApplication.Active = true;
        }

        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            FlummeryApplication.Active = false;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            FlummeryApplication.Active = (WindowState != FormWindowState.Minimized);
        }
    }
}