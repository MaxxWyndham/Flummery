using Flummery.Core.Collision;

using ToxicRagers.Helpers;

namespace Flummery.Core
{
    public class BoundingSphere
    {
        public Vector3 Centre { get; set; }

        public float Radius { get; set; }

        public static BoundingSphere CreateFromBoundingBox(BoundingBox box)
        {
            return new BoundingSphere
            {
                Centre = box.Centre,
                Radius = Vector3.Distance(box.Centre, box.Max)
            };
        }

        public float? Intersects(Ray ray)
        {
            return ray.Intersects(this);
        }
    }
}