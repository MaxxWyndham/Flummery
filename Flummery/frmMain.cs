using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

using ToxicRagers.Carmageddon.Helpers;
using ToxicRagers.Carmageddon2.Formats;

namespace Flummery
{
    public partial class frmMain : Form
    {
        #region Constructors
        public frmMain()
        {
            InitializeComponent();
        }
        #endregion

        public static bool bVertexBuffer = false;

        Stopwatch sw = new Stopwatch();
        Single rotation = 0;
        double accumulator = 0;
        int idleCounter = 0;
//        string title = "";

        int renderMode = 0;
        int[] renderModes = new int[] { 6914, 6913, 6912 };

        List<Node> nodes = new List<Node>();

        public ToxicRagers.Stainless.Formats.CNT content;

//        #region DeltaTime
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
//        #endregion


        private void frmMain_Load(object sender, EventArgs e)
        {
            var extensions = new List<string>(GL.GetString(StringName.Extensions).Split(' '));
            this.Text += " v0.0.1.0";
            //title = this.Text;

            bVertexBuffer = extensions.Contains("GL_ARB_vertex_buffer_object");

            BuildMenu();
            GLControlInit();

            //sw.Start();

            Application.Idle += new EventHandler(Application_Idle);

            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(frmMain_KeyPress);
        }

        void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)44:  // ,
                    toggleNodesRender();
                    break;

                case (char)46:  // .
                    renderMode++;
                    if (renderMode == renderModes.Length) { renderMode = 0; }
                    GL.PolygonMode(MaterialFace.FrontAndBack, (PolygonMode)renderModes[renderMode]);
                    break;

