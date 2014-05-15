using System;
using System.Drawing;
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

        bool bActive;
        Camera camera;
        Size width = Size.Half;
        Size height = Size.Half;
        Quadrant position;
        Mode mode = Mode.Perspective;
        Vector3 axis = Vector3.UnitY;

        int x = 0;
        int y = 0;
        int w = 0;
        int h = 0;
        int vw = 0;
        int vh = 0;
        float aspect_ratio;
        Matrix4 perspective = Matrix4.Identity;

        public Camera Camera { get { return camera; } }

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

            x = (xo * 2) + 1 + (vw * xo);
            y = (yo * 2) + 1 + (vh * yo);
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

            //GL.Disable(EnableCap.DepthTest);
            //GL.Disable(EnableCap.Lighting);
            //GL.Disable(EnableCap.Texture2D);

            //GL.Viewport(0, 0, control.Width, control.Height);
            //GL.Scissor(0, 0, control.Width, control.Height);
            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
            //GL.Ortho(0, 1, 0, 1, -1, 1);
            //GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadIdentity();

            //GL.Begin(PrimitiveType.LineStrip);
            //GL.Color3(Color.Blue);
            //GL.LineWidth(2.0f);

            //GL.Vertex2(0.0f, 1.0f); GL.Vertex2(0.5f, 1.0f);
            //GL.Vertex2(0.5f, 0.5f); GL.Vertex2(0.0f, 0.5f);
            //GL.Vertex2(0.0f, 1.0f);
            //GL.End();
        }

        public void DrawOverlay()
        {
        }
    }
}
