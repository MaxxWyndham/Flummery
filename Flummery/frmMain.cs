using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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
        public frmMain()
        {
            InitializeComponent();
        }

        ContentManager Content = new ContentManager();
        SceneManager scene;

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
            this.Text += " v0.0.1.2";
            //title = this.Text;

            scene = new SceneManager(extensions.Contains("GL_ARB_vertex_buffer_object"));

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
            //if (nodes.Count == 0) { return; }

            //bool bAllVisibile = (nodes.Where(n => n.CanRender).Count() == nodes.Count);
            //int firstVisible = nodes.FindIndex(n => n.CanRender == true);

            //for (int i = 0; i < nodes.Count; i++) { nodes[i].CanRender = false; }

            //if (bAllVisibile)
            //{
            //    nodes[0].CanRender = true;
            //}
            //else if (firstVisible + 1 < nodes.Count)
            //{
            //    nodes[firstVisible + 1].CanRender = true;
            //}
            //else
            //{
            //    for (int i = 0; i < nodes.Count; i++) { nodes[i].CanRender = true; }
            //}
        }

        private void glcViewport_Load(object sender, EventArgs e)
        {

        }

        private void glcViewport_Resize(object sender, EventArgs e)
        {
            int w = glcViewport.Width;
            int h = glcViewport.Height;
            GL.Viewport(0, 0, w, h);

            float aspect_ratio = w / (float)h;

            OpenTK.Matrix4 perpective = OpenTK.Matrix4.CreatePerspectiveFieldOfView(OpenTK.MathHelper.PiOver4, aspect_ratio, 0.0001f, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perpective);
        }

        private void glcViewport_Paint(object sender, PaintEventArgs e) { Draw(); }

        private void Draw()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            OpenTK.Matrix4 lookat = OpenTK.Matrix4.LookAt(0, 2.5f, 8.0f, 0, 0.5f, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            // Fix for OpenGL LHS
            GL.Scale(1.0f, 1.0f, -1.0f);

            GL.Rotate(-rotation, OpenTK.Vector3.UnitY);

            scene.Draw();

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
            menu.MenuItems[0].MenuItems[1].MenuItems.Add("BRender DAT File...", menuClick);
            menu.MenuItems[0].MenuItems[1].MenuItems.Add("Stainless CNT File...", menuClick);
            menu.MenuItems[0].MenuItems[1].MenuItems.Add("Stainless MDL File...", menuClick);
            menu.MenuItems[0].MenuItems.Add("-");
            menu.MenuItems[0].MenuItems.Add("Save", menuClick);
            menu.MenuItems[0].MenuItems.Add("-");
            menu.MenuItems[0].MenuItems.Add("E&xit", menuClick);

            menu.MenuItems.Add("&Debug");
            menu.MenuItems[1].MenuItems.Add("Process...");
            menu.MenuItems[1].MenuItems[0].MenuItems.Add("XT2 file", menuNovadromeClick);
            menu.MenuItems[1].MenuItems.Add("Process all...");
            menu.MenuItems[1].MenuItems[1].MenuItems.Add("CNT files", menuCarmageddonReincarnationClick);
            menu.MenuItems[1].MenuItems[1].MenuItems.Add("MDL files", menuCarmageddonReincarnationClick);
            menu.MenuItems[1].MenuItems[1].MenuItems.Add("MTL files", menuCarmageddonReincarnationClick);
            menu.MenuItems[1].MenuItems[1].MenuItems.Add("TDX files", menuCarmageddonReincarnationClick);
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

                        Games.Loader.LoadContent(ofdBrowse.FileName, this, ref hints, ref nodes);

                        Properties.Settings.Default.FolderHints = hints;
                        Properties.Settings.Default.Save();
                    }
                    break;

                case "BRender DAT File...":
                    ofdBrowse.Filter = "BRender DAT files (*.dat)|*.dat";
                    ofdBrowse.ShowDialog();

                    if (ofdBrowse.FileName.Length > 0 && File.Exists(ofdBrowse.FileName))
                    {
                        var dat = ToxicRagers.Carmageddon2.Formats.DAT.Load(ofdBrowse.FileName);
                        if (dat == null) { return; }

                        foreach (DatMesh datmesh in dat.DatMeshes)
                        {
                            ToxicRagers.Helpers.Vector3[] vl = datmesh.Mesh.GetVertexList();
                            ToxicRagers.Helpers.Vector2[] uvl = datmesh.Mesh.GetUVList();

                            Vertex[] v = new Vertex[vl.Length];

                            for (int i = 0; i < v.Length; i++)
                            {
                                v[i].Position = new OpenTK.Vector3(vl[i].X, vl[i].Y, vl[i].Z);
                                //v[i].UV = new OpenTK.Vector2(uvl[i].X, uvl[i].Y);
                            }

                            //for (int i = 0; i < v.Length; i += 3)
                            //{
                            //    OpenTK.Vector3 v0 = v[i].Position;
                            //    OpenTK.Vector3 v1 = v[i + 1].Position;
                            //    OpenTK.Vector3 v2 = v[i + 2].Position;

                            //    OpenTK.Vector3 normal = OpenTK.Vector3.Normalize(OpenTK.Vector3.Cross(v2 - v0, v1 - v0));

                            //    v[i].Normal += normal;
                            //    v[i + 1].Normal += normal;
                            //    v[i + 2].Normal += normal;
                            //}

                            //for (int i = 0; i < v.Length; i++)
                            //{
                            //    v[i].Normal = OpenTK.Vector3.Normalize(v[i].Normal);
                            //}


                            //ToxicRagers.Stainless.Formats.MDL mdlxx = new ToxicRagers.Stainless.Formats.MDL();
                            //mdlxx.Materials.Add(new ToxicRagers.Stainless.Formats.MDLMaterial("BBlocks"));

                            //for (int i = 0; i < v.Length; i+=3)
                            //{
                            //    mdlxx.Faces.Add(new ToxicRagers.Stainless.Formats.MDLFace(0, i + 0, i + 1, i + 2));

                            //    mdlxx.Vertices.Add(new ToxicRagers.Stainless.Formats.MDLVertex(v[i + 0].Position.X, v[i + 0].Position.Y, v[i + 0].Position.Z, v[i + 0].Normal.X, v[i + 0].Normal.Y, v[i + 0].Normal.Z, v[i + 0].UV.X, v[i + 0].UV.Y, 0, 0, 0, 0, 0, 0));
                            //    mdlxx.Vertices.Add(new ToxicRagers.Stainless.Formats.MDLVertex(v[i + 1].Position.X, v[i + 1].Position.Y, v[i + 1].Position.Z, v[i + 1].Normal.X, v[i + 1].Normal.Y, v[i + 1].Normal.Z, v[i + 1].UV.X, v[i + 1].UV.Y, 0, 0, 0, 0, 0, 0));
                            //    mdlxx.Vertices.Add(new ToxicRagers.Stainless.Formats.MDLVertex(v[i + 2].Position.X, v[i + 2].Position.Y, v[i + 2].Position.Z, v[i + 2].Normal.X, v[i + 2].Normal.Y, v[i + 2].Normal.Z, v[i + 2].UV.X, v[i + 2].UV.Y, 0, 0, 0, 0, 0, 0));
                            //}

                            //mdlxx.Save(@"D:\FuckYeah.mdl");

                            //VertexBuffer vbo = new VertexBuffer(datmesh.Name);
                            //vbo.SetData(v, OpenTK.Graphics.OpenGL.PrimitiveType.Triangles);

                            //Node n = new Node(datmesh.Name, vbo);
                            //nodes.Add(n);
                        }
                    }
                    break;

                case "Stainless MDL File...":
                    ofdBrowse.Filter = "Stainless MDL files (*.mdl)|*.mdl";
                    ofdBrowse.ShowDialog();

                    if (ofdBrowse.FileName.Length > 0 && File.Exists(ofdBrowse.FileName))
                    {
                        Stopwatch t = new Stopwatch();
                        t.Start();
                        scene.Add(Flummery.ContentPipeline.Stainless.MDLImporter.Import(ofdBrowse.FileName));
                        t.Stop();
                        Console.WriteLine(t.Elapsed.Duration().ToString());

                        //var mdl = ToxicRagers.Stainless.Formats.MDL.Load(ofdBrowse.FileName);
                        //if (mdl == null) { return; }

                        //for (int j = 0; j < mdl.Materials.Count; j++)
                        //{
                        //    var vl = mdl.GetTriangleStrip(j);
                        //    Vertex[] v = new Vertex[vl.Count];

                        //    for (int i = 0; i < v.Length; i++)
                        //    {
                        //        v[i].Position = new OpenTK.Vector3(vl[i].Position.X, vl[i].Position.Y, vl[i].Position.Z);
                        //        v[i].Normal = new OpenTK.Vector3(vl[i].Normal.X, vl[i].Normal.Y, vl[i].Normal.Z);
                        //        v[i].UV = new OpenTK.Vector2(vl[i].UV.X, vl[i].UV.Y);
                        //    }

                        //    VertexBuffer vbo = new VertexBuffer(mdl.Name);
                        //    vbo.SetData(v);

                        //    Node n = new Node(mdl.Name, vbo);
                        //    nodes.Add(n);
                        //}
                    }
                    break;

                case "Save":
                    MessageBox.Show("[code goes here]");

                    //Bitmap bitmap = new Bitmap(@"F:\websites\toxic-ragers.co.uk\images\misc\novadrome_xt2_CONTROLLER360003.png");
                    //byte[] data = new byte[bitmap.Width*bitmap.Height*4];
                    //byte[] dest = new byte[Squish.Squish.GetStorageRequirements(bitmap.Width, bitmap.Height, Squish.SquishFlags.kDxt3 | Squish.SquishFlags.kColourIterativeClusterFit | Squish.SquishFlags.kWeightColourByAlpha)];

                    //int ii = 0;
                    //for (int y = 0; y < bitmap.Height; y++)
                    //{
                    //    for (int x = 0; x < bitmap.Width; x++)
                    //    {
                    //        var p = bitmap.GetPixel(x, y);
                    //        data[ii + 0] = p.R;
                    //        data[ii + 1] = p.G;
                    //        data[ii + 2] = p.B;
                    //        data[ii + 3] = p.A;

                    //        ii+=4;
                    //    }
                    //}

                    //Squish.Squish.CompressImage(data, bitmap.Width, bitmap.Height, ref dest, Squish.SquishFlags.kDxt3 | Squish.SquishFlags.kColourIterativeClusterFit | Squish.SquishFlags.kWeightColourByAlpha);
                    
                    //using (BinaryWriter bw = new BinaryWriter(new FileStream(@"D:\FuckYeah.dds", FileMode.Create)))
                    //{
                    //    bw.Write(dest);
                    //}

                    //MessageBox.Show("Done!");

                    //ToxicRagers.Stainless.Formats.MDL mdlx = new ToxicRagers.Stainless.Formats.MDL();
                    //mdlx.Materials.Add(new ToxicRagers.Stainless.Formats.MDLMaterial("AP_cardboardBox"));

                    //mdlx.Vertices.Add(new ToxicRagers.Stainless.Formats.MDLVertex(-5.0f, -5.0f, -5.0f, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0));
                    //mdlx.Vertices.Add(new ToxicRagers.Stainless.Formats.MDLVertex( 5.0f, -5.0f, -5.0f, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0));
                    //mdlx.Vertices.Add(new ToxicRagers.Stainless.Formats.MDLVertex( 5.0f, -5.0f,  5.0f, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0));
                    //mdlx.Vertices.Add(new ToxicRagers.Stainless.Formats.MDLVertex(-5.0f, -5.0f,  5.0f, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0));
                    //mdlx.Vertices.Add(new ToxicRagers.Stainless.Formats.MDLVertex(-5.0f,  5.0f, -5.0f, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0));
                    //mdlx.Vertices.Add(new ToxicRagers.Stainless.Formats.MDLVertex( 5.0f,  5.0f, -5.0f, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0));
                    //mdlx.Vertices.Add(new ToxicRagers.Stainless.Formats.MDLVertex( 5.0f,  5.0f,  5.0f, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0));
                    //mdlx.Vertices.Add(new ToxicRagers.Stainless.Formats.MDLVertex(-5.0f,  5.0f,  5.0f, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0));

                    //mdlx.Faces.Add(new ToxicRagers.Stainless.Formats.MDLFace(1, 0, 1, 4));
                    //mdlx.Faces.Add(new ToxicRagers.Stainless.Formats.MDLFace(1, 1, 5, 4));
                    //mdlx.Faces.Add(new ToxicRagers.Stainless.Formats.MDLFace(1, 1, 5, 2));
                    //mdlx.Faces.Add(new ToxicRagers.Stainless.Formats.MDLFace(1, 2, 5, 6));
                    //mdlx.Faces.Add(new ToxicRagers.Stainless.Formats.MDLFace(1, 2, 6, 7));
                    //mdlx.Faces.Add(new ToxicRagers.Stainless.Formats.MDLFace(1, 2, 7, 3));
                    //mdlx.Faces.Add(new ToxicRagers.Stainless.Formats.MDLFace(1, 3, 7, 0));
                    //mdlx.Faces.Add(new ToxicRagers.Stainless.Formats.MDLFace(1, 0, 3, 4));
                    //mdlx.Faces.Add(new ToxicRagers.Stainless.Formats.MDLFace(1, 0, 1, 2));
                    //mdlx.Faces.Add(new ToxicRagers.Stainless.Formats.MDLFace(1, 0, 2, 3));
                    //mdlx.Faces.Add(new ToxicRagers.Stainless.Formats.MDLFace(1, 4, 5, 6));
                    //mdlx.Faces.Add(new ToxicRagers.Stainless.Formats.MDLFace(1, 4, 6, 7));

                    //mdlx.Save(@"D:\FuckYeah.mdl");
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

                        Games.Loader.LoadContent(ofdBrowse.FileName, this, ref hints, ref nodes);

                        Properties.Settings.Default.FolderHints = hints;
                        Properties.Settings.Default.Save();
                    }
                    break;

                case "Pedestrian":
                    ofdBrowse.Filter = "Carmageddon ReinCARnation Pedestrians (bodyform.cnt)|bodyform.cnt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        string hints = (Properties.Settings.Default.FolderHints != null ? Properties.Settings.Default.FolderHints : "");

                        Games.Loader.LoadContent(ofdBrowse.FileName, this, ref hints, ref nodes);

                        Properties.Settings.Default.FolderHints = hints;
                        Properties.Settings.Default.Save();
                    }
                    break;

                case "Vehicle":
                    ofdBrowse.Filter = "Carmageddon ReinCARnation Vehicles (car.cnt)|car.cnt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        string hints = (Properties.Settings.Default.FolderHints != null ? Properties.Settings.Default.FolderHints : "");

                        content = Games.Loader.LoadContent(ofdBrowse.FileName, this, ref hints, ref nodes);

                        Properties.Settings.Default.FolderHints = hints;
                        Properties.Settings.Default.Save();
                    }
                    break;

                case "CNT files":
                case "MDL files":
                case "MTL files":
                case "TDX files":
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

                                    case "tdx":
                                        ToxicRagers.CarmageddonReincarnation.Formats.TDX.Load(fi.FullName);
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
                    ofdBrowse.Filter = "Novadrome Vehicles (carbody.cnt)|carbody.cnt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        string hints = (Properties.Settings.Default.FolderHints != null ? Properties.Settings.Default.FolderHints : "");
                        nodes.Clear();

                        Games.Loader.LoadContent(ofdBrowse.FileName, this, ref hints, ref nodes);

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
    }
}
 