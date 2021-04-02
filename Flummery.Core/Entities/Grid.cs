using ToxicRagers.Helpers;

namespace Flummery.Core.Entities
{
    public class Grid : IEntity
    {
        public string Name { get; set; } = "Grid";

        public object Tag { get; set; }

        public Matrix4D Transform { get; set; } = Matrix4D.Identity;

        public void Draw()
        {
            IRenderer renderer = SceneManager.Current.Renderer;

            renderer.Disable("CullFace");
            renderer.Disable("Texture2D");
            renderer.Disable("Lighting");
            renderer.Disable("Light0");

            renderer.PolygonMode("FrontAndBack", "Line");

            renderer.Begin(PrimitiveType.Quads);
            renderer.Color4(0f, 1.0f, 0f, 1.0f);

            renderer.Vertex3(-1.0f, 0, -1.0f);
            renderer.Vertex3(0, 0, -1.0f);
            renderer.Vertex3(0, 0, 0);
            renderer.Vertex3(-1.0f, 0, 0);

            renderer.Vertex3(0, 0, -1.0f);
            renderer.Vertex3(1.0f, 0, -1.0f);
            renderer.Vertex3(1.0f, 0, 0);
            renderer.Vertex3(0, 0, 0);

            renderer.Vertex3(-1.0f, 0, 0);
            renderer.Vertex3(0, 0, 0);
            renderer.Vertex3(0, 0, 1.0f);
            renderer.Vertex3(-1.0f, 0, 1.0f);

            renderer.Vertex3(0, 0, 0);
            renderer.Vertex3(1.0f, 0, 0);
            renderer.Vertex3(1.0f, 0, 1.0f);
            renderer.Vertex3(0, 0, 1.0f);
            renderer.End();

            renderer.Enable("CullFace");
            renderer.Enable("Texture2D");
            renderer.Enable("Lighting");
            renderer.Enable("Light0");
            renderer.FrontFace(SceneManager.Current.FrontFace);
        }
    }
}
