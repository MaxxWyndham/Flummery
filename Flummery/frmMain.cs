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
        bool bActive = true;

        public static GLControl Control;
        SceneManager scene;
        ViewportManager viewman;
        Stopwatch sw = new Stopwatch();
        double accumulator = 0;

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
            Control = new GLControl(new GraphicsMode(32, 24, 8, 4), 3, 0, GraphicsContextFlags.Default);
            Control.Name = "glcViewport";
            Control.VSync = true;
            Control.Width = 716;
            Control.Height = 498;
            Control.Top = 3;
            Control.Left = 3;
            Control.BackColor = Color.Black;
            Control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Control.Paint += glcViewport_Paint;
            Control.Resize += glcViewport_Resize;
            Control.MouseMove += glcViewport_MouseMove;
            Control.Click += glcViewport_Click;
            scTreeView.Panel2.Controls.Add(Control);

            viewman = new ViewportManager();

            var extensions = new List<string>(GL.GetString(StringName.Extensions).Split(' '));
            this.Text += " v0.0.2.8";

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
            scene.OnReset += scene_OnReset;
            scene.OnProgress += scene_OnProgress;

            flpMaterials.Tag = new SortedList<string, string>();

            viewman.Initialise();
        }

        void scene_OnReset(object sender, ResetEventArgs e)
        {
            ProcessTree(new Model(), true);
            flpMaterials.Controls.Clear();
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
            if (!bActive) { return; }

            switch (e.KeyChar)
            {
                case '*':
                    if (actionScaling + 1 < actionScales.Length)
                    {
                        actionScaling++;
                        viewman.SetActionScale(actionScales[actionScaling]);
                        tsslActionScaling.Text = "Action Scaling: " + actionScales[actionScaling].ToString("0.000");
                    }
                    break;

                case '/':
                    if (actionScaling - 1 > -1)
                    {
                        actionScaling--;
                        viewman.SetActionScale(actionScales[actionScaling]);
                        tsslActionScaling.Text = "Action Scaling: " + actionScales[actionScaling].ToString("0.000");
                    }
                    break;
            }

            e.Handled = true;
        }

        private void GLControlInit()
        {
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
            GL.ShadeModel(ShadingModel.Smooth);
            GL.PointSize(3.0f);
            GL.Enable(EnableCap.CullFace);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            if (!bActive) { return; }

            double milliseconds = dt;
            Accumulate(milliseconds);
            Animate(milliseconds);
        }

        private void Animate(double milliseconds)
        {
            Control.Invalidate();
        }

        private void Accumulate(double milliseconds)
        {
            accumulator += milliseconds;
            if (accumulator > 1000) { accumulator -= 1000; }
        }

        private void glcViewport_Paint(object sender, PaintEventArgs e) 
        {
            scene.Update((float)dt);
            viewman.Update((float)dt);
            Draw(); 
        }

        private void glcViewport_Click(object sender, EventArgs e)
        {
            var mouse = (MouseEventArgs)e;

            if (viewman.Active.RightClickLabel(mouse))
            {
                foreach (ToolStripItem item in cmsViewport.Items)
                {
                    var entry = (item as ToolStripMenuItem);
                    if (entry == null) { continue; }

                    entry.Checked = (entry.Text == viewman.Active.Name);

                    if (entry.Text == "Maximise") { entry.Enabled = !viewman.Active.Maximised; }
                    if (entry.Text == "Minimise") { entry.Enabled = viewman.Active.Maximised; }
                }

                cmsViewport.Show(Cursor.Position);
            }
        }

        void glcViewport_MouseMove(object sender, MouseEventArgs e)
        {
            viewman.MouseMove(e.X, e.Y);
        }

        private void glcViewport_Resize(object sender, EventArgs e)
        {
            if (viewman != null) { viewman.Initialise(); }
        }

        private void Draw()
        {
            GL.Disable(EnableCap.ScissorTest);
            GL.ClearColor(Color.Blue);
            GL.Viewport(0, 0, Control.Width, Control.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.ScissorTest);

            viewman.Draw();

            Control.SwapBuffers();
        }

        private void BuildMenu()
        {
            MainMenu menu = new MainMenu();
            menu.MenuItems.Add("&File");
            menu.MenuItems[0].MenuItems.Add("&New", menuClick);
            menu.MenuItems[0].MenuItems[0].Shortcut = Shortcut.CtrlN;
            menu.MenuItems[0].MenuItems.Add("&Open...");
            menu.MenuItems[0].MenuItems[1].MenuItems.Add("Carmageddon 2");
            menu.MenuItems[0].MenuItems[1].MenuItems[0].MenuItems.Add("Actor", menuCarmageddon2Click);

            menu.MenuItems[0].MenuItems[1].MenuItems.Add("Carmageddon Mobile");
            menu.MenuItems[0].MenuItems[1].MenuItems[1].MenuItems.Add("Vehicle", menuCarmageddonMobileClick);

            menu.MenuItems[0].MenuItems[1].MenuItems.Add("Carmageddon Reincarnation");
            menu.MenuItems[0].MenuItems[1].MenuItems[2].MenuItems.Add("Accessory", menuCarmageddonReincarnationClick);
            menu.MenuItems[0].MenuItems[1].MenuItems[2].MenuItems.Add("Environment", menuCarmageddonReincarnationClick);
            menu.MenuItems[0].MenuItems[1].MenuItems[2].MenuItems.Add("Pedestrian", menuCarmageddonReincarnationClick);
            menu.MenuItems[0].MenuItems[1].MenuItems[2].MenuItems.Add("Vehicle", menuCarmageddonReincarnationClick);

            menu.MenuItems[0].MenuItems[1].MenuItems.Add("Novadrome");
            menu.MenuItems[0].MenuItems[1].MenuItems[3].MenuItems.Add("Environment", menuNovadromeClick);
            menu.MenuItems[0].MenuItems[1].MenuItems[3].MenuItems.Add("Vehicle", menuNovadromeClick);

            menu.MenuItems[0].MenuItems[1].MenuItems.Add("TDR2000");
            menu.MenuItems[0].MenuItems[1].MenuItems[4].MenuItems.Add("Hierarchy", menuTDR2000Click);

            menu.MenuItems[0].MenuItems.Add("&Import");
            menu.MenuItems[0].MenuItems[2].MenuItems.Add("BRender ACT File...", menuClick);
            menu.MenuItems[0].MenuItems[2].MenuItems.Add("BRender DAT File...", menuClick);
            menu.MenuItems[0].MenuItems[2].MenuItems.Add("Stainless CNT File...", menuClick);
            menu.MenuItems[0].MenuItems[2].MenuItems.Add("Stainless MDL File...", menuClick);

            if (!bPublicRelease)
            {
                menu.MenuItems[0].MenuItems.Add("-");
                menu.MenuItems[0].MenuItems.Add("Save", menuClick);

                menu.MenuItems[0].MenuItems.Add("Save As...");
                menu.MenuItems[0].MenuItems[5].MenuItems.Add("Carmageddon Reincarnation");
                menu.MenuItems[0].MenuItems[5].MenuItems[0].MenuItems.Add("Environment", menuSaveAsClick);
            }

            menu.MenuItems[0].MenuItems.Add("-");
            menu.MenuItems[0].MenuItems.Add("E&xit", menuClick);

            menu.MenuItems.Add("&View");
            menu.MenuItems[1].MenuItems.Add("Preferences", menuViewClick);

            menu.MenuItems.Add("&Object");
            menu.MenuItems[2].MenuItems.Add("Rename", menuObjectClick);

            menu.MenuItems.Add("&Tools");
            menu.MenuItems[3].MenuItems.Add("Carma 2");
            menu.MenuItems[3].MenuItems[0].MenuItems.Add("Convert &&Actors to Entities", menuCarmageddon2Click);
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
                case "&New":
                    scene.Reset();
                    break;

                case "BRender ACT File...":
                    ofdBrowse.Filter = "BRender ACT files (*.act)|*.act";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        scene.Content.Load<Model, ACTImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);
                    }
                    break;

                case "BRender DAT File...":
                    ofdBrowse.Filter = "BRender DAT files (*.dat)|*.dat";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        scene.Content.Load<Model, DATImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);
                    }
                    break;

                case "Stainless CNT File...":
                    ofdBrowse.Filter = "Stainless CNT files (*.cnt)|*.cnt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        scene.Content.Load<Model, CNTImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);
                    }
                    break;

                case "Stainless MDL File...":
                    ofdBrowse.Filter = "Stainless MDL files (*.mdl)|*.mdl";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        scene.Content.Load<Model, MDLImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);
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

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        scene.Content.Load<Model, ACTImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);
                    }
                    break;

                case "Convert &&Actors to Entities":
                    if (scene.Models.Count == 0) { return; }

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

        private void menuCarmageddonMobileClick(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

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
                scene.Reset();
                scene.Content.Load<Model, CNTImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);
            }
        }

        private void menuCarmageddonReincarnationClick(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            switch (mi.Text)
            {
                case "Accessory":
                    ofdBrowse.Filter = "Carmageddon ReinCARnation Accessory files (accessory.cnt)|accessory.cnt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        scene.Reset();
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
                    processAll(mi.Text);
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
                    processAll(mi.Text);
                    break;
            }
        }

        private void processAll(string fileType)
        {
            string extension = fileType.Substring(0, fileType.IndexOf(' ')).ToLower();
            fbdBrowse.SelectedPath = (Properties.Settings.Default.LastBrowsedFolder != null ? Properties.Settings.Default.LastBrowsedFolder : Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));

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
                            case "cnt":
                                result = ToxicRagers.Stainless.Formats.CNT.Load(fi.FullName);
                                break;

                            case "mdl":
                                result = ToxicRagers.Stainless.Formats.MDL.Load(fi.FullName);
                                break;

                            case "mtl":
                                result = ToxicRagers.Stainless.Formats.MTL.Load(fi.FullName);
                                break;

                            case "tdx":
                                result = ToxicRagers.CarmageddonReincarnation.Formats.TDX.Load(fi.FullName);
                                break;

                            case "light":
                                result = ToxicRagers.CarmageddonReincarnation.Formats.LIGHT.Load(fi.FullName);
                                break;

                            case "xt2":
                                result = ToxicRagers.Novadrome.Formats.XT2.Load(fi.FullName);
                                break;

                            case "accessory.txt":
                                result = ToxicRagers.CarmageddonReincarnation.Formats.Accessory.Load(fi.FullName);
                                break;

                            case "routes.txt":
                                result = ToxicRagers.CarmageddonReincarnation.Formats.Routes.Load(fi.FullName);
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
            MenuItem mi = (MenuItem)sender;

            switch (mi.Text)
            {
                case "Hierarchy":
                    ofdBrowse.Filter = "TDR2000 Hierarchy (*.hie)|*.hie";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK && File.Exists(ofdBrowse.FileName))
                    {
                        scene.Reset();
                        scene.Content.Load<Model, ContentPipeline.TDR2000.HIEImporter>(Path.GetFileNameWithoutExtension(ofdBrowse.FileName), Path.GetDirectoryName(ofdBrowse.FileName), true);
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
                    var tdx = new frmTDXConvert();
                    tdx.Show(this);
                    break;
            }
        }

        private void tvNodes_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                //scene.Camera.ResetCamera();
                //scene.Camera.SetPosition(scene.Models[0].Bones[(int)e.Node.Tag].CombinedTransform.Position());
            }
        }

        private void tsmiViewportMaximise_Click(object sender, EventArgs e)
        {
            viewman.Maximise(viewman.Active);
        }

        private void tsmiViewportMinimise_Click(object sender, EventArgs e)
        {
            viewman.Minimise(viewman.Active);
        }

        private void tsmiViewportPreset_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            bActive = true;
        }

        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            bActive = false;
        }
    }
}
 