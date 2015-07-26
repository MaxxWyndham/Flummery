using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
                // Specific to C:R, I'll abstract this out as and when necessary
                foreach (ModelMesh mesh in model.Meshes)
                {
                    int partCount = mesh.MeshParts.Count;

                    for (int i = partCount - 1; i >= 0; i--)
                    {
                        ModelMeshPart part = mesh.MeshParts[i];

                        if (part.VertexBuffer.Data.Count > 16383)
                        {
                            while (part.IndexBuffer.Data.Count > 0)
                            {
                                var buffer = part.IndexBuffer.Data;
                                HashSet<int> usedVerts = new HashSet<int>();
                                int total = buffer.Count;

                                for (int j = 0; j < buffer.Count; j += 3)
                                {
                                    usedVerts.Add(buffer[j + 0]);
                                    usedVerts.Add(buffer[j + 1]);
                                    usedVerts.Add(buffer[j + 2]);

                                    int chunkSize = Math.Min(buffer.Count, 16383);

                                    if (usedVerts.Count >= chunkSize)
                                    {
                                        if (usedVerts.Count == chunkSize) { j += 3; }

                                        Dictionary<int, int> indexLUT = new Dictionary<int, int>();

                                        var newPart = new ModelMeshPart();
                                        newPart.Material = part.Material;

                                        for (int k = 0; k < j; k++)
                                        {
                                            if (!indexLUT.ContainsKey(buffer[k]))
                                            {
                                                indexLUT.Add(buffer[k], newPart.VertexBuffer.AddVertex(part.VertexBuffer.Data[buffer[k]]));
                                            }

                                            newPart.IndexBuffer.AddIndex(indexLUT[buffer[k]]);
                                        }

                                        buffer.RemoveRange(0, j);

                                        mesh.AddModelMeshPart(newPart);

                                        SceneManager.Current.UpdateProgress(string.Format("Allocated {0:n0} of {1:n0}", j * chunkSize, total));
                                        break;
                                    }
                                }
                            }

                            mesh.MeshParts.RemoveAt(i);
                        }
                    }
                }
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
            var processed = new List<string>();

            var bones = (bApplyToHierarchy ? model.Parent.AllChildren() : new ModelBoneCollection { model.Parent });

            switch (axis)
            {
                case Axis.X:
                    transform.X = -1.0f;
                    break;

                case Axis.Y:
                    transform.Y = -1.0f;
                    break;

                case Axis.Z:
                    transform.Z = -1.0f;
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

                bone.Transform = Matrix4.CreateScale(transform) * bone.Transform * Matrix4.CreateScale(transform);
            }
        }

        public static void FlipFaces(ModelBoneCollection bones, bool bApplyToHierarchy = false)
        {
            var processed = new List<string>();

            foreach (var bone in bones)
            {
                if (bone.Type == BoneType.Mesh && bone.Mesh != null && !processed.Contains(bone.Mesh.Name))
                {
                    var mesh = bone.Mesh;

                    foreach (var meshpart in mesh.MeshParts)
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

        public static void Scale(ModelBoneCollection bones, Matrix4 scale, bool bApplyToHierarchy = false)
        {
            var processed = new List<string>();

            foreach (var bone in bones)
            {
                if (bone.Type == BoneType.Mesh && bone.Mesh != null && !processed.Contains(bone.Mesh.Name))
                {
                    var mesh = bone.Mesh;

                    foreach (var meshpart in mesh.MeshParts)
                    {
                        for (int i = 0; i < meshpart.VertexCount; i++)
                        {
                            var position = Vector3.Transform(meshpart.VertexBuffer.Data[i].Position, scale);
                            meshpart.VertexBuffer.ModifyVertexPosition(i, position);
                        }

                        meshpart.VertexBuffer.Initialise();
                    }

                    processed.Add(mesh.Name);
                }

                if (bApplyToHierarchy)
                {
                    var transform = bone.Transform;
                    var position = Vector3.TransformPosition(transform.ExtractTranslation(), scale);

                    transform.M41 = position.X;
                    transform.M42 = position.Y;
                    transform.M43 = position.Z;

                    bone.Transform = transform;
                }
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

        public static void Freeze(Model model, Matrix4 matrix)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                Matrix4 o = mesh.Parent.Transform;
                Vector3 p = Vector3.Transform(o.ExtractTranslation(), matrix);
                Vector3 e = o.ExtractRotation().ToEuler(RotationOrder.OrderXYZ);

                o = Matrix4.CreateFromQuaternion(
                    Quaternion.FromAxisAngle(OpenTK.Vector3.UnitX, MathHelper.DegreesToRadians( e.X)) *
                    Quaternion.FromAxisAngle(OpenTK.Vector3.UnitZ, MathHelper.DegreesToRadians(-e.Y)) *
                    Quaternion.FromAxisAngle(OpenTK.Vector3.UnitY, MathHelper.DegreesToRadians(-e.Z))
                );

                o.M41 = p.X;
                o.M42 = p.Y;
                o.M43 = p.Z;

                mesh.Parent.Transform = matrix;

                ModelManipulator.Freeze(mesh, FreezeComponents.Rotation);

                mesh.Parent.Transform = o;
            }
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
