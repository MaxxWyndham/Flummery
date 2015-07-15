using System;
using System.Collections.Generic;
using System.Drawing;

using OpenTK;

namespace Flummery
{
    public enum Axis
    {
        X,
        Y,
        Z
    }

    [Flags]
    public enum FreezeComponents
    {
        Position = 1,
        Rotation = 2,
        Scale = 4,
        All = Position | Rotation | Scale
    }

    [Flags]
    public enum PreProcessOptions
    {
        SplitMeshPart = 1,
        Dedupe = 2,
        ResolveNonManifold = 4
    }

    public static class ModelManipulator
    {
        public static void PreProcess(Model model, PreProcessOptions options)
        {
            if (options.HasFlag(PreProcessOptions.SplitMeshPart))
            {
            }

            if (options.HasFlag(PreProcessOptions.Dedupe))
            {
                foreach (ModelMesh mesh in model.Meshes)
                {
                    foreach (ModelMeshPart part in mesh.MeshParts)
                    {
                        part.Optimise();
                    }
                }
            }

            if (options.HasFlag(PreProcessOptions.ResolveNonManifold))
            {
                foreach (ModelMesh mesh in model.Meshes)
                {
                    foreach (ModelMeshPart part in mesh.MeshParts)
                    {
                        Dictionary<int, int> edgeCounts = new Dictionary<int, int>();
                        List<int> buffer = part.IndexBuffer.Data;
                        bool bFixedNonManifoldMesh = false;

                        for (int i = 0; i < buffer.Count; i += 3)
                        {
                            int[] edges = new int[3];

                            for (int j = 0; j < 3; j++)
                            {
                                int oppositeIndex = (j + 1 < 3 ? j + 1 : 0);

                                edges[j] = Math.Max(buffer[i + j], buffer[i + oppositeIndex]) << 24 + Math.Min(buffer[i + j], buffer[i + oppositeIndex]);

                                if (edgeCounts.ContainsKey(edges[j]))
                                {
                                    if (edgeCounts[edges[j]] == 2)
                                    {
                                        buffer[i + j] = part.VertexBuffer.AddVertex(part.VertexBuffer.Data[buffer[i + j]].Clone());
                                        buffer[i + oppositeIndex] = part.VertexBuffer.AddVertex(part.VertexBuffer.Data[buffer[i + oppositeIndex]].Clone());

                                        j--;

                                        bFixedNonManifoldMesh = true;
                                    }
                                    else
                                    {
                                        edgeCounts[edges[j]]++;
                                    }
                                }
                                else
                                {
                                    edgeCounts.Add(edges[j], 1);
                                }
                            }
                        }

                        if (bFixedNonManifoldMesh)
                        {
                            part.IndexBuffer.Initialise();
                            part.VertexBuffer.Initialise();
                        }
                    }
                }
            }
        }

        public static void FlipAxis(ModelMesh model, Axis axis, bool bApplyToHierarchy = false)
        {
            var transform = Vector3.One;
            var transform4 = Vector4.One;
            var processed = new List<string>();

            var bones = (bApplyToHierarchy ? model.Parent.AllChildren() : new ModelBoneCollection { model.Parent });

            switch (axis)
            {
                case Axis.X:
                    transform.X = -1.0f;
                    transform4.X = -1.0f;
                    break;

                case Axis.Y:
                    transform.Y = -1.0f;
                    transform4.Y = -1.0f;
                    break;

                case Axis.Z:
                    transform.Z = -1.0f;
                    transform4.Z = -1.0f;
                    break;
            }

            foreach (var bone in bones)
            {
                if (bone.Type == BoneType.Mesh && bone.Mesh != null && !processed.Contains(bone.Mesh.Name))
                {
                    var mesh = bone.Mesh;

                    foreach (var meshpart in mesh.MeshParts)
                    {
                        for (int i = 0; i < meshpart.VertexCount; i++)
                        {
                            meshpart.VertexBuffer.ModifyVertexPosition(i, Vector3.Multiply(meshpart.VertexBuffer.Data[i].Position, transform));
                            meshpart.VertexBuffer.ModifyVertexNormal(i, Vector3.Multiply(meshpart.VertexBuffer.Data[i].Normal, transform));
                        }

                        for (int i = 0; i < meshpart.IndexBuffer.Data.Count; i += 3)
                        {
                            meshpart.IndexBuffer.SwapIndices(i + 1, i + 2);
                        }

                        meshpart.IndexBuffer.Initialise();
                        meshpart.VertexBuffer.Initialise();
                    }

                    mesh.BoundingBox.Calculate(mesh);

                    processed.Add(mesh.Name);
                }

                // There is probably a neater way of doing this
                var boneTransform = bone.Transform;
                var scale = new Vector3(boneTransform.M11, boneTransform.M22, boneTransform.M33);
                boneTransform.Row0 = Vector4.Multiply(boneTransform.Row0, transform4);
                boneTransform.Row1 = Vector4.Multiply(boneTransform.Row1, transform4);
                boneTransform.Row2 = Vector4.Multiply(boneTransform.Row2, transform4);
                boneTransform.Row3 = Vector4.Multiply(boneTransform.Row3, transform4);
                boneTransform.M11 = scale.X;
                boneTransform.M22 = scale.Y;
                boneTransform.M33 = scale.Z;
                bone.Transform = boneTransform;
            }
        }

