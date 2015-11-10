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

                    var n1 = new Vector3(
                                    (Single)(Math.Sin(theta1) * Math.Cos(phi1)),
                                    (Single)(Math.Cos(theta1)),
                                    (Single)(Math.Sin(theta1) * Math.Sin(phi1))
                             );

                    var n2 = new Vector3(
                                    (Single)(Math.Sin(theta1) * Math.Cos(phi2)),
                                    (Single)(Math.Cos(theta1)),
                                    (Single)(Math.Sin(theta1) * Math.Sin(phi2))
                             );

                    var n3 = new Vector3(
                                    (Single)(Math.Sin(theta2) * Math.Cos(phi2)),
                                    (Single)(Math.Cos(theta2)),
                                    (Single)(Math.Sin(theta2) * Math.Sin(phi2))
                             );

                    var n4 = new Vector3(
                                    (Single)(Math.Sin(theta2) * Math.Cos(phi1)),
                                    (Single)(Math.Cos(theta2)),
                                    (Single)(Math.Sin(theta2) * Math.Sin(phi1))
                             );

                    var p1 = n1 * radius;
                    var p2 = n2 * radius;
                    var p3 = n3 * radius;
                    var p4 = n4 * radius;

                    var uv1 = new Vector2(
                                    0.5f + (Single)Math.Atan2(-p1.Z, p1.X) / MathHelper.TwoPi,
                                    0.5f - (Single)Math.Asin(p1.Y) / MathHelper.Pi
                              );

                    var uv2 = new Vector2(
                                    0.5f + (Single)Math.Atan2(-p2.Z, p2.X) / MathHelper.TwoPi,
                                    0.5f - (Single)Math.Asin(p2.Y) / MathHelper.Pi
                              );

                    var uv3 = new Vector2(
                                    0.5f + (Single)Math.Atan2(-p3.Z, p3.X) / MathHelper.TwoPi,
                                    0.5f - (Single)Math.Asin(p3.Y) / MathHelper.Pi
                              );

                    var uv4 = new Vector2(
                                    0.5f + (Single)Math.Atan2(-p4.Z, p4.X) / MathHelper.TwoPi,
                                    0.5f - (Single)Math.Asin(p4.Y) / MathHelper.Pi
                              );

                    if (t == 0)
                    {
                        meshpart.AddFace(
                            new Vector3[] { p1, p3, p4 },
                            new Vector3[] { n1, n3, n4 },
                            new Vector2[] { uv1, uv3, uv4 }
                        );
                    }
                    else if (t + 1 == stacks)
                    {
                        meshpart.AddFace(
                            new Vector3[] { p3, p1, p2 },
                            new Vector3[] { n3, n1, n2 },
                            new Vector2[] { uv3, uv1, uv2 }
                        );
                    }
                    else
                    {
                        meshpart.AddFace(
                            new Vector3[] { p1, p2, p4 },
                            new Vector3[] { n1, n2, n4 }, 
                            new Vector2[] { uv1, uv2, uv4 }
                        );

                        meshpart.AddFace(
                            new Vector3[] { p2, p3, p4 },
                            new Vector3[] { n2, n3, n4 }, 
                            new Vector2[] { uv2, uv3, uv4 }
                        );
                    }
                }
            }

            //Material material = new Material { Name = "sky", Texture = new Texture() };
            //SceneManager.Current.Add(material);
            //meshpart.Material = material;

            this.AddModelMeshPart(meshpart);
        }
    }
}
