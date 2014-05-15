using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
            control.Height = 498;
            control.Top = 3;
            control.Left = 3;
            control.BackColor = Color.Black;
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            control.Resize += glcViewport_Resize;
            control.Paint += glcViewport_Paint;
            control.Click += glcViewport_Click;
            scTreeView.Panel2.Controls.Add(control);

            var extensions = new List<string>(GL.GetString(StringName.Extensions).Split(' '));
            this.Text += " v0.0.2.6c";

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

            flpMaterials.Tag = new SortedList<string, string>();
        }

        void scene_OnAdd(object sender, AddEventArgs e)
        {
            var m = (e.Item as Model);

            if (m != null)
            {
                ProcessTree(m);
            }
            else
            {
                var t = (e.Item as Material);
                var mi = new MaterialItem();

                mi.MaterialName = t.Name;
                mi.Material = t;
                if (t.Texture != null) { mi.SetThumbnail(t.Texture.GetThumbnail()); }

                //var matList = (flpMaterials.Tag as SortedList<string, string>);
                //matList[t.Name] = t.Name;

                flpMaterials.Controls.Add(mi);
                //flpMaterials.Controls.SetChildIndex(mi, matList.IndexOfKey(t.Name));

                //flpMaterials.Tag = matList;
            }
        }

        public void ProcessTree(Model m, bool bReset = false)
        {
            if (bReset) { tvNodes.Nodes.Clear(); }

            TreeNode ParentNode = (tvNodes.Nodes.Count == 0 ? tvNodes.Nodes.Add("ROOT") : tvNodes.Nodes[0]);

            if (m.Root.Children.Count > 0)
            {
                TravelTree(m.Root.Children[0], ref ParentNode);

                tvNodes.Nodes[0].Expand();
                tvNodes.Nodes[0].Nodes[0].Expand();
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
            GL.Enable(EnableCap.ScissorTest);

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
            //GL.Viewport(0, 0, w, h);
        }

        private void glcViewport_Paint(object sender, PaintEventArgs e) 
        {
            scene.Update((float)dt);
            Draw(); 
        }

        private void glcViewport_Click(object sender, EventArgs e)
        {
        }

        private void Draw()
        {
            int w = control.Width;
            int h = control.Height;
            float aspect_ratio = w / (float)h;

            Matrix4 perpective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect_ratio, 0.1f, 1000);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perpective);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.ClearColor(Color.Gray);
            int hw = control.Width / 2;
            int hh = control.Height / 2;

            var right = new Rectangle(0, hh, hw, hh);
            var top = new Rectangle(hw, hh, hw, hh);
            var front = new Rectangle(0, 0, hw, hh);
            var threed = new Rectangle(hw, 0, hw, hh);

            // Right
            GL.Viewport(right);
            GL.Scissor(right.X, right.Y, right.Width, right.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            scene.Draw();

            //// Top
            //GL.Viewport(top);
            //GL.Scissor(top.X, top.Y, top.Width, top.Height);
            //GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //scene.Draw();

            //// Front
            //GL.Viewport(front);
            //GL.Scissor(front.X, front.Y, front.Width, front.Height);
            //GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //scene.Draw();

            //// 3D
            //GL.Viewport(threed);
            //GL.Scissor(threed.X, threed.Y, threed.Width, threed.Height);
            //GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //scene.Draw();

            GL.Disable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Lighting);

            GL.Viewport(0, 0, control.Width, control.Height);
            GL.Scissor(0, 0, control.Width, control.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, 1, 0, 1, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Begin(PrimitiveType.LineStrip);
            GL.Color3(Color.Blue);
            GL.LineWidth(2f);
                
            GL.Vertex2(0.0f, 0.0f);
            GL.Vertex2(0.5f, 0.0f);

            GL.Vertex2(0.5f, 0.5f);
            GL.Vertex2(0.0f, 0.5f);
            GL.End();

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
            menu.MenuItems[0].MenuItems[0].MenuItems[2].MenuItems.Add("Environment", menuNovadromeClick);
            menu.MenuItems[0].MenuItems[0].MenuItems[2].MenuItems.Add("Vehicle", menuNovadromeClick);

            menu.MenuItems[0].MenuItems[0].MenuItems.Add("TDR2000");
            menu.MenuItems[0].MenuItems[0].MenuItems[3].MenuItems.Add("Hierarchy", menuTDR2000Click);

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

            menu.MenuItems.Add("&View");
            menu.MenuItems[1].MenuItems.Add("Preferences", menuViewClick);

            menu.MenuItems.Add("&Object");
            menu.MenuItems[2].MenuItems.Add("Rename", menuObjectClick);

            menu.MenuItems.Add("&Tools");
            menu.MenuItems[3].MenuItems.Add("Carma 2");
            menu.MenuItems[3].MenuItems[0].MenuItems.Add("Convert Powerups to Entities", menuCarmageddon2Click);
            menu.MenuItems[3].MenuItems.Add("Process all...");
            menu.MenuItems[3].MenuItems[1].MenuItems.Add("CNT files", menuCarmageddonReincarnationClick);
            menu.MenuItems[3].MenuItems[1].MenuItems.Add("LIGHT files", menuCarmageddonReincarnationClick);
            menu.MenuItems[3].MenuItems[1].MenuItems.Add("MDL files", menuCarmageddonReincarnationClick);
            menu.MenuItems[3].MenuItems[1].MenuItems.Add("MTL files", menuCarmageddonReincarnationClick);
            menu.MenuItems[3].MenuItems[1].MenuItems.Add("TDX files", menuCarmageddonReincarnationClick);
            menu.MenuItems[3].MenuItems[1].MenuItems.Add("Accessory.txt files", menuCarmageddonReincarnationClick);
            menu.MenuItems[3].MenuItems[1].MenuItems.Add("Routes.txt files", menuCarmageddonReincarnationClick);
            menu.MenuItems[3].MenuItems[1].MenuItems.Add("XT2 files", menuNovadromeClick);
            menu.MenuItems[3].MenuItems.Add("General");
            menu.MenuItems[3].MenuItems[2].MenuItems.Add("TDX Convertor", menuToolsClick);

            menu.MenuItems.Add("&Help");
            menu.MenuItems[4].MenuItems.Add("About Flummery");

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
                    sfdBrowse.Filter = "Stainless CNT files (*.cnt)|*.cnt";
                    if (sfdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        var cx = new CNTExporter();
                        cx.SetExportOptions(new { Scale = new Vector3(1.0f, 1.0f, -1.0f) });
                        cx.Export(scene.Models[0], sfdBrowse.FileName);

                        var mx = new MDLExporter();
                        mx.SetExportOptions(new { Transform = Matrix4.CreateScale(1.0f, 1.0f, -1.0f) });
                        mx.Export(scene.Models[0], Path.GetDirectoryName(sfdBrowse.FileName) + "\\" );
                    }
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

                case "Convert Powerups to Entities":
                    for (int i = scene.Models[0].Bones.Count - 1; i >= 0; i--)
                    {
                        var bone = scene.Models[0].Bones[i];

                        if (bone.Name.StartsWith("&"))
                        {
                            var entity = new Entity();

                            if (bone.Name.StartsWith("&£"))
                            {
                                string key = bone.Name.Substring(2, 2);

                                entity.UniqueIdentifier = "errol_B00BIE" + key + "_" + i.ToString("000");
                                entity.EntityType = EntityType.Powerup;

                                var pup = ToxicRagers.Carmageddon2.Powerups.LookupID(int.Parse(key));

                                if (pup.InCR)
                                {
                                    entity.Name = "pup_" + pup.Name;
                                    entity.Tag = pup.Model;
                                }
                                else
                                {
                                    entity.Name = "pup_Pinball";
                                    entity.Tag = pup.Model;
                                }
                            }
                            else
                            {
                                // accessory
                                entity.UniqueIdentifier = "errol_HEAD00" + bone.Name.Substring(1, 2) + "_" + i.ToString("000");
                                entity.EntityType = EntityType.Accessory;
                                entity.Name = "C2_" + ((ModelMesh)bone.Tag).Name.Substring(3);
                            }

                            entity.Transform = bone.CombinedTransform;
                            scene.Entities.Add(entity);

                            scene.Models[0].RemoveBone(bone.Index);
                        }
                    }

                    ProcessTree(scene.Models[0], true);
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
                    ofdBrowse.Filter = "Carmageddon ReinCARnation Accessory files (accessory.cnt)|accessory.cnt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        var accessory = scene.Add(scene.Content.Load<Model, CNTImporter>(Path.GetFileName(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName)));

                        string accessorytxt = ofdBrowse.FileName.Replace(".cnt", ".txt", StringComparison.OrdinalIgnoreCase);

                        if (File.Exists(accessorytxt))
                        {
                            accessory.Tag = ToxicRagers.CarmageddonReincarnation.Formats.Accessory.Load(accessorytxt);
                        }
                    }
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
                case "Accessory.txt files":
                case "Routes.txt files":
                    string extension = mi.Text.Substring(0, mi.Text.IndexOf(' ')).ToLower();
                    fbdBrowse.SelectedPath = (Properties.Settings.Default.LastBrowsedFolder != null ? Properties.Settings.Default.LastBrowsedFolder : Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
                    fbdBrowse.ShowDialog();

                    if (fbdBrowse.SelectedPath.Length > 0)
                    {
                        Properties.Settings.Default.LastBrowsedFolder = fbdBrowse.SelectedPath;
                        Properties.Settings.Default.Save();

                        ToxicRagers.Helpers.IO.LoopDirectoriesIn(fbdBrowse.SelectedPath, (d) =>
                        {
                            foreach (FileInfo fi in d.GetFiles((extension.Contains(".") ? extension : "*." + extension)))
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

                                    case "accessory.txt":
                                        ToxicRagers.CarmageddonReincarnation.Formats.Accessory.Load(fi.FullName);
                                        break;

                                    case "routes.txt":
                                        ToxicRagers.CarmageddonReincarnation.Formats.Routes.Load(fi.FullName);
                                        break;
                                }

                                tsslProgress.Text = fi.FullName.Replace(fbdBrowse.SelectedPath, "");
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
                case "Environment":
                    openContent("Novadrome Environments (level-*.cnt)|level-*.cnt");
                    break;

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

        private void menuTDR2000Click(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            switch (mi.Text)
            {
                case "Hierarchy":
                    ofdBrowse.Filter = "TDR2000 Hierarchy (*.hie)|*.hie";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        scene.Add(scene.Content.Load<Model, ContentPipeline.TDR2000.HIEImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName)));
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
                    var fmSaveAsEnvironment = new frmSaveAsEnvironment();
                    fmSaveAsEnvironment.Show(this);
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

        private void menuObjectClick(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            switch (mi.Text)
            {
                case "Rename":
                    var rename = new frmRename();
                    rename.Show();
                    break;
            }
        }

        private void menuToolsClick(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            switch (mi.Text)
            {
                case "TDX Convertor":
                    //var tdx = new frmTDXConvert();
                    //tdx.Show(this);
                    var t = SceneManager.Current.Content.Load<Texture, TIFImporter>("airpmap", @"D:\");

                    var tx = new TDXExporter();
                    tx.SetExportOptions(new { Format = ToxicRagers.Helpers.D3DFormat.DXT1 });
                    tx.Export(t, @"D:\");
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
 