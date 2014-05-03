using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using ToxicRagers.Carmageddon2.Formats;
using Flummery.ContentPipeline.Stainless;

namespace Flummery
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        static bool bPublicRelease = false;

        SceneManager scene;
        GLControl control;
        Stopwatch sw = new Stopwatch();
        double accumulator = 0;

        int renderMode = 0;
        int[] renderModes = new int[] { 6914, 6913, 6912 };

        int actionScaling = 3;
        float[] actionScales = new float[] { 0.01f, 0.1f, 0.5f, 1.0f, 5.0f, 10.0f };

        private double dt
        {
            get
            {
                sw.Stop();
                double timeslice = sw.Elapsed.TotalMilliseconds;
                sw.Reset();
                sw.Start();
                return timeslice;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            control = new GLControl(new GraphicsMode(32, 24, 8, 4), 3, 0, GraphicsContextFlags.Default);
            control.Name = "glcViewport";
            control.VSync = true;
            control.Width = 716;
            control.Height = 512;
            control.Top = 3;
            control.Left = 3;
            control.BackColor = Color.Black;
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            control.Resize += glcViewport_Resize;
            control.Paint += glcViewport_Paint;
            scTreeView.Panel2.Controls.Add(control);

            var extensions = new List<string>(GL.GetString(StringName.Extensions).Split(' '));
            this.Text += " v0.0.2.3";

            scene = new SceneManager(extensions.Contains("GL_ARB_vertex_buffer_object"));

            BuildMenu();
            GLControlInit();

            sw.Start();

            ToxicRagers.Helpers.Logger.ResetLog();

            tsslActionScaling.Text = "Action Scaling: " + actionScales[actionScaling].ToString("0.000");

            Application.Idle += new EventHandler(Application_Idle);

            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(frmMain_KeyPress);

            scene.OnAdd += scene_OnAdd;
            scene.OnProgress += scene_OnProgress;
        }

        void scene_OnAdd(object sender, AddEventArgs e)
        {
            var m = (e.Item as Model);

            if (m != null)
            {
                TreeNode ParentNode = (tvNodes.Nodes.Count == 0 ? tvNodes.Nodes.Add("ROOT") : tvNodes.Nodes[0]);

                if (m.Root.Children.Count > 0)
                {
                    TravelTree(m.Root.Children[0], ref ParentNode);

                    tvNodes.Nodes[0].Expand();
                    tvNodes.Nodes[0].Nodes[0].Expand();
                }
            }
            else
            {
                var t = (e.Item as Texture);

                var mi = new MaterialItem();
                mi.MaterialName = t.Name;

                var b = (t.Tag as Bitmap);
                if (b == null)
                {
                    var tdx = (ToxicRagers.CarmageddonReincarnation.Formats.TDX)t.Tag;
                    if (tdx != null) { b = tdx.Decompress(tdx.GetMipLevelForSize(128)); }
                }

                if (b != null) { mi.SetThumbnail(b); }

                flpMaterials.Controls.Add(mi);
            }
        }

        public static void TravelTree(ModelBone bone, ref TreeNode node)
        {
            node = node.Nodes.Add(bone.Name);
            node.Tag = bone.Index;

            foreach (var b in bone.Children)
            {
                TravelTree(b, ref node);
            }

            node = node.Parent;
        }

        void scene_OnProgress(object sender, ProgressEventArgs e)
        {
            tsslProgress.Text = e.Status;
            tsslProgress.Owner.Refresh();
            Application.DoEvents();
        }

        void frmMain_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '.':
                    renderMode++;
                    if (renderMode == renderModes.Length) { renderMode = 0; }
                    GL.PolygonMode(MaterialFace.FrontAndBack, (PolygonMode)renderModes[renderMode]);
                    break;

                case '*':
                    if (actionScaling + 1 < actionScales.Length)
                    {
                        actionScaling++;
                        scene.Camera.SetActionScale(actionScales[actionScaling]);
                        tsslActionScaling.Text = "Action Scaling: " + actionScales[actionScaling].ToString("0.000");
                    }
                    break;

                case '/':
                    if (actionScaling - 1 > -1)
                    {
                        actionScaling--;
                        scene.Camera.SetActionScale(actionScales[actionScaling]);
                        tsslActionScaling.Text = "Action Scaling: " + actionScales[actionScaling].ToString("0.000");
                    }
                    break;

                default:
                //    Console.WriteLine((byte)e.KeyChar);
                    break;
            }

            e.Handled = true;
        }

        private void GLControlInit()
        {
            GL.ClearColor(Color.Gray);
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
            GL.ShadeModel(ShadingModel.Smooth);
            GL.PointSize(3.0f);
            GL.Enable(EnableCap.CullFace);
            //GL.FrontFace(FrontFaceDirection.Cw);
            GL.Light(LightName.Light0, LightParameter.Position, new float[] { 0.0f, 2.0f, 0.0f });
            GL.Light(LightName.Light0, LightParameter.Ambient, new float[] { 0.6f, 0.6f, 0.6f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Specular, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.SpotExponent, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.LightModel(LightModelParameter.LightModelAmbient, new float[] { 0.7f, 0.7f, 0.7f, 1.0f });
            GL.LightModel(LightModelParameter.LightModelTwoSide, 1);
            GL.LightModel(LightModelParameter.LightModelLocalViewer, 1);

            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);

            GL.Enable(EnableCap.Texture2D);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            double milliseconds = dt;
            Accumulate(milliseconds);
            Animate(milliseconds);
        }

        private void Animate(double milliseconds)
        {
            control.Invalidate();
        }

        private void Accumulate(double milliseconds)
        {
            accumulator += milliseconds;
            if (accumulator > 1000) { accumulator -= 1000; }
        }

        private void glcViewport_Resize(object sender, EventArgs e)
        {
            int w = control.Width;
            int h = control.Height;
            GL.Viewport(0, 0, w, h);

            float aspect_ratio = w / (float)h;

            Matrix4 perpective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect_ratio, 0.1f, 640);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perpective);
        }

        private void glcViewport_Paint(object sender, PaintEventArgs e) 
        {
            scene.Update((float)dt);
            Draw(); 
        }

        private void Draw()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            scene.Draw();

            control.SwapBuffers();
        }

        private void BuildMenu()
        {
            MainMenu menu = new MainMenu();
            menu.MenuItems.Add("&File");
            menu.MenuItems[0].MenuItems.Add("&Open...", menuClick);
            menu.MenuItems[0].MenuItems[0].Shortcut = Shortcut.CtrlO;
            menu.MenuItems[0].MenuItems[0].MenuItems.Add("Carmageddon 2");
            menu.MenuItems[0].MenuItems[0].MenuItems[0].MenuItems.Add("Actor", menuCarmageddon2Click);

            menu.MenuItems[0].MenuItems[0].MenuItems.Add("Carmageddon Reincarnation");
            menu.MenuItems[0].MenuItems[0].MenuItems[1].MenuItems.Add("Accessory", menuCarmageddonReincarnationClick);
            menu.MenuItems[0].MenuItems[0].MenuItems[1].MenuItems.Add("Environment", menuCarmageddonReincarnationClick);
            menu.MenuItems[0].MenuItems[0].MenuItems[1].MenuItems.Add("Pedestrian", menuCarmageddonReincarnationClick);
            menu.MenuItems[0].MenuItems[0].MenuItems[1].MenuItems.Add("Vehicle", menuCarmageddonReincarnationClick);

            menu.MenuItems[0].MenuItems[0].MenuItems.Add("Novadrome");
            menu.MenuItems[0].MenuItems[0].MenuItems[2].MenuItems.Add("Vehicle", menuNovadromeClick);

            menu.MenuItems[0].MenuItems.Add("&Import");
            //menu.MenuItems[0].MenuItems[1].MenuItems.Add("BRender ACT File...", menuClick);
            menu.MenuItems[0].MenuItems[1].MenuItems.Add("BRender DAT File...", menuClick);
            menu.MenuItems[0].MenuItems[1].MenuItems.Add("Stainless CNT File...", menuClick);
            menu.MenuItems[0].MenuItems[1].MenuItems.Add("Stainless MDL File...", menuClick);

            if (!bPublicRelease)
            {
                menu.MenuItems[0].MenuItems.Add("-");
                menu.MenuItems[0].MenuItems.Add("Save", menuClick);

                menu.MenuItems[0].MenuItems.Add("Save As...");
                menu.MenuItems[0].MenuItems[4].MenuItems.Add("Carmageddon Reincarnation");
                menu.MenuItems[0].MenuItems[4].MenuItems[0].MenuItems.Add("Environment", menuSaveAsClick);
            }

            menu.MenuItems[0].MenuItems.Add("-");
            menu.MenuItems[0].MenuItems.Add("E&xit", menuClick);

            menu.MenuItems.Add("&Debug");
            if (!bPublicRelease)
            {
                menu.MenuItems[1].MenuItems.Add("Process...");
                menu.MenuItems[1].MenuItems[0].MenuItems.Add("XT2 file", menuNovadromeClick);
                menu.MenuItems[1].MenuItems.Add("Process all...");
                menu.MenuItems[1].MenuItems[1].MenuItems.Add("CNT files", menuCarmageddonReincarnationClick);
                menu.MenuItems[1].MenuItems[1].MenuItems.Add("LIGHT files", menuCarmageddonReincarnationClick);
                menu.MenuItems[1].MenuItems[1].MenuItems.Add("MDL files", menuCarmageddonReincarnationClick);
                menu.MenuItems[1].MenuItems[1].MenuItems.Add("MTL files", menuCarmageddonReincarnationClick);
                menu.MenuItems[1].MenuItems[1].MenuItems.Add("TDX files", menuCarmageddonReincarnationClick);
                menu.MenuItems[1].MenuItems[1].MenuItems.Add("XT2 files", menuNovadromeClick);
            }

            menu.MenuItems.Add("View");
            menu.MenuItems[2].MenuItems.Add("Preferences", menuViewClick);

            menu.MenuItems.Add("About");
            menu.MenuItems[3].MenuItems.Add("I LIKE CAKE");

            this.Menu = menu;
        }

        private void menuClick(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            switch (mi.Text)
            {
                case "BRender DAT File...":
                    ofdBrowse.Filter = "BRender DAT files (*.dat)|*.dat";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        string path = ofdBrowse.FileName;
                        string fileName = path.Substring(path.LastIndexOf("\\") + 1);
                        path = path.Replace(fileName, "");

                        scene.Add(scene.Content.Load<Model, DATImporter>(fileName, path));
                    }
                    break;

                case "Stainless CNT File...":
                    ofdBrowse.Filter = "Stainless CNT files (*.cnt)|*.cnt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        string path = ofdBrowse.FileName;
                        string fileName = path.Substring(path.LastIndexOf("\\") + 1);
                        path = path.Replace(fileName, "");

                        scene.Add(scene.Content.Load<Model, CNTImporter>(fileName, path));
                    }
                    break;

                case "Stainless MDL File...":
                    ofdBrowse.Filter = "Stainless MDL files (*.mdl)|*.mdl";
                    ofdBrowse.ShowDialog();

                    if (ofdBrowse.FileName.Length > 0 && File.Exists(ofdBrowse.FileName))
                    {
                        string path = ofdBrowse.FileName;
                        string fileName = path.Substring(path.LastIndexOf("\\") + 1);
                        path = path.Replace(fileName, "");

                        scene.Content.Load<Model, MDLImporter>(fileName, path, true);
                    }
                    break;

                case "Save":
                    MessageBox.Show("[code goes here]");
                    break;

                case "E&xit":
                    Application.Exit();
                    break;
            }
        }

        private void menuCarmageddon2Click(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            switch (mi.Text)
            {
                case "Actor":
                    ofdBrowse.Filter = "Carmageddon 2 ACTOR (*.act)|*.act";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        string path = ofdBrowse.FileName;
                        string fileName = path.Substring(path.LastIndexOf("\\") + 1);
                        path = path.Replace(fileName, "");

                        scene.Add(scene.Content.Load<Model, ACTImporter>(fileName, path));
                    }
                    break;
            }
        }

        private void openContent(string filter)
        {
            ofdBrowse.Filter = filter;

            if (ofdBrowse.ShowDialog() == DialogResult.OK)
            {
                string path = ofdBrowse.FileName;
                string fileName = path.Substring(path.LastIndexOf("\\") + 1);
                path = path.Replace(fileName, "");

                scene.Add(scene.Content.Load<Model, CNTImporter>(fileName, path));
            }
        }

        private void menuCarmageddonReincarnationClick(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            switch (mi.Text)
            {
                case "Accessory":
                    openContent("Carmageddon ReinCARnation Accessory files (accessory.cnt)|accessory.cnt");
                    break;

                case "Environment":
                    openContent("Carmageddon ReinCARnation Environment files (level.cnt)|level.cnt");
                    break;

                case "Pedestrian":
                    openContent("Carmageddon ReinCARnation Pedestrians (bodyform.cnt)|bodyform.cnt");
                    break;

                case "Vehicle":
                    openContent("Carmageddon ReinCARnation Vehicles (car.cnt)|car.cnt");
                    break;

                case "CNT files":
                case "MDL files":
                case "MTL files":
                case "TDX files":
                case "LIGHT files":
                    string extension = mi.Text.Substring(0, mi.Text.IndexOf(' ')).ToLower();
                    fbdBrowse.SelectedPath = (Properties.Settings.Default.LastBrowsedFolder != null ? Properties.Settings.Default.LastBrowsedFolder : Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
                    fbdBrowse.ShowDialog();

                    if (fbdBrowse.SelectedPath.Length > 0)
                    {
                        Properties.Settings.Default.LastBrowsedFolder = fbdBrowse.SelectedPath;
                        Properties.Settings.Default.Save();

                        ToxicRagers.Helpers.IO.LoopDirectoriesIn(fbdBrowse.SelectedPath, (d) =>
                        {
                            foreach (FileInfo fi in d.GetFiles("*." + extension))
                            {
                                switch (extension)
                                {
                                    case "cnt":
                                        ToxicRagers.Stainless.Formats.CNT.Load(fi.FullName);
                                        break;

                                    case "mdl":
                                        ToxicRagers.Stainless.Formats.MDL.Load(fi.FullName);
                                        break;

                                    case "mtl":
                                        ToxicRagers.Stainless.Formats.MTL.Load(fi.FullName);
                                        break;

                                    case "tdx":
                                        ToxicRagers.CarmageddonReincarnation.Formats.TDX.Load(fi.FullName);
                                        break;

                                    case "light":
                                        ToxicRagers.CarmageddonReincarnation.Formats.LIGHT.Load(fi.FullName);
                                        break;
                                }

                                tsslProgress.Text = fi.Name;
                                Application.DoEvents();
                            }
                        }
                        );

                        MessageBox.Show("Done!");
                    }
                    break;
            }
        }

        private void menuNovadromeClick(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            switch (mi.Text)
            {
                case "Vehicle":
                    openContent("Novadrome Vehicles (carbody.cnt)|carbody.cnt");
                    break;

                case "XT2 files":
                    fbdBrowse.SelectedPath = (Properties.Settings.Default.LastBrowsedFolder != null ? Properties.Settings.Default.LastBrowsedFolder : Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
                    fbdBrowse.ShowDialog();

                    if (fbdBrowse.SelectedPath.Length > 0)
                    {
                        Properties.Settings.Default.LastBrowsedFolder = fbdBrowse.SelectedPath;
                        Properties.Settings.Default.Save();

                        ToxicRagers.Helpers.IO.LoopDirectoriesIn(fbdBrowse.SelectedPath, (d) =>
                        {
                            foreach (FileInfo fi in d.GetFiles("*.xt2"))
                            {
                                ToxicRagers.Novadrome.Formats.XT2.Load(fi.FullName);
                            }
                        }
                        );

                        MessageBox.Show("Done!");
                    }
                    break;
            }
        }

        private void menuSaveAsClick(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            switch (mi.Text)
            {
                case "Environment":
                    if (fbdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        var d = new DirectoryInfo(fbdBrowse.SelectedPath);

                        if (!Directory.Exists(fbdBrowse.SelectedPath + "\\levels\\Airport\\")) { Directory.CreateDirectory(fbdBrowse.SelectedPath + "\\levels\\Airport\\"); }

                        using (StreamWriter w = File.CreateText(fbdBrowse.SelectedPath + "\\environment.lol"))
                        {
                            w.WriteLine("module((...), environment_config, package.seeall)");
                            w.WriteLine("name = txt.fe_environment_" + d.Name.ToLower() + "_ucase");
                        }

                        using (StreamWriter w = File.CreateText(fbdBrowse.SelectedPath + "\\environment.txt"))
                        {
                            w.WriteLine("[LUMP]");
                            w.WriteLine("environment");
                        }

                        using (StreamWriter w = File.CreateText(fbdBrowse.SelectedPath + "\\levels\\Airport\\level.txt"))
                        {
                            w.WriteLine("[LUMP]");
                            w.WriteLine("level");
                            w.WriteLine();
                            w.WriteLine("[RACE_NAMES]");
                            w.WriteLine("txt.fe_level_airport_race_1_ucase");
                            w.WriteLine();
                            w.WriteLine("[RACE_WRITEUP]");
                            w.WriteLine("txt.fe_level_airport_race_1_writeup");
                            w.WriteLine();
                            w.WriteLine("[RACE_IMAGES]");
                            w.WriteLine("race\\" + d.Name + "_Airport_race_01");
                            w.WriteLine();
                            w.WriteLine("[RACE_BACKGROUNDS]");
                            w.WriteLine("background_list\\" + d.Name + "_Airport_race_01");
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

                        var cx = new CNTExporter();
                        cx.SetExportOptions(new { Scale = new Vector3(2.5f, 2.5f, -2.5f) });
                        cx.Export(scene.Models[0], fbdBrowse.SelectedPath + "\\levels\\Airport\\level.cnt");

                        var mx = new MDLExporter();
                        mx.SetExportOptions(new { Transform = Matrix4.CreateScale(2.5f, 2.5f, -2.5f) });
                        mx.Export(scene.Models[0], fbdBrowse.SelectedPath + "\\levels\\Airport\\");

                        //foreach (var material in scene.Textures)
                        //{
                        //    var tx = new TDXExporter();
                        //    tx.SetExportOptions(new { Format = ToxicRagers.Helpers.D3DFormat.DXT5 });
                        //    tx.Export(material, fbdBrowse.SelectedPath + "\\levels\\Airport\\");
                        //}

                        MessageBox.Show("Done!");
                    }
                    break;
            }
        }

        private void menuViewClick(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            switch (mi.Text)
            {
                case "Preferences":
                    var prefs = new frmPreferences();
                    prefs.Show();
                    break;
            }
        }

        private void tvNodes_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                scene.Camera.ResetCamera();
                scene.Camera.SetPosition(scene.Models[0].Bones[(int)e.Node.Tag].CombinedTransform.Position());
            }
        }
    }
}
 