using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.WinForms;
using OpenTK.Windowing.Common;

using WeifenLuo.WinFormsUI.Docking;

using Flummery.Core;


namespace Flummery
{
    public partial class PnlViewport : DockContent
    {
        public static GLControl Control;
        ViewportManager viewman;
        readonly Stopwatch sw = new Stopwatch();
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
            SceneManager.Current.OnContextChange += scene_OnContextChage;
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
            //tsbSelect.ToolTipText = $"{tsbSelect.Text} ({Properties.Settings.Default.KeysCameraSelect})";
            //tsbPan.ToolTipText = $"{tsbPan.Text} ({Properties.Settings.Default.KeysCameraPan})";
            //tsbZoom.ToolTipText = $"{tsbZoom.Text} ({Properties.Settings.Default.KeysCameraZoom})";
            //tsbRotate.ToolTipText = $"{tsbRotate.Text} ({Properties.Settings.Default.KeysCameraRotate})";
            //tsbFrame.ToolTipText = $"{tsbFrame.Text} ({Properties.Settings.Default.KeysCameraFrame})";
        }

        private void pnlViewport_Load(object sender, EventArgs e)
        {
            // new GraphicsMode(32, 24, 8, 4), 3, 0, GraphicsContextFlags.Default

            Control = new GLControl()
            {
                Name = "glcViewport",
                //VSync = true,
                Width = 100,
                Height = 100,
                Dock = DockStyle.Fill,
                Top = 3,
                Left = 3,
                BackColor = Color.Black,
                Profile = ContextProfile.Compatability
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

            viewman.Initialise(Control.Width, Control.Height);

            InputManager.Current.RegisterInputAction(SetModeSelect, "CameraModeSelect", "Activates the Camera Select mode", "Camera Controls");
            InputManager.Current.RegisterInputAction(SetModePan, "CameraModePan", "Activates the Camera Pan mode", "Camera Controls");
            InputManager.Current.RegisterInputAction(SetModeZoom, "CameraModeZoom", "Activates the Camera Zoom mode", "Camera Controls");
            InputManager.Current.RegisterInputAction(SetModeRotate, "CameraModeRotate", "Activates the Camera Rotate mode", "Camera Controls");
        }

        private void gLControlInit()
        {

        }

        private void glcViewport_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            MouseEvent mouse = new MouseEvent { X = me.X, Y = me.Y, Button = (Core.MouseButtons)me.Button };

            if (viewman.Active.RightClickLabel(mouse))
            {
                foreach (ToolStripItem item in cmsViewport.Items)
                {
                    if (!(item is ToolStripMenuItem entry)) { continue; }

                    entry.Checked = entry.Text == viewman.Active.Name;

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

        void glcViewport_MouseDown(object sender, MouseEventArgs e)
        {
            if (!bRendered) { return; }

            viewman.MouseDown(e.X, e.Y);
        }

        void glcViewport_MouseUp(object sender, MouseEventArgs e)
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
            if (viewman != null) { viewman.Initialise(Control.Width, Control.Height); }
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
            SceneManager.Current.Renderer.Disable("ScissorTest");
            SceneManager.Current.Renderer.ClearColor(Color.Blue);
            SceneManager.Current.Renderer.Viewport(0, 0, Control.Width, Control.Height);
            SceneManager.Current.Renderer.Clear("ColorBufferBit", "DepthBufferBit");
            SceneManager.Current.Renderer.Enable("ScissorTest");

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
            new frmChangeContext().ShowDialog(this);
        }
    }
}