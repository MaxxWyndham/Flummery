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

        Projection mode = Projection.Perspective;
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

        public Projection ProjectionMode
        {
            get { return mode; }
            set 
            { 
                mode = value;
                camera.ProjectionMode = mode;
            }
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

        public Viewport()
        {
            camera = new Camera() { ProjectionMode = mode, Zoom = 2 };
            tw = new TextWriter(vw, vh, 50, 20);
        }

        public bool IsActive(int x, int y)
        {
            y = pnlViewport.Control.Height - y;

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

        public Vector3 ConvertScreenToWorldCoords(int X, int Y)
        {
            if (mode != Projection.Orthographic) { return Vector3.Zero; }

            var m = SceneManager.Current.Transform;

            Matrix4 lookat = camera.viewMatrix;
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
            GL.MultMatrix(ref m);

            perspective = Matrix4.CreateOrthographic(4 * camera.Zoom, (4 / aspect_ratio) * camera.Zoom, 0.001f, 1000);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            int[] viewport = new int[4];
            Matrix4 modelViewMatrix, projectionMatrix;
            GL.GetFloat(GetPName.ModelviewMatrix, out modelViewMatrix);
            GL.GetFloat(GetPName.ProjectionMatrix, out projectionMatrix);
            GL.GetInteger(GetPName.Viewport, viewport);

            return UnProject(ref projectionMatrix, modelViewMatrix, viewport, new Vector2(X - this.x + 1, Y));
        }

        public Vector3 UnProject(ref Matrix4 projection, Matrix4 view, int[] viewport, Vector2 mouse)
        {
            Vector4 vec;

            float Y = mouse.Y;
            //Y = h - Y - 1;
            //Y = Y - this.y;

            vec.X = 2.0f * mouse.X / (float)viewport[2] - 1;
            vec.Y = -(2.0f * Y / (float)viewport[3] - 1);
            vec.Z = 0;
            vec.W = 1.0f;

            Matrix4 viewInv = Matrix4.Invert(view);
            Matrix4 projInv = Matrix4.Invert(projection);

            Vector4.Transform(ref vec, ref projInv, out vec);
            Vector4.Transform(ref vec, ref viewInv, out vec);

            if (vec.W > float.Epsilon || vec.W < float.Epsilon)
            {
                vec.X /= vec.W;
                vec.Y /= vec.W;
                vec.Z /= vec.W;
            }

            return new Vector3(vec.X, vec.Y, vec.Z);
        }

        int ow = -1;
        int oh = -1;

        public void Resize()
        {
            w = pnlViewport.Control.Width;
            h = pnlViewport.Control.Height;

            if ((w == ow && h == oh) || (w <= 0 || h <= 0)) { return; }

            ow = vw;
            oh = vh;

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
            GL.ClearColor(Color.FromArgb(0x9D9D9D));

            if (mode == Projection.Orthographic) { perspective = Matrix4.CreateOrthographic(4 * camera.Zoom, (4 / aspect_ratio) * camera.Zoom, 0.001f, 100); }

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
            GL.Enable(EnableCap.Texture2D);

            var offsetX = (bActive ? x + 1 : x);
            var offsetY = (bActive ? y + 1 : y);
            var scissorWidth = (bActive ? vw - 2 : vw);
            var scissorHeight = (bActive ? vh - 2 : vh);

            GL.Viewport(x, y, vw, vh);
            GL.Scissor(offsetX, offsetY, scissorWidth, scissorHeight);
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