                default:
                    Console.WriteLine((byte)e.KeyChar);
                    break;
            }
        }

        private void GLControlInit()
        {
            //glcViewport.VSync = true;

            GL.ClearColor(Color.Gray);
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
            GL.ShadeModel(ShadingModel.Smooth);
            GL.PointSize(3.0f);
            GL.Enable(EnableCap.CullFace);
            GL.FrontFace(FrontFaceDirection.Cw);
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

//        #region FPS and "animation"
        void Application_Idle(object sender, EventArgs e)
        {
            double milliseconds = dt;
            Accumulate(milliseconds);
            Animate(milliseconds);
        }

        private void Animate(double milliseconds)
        {
            float deltaRotation = (float)milliseconds / 20.0f;
            rotation += deltaRotation;
            glcViewport.Invalidate();
        }

        private void Accumulate(double milliseconds)
        {
            idleCounter++;
            accumulator += milliseconds;
            if (accumulator > 1000)
            {
                //this.Text = title + " (" + idleCounter + ")";
                accumulator -= 1000;
                idleCounter = 0;
            }
        }
//        #endregion

        private void toggleNodesRender()
        {
            if (nodes.Count == 0) { return; }

            bool bAllVisibile = (nodes.Where(n => n.CanRender).Count() == nodes.Count);
            int firstVisible = nodes.FindIndex(n => n.CanRender == true);

            for (int i = 0; i < nodes.Count; i++) { nodes[i].CanRender = false; }

            if (bAllVisibile)
            {
                nodes[0].CanRender = true;
            }
            else if (firstVisible + 1 < nodes.Count)
            {
                nodes[firstVisible + 1].CanRender = true;
            }
            else
            {
                for (int i = 0; i < nodes.Count; i++) { nodes[i].CanRender = true; }
            }
        }

        private void glcViewport_Load(object sender, EventArgs e)
        {
            int w = glcViewport.Width;
            int h = glcViewport.Height;
            GL.Viewport(0, 0, w, h);

            float aspect_ratio = w / (float)h;

            OpenTK.Matrix4 perpective = OpenTK.Matrix4.CreatePerspectiveFieldOfView(OpenTK.MathHelper.PiOver4, aspect_ratio, 0.0001f, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perpective);
        }

        private void glcViewport_Paint(object sender, PaintEventArgs e) { Render(); }

        private void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            OpenTK.Matrix4 lookat = OpenTK.Matrix4.LookAt(0, 2.5f, 8.0f, 0, 0.5f, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            // Fix for OpenGL LHS
            GL.Scale(1.0f, 1.0f, -1.0f);

            GL.Rotate(-rotation, OpenTK.Vector3.UnitY);

            foreach (var node in nodes)
            {
                node.Render();
            }

            glcViewport.SwapBuffers();
        }

        private void BuildMenu()
        {
            MainMenu menu = new MainMenu();
            menu.MenuItems.Add("&File");
            menu.MenuItems[0].MenuItems.Add("&Open...", menuClick);
            menu.MenuItems[0].MenuItems[0].Shortcut = Shortcut.CtrlO;
            menu.MenuItems[0].MenuItems[0].MenuItems.Add("Carmageddon Reincarnation");
            menu.MenuItems[0].MenuItems[0].MenuItems[0].MenuItems.Add("Accessory", menuCarmageddonReincarnationClick);
            menu.MenuItems[0].MenuItems[0].MenuItems[0].MenuItems.Add("Pedestrian", menuCarmageddonReincarnationClick);
            menu.MenuItems[0].MenuItems[0].MenuItems[0].MenuItems.Add("Vehicle", menuCarmageddonReincarnationClick);
            menu.MenuItems[0].MenuItems[0].MenuItems.Add("Novadrome");
            menu.MenuItems[0].MenuItems[0].MenuItems[1].MenuItems.Add("Vehicle", menuNovadromeClick);

            menu.MenuItems[0].MenuItems.Add("&Import");
            //menu.MenuItems[0].MenuItems[1].MenuItems.Add("BRender ACT File...", menuClick);
            //menu.MenuItems[0].MenuItems[1].MenuItems.Add("BRender DAT File...", menuClick);
            menu.MenuItems[0].MenuItems[1].MenuItems.Add("Stainless CNT File...", menuClick);
            menu.MenuItems[0].MenuItems[1].MenuItems.Add("Stainless MDL File...", menuClick);
            menu.MenuItems[0].MenuItems.Add("-");
            menu.MenuItems[0].MenuItems.Add("E&xit", menuClick);

            menu.MenuItems.Add("&Debug");
            menu.MenuItems[1].MenuItems.Add("Process...");
            menu.MenuItems[1].MenuItems[0].MenuItems.Add("XT2 file", menuNovadromeClick);
            menu.MenuItems[1].MenuItems.Add("Process all...");
            menu.MenuItems[1].MenuItems[1].MenuItems.Add("CNT files", menuCarmageddonReincarnationClick);
            menu.MenuItems[1].MenuItems[1].MenuItems.Add("MDL files", menuCarmageddonReincarnationClick);
            menu.MenuItems[1].MenuItems[1].MenuItems.Add("MTL files", menuCarmageddonReincarnationClick);
            menu.MenuItems[1].MenuItems[1].MenuItems.Add("XT2 files", menuNovadromeClick);

            this.Menu = menu;
        }

        private void menuClick(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            switch (mi.Text)
            {
                case "Stainless CNT File...":
                    ofdBrowse.Filter = "Stainless CNT files (*.cnt)|*.cnt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        string hints = (Properties.Settings.Default.FolderHints != null ? Properties.Settings.Default.FolderHints : "");

                        Games.Novadrome.Loader.LoadContent(ofdBrowse.FileName, this, ref hints, ref nodes);

                        Properties.Settings.Default.FolderHints = hints;
                        Properties.Settings.Default.Save();
                    }
                    break;

                case "Stainless MDL File...":
                    ofdBrowse.Filter = "Stainless MDL files (*.mdl)|*.mdl";
                    ofdBrowse.ShowDialog();

                    if (ofdBrowse.FileName.Length > 0 && File.Exists(ofdBrowse.FileName))
                    {
                        var mdl = ToxicRagers.Stainless.Formats.MDL.Load(ofdBrowse.FileName);
                        if (mdl == null) { return; }

                        for (int j = 0; j < mdl.Materials.Count; j++)
                        {
                            var vl = mdl.GetTriangleStrip(j);
                            Vertex[] v = new Vertex[vl.Count];

                            for (int i = 0; i < v.Length; i++)
                            {
                                v[i].Position = new OpenTK.Vector3(vl[i].Position.X, vl[i].Position.Y, vl[i].Position.Z);
                                v[i].Normal = new OpenTK.Vector3(vl[i].Normal.X, vl[i].Normal.Y, vl[i].Normal.Z);
                                v[i].UV = new OpenTK.Vector2(vl[i].UV.X, vl[i].UV.Y);
                            }

                            VertexBuffer vbo = new VertexBuffer(mdl.Name);
                            vbo.SetData(v, (mdl.GetMaterialMode(j) == "trianglestrip" ? OpenTK.Graphics.OpenGL.PrimitiveType.TriangleStrip : OpenTK.Graphics.OpenGL.PrimitiveType.Triangles));

                            Node n = new Node(mdl.Name, vbo);
                            nodes.Add(n);
                        }
                    }
                    break;

                case "E&xit":
                    Application.Exit();
                    break;
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
                        string hints = (Properties.Settings.Default.FolderHints != null ? Properties.Settings.Default.FolderHints : "");

                        Games.CarmageddonReincarnation.Loader.LoadContent(ofdBrowse.FileName, this, ref hints, ref nodes);

                        Properties.Settings.Default.FolderHints = hints;
                        Properties.Settings.Default.Save();
                    }
                    break;

                case "Pedestrian":
                    ofdBrowse.Filter = "Carmageddon ReinCARnation Pedestrians (bodyform.cnt)|bodyform.cnt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        string hints = (Properties.Settings.Default.FolderHints != null ? Properties.Settings.Default.FolderHints : "");

                        Games.CarmageddonReincarnation.Loader.LoadContent(ofdBrowse.FileName, this, ref hints, ref nodes);

                        Properties.Settings.Default.FolderHints = hints;
                        Properties.Settings.Default.Save();
                    }
                    break;

                case "Vehicle":
                    ofdBrowse.Filter = "Carmageddon ReinCARnation Vehicles (car.cnt)|car.cnt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        string hints = (Properties.Settings.Default.FolderHints != null ? Properties.Settings.Default.FolderHints : "");

                        content = Games.CarmageddonReincarnation.Loader.LoadContent(ofdBrowse.FileName, this, ref hints, ref nodes);

                        Properties.Settings.Default.FolderHints = hints;
                        Properties.Settings.Default.Save();
                    }
                    break;

                case "CNT files":
                case "MDL files":
                case "MTL files":
                    string extension = mi.Text.Substring(0, 3).ToLower();
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
                                }
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
                    ofdBrowse.Filter = "Novadrome Vehicles (carbody.cnt)|carbody.cnt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        string hints = (Properties.Settings.Default.FolderHints != null ? Properties.Settings.Default.FolderHints : "");
                        nodes.Clear();

                        Games.Novadrome.Loader.LoadContent(ofdBrowse.FileName, this, ref hints, ref nodes);

                        Properties.Settings.Default.FolderHints = hints;
                        Properties.Settings.Default.Save();
                    }
                    break;

                case "XT2 file":
                    ToxicRagers.Novadrome.Formats.XT2.Load(@"F:\Novadrome_Demo\Novadrome_Demo\WADs\data\DATA\TEXTURES\LEVEL1_BRONZE.XT2");
                    ToxicRagers.Novadrome.Formats.XT2.Load(@"F:\Novadrome_Demo\Novadrome_Demo\WADs\data\DATA\FRONTEND\CONTROLLER360.XT2");
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

        public bool TryLoadOrFindFile(string Filename, string FileType, string FileExtension, out string FilePath, params string[] hints)
        {
            var FileNames = Filename.Split(';');

            foreach (string file in FileNames)
            {
                foreach (string hint in hints)
                {
                    FilePath = hint + "\\" + file;

                    if (File.Exists(hint + "\\" + file)) { return true; }
                }
            }

            ofdBrowse.FileName = "";
            ofdBrowse.Filter = Filename + "|" + Filename + "|" + FileType + " (" + FileExtension + ")|" + FileExtension;
            if (ofdBrowse.ShowDialog() == DialogResult.OK)
            {
                FilePath = ofdBrowse.FileName;
                return true;
            }

            FilePath = null;
            return false;
        }

//        public ToxicRagers.CarmageddonReincarnation.Formats.CNT nodeCNT;
    }

//    #region Vertex

//    #endregion

}
 