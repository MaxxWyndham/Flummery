using System;
using System.Collections.Generic;

using OpenTK;
using thatGameEngine;

namespace Flummery
{
    public class Capsule : Primitive
    {
        public Capsule(Vector3 p0, Vector3 p1, Single radius)
        {
            ModelMeshPart mesh = new ModelMeshPart();

            int segments = 10; // Higher numbers improve quality 
            radius = 3;    // The radius (width) of the cylinder
            int height = 10;   // The height of the cylinder

            var vertices = new List<Vector3>();
            for (double y = 0; y < 2; y++)
            {
                for (double x = 0; x < segments; x++)
                {
                    double theta = (x / (segments - 1)) * 2 * Math.PI;

                    vertices.Add(new Vector3()
                    {
                        X = (float)(radius * Math.Cos(theta)),
                        Y = (float)(height * y),
                        Z = (float)(radius * Math.Sin(theta)),
                    });
                }
            }

            var indices = new List<int>();
            for (int x = 0; x < segments - 1; x++)
            {
                indices.Add(x);
                indices.Add(x + segments);
                indices.Add(x + segments + 1);

                indices.Add(x + segments + 1);
                indices.Add(x + 1);
                indices.Add(x);
            }
        }
    }
}
