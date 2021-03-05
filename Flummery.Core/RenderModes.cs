using System.Drawing;

namespace Flummery.Core
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
            SceneManager.Current.Renderer.PolygonMode("Front", "Fill");
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
            SceneManager.Current.Renderer.Disable("Texture2D");
            SceneManager.Current.Renderer.Disable("Lighting");
            SceneManager.Current.Renderer.Disable("Light0");
            SceneManager.Current.Renderer.PolygonMode("Front", "Line");
            //SceneManager.Current.Renderer.Color4(part.Colour);
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
            SceneManager.Current.Renderer.PolygonMode("Front", "Fill");
            part.VertexBuffer.Draw(part.IndexBuffer, part.PrimitiveType);
            SceneManager.Current.Renderer.PolygonOffset(1.0f, 2);
            SceneManager.Current.Renderer.Disable("Texture2D");
            SceneManager.Current.Renderer.Color4(Color.White);
            SceneManager.Current.Renderer.PolygonMode("Front", "Line");
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
            SceneManager.Current.Renderer.Disable("Texture2D");
            SceneManager.Current.Renderer.PolygonMode("Front", "Fill");
            part.VertexBuffer.Draw(part.IndexBuffer, part.PrimitiveType);

            SceneManager.Current.Renderer.Disable("Lighting");
            SceneManager.Current.Renderer.Disable("Light0");
            SceneManager.Current.Renderer.PolygonOffset(1.0f, 2);
            SceneManager.Current.Renderer.PolygonMode("Front", "Point");
        }

        public bool IsValid()
        {
            return true;
        }
    }

    //public class CrushData : IRenderMode
    //{
    //    public string Name => "Crush Data";

    //    public void Draw(ModelMeshPart part)
    //    {
    //        SceneManager.Current.Renderer.PolygonMode("Front", "Point");
    //    }

    //    public bool IsValid()
    //    {
    //        return SceneManager.Current.Game == ContextGame.Carmageddon1 && SceneManager.Current.Mode == ContextMode.Car;
    //    }
    //}
}
