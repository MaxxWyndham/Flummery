using ToxicRagers.Helpers;

namespace Flummery.Core.Gizmos
{
    public class Scale : IGizmo, IEntity
    {
        public string Name { get; set; }

        public object Tag { get; set; }

        public Matrix4D Transform { get; set; } = Matrix4D.Identity;

        public void Draw()
        {

        }
    }
}