        public static void Freeze(ModelMesh model, FreezeComponents flags)
        {
            bool bFreezePos = ((flags & FreezeComponents.Position) == FreezeComponents.Position);
            bool bFreezeRot = ((flags & FreezeComponents.Rotation) == FreezeComponents.Rotation);
            bool bFreezeSca = ((flags & FreezeComponents.Scale) == FreezeComponents.Scale);

            var mPosition = Matrix4.CreateTranslation(model.Parent.Transform.ExtractTranslation());
            var mRotation = Matrix4.CreateFromQuaternion(model.Parent.Transform.ExtractRotation());
            var mScale = Matrix4.CreateScale(model.Parent.Transform.ExtractScale());

            if (bFreezePos) { model.Parent.Transform = model.Parent.Transform.ClearTranslation(); }
            if (bFreezeRot) { model.Parent.Transform = model.Parent.Transform.ClearRotation(); }
            if (bFreezeSca) { model.Parent.Transform = model.Parent.Transform.ClearScale(); }

            foreach (var meshpart in model.MeshParts)
            {
                for (int i = 0; i < meshpart.VertexCount; i++)
                {
                    if (bFreezePos) { meshpart.VertexBuffer.ModifyVertexPosition(i, Vector3.Transform(meshpart.VertexBuffer.Data[i].Position, mPosition)); }
                    if (bFreezeRot)
                    {
                        meshpart.VertexBuffer.ModifyVertexPosition(i, Vector3.Transform(meshpart.VertexBuffer.Data[i].Position, mRotation));
                        meshpart.VertexBuffer.ModifyVertexNormal(i, Vector3.TransformNormal(meshpart.VertexBuffer.Data[i].Normal, mRotation)); 
                    }
                    if (bFreezeSca) { meshpart.VertexBuffer.ModifyVertexPosition(i, Vector3.Transform(meshpart.VertexBuffer.Data[i].Position, mScale)); }
                }

                meshpart.VertexBuffer.Initialise();
            }

            model.BoundingBox.Calculate(model);
        }

        public static void FlipUVs(ModelMesh model)
        {
            var flip = new Vector4(1, -1, 1, -1);

            foreach (var meshpart in model.MeshParts)
            {
                for (int i = 0; i < meshpart.VertexCount; i++)
                {
                    meshpart.VertexBuffer.ModifyVertexUVs(i, Vector4.Multiply(meshpart.VertexBuffer.Data[i].UV, flip));
                }

                meshpart.VertexBuffer.Initialise();
            }
        }

        public static void SetVertexColour(ModelMesh model, int R, int G, int B, int A)
        {
            SetVertexColour(model, Color.FromArgb(A, R, G, B));
        }

        public static void SetVertexColour(ModelMesh model, Color colour)
        {
            foreach (var meshpart in model.MeshParts)
            {
                for (int i = 0; i < meshpart.VertexCount; i++)
                {
                    meshpart.VertexBuffer.ModifyVertexColour(i, colour);
                }

                meshpart.VertexBuffer.Initialise();
            }
        }
    }
}
