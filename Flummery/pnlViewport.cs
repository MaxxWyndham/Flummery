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

            UpdateKeyboardShortcuts();
        }

        public void RegisterEventHandlers()
        {
            InputManager.Current.OnBindingsChanged += input_OnBindingsChanged;
        }

        void input_OnBindingsChanged(object sender, EventArgs e)
        {
            UpdateKeyboardShortcuts();
        }

        public void UpdateKeyboardShortcuts()
        {
            this.tsbSelect.ToolTipText = string.Format("{0} ({1})", this.tsbSelect.Text, Properties.Settings.Default.KeysCameraSelect);
            this.tsbPan.ToolTipText = string.Format("{0} ({1})", this.tsbPan.Text, Properties.Settings.Default.KeysCameraPan);
            this.tsbZoom.ToolTipText = string.Format("{0} ({1})", this.tsbZoom.Text, Properties.Settings.Default.KeysCameraZoom);
            this.tsbRotate.ToolTipText = string.Format("{0} ({1})", this.tsbRotate.Text, Properties.Settings.Default.KeysCameraRotate);
            this.tsbFrame.ToolTipText = string.Format("{0} ({1})", this.tsbFrame.Text, Properties.Settings.Default.KeysCameraFrame);
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
            Control.MouseDown += glcViewport_MouseDown;
            Control.MouseUp += glcViewport_MouseUp;
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

            InputManager.Current.RegisterBinding(Properties.Settings.Default.KeysCameraSelect, KeyBinding.KeysCameraSelect, SetModeSelect);
            InputManager.Current.RegisterBinding(Properties.Settings.Default.KeysCameraPan, KeyBinding.KeysCameraPan, SetModePan);
            InputManager.Current.RegisterBinding(Properties.Settings.Default.KeysCameraZoom, KeyBinding.KeysCameraZoom, SetModeZoom);
            InputManager.Current.RegisterBinding(Properties.Settings.Default.KeysCameraRotate, KeyBinding.KeysCameraRotate, SetModeRotate);
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

        void glcViewport_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!bRendered) { return; }
            viewman.MouseDown(e.X, e.Y);
        }

        void glcViewport_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!bRendered) { return; }
            viewman.MouseUp( e.X, e.Y);
        }

        void glcViewport_MouseWheel(object sender, MouseEventArgs e)
        {
            viewman.MouseScroll(e.Delta);
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

            if (Control == null)
            {
                Console.WriteLine();
            }

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

        private void tsbSelect_Click(object sender, EventArgs e)
        {
            tsbSelect.Checked = true;
            tsbPan.Checked = false;
            tsbZoom.Checked = false;
            tsbRotate.Checked = false;

            viewman.Mode = MouseMode.Select;
        }

        private void tsbPan_Click(object sender, EventArgs e)
        {
            tsbSelect.Checked = false;
            tsbPan.Checked = true;
            tsbZoom.Checked = false;
            tsbRotate.Checked = false;

            viewman.Mode = MouseMode.Pan;
        }

        private void tsbZoom_Click(object sender, EventArgs e)
        {
            tsbSelect.Checked = false;
            tsbPan.Checked = false;
            tsbZoom.Checked = true;
            tsbRotate.Checked = false;

            viewman.Mode = MouseMode.Zoom;
        }

        private void tsbRotate_Click(object sender, EventArgs e)
        {
            tsbSelect.Checked = false;
            tsbPan.Checked = false;
            tsbZoom.Checked = false;
            tsbRotate.Checked = true;

            viewman.Mode = MouseMode.Rotate;
        }

        public void SetModeSelect()
        {
            SetMode(MouseMode.Select);
        }

        public void SetModePan()
        {
            SetMode(MouseMode.Pan);
        }

        public void SetModeZoom()
        {
            SetMode(MouseMode.Zoom);
        }

        public void SetModeRotate()
        {
            SetMode(MouseMode.Rotate);
        }

        private void SetMode(MouseMode mode)
        {
            tsbSelect.Checked = false;
            tsbPan.Checked = false;
            tsbZoom.Checked = false;
            tsbRotate.Checked = false;

            viewman.Mode = mode;
            ((ToolStripButton)this.tsStatic.Items.Find("tsb" + mode.ToString(), true)[0]).Checked = true;
        }

        private void tsbFrame_Click(object sender, EventArgs e)
        {
            viewman.Frame();
        }
    }
}
