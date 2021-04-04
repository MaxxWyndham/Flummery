using System;

using ToxicRagers.Helpers;

namespace Flummery.Core.Collision
{
    public class Ray
    {
        public Vector3 Position { get; set; }

        public Vector3 Direction { get; set; }

        public float? Intersects(BoundingSphere sphere)
        {
            Vector3 difference = sphere.Centre - Position;

            float differenceLengthSquared = difference.LengthSquared;
            float sphereRadiusSquared = sphere.Radius * sphere.Radius;

            float distanceAlongRay;


            if (differenceLengthSquared < sphereRadiusSquared)
            {
                return 0.0f;
            }

            distanceAlongRay = Vector3.Dot(Direction, difference);

            if (distanceAlongRay < 0)
            {
                return null;
            }

            float dist = sphereRadiusSquared + distanceAlongRay * distanceAlongRay - differenceLengthSquared;

            return (dist < 0) ? null : distanceAlongRay - (float?)Math.Sqrt(dist);
        }
    }
}