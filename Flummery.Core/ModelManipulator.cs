using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToxicRagers.Helpers;

namespace Flummery.Core
{
    public static class ModelManipulator
    {
        public static void FlipFaces(ModelBoneCollection bones, bool bApplyToHierarchy = false)
        {
            List<string> processed = new List<string>();

            foreach (ModelBone bone in bones)
            {
                if (bone.Type == BoneType.Mesh && bone.Mesh != null && !processed.Contains(bone.Mesh.Name))
                {
                    ModelMesh mesh = bone.Mesh;

                    foreach (ModelMeshPart meshpart in mesh.MeshParts)
                    {
                        for (int i = 0; i < meshpart.IndexBuffer.Data.Count; i += 3)
                        {
                            meshpart.IndexBuffer.SwapIndices(i + 1, i + 2);
                        }

                        meshpart.IndexBuffer.Initialise();
                    }

                    processed.Add(mesh.Name);
                }
            }
        }

        public static void Scale(ModelBoneCollection bones, Matrix4D scale, bool applyToHierarchy = false)
        {
            List<string> processed = new List<string>();

            foreach (ModelBone bone in bones)
            {
                if (bone.Type == BoneType.Mesh && bone.Mesh != null && !processed.Contains(bone.Mesh.Name))
                {
                    ModelMesh mesh = bone.Mesh;

                    foreach (ModelMeshPart meshpart in mesh.MeshParts)
                    {
                        for (int i = 0; i < meshpart.VertexCount; i++)
                        {
                            Vector3 position = Vector3.TransformVector(meshpart.VertexBuffer.Data[i].Position, scale);
                            meshpart.VertexBuffer.ModifyVertexPosition(i, position);
                        }

                        meshpart.VertexBuffer.Initialise();
                    }

                    processed.Add(mesh.Name);
                }

                if (applyToHierarchy)
                {
                    Matrix4D transform = bone.Transform;
                    Vector3 position = Vector3.TransformPosition(transform.ExtractTranslation(), scale);

                    transform.M41 = position.X;
                    transform.M42 = position.Y;
                    transform.M43 = position.Z;

                    bone.Transform = transform;
                }
            }
        }
    }
}
