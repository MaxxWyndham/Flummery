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
    public partial class PnlViewport : DockContent
    {
        public static GLControl Control;
        ViewportManager viewman;
        Stopwatch sw = new Stopwatch();
        double accumulator = 0;
        bool bRendered = false;

        private double Dt
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

        public PnlViewport()
        {
            InitializeComponent();

            AllowEndUserDocking = false;
            TabText = "Untitled";
            CloseButton = false;
            CloseButtonVisible = false;

            UpdateKeyboardShortcuts();
        }

        public void RegisterEventHandlers()
        {
            InputManager.Current.OnBindingsChanged += input_OnBindingsChanged;
            //SceneManager.Current.OnContextChange += scene_OnContextChage;
        }

        private void scene_OnContextChage(object sender, ContextChangeEventArgs e)
        {
            tslContext.Text = $"{e.GameContext.ToString().Replace("_", " ")} : {e.ModeContext}";
        }

        void input_OnBindingsChanged(object sender, EventArgs e)
        {
            UpdateKeyboardShortcuts();
        }

        public void UpdateKeyboardShortcuts()
        {
            tsbSelect.ToolTipText = $"{tsbSelect.Text} ({Properties.Settings.Default.KeysCameraSelect})";
            tsbPan.ToolTipText = $"{tsbPan.Text} ({Properties.Settings.Default.KeysCameraPan})";
            tsbZoom.ToolTipText = $"{tsbZoom.Text} ({Properties.Settings.Default.KeysCameraZoom})";
            tsbRotate.ToolTipText = $"{tsbRotate.Text} ({Properties.Settings.Default.KeysCameraRotate})";
            tsbFrame.ToolTipText = $"{tsbFrame.Text} ({Properties.Settings.Default.KeysCameraFrame})";
        }

        private void pnlViewport_Load(object sender, EventArgs e)
        {
            Control = new GLControl(new GraphicsMode(32, 24, 8, 4), 3, 0, GraphicsContextFlags.Default)
            {
                Name = "glcViewport",
                VSync = true,
                Width = 100,
                Height = 100,
                Dock = DockStyle.Fill,
                Top = 3,
                Left = 3,
                BackColor = Color.Black
            };

            Control.Paint += glcViewport_Paint;
            Control.Resize += glcViewport_Resize;
            Control.MouseMove += glcViewport_MouseMove;
            Control.MouseDown += glcViewport_MouseDown;
            Control.MouseUp += glcViewport_MouseUp;
            Control.MouseEnter += glcViewport_MouseEnter;
            Control.MouseLeave += glcViewport_MouseLeave;
            Control.MouseWheel += glcViewport_MouseWheel;
            Control.Click += glcViewport_Click;
            paneViewport.Controls.Add(Control);

            gLControlInit();
            viewman = new ViewportManager();

            sw.Start();
            Application.Idle += new EventHandler(application_Idle);

            viewman.Initialise();

            InputManager.Current.RegisterBinding(Properties.Settings.Default.KeysCameraSelect, KeyBinding.KeysCameraSelect, SetModeSelect);
            InputManager.Current.RegisterBinding(Properties.Settings.Default.KeysCameraPan, KeyBinding.KeysCameraPan, SetModePan);
            InputManager.Current.RegisterBinding(Properties.Settings.Default.KeysCameraZoom, KeyBinding.KeysCameraZoom, SetModeZoom);
            InputManager.Current.RegisterBinding(Properties.Settings.Default.KeysCameraRotate, KeyBinding.KeysCameraRotate, SetModeRotate);
        }

        private void gLControlInit()
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
            MouseEventArgs mouse = (MouseEventArgs)e;

            if (viewman.Active.RightClickLabel(mouse))
            {
                foreach (ToolStripItem item in cmsViewport.Items)
                {
                    ToolStripMenuItem entry = (item as ToolStripMenuItem);
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
            viewman.MouseUp(e.X, e.Y);
        }

        void glcViewport_MouseWheel(object sender, MouseEventArgs e)
        {
            viewman.MouseScroll(e.Delta);
        }

        private void glcViewport_Paint(object sender, PaintEventArgs e)
        {
            SceneManager.Current.Update((float)Dt);
            viewman.Update((float)Dt);
            draw();
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

        void application_Idle(object sender, EventArgs e)
        {
            if (!FlummeryApplication.Active) { return; }

            double milliseconds = Dt;

            accumulator += milliseconds;
            if (accumulator > 1000) { accumulator -= 1000; }

            Control.Invalidate();
        }

        private void draw()
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
            setMode(MouseMode.Select);
        }

        public void SetModePan()
        {
            setMode(MouseMode.Pan);
        }

        public void SetModeZoom()
        {
            setMode(MouseMode.Zoom);
        }

        public void SetModeRotate()
        {
            setMode(MouseMode.Rotate);
        }

        private void setMode(MouseMode mode)
        {
            tsbSelect.Checked = false;
            tsbPan.Checked = false;
            tsbZoom.Checked = false;
            tsbRotate.Checked = false;

            viewman.Mode = mode;
            ((ToolStripButton)tsStatic.Items.Find("tsb" + mode.ToString(), true)[0]).Checked = true;
        }

        private void tsbFrame_Click(object sender, EventArgs e)
        {
            viewman.Frame();
        }

        private void tslContext_Click(object sender, EventArgs e)
        {
            (new frmChangeContext()).ShowDialog(this);
        }
    }
}