using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public class Viewport
    {
        public enum Size
        {
            Full = 1,
            Half = 2
        }

        public enum Quadrant
        {
            BottomLeft = 0,
            BottomRight = 1,
            TopLeft = 2,
            TopRight = 3
        }

        public enum Mode
        {
            Orthographic,
            Perspective
        }

        bool bDisabled = false;
        string name;
        bool bActive;
        Camera camera;

        Size width = Size.Half;
        Size height = Size.Half;
        Quadrant position = Quadrant.BottomLeft;

        Size oldwidth;
        Size oldheight;
        Quadrant oldposition;
        
        Mode mode = Mode.Perspective;
        Vector3 axis = Vector3.UnitY;
        TextWriter tw;

        int x = 0;
        int y = 0;
        int w = 0;
        int h = 0;
        int vw = 0;
        int vh = 0;
        float aspect_ratio;
        Matrix4 perspective = Matrix4.Identity;

        public Camera Camera { get { return camera; } }

        public bool Enabled
        {
            get { return !bDisabled; }
            set { bDisabled = !value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Mode ProjectionMode
        {
            get { return mode; }
            set { mode = value; }
        }

        public Quadrant Position
        {
            get { return position; }
            set { position = value; }
        }

        public bool Maximised { get { return (width == Size.Full && height == Size.Full); } }

        public bool Active
        {
            get { return bActive; }
            set { bActive = value; }
        }

        public float Zoom { get { return Math.Max(0, Vector3.Multiply(camera.Position, axis).Length); } }
        public Vector3 ZoomAxis { set { axis = value; } }

        public Viewport()
        {
            camera = new Camera();
            tw = new TextWriter(vw, vh, 50, 20);
        }

        public bool IsActive(int x, int y)
        {
            y = frmMain.Control.Height - y;

            return (
                x > this.x &&
                x < this.x + vw &&
                y > this.y &&
                y < this.y + vh
            );
        }

        public bool RightClickLabel(MouseEventArgs e)
        {
            return (
                e.Button == MouseButtons.Right &&
                e.X > x &&
                e.X < x + 43 &&
                e.Y > (h - (y + vh)) &&
                e.Y < (h - (y + vh)) + 25
            );
        }

        public void Resize()
        {
            w = frmMain.Control.Width;
            h = frmMain.Control.Height;
            aspect_ratio = w / (float)h;

            perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect_ratio, 0.1f, 1000);

            int xo = ((int)position & 1);
            int yo = ((int)position & 2) >> 1;

            vw = (w / (int)width) - 2;
            vh = (h / (int)height) - 2;

            tw = new TextWriter(vw, vh, vw, vh);
            tw.AddLine(name, new PointF(5, 5), Brushes.Blue);

            x = (xo * 2) + 1 + (vw * xo);
            y = (yo * 2) + 1 + (vh * yo);
        }

        public void SetWidthHeightPosition(Size width = Size.Half, Size height = Size.Half, Quadrant position = Quadrant.BottomLeft)
        {
            oldwidth = this.width;
            oldheight = this.height;
            oldposition = this.position;

            this.width = width;
            this.height = height;
            this.position = position;
        }

        public void ResetWidthHeightPosition()
        {
            this.width = oldwidth;
            this.height = oldheight;
            this.position = oldposition;
        }

        public void Update(float dt)
        {
            tw.UpdateText();
            camera.Update(dt);
        }

        public void Draw(SceneManager scene)
        {
            if (bActive) { GL.ClearColor(Color.LightGray); } else { GL.ClearColor(Color.Gray); }

            if (mode == Mode.Orthographic) { perspective = Matrix4.CreateOrthographic((w * 0.001f) * Zoom, (h * 0.001f) * Zoom, 0.001f, 100); }

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
            GL.Enable(EnableCap.Texture2D);

            GL.Viewport(x, y, vw, vh);
            GL.Scissor(x, y, vw, vh);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            scene.Draw(camera);
        }

        public void DrawOverlay()
        {
            GL.Disable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Lighting);
            GL.Disable(EnableCap.Texture2D);

            GL.Viewport(x, y, vw, vh);
            GL.Scissor(x, y, vw, vh);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, vw, 0, vh, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            tw.Draw();

            GL.Begin(PrimitiveType.LineStrip);
            GL.Color4(Color.Blue);
            GL.LineWidth(1);

            GL.Vertex2(4, vh - 4); GL.Vertex2(42, vh - 4);
            GL.Vertex2(42, vh - 20); GL.Vertex2(4, vh - 20);
            GL.Vertex2(4, vh - 4);
            GL.End();

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Texture2D);
        }
    }
}
