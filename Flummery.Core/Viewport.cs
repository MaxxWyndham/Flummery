using System.Drawing;

using ToxicRagers.Helpers;

namespace Flummery.Core
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

        bool disabled = false;
        Size width = Size.Half;
        Size height = Size.Half;
        Size oldwidth;
        Size oldheight;
        Quadrant oldposition;

        ProjectionType mode = ProjectionType.Perspective;
        TextWriter tw = null;

        public int X { get; private set; }

        public int Y { get; private set; }

        int w = 0;
        int h = 0;
        int vw = 0;
        int vh = 0;
        float aspect_ratio;
        Matrix4D perspective = Matrix4D.Identity;

        public Camera Camera { get; }

        public bool Enabled
        {
            get => !disabled;
            set => disabled = !value;
        }

        public string Name { get; set; }

        public ProjectionType ProjectionMode
        {
            get => mode;
            set
            {
                mode = value;
                Camera.ProjectionMode = mode;
            }
        }

        public Quadrant Position { get; set; } = Quadrant.BottomLeft;

        public bool Maximised => (width == Size.Full && height == Size.Full);

        public bool Active { get; set; }

        public Vector3 Axis { get; set; } = Vector3.UnitY;

        public Viewport()
        {
            Camera = new Camera() { ProjectionMode = mode, Zoom = 2 };
            tw = new TextWriter(50, 20);
        }

        public bool IsActive(int x, int y)
        {
            y = h - y;

            return (
                x > X &&
                x < X + vw &&
                y > Y &&
                y < Y + vh
            );
        }

        public bool RightClickLabel(MouseEvent e)
        {
            return (
                e.Button == MouseButtons.Right &&
                e.X > X &&
                e.X < X + 43 &&
                e.Y > (h - (Y + vh)) &&
                e.Y < (h - (Y + vh)) + 25
            );
        }

        public Vector3 ConvertScreenToWorldCoords(int x, int y)
        {
            if (mode != ProjectionType.Orthographic) { return Vector3.Zero; }

            Matrix4D m = SceneManager.Current.Transform;

            Matrix4D lookat = Camera.View;

            SceneManager.Current.Renderer.MatrixMode("Modelview");
            SceneManager.Current.Renderer.LoadMatrix(ref lookat);
            SceneManager.Current.Renderer.MultMatrix(ref m);

            perspective = Matrix4D.CreateOrthographic(4 * Camera.Zoom, (4 / aspect_ratio) * Camera.Zoom, 0.001f, 1000);

            SceneManager.Current.Renderer.MatrixMode("Projection");
            SceneManager.Current.Renderer.LoadMatrix(ref perspective);

            int[] viewport = new int[4];
            SceneManager.Current.Renderer.GetFloat("ModelviewMatrix", out Matrix4D modelViewMatrix);
            SceneManager.Current.Renderer.GetFloat("ProjectionMatrix", out Matrix4D projectionMatrix);
            SceneManager.Current.Renderer.GetInteger("Viewport", viewport);

            return UnProject(ref projectionMatrix, modelViewMatrix, viewport, new Vector2(x - X + 1, h - y - 1 - Y));
        }

        public Vector3 UnProject(ref Matrix4D projection, Matrix4D view, int[] viewport, Vector2 mouse)
        {
            Vector4 vec = Vector4.Zero;

            vec.X = 2.0f * mouse.X / viewport[2] - 1;
            vec.Y = 2.0f * mouse.Y / viewport[3] - 1;
            vec.Z = 0;
            vec.W = 1.0f;

            Matrix4D viewInv = Matrix4D.Invert(view);
            Matrix4D projInv = Matrix4D.Invert(projection);

            Vector4.Transform(ref vec, ref projInv, out vec);
            Vector4.Transform(ref vec, ref viewInv, out vec);

            if (vec.W > float.Epsilon || vec.W < float.Epsilon)
            {
                vec.X /= vec.W;
                vec.Y /= vec.W;
                vec.Z /= vec.W;
            }

            if (Axis == Vector3.UnitX) { vec.X = 0; }
            if (Axis == Vector3.UnitY) { vec.Y = 0; }
            if (Axis == Vector3.UnitZ) { vec.Z = 0; }

            return new Vector3(vec.X, vec.Y, vec.Z);
        }

        int ow = -1;
        int oh = -1;

        public void Resize(int panelwidth, int panelheight)
        {
            w = panelwidth;
            h = panelheight;

            if ((w == ow && h == oh) || (w <= 0 || h <= 0)) { return; }

            ow = vw;
            oh = vh;

            aspect_ratio = w / (float)h;

            perspective = Matrix4D.CreatePerspectiveFieldOfView(Maths.PiOver4, aspect_ratio, 0.1f, 1000);

            int xo = ((int)Position & 1);
            int yo = ((int)Position & 2) >> 1;

            vw = (w / (int)width) - 2;
            vh = (h / (int)height) - 2;

            tw.SetWidthHeight(vw, vh);
            tw.AddLine(Name, new PointF(5, 5), Brushes.Blue);
            //tw.AddLine(name, new PointF(vw / 2 + 9, vh / 2 - 5), Brushes.Red, Fonts.AxisLabel);

            X = (xo * 2) + 1 + (vw * xo);
            Y = (yo * 2) + 1 + (vh * yo);
        }

        public void SetWidthHeightPosition(Size width = Size.Half, Size height = Size.Half, Quadrant position = Quadrant.BottomLeft)
        {
            oldwidth = this.width;
            oldheight = this.height;
            oldposition = Position;

            this.width = width;
            this.height = height;
            Position = position;
        }

        public void ResetWidthHeightPosition()
        {
            width = oldwidth;
            height = oldheight;
            Position = oldposition;
        }

        public void Update(float dt)
        {
            Camera.Update(dt);
        }

        public void Draw(SceneManager scene)
        {
            scene.Renderer.ClearColor(Color.FromArgb(0x9D9D9D));

            if (mode == ProjectionType.Orthographic) { perspective = Matrix4D.CreateOrthographic(4 * Camera.Zoom, (4 / aspect_ratio) * Camera.Zoom, 0.001f, 100); }

            scene.Renderer.MatrixMode("Projection");
            scene.Renderer.LoadMatrix(ref perspective);
            scene.Renderer.Enable("Texture2D");

            int offsetX = Active ? X + 1 : X;
            int offsetY = Active ? Y + 1 : Y;
            int scissorWidth = Active ? vw - 2 : vw;
            int scissorHeight = Active ? vh - 2 : vh;

            scene.Renderer.Viewport(X, Y, vw, vh);
            scene.Renderer.Scissor(offsetX, offsetY, scissorWidth, scissorHeight);
            scene.Renderer.Clear("ColorBufferBit", "DepthBufferBit");

            scene.Draw(Camera);
        }

        public void DrawOverlay()
        {
            SceneManager.Current.Renderer.Disable("DepthTest");
            SceneManager.Current.Renderer.Disable("Lighting");
            SceneManager.Current.Renderer.Disable("Texture2D");

            SceneManager.Current.Renderer.Viewport(X, Y, vw, vh);
            SceneManager.Current.Renderer.Scissor(X, Y, vw, vh);
            SceneManager.Current.Renderer.MatrixMode("Projection");
            SceneManager.Current.Renderer.LoadIdentity();
            SceneManager.Current.Renderer.Ortho(0, vw, 0, vh, -1, 1);
            SceneManager.Current.Renderer.MatrixMode("Modelview");
            SceneManager.Current.Renderer.LoadIdentity();

            SceneManager.Current.Renderer.Begin(PrimitiveType.LineStrip);
            SceneManager.Current.Renderer.Color4(Color.Blue);
            SceneManager.Current.Renderer.LineWidth(1);

            SceneManager.Current.Renderer.Vertex2(4, vh - 4); SceneManager.Current.Renderer.Vertex2(42, vh - 4);
            SceneManager.Current.Renderer.Vertex2(42, vh - 20); SceneManager.Current.Renderer.Vertex2(4, vh - 20);
            SceneManager.Current.Renderer.Vertex2(4, vh - 4);
            SceneManager.Current.Renderer.End();

            Matrix4D m = Matrix4D.CreateTranslation(20, 20, 0);
            Matrix4D c = Camera.View;
            Matrix4D s = SceneManager.Current.Transform;
            c = c.ClearTranslation();

            tw.Draw();

            SceneManager.Current.Renderer.PolygonMode("FrontAndBack", "Fill");
            SceneManager.Current.Renderer.Disable("CullFace");

            SceneManager.Current.Renderer.MultMatrix(ref m);
            SceneManager.Current.Renderer.MultMatrix(ref c);
            SceneManager.Current.Renderer.MultMatrix(ref s);

            SceneManager.Current.Renderer.Begin(PrimitiveType.LineStrip);
            SceneManager.Current.Renderer.Color4(Color.Blue);
            SceneManager.Current.Renderer.LineWidth(2);
            SceneManager.Current.Renderer.Vertex3(0, 0, 0); SceneManager.Current.Renderer.Vertex3(10, 0, 0);
            SceneManager.Current.Renderer.End();

            SceneManager.Current.Renderer.Begin(PrimitiveType.Triangles);
            SceneManager.Current.Renderer.Color4(Color.Blue);
            SceneManager.Current.Renderer.Vertex3(10, -2, 0); SceneManager.Current.Renderer.Vertex3(15, 0, 0); SceneManager.Current.Renderer.Vertex3(10, 2, 0);
            SceneManager.Current.Renderer.Vertex3(10, 0, -2); SceneManager.Current.Renderer.Vertex3(15, 0, 0); SceneManager.Current.Renderer.Vertex3(10, 0, 2);
            SceneManager.Current.Renderer.End();

            SceneManager.Current.Renderer.Begin(PrimitiveType.LineStrip);
            SceneManager.Current.Renderer.Color4(Color.Green);
            SceneManager.Current.Renderer.LineWidth(2);
            SceneManager.Current.Renderer.Vertex3(0, 0, 0); SceneManager.Current.Renderer.Vertex3(0, 10, 0);
            SceneManager.Current.Renderer.End();

            SceneManager.Current.Renderer.Begin(PrimitiveType.Triangles);
            SceneManager.Current.Renderer.Color4(Color.Green);
            SceneManager.Current.Renderer.Vertex3(-2, 10, 0); SceneManager.Current.Renderer.Vertex3(0, 15, 0); SceneManager.Current.Renderer.Vertex3(2, 10, 0);
            SceneManager.Current.Renderer.Vertex3(0, 10, -2); SceneManager.Current.Renderer.Vertex3(0, 15, 0); SceneManager.Current.Renderer.Vertex3(0, 10, 2);
            SceneManager.Current.Renderer.End();

            SceneManager.Current.Renderer.Begin(PrimitiveType.LineStrip);
            SceneManager.Current.Renderer.Color4(Color.Red);
            SceneManager.Current.Renderer.LineWidth(2);
            SceneManager.Current.Renderer.Vertex3(0, 0, 0); SceneManager.Current.Renderer.Vertex3(0, 0, 10);
            SceneManager.Current.Renderer.End();

            SceneManager.Current.Renderer.Begin(PrimitiveType.Triangles);
            SceneManager.Current.Renderer.Color4(Color.Red);
            SceneManager.Current.Renderer.Vertex3(0, -2, 10); SceneManager.Current.Renderer.Vertex3(0, 0, 15); SceneManager.Current.Renderer.Vertex3(0, 2, 10);
            SceneManager.Current.Renderer.Vertex3(-2, 0, 10); SceneManager.Current.Renderer.Vertex3(0, 0, 15); SceneManager.Current.Renderer.Vertex3(2, 0, 10);
            SceneManager.Current.Renderer.End();

            SceneManager.Current.Renderer.Enable("DepthTest");
            SceneManager.Current.Renderer.Enable("Lighting");
            SceneManager.Current.Renderer.Enable("Texture2D");
        }
    }
}