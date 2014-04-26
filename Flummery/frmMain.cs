using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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

        SceneManager scene;

        Stopwatch sw = new Stopwatch();
        double accumulator = 0;

        int renderMode = 0;
        int[] renderModes = new int[] { 6914, 6913, 6912 };

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
            var extensions = new List<string>(GL.GetString(StringName.Extensions).Split(' '));
            this.Text += " v0.0.1.7";

            scene = new SceneManager(extensions.Contains("GL_ARB_vertex_buffer_object"));

            BuildMenu();
            GLControlInit();

            sw.Start();

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

                //OpenTK.Matrix4[] bones = new OpenTK.Matrix4[m.Bones.Count];
                //m.CopyAbsoluteBoneTransformsTo(bones);

                //for (int i = 0; i < bones.Length; i++)
                //{
                //    Console.WriteLine("{0}) {1}", i, m.Bones[i].Name);
                //    Console.WriteLine("{0}", bones[i]);
                //}

                TravelTree(m.Root.Children[0], ref ParentNode);

                tvNodes.Nodes[0].Expand();
                tvNodes.Nodes[0].Nodes[0].Expand();
            }
            else
            {
                var t = (e.Item as Texture);

                var mi = new MaterialItem();
                mi.MaterialName = t.Name;
                mi.SetThumbnail(((ToxicRagers.CarmageddonReincarnation.Formats.TDX)t.Tag).Decompress());

                flpMaterials.Controls.Add(mi);
            }
        }

        public static void TravelTree(ModelBone bone, ref TreeNode node)
        {
            //Console.WriteLine("{0}", bone.Name);
            //Console.WriteLine("{0}", bone.Transform);

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
        }

        void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case ',':
                    toggleNodesRender();
                    break;

                case '.':
                    renderMode++;
                    if (renderMode == renderModes.Length) { renderMode = 0; }
                    GL.PolygonMode(MaterialFace.FrontAndBack, (PolygonMode)renderModes[renderMode]);
                    break;

                default:
                //    Console.WriteLine((byte)e.KeyChar);
                    break;
            }
        }

        private void GLControlInit()
        {
            glcViewport.VSync = true;

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

        void Application_Idle(object sender, EventArgs e)
        {
            double milliseconds = dt;
            Accumulate(milliseconds);
            Animate(milliseconds);
        }

        private void Animate(double milliseconds)
        {
            glcViewport.Invalidate();
        }

        private void Accumulate(double milliseconds)
        {
            accumulator += milliseconds;
            if (accumulator > 1000) { accumulator -= 1000; }
        }

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

            OpenTK.Matrix4 perpective = OpenTK.Matrix4.CreatePerspectiveFieldOfView(OpenTK.MathHelper.PiOver4, aspect_ratio, 0.0001f, 640);
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
            menu.MenuItems[0].MenuItems[0].MenuItems[0].MenuItems.Add("Environment", menuCarmageddonReincarnationClick);
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
            menu.MenuItems[1].MenuItems[1].MenuItems.Add("LIGHT files", menuCarmageddonReincarnationClick);
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
                        //Games.Loader.LoadContent(ofdBrowse.FileName, this, ref hints, ref nodes);
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
                        scene.Add(Flummery.ContentPipeline.Stainless.MDLImporter.Import(ofdBrowse.FileName));
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

        private void openContent(string filter)
        {
            ofdBrowse.Filter = filter;

            if (ofdBrowse.ShowDialog() == DialogResult.OK)
            {
                scene.Add(scene.Content.Load<Model, CNTImporter>(ofdBrowse.FileName));
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
                    ofdBrowse.Filter = "Novadrome Vehicles (carbody.cnt)|carbody.cnt";

                    if (ofdBrowse.ShowDialog() == DialogResult.OK)
                    {
                        //Games.Loader.LoadContent(ofdBrowse.FileName, this, ref hints, ref nodes);
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

        private void tvNodes_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            MessageBox.Show(e.Node.Tag.ToString());
        }
    }
}
 