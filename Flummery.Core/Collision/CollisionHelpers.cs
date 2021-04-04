using ToxicRagers.Helpers;

namespace Flummery.Core.Collision
{
    public static class CollisionHelpers
    {
        public static float? RayIntersectsModel(Ray ray, Model model,
                                                    out bool insideBoundingSphere,
                                                    out Vector3 vertex1, out Vector3 vertex2, out Vector3 vertex3,
                                                    out ModelMeshPart intersectsWithPart,
                                                    out ModelMesh intersectsWith
                                                )
        {
            vertex1 = vertex2 = vertex3 = Vector3.Zero;
            insideBoundingSphere = false;
            intersectsWithPart = null;
            intersectsWith = null;

            Matrix4D[] transforms = new Matrix4D[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);

            float? closestIntersection = null;

            foreach (ModelMesh mesh in model.Meshes)
            {
                Matrix4D inverseTransform = Matrix4D.Invert(transforms[mesh.Parent.Index]);

                Ray local = new Ray
                {
                    Position = Vector3.TransformPosition(ray.Position, inverseTransform),
                    Direction = Vector3.TransformNormal(ray.Direction, inverseTransform)
                };

                if (mesh.BoundingSphere.Intersects(local) != null)
                {
                    insideBoundingSphere = true;

                    foreach (ModelMeshPart part in mesh.MeshParts)
                    {
                        for (int i = 0; i < part.IndexBuffer.Data.Count; i += 3)
                        {

                            RayIntersectsTriangle(local,
                                                  part.VertexBuffer.Data[part.IndexBuffer.Data[i + 0]].Position,
                                                  part.VertexBuffer.Data[part.IndexBuffer.Data[i + 1]].Position,
                                                  part.VertexBuffer.Data[part.IndexBuffer.Data[i + 2]].Position,
                                                  out float? intersection);

                            if (intersection != null)
                            {
                                if ((closestIntersection == null) || (intersection < closestIntersection))
                                {
                                    closestIntersection = intersection;

                                    vertex1 = Vector3.TransformPosition(part.VertexBuffer.Data[part.IndexBuffer.Data[i + 0]].Position, transforms[mesh.Parent.Index]);
                                    vertex2 = Vector3.TransformPosition(part.VertexBuffer.Data[part.IndexBuffer.Data[i + 1]].Position, transforms[mesh.Parent.Index]);
                                    vertex3 = Vector3.TransformPosition(part.VertexBuffer.Data[part.IndexBuffer.Data[i + 2]].Position, transforms[mesh.Parent.Index]);

                                    intersectsWithPart = part;
                                    intersectsWith = mesh;
                                }
                            }
                        }
                    }
                }
            }

            return closestIntersection;
        }

        public static void RayIntersectsTriangle(Ray ray,
                                  Vector3 vertex1,
                                  Vector3 vertex2,
                                  Vector3 vertex3, out float? result)
        {
            // Compute vectors along two edges of the triangle.
            Vector3 edge1, edge2;

            edge1 = vertex2 - vertex1;
            edge2 = vertex3 - vertex1;

            // Compute the determinant.
            Vector3 directionCrossEdge2 = Vector3.Cross(ray.Direction, edge2);

            float determinant = Vector3.Dot(edge1, directionCrossEdge2);

            // If the ray is parallel to the triangle plane, there is no collision.
            if (determinant > -float.Epsilon && determinant < float.Epsilon)
            {
                result = null;
                return;
            }

            float inverseDeterminant = 1.0f / determinant;

            // Calculate the U parameter of the intersection point.
            Vector3 distanceVector = ray.Position - vertex1;

            float triangleU = Vector3.Dot(distanceVector, directionCrossEdge2);
            triangleU *= inverseDeterminant;

            // Make sure it is inside the triangle.
            if (triangleU < 0 || triangleU > 1)
            {
                result = null;
                return;
            }

            // Calculate the V parameter of the intersection point.
            Vector3 distanceCrossEdge1 = Vector3.Cross(distanceVector, edge1);

            float triangleV = Vector3.Dot(ray.Direction, distanceCrossEdge1);
            triangleV *= inverseDeterminant;

            // Make sure it is inside the triangle.
            if (triangleV < 0 || triangleU + triangleV > 1)
            {
                result = null;
                return;
            }

            // Compute the distance along the ray to the triangle.
            float rayDistance = Vector3.Dot(edge2, distanceCrossEdge1);
            rayDistance *= inverseDeterminant;

            // Is the triangle behind the ray origin?
            if (rayDistance < 0)
            {
                result = null;
                return;
            }

            result = rayDistance;
        }
    }
}
