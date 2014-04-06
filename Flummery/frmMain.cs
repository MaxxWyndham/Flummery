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
        string title = "";

        int renderMode = 0;
        int[] renderModes = new int[] { 6914, 6913, 6912 };

        List<Node> nodes = new List<Node>();

        #region DeltaTime
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
        #endregion


        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text += " v0.0.0.8";
            title = this.Text;

            string version = GL.GetString(StringName.Version);

            txtDebug.Text += "OpenGL Version : " + GL.GetString(StringName.Version) + "\r\n";
            txtDebug.Text += "Colour Depth   : " + glcViewport.Context.GraphicsMode.ColorFormat.ToString() + "\r\n";
            txtDebug.Text += "Depth Buffer   : " + glcViewport.Context.GraphicsMode.Depth + "\r\n";
            txtDebug.Text += "Stencil        : " + glcViewport.Context.GraphicsMode.Stencil + "\r\n";
            txtDebug.Text += "Samples        : " + glcViewport.Context.GraphicsMode.Samples + "\r\n";
            txtDebug.Text += "Extensions     :\r\n";
            var extensions = new List<string>(GL.GetString(StringName.Extensions).Split(' '));
            foreach (var ext in extensions) { txtDebug.Text += ext + "\r\n"; }

            bVertexBuffer = extensions.Contains("GL_ARB_vertex_buffer_object");

            BuildMenu();
            GLControlInit();

            sw.Start();

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

        #region GLControlInit()
        private void GLControlInit()
        {
            glcViewport.VSync = true;

            GL.ClearColor(Color.CornflowerBlue);
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
            GL.ShadeModel(ShadingModel.Smooth);
            GL.PointSize(3.0f);
            GL.Enable(EnableCap.CullFace);
            GL.FrontFace(FrontFaceDirection.Cw);
            GL.PolygonMode(MaterialFace.FrontAndBack, (PolygonMode)renderModes[renderMode]);
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
        #endregion

        #region FPS and "animation"
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
                this.Text = title + " (" + idleCounter + ")";
                accumulator -= 1000;
                idleCounter = 0; 
            }
        }
        #endregion

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
            int w = 800;// glcViewport.Width;
            int h = 600;// glcViewport.Height;
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

            OpenTK.Matrix4 lookat = OpenTK.Matrix4.LookAt(0, 3.0f, 7.0f, 0, 1.0f, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
            GL.Scale(1.0f, 1.0f, -1.0f);

            GL.Rotate(-rotation, OpenTK.Vector3.UnitY);

            foreach (var node in nodes)
            {
                node.Render();
            }
            
            glcViewport.SwapBuffers();
        }

        #region Menu functionality
        private void BuildMenu()
        {
            MainMenu menu = new MainMenu();
            menu.MenuItems.Add("&File");
            menu.MenuItems[0].MenuItems.Add("&Open...", menuClick);
            menu.MenuItems[0].MenuItems[0].Shortcut = Shortcut.CtrlO;
            menu.MenuItems[0].MenuItems[0].MenuItems.Add("Carmageddon Reincarnation");
            menu.MenuItems[0].MenuItems[0].MenuItems[0].MenuItems.Add("Accessory", menuClick);
            menu.MenuItems[0].MenuItems[0].MenuItems[0].MenuItems.Add("Pedestrian", menuClick);
            menu.MenuItems[0].MenuItems[0].MenuItems[0].MenuItems.Add("Vehicle", menuClick);

            menu.MenuItems[0].MenuItems.Add("&Import");
            menu.MenuItems[0].MenuItems[1].MenuItems.Add("BRender ACT File...", menuClick);
            menu.MenuItems[0].MenuItems[1].MenuItems.Add("BRender DAT File...", menuClick);
            menu.MenuItems[0].MenuItems[1].MenuItems.Add("Reincarnation MDL File...", menuClick);
            menu.MenuItems[0].MenuItems.Add("-");
            menu.MenuItems[0].MenuItems.Add("E&xit", menuClick);

            menu.MenuItems.Add("&Debug");
            menu.MenuItems[1].MenuItems.Add("Process all...");
            menu.MenuItems[1].MenuItems[0].MenuItems.Add("CNT files", menuClick);
            menu.MenuItems[1].MenuItems[0].MenuItems.Add("MDL files", menuClick);
            menu.MenuItems[1].MenuItems[0].MenuItems.Add("MTL files", menuClick);

            this.Menu = menu;
        }

        private void menuClick(object sender, EventArgs e)
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

                        Games.CarmageddonReincarnation.Loader.LoadContent(ofdBrowse.FileName, this, ref hints, ref nodes);

                        Properties.Settings.Default.FolderHints = hints;
                        Properties.Settings.Default.Save();
                    }
                    break;

                //case "Carmageddon 1 Car...":
                //    ofdBrowse.Filter = "Carmageddon Car Files (*.txt)|*.txt|All Files (*.*)|*.*";
                //    ofdBrowse.ShowDialog();

                //    if (ofdBrowse.FileName.Length > 0 && File.Exists(ofdBrowse.FileName))
                //    {
                //        FileInfo fi = new FileInfo(ofdBrowse.FileName);
                //        c1Car c = new c1Car(fi.Name.Replace(fi.Extension, ""));
                //        c.Load(fi.FullName, false);

                //        tvOverview.Nodes.Clear();
                //        tvOverview.Nodes.Add("Actors");
                //        TreeNode ParentNode;

                //        foreach (c2Act act in c.Actors)
                //        {
                //            ParentNode = tvOverview.Nodes[0];

                //            foreach (Actor A in act.Actors)
                //            {
                //                switch (A.Section)
                //                {
                //                    case Actor.Sections.Name:
                //                        ParentNode = ParentNode.Nodes.Add(A.Name);
                //                        break;

                //                    case Actor.Sections.SubLevelEnd:
                //                        ParentNode = ParentNode.Parent;
                //                        break;
                //                }
                //            }
                //        }

                //        tvOverview.Nodes[0].ExpandAll();

                //        //c.Models[0].DatMeshes[0].Mesh.GetIndexList();
                //        foreach (c2Dat dat in c.Models)
                //        {
                //            foreach (DatMesh datmesh in dat.DatMeshes)
                //            {
                //                ToxicRagers.Helpers.Vector3[] vl = datmesh.Mesh.GetVertexList();
                //                ToxicRagers.Helpers.Vector2[] uvl = datmesh.Mesh.GetUVList();

                //                Vertex[] v = new Vertex[vl.Length];

                //                for (int i = 0; i < v.Length; i++)
                //                {
                //                    v[i].Position = new OpenTK.Vector3(vl[i].X, vl[i].Y, vl[i].Z);
                //                    v[i].UV = new OpenTK.Vector2(uvl[i].X, uvl[i].Y);
                //                }

                //                for (int i = 0; i < v.Length; i += 3)
                //                {
                //                    OpenTK.Vector3 v0 = v[i].Position;
                //                    OpenTK.Vector3 v1 = v[i + 1].Position;
                //                    OpenTK.Vector3 v2 = v[i + 2].Position;

                //                    OpenTK.Vector3 normal = OpenTK.Vector3.Normalize(OpenTK.Vector3.Cross(v2 - v0, v1 - v0));

                //                    v[i].Normal += normal;
                //                    v[i + 1].Normal += normal;
                //                    v[i + 2].Normal += normal;
                //                }

                //                for (int i = 0; i < v.Length; i++)
                //                {
                //                    v[i].Normal = OpenTK.Vector3.Normalize(v[i].Normal);
                //                }

                //                VertexBuffer vbo = new VertexBuffer(datmesh.Name);
                //                vbo.SetData(v);

                //                Node n = new Node(datmesh.Name, vbo);
                //                nodes.Add(n);
                //            }
                //        }

                //        pgSettings.SelectedObject = c;

                //    }
                //    break;

                case "Reincarnation MDL File...":
                    ofdBrowse.Filter = "Carmageddon Reincarnation MDL files (*.mdl)|*.mdl|All Files (*.*)|*.*";
                    ofdBrowse.ShowDialog();

                    if (ofdBrowse.FileName.Length > 0 && File.Exists(ofdBrowse.FileName))
                    {
                        var mdl = ToxicRagers.CarmageddonReincarnation.Formats.MDL.Load(ofdBrowse.FileName);
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
                            vbo.SetData(v);

                            Node n = new Node(mdl.Name, vbo);
                            nodes.Add(n);
                        }
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
                                        ToxicRagers.CarmageddonReincarnation.Formats.CNT.Load(fi.FullName);
                                        break;

                                    case "mdl":
                                        ToxicRagers.CarmageddonReincarnation.Formats.MDL.Load(fi.FullName);
                                        break;

                                    case "mtl":
                                        ToxicRagers.CarmageddonReincarnation.Formats.MTL.Load(fi.FullName);
                                        break;
                                }
                            }
                        }
                        );

                        MessageBox.Show("Done!");
                    }
                    break;

                case "E&xit":
                    Application.Exit();
                    break;

                default:
                    MessageBox.Show("[code goes here]");
                    break;
            }
        }
        #endregion

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
    }

    #region Vertex

    #endregion

}
 