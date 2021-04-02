using ToxicRagers.Helpers;

namespace Flummery.Core.Entities
{
    public class Bounds : IEntity
    {
        public string Name { get; set; }

        public object Tag { get; set; }

        public Matrix4D Transform { get; set; }

        public BoundingBox LinkedBox { get; set; }

        public void Draw()
        {
            if (LinkedBox != null)
            {
                IRenderer renderer = SceneManager.Current.Renderer;

                renderer.Disable("CullFace");
                renderer.Disable("Texture2D");
                renderer.Disable("Lighting");
                renderer.Disable("Light0");

                renderer.PolygonMode("FrontAndBack", "Line");

                LinkedBox.Draw();

                renderer.Enable("CullFace");
                renderer.Enable("Texture2D");
                renderer.Enable("Lighting");
                renderer.Enable("Light0");
            }
        }
    }
}
