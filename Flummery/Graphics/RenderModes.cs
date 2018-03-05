using System.Drawing;

using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public interface IRenderMode
    {
        string Name { get; }

        bool IsValid();

        void Draw(ModelMeshPart part);
    }

    public class Solid : IRenderMode
    {
        public string Name => "Solid";

        public void Draw(ModelMeshPart part)
        {
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
        }

        public bool IsValid()
        {
            return true;
        }
    }

    public class Wireframe : IRenderMode
    {
        public string Name => "Wireframe";

        public void Draw(ModelMeshPart part)
        {
            GL.Disable(EnableCap.Texture2D);
            GL.Disable(EnableCap.Lighting);
            GL.Disable(EnableCap.Light0);
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
            GL.Color4(part.Colour);
        }

        public bool IsValid()
        {
            return true;
        }
    }

    public class SolidWireframe : IRenderMode
    {
        public string Name => "Solid Wireframe";

        public void Draw(ModelMeshPart part)
        {
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
            part.VertexBuffer.Draw(part.IndexBuffer, part.PrimitiveType);
            GL.PolygonOffset(1.0f, 2);
            GL.Disable(EnableCap.Texture2D);
            GL.Color4(Color.White);
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
        }

        public bool IsValid()
        {
            return true;
        }
    }

    public class VertexColour : IRenderMode
    {
        public string Name => "Vertex Colour";

        public void Draw(ModelMeshPart part)
        {
            GL.Disable(EnableCap.Texture2D);
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
            part.VertexBuffer.Draw(part.IndexBuffer, part.PrimitiveType);

            GL.Disable(EnableCap.Lighting);
            GL.Disable(EnableCap.Light0);
            GL.PolygonOffset(1.0f, 2);
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Point);
        }

        public bool IsValid()
        {
            return true;
        }
    }

    public class CrushData : IRenderMode
    {
        public string Name => "Crush Data";

        public void Draw(ModelMeshPart part)
        {
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Point);
        }

        public bool IsValid()
        {
            return SceneManager.Current.Game == ContextGame.Carmageddon1 && SceneManager.Current.Mode == ContextMode.Car;
        }
    }
}
