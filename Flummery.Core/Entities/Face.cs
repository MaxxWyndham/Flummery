using System.Collections.Generic;

using ToxicRagers.Helpers;

namespace Flummery.Core.Entities
{
    public class Face : IEntity
    {
        public string Name { get; set; }

        public object Tag { get; set; }

        public Matrix4D Transform { get; set; }

        public List<Vector3> Points { get; set; } = new List<Vector3>();

        public void Draw()
        {
            if (Points.Count != 3) { return; }

            IRenderer renderer = SceneManager.Current.Renderer;

            renderer.Disable("CullFace");
            renderer.Disable("Texture2D");
            renderer.Disable("Lighting");
            renderer.Disable("Light0");

            renderer.PolygonMode("FrontAndBack", "Line");

            renderer.Begin(PrimitiveType.Triangles);
            renderer.Color4(0f, 1.0f, 0f, 1.0f);

            renderer.Vertex3(Points[0]);
            renderer.Vertex3(Points[1]);
            renderer.Vertex3(Points[2]);
            renderer.End();

            renderer.Enable("CullFace");
            renderer.Enable("Texture2D");
            renderer.Enable("Lighting");
            renderer.Enable("Light0");
            renderer.FrontFace(SceneManager.Current.FrontFace);
        }
    }
}
