using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using WeifenLuo.WinFormsUI.Docking;

namespace Flummery
{
    public partial class pnlViewport : DockContent
    {
        public static GLControl Control;
        ViewportManager viewman;
        Stopwatch sw = new Stopwatch();
        double accumulator = 0;
        bool bRendered = false;

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

        public pnlViewport()
        {
            InitializeComponent();

            this.AllowEndUserDocking = false;
            this.TabText = "Untitled";
            this.CloseButton = false;
            this.CloseButtonVisible = false;
        }

        private void pnlViewport_Load(object sender, EventArgs e)
        {
            Control = new GLControl(new GraphicsMode(32, 24, 8, 4), 3, 0, GraphicsContextFlags.Default);
            Control.Name = "glcViewport";
            Control.VSync = true;
            Control.Width = 100;
            Control.Height = 100;
            Control.Dock = DockStyle.Fill;
            Control.Top = 3;
            Control.Left = 3;
            Control.BackColor = Color.Black;
            Control.Paint += glcViewport_Paint;
            Control.Resize += glcViewport_Resize;
            Control.MouseMove += glcViewport_MouseMove;
            Control.MouseEnter += glcViewport_MouseEnter;
            Control.MouseLeave += glcViewport_MouseLeave;
            Control.MouseWheel += glcViewport_MouseWheel;
            Control.Click += glcViewport_Click;
            this.paneViewport.Controls.Add(Control);

            GLControlInit();
            viewman = new ViewportManager();

            sw.Start();
            Application.Idle += new EventHandler(Application_Idle);

            viewman.Initialise();
        }

        private void GLControlInit()
        {
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
            GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);
            GL.Hint(HintTarget.PointSmoothHint, HintMode.Nicest);
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
            GL.ShadeModel(ShadingModel.Smooth);
            GL.PointSize(3.0f);
            GL.Enable(EnableCap.CullFace);
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
            if (!bRendered) { return; }

            viewman.MouseMove(e.X, e.Y);
        }

        void glcViewport_MouseWheel(object sender, MouseEventArgs e)
        {
            //viewman.MouseScroll(e);
        }

        private void glcViewport_Paint(object sender, PaintEventArgs e)
        {
            SceneManager.Current.Update((float)dt);
            viewman.Update((float)dt);
            Draw();
        }

        private void glcViewport_Resize(object sender, EventArgs e)
        {
            if (viewman != null) { viewman.Initialise(); }
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

        void Application_Idle(object sender, EventArgs e)
        {
            if (!Flummery.Active) { return; }

            double milliseconds = dt;

            accumulator += milliseconds;
            if (accumulator > 1000) { accumulator -= 1000; }

            Control.Invalidate();
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

            bRendered = true;
        }

        private void glcViewport_MouseEnter(object sender, EventArgs e)
        {
            ViewportManager.Current.HasFocus = true;
        }

        private void glcViewport_MouseLeave(object sender, EventArgs e)
        {
            ViewportManager.Current.HasFocus = false;
        }
    }
}
