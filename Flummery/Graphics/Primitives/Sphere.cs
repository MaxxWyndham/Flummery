using System;
using OpenTK;

namespace Flummery
{
    public class Sphere : Primitive
    {
        public Sphere(Single radius, int stacks = 15, int slices = 15)
        {
            ModelMeshPart meshpart = new ModelMeshPart();

            // TODO: Correctly assign normals and UVs

            for (int t = 0; t < stacks; t++)
            {
                Single theta1 = ((Single)(t) / stacks) * (Single)Math.PI;
                Single theta2 = ((Single)(t + 1) / stacks) * (Single)Math.PI;

                for (int p = 0; p < slices; p++)
                {
                    Single phi1 = ((Single)(p) / slices) * 2 * (Single)Math.PI;
                    Single phi2 = ((Single)(p + 1) / slices) * 2 * (Single)Math.PI;

                    var v1 = new Vector3(
                                    (Single)(radius * Math.Sin(theta1) * Math.Cos(phi1)),
                                    (Single)(radius * Math.Sin(theta1) * Math.Sin(phi1)),
                                    (Single)(radius * Math.Cos(theta1))
                             );

                    var v2 = new Vector3(
                                    (Single)(radius * Math.Sin(theta1) * Math.Cos(phi2)),
                                    (Single)(radius * Math.Sin(theta1) * Math.Sin(phi2)),
                                    (Single)(radius * Math.Cos(theta1))
                             );

                    var v3 = new Vector3(
                                    (Single)(radius * Math.Sin(theta2) * Math.Cos(phi2)),
                                    (Single)(radius * Math.Sin(theta2) * Math.Sin(phi2)),
                                    (Single)(radius * Math.Cos(theta2))
                             );

                    var v4 = new Vector3(
                                    (Single)(radius * Math.Sin(theta2) * Math.Cos(phi1)),
                                    (Single)(radius * Math.Sin(theta2) * Math.Sin(phi1)),
                                    (Single)(radius * Math.Cos(theta2))
                             );

                    if (t == 0)
                    {
                        meshpart.AddFace(new Vector3[] { v1, v3, v4 }, new Vector3[] { Vector3.Zero, Vector3.Zero, Vector3.Zero }, new Vector2[] { Vector2.Zero, Vector2.Zero, Vector2.Zero });
                    }
                    else if (t + 1 == stacks)
                    {
                        meshpart.AddFace(new Vector3[] { v3, v1, v2 }, new Vector3[] { Vector3.Zero, Vector3.Zero, Vector3.Zero }, new Vector2[] { Vector2.Zero, Vector2.Zero, Vector2.Zero });
                    }
                    else
                    {
                        meshpart.AddFace(new Vector3[] { v1, v2, v4 }, new Vector3[] { Vector3.Zero, Vector3.Zero, Vector3.Zero }, new Vector2[] { Vector2.Zero, Vector2.Zero, Vector2.Zero });
                        meshpart.AddFace(new Vector3[] { v2, v3, v4 }, new Vector3[] { Vector3.Zero, Vector3.Zero, Vector3.Zero }, new Vector2[] { Vector2.Zero, Vector2.Zero, Vector2.Zero });
                    }
                }
            }

            this.AddModelMeshPart(meshpart);
        }
    }
}
