using System;
using System.IO;

using OpenTK;
using thatGameEngine;
using thatGameEngine.ContentPipeline;
using ToxicRagers.Helpers;
using ToxicRagers.Carmageddon2.Formats;

namespace Flummery.ContentPipeline.Stainless
{
    class DATImporter : ContentImporter
    {
        public override string GetExtension() { return "dat"; }

        public override string GetHints(string currentPath)
        {
            string hints = (currentPath != null ? currentPath + ";" : "");

            if (Properties.Settings.Default.PathCarmageddon1 != null && currentPath.Contains(Properties.Settings.Default.PathCarmageddon1))
            {
                if (Directory.Exists(Properties.Settings.Default.PathCarmageddon1 + "DATA\\MODELS\\")) { hints += Properties.Settings.Default.PathCarmageddon1 + "DATA\\MODELS\\;"; }
            }

            return hints;
        }

        public override Asset Import(string path)
        {
            DAT dat = DAT.Load(path);
            SceneManager.Current.Content.LoadMany<MaterialList, MaterialImporter>(Path.GetFileName(path).Replace(".dat", ".mat", StringComparison.OrdinalIgnoreCase), Path.GetDirectoryName(path) + "\\", true);
            Model model = new Model();

            foreach (var datmesh in dat.DatMeshes)
            {
                datmesh.Mesh.GenerateNormals();

                ModelMesh mesh = new ModelMesh();

                mesh.Name = (datmesh.Name.Contains(".") ? datmesh.Name.Substring(0, datmesh.Name.IndexOf(".")) : datmesh.Name);

                SceneManager.Current.UpdateProgress(string.Format("Processing {0}", mesh.Name));

                for (int i = 0; i < datmesh.Mesh.Materials.Count + 1; i++) 
                { 
                    var meshpart = new ModelMeshPart();
                    meshpart.PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType.Triangles;

                    mesh.AddModelMeshPart(meshpart, false); 
                }

                for (int i = 0; i < datmesh.Mesh.Faces.Count; i++)
                {
                    var face = datmesh.Mesh.Faces[i];
                    var materialID = face.MaterialID + 1;

                    if (face.MaterialID > -1 && mesh.MeshParts[materialID].Material == null)
                    {
                        var material = SceneManager.Current.Materials.Entries.Find(m => m.Name == datmesh.Mesh.Materials[face.MaterialID]);
                        if (material == null)
                        { 
                            material = new Material() { Name = datmesh.Mesh.Materials[face.MaterialID] };
                            SceneManager.Current.Add(material);
                        }
                        mesh.MeshParts[materialID].Material = (Material)material;
                    }

                    mesh.MeshParts[materialID].AddFace(
                        new OpenTK.Vector3[] {
                            new OpenTK.Vector3(datmesh.Mesh.Verts[face.V1].X, datmesh.Mesh.Verts[face.V1].Y, datmesh.Mesh.Verts[face.V1].Z),
                            new OpenTK.Vector3(datmesh.Mesh.Verts[face.V2].X, datmesh.Mesh.Verts[face.V2].Y, datmesh.Mesh.Verts[face.V2].Z),
                            new OpenTK.Vector3(datmesh.Mesh.Verts[face.V3].X, datmesh.Mesh.Verts[face.V3].Y, datmesh.Mesh.Verts[face.V3].Z)
                        },
                        new OpenTK.Vector3[] {
                            new OpenTK.Vector3(datmesh.Mesh.Normals[face.V1].X, datmesh.Mesh.Normals[face.V1].Y, datmesh.Mesh.Normals[face.V1].Z),
                            new OpenTK.Vector3(datmesh.Mesh.Normals[face.V2].X, datmesh.Mesh.Normals[face.V2].Y, datmesh.Mesh.Normals[face.V2].Z),
                            new OpenTK.Vector3(datmesh.Mesh.Normals[face.V3].X, datmesh.Mesh.Normals[face.V3].Y, datmesh.Mesh.Normals[face.V3].Z)
                        },
                        new OpenTK.Vector2[] {
                            (datmesh.Mesh.HasUVs ? new OpenTK.Vector2(datmesh.Mesh.UVs[face.UV1].X, datmesh.Mesh.UVs[face.UV1].Y) : OpenTK.Vector2.Zero),
                            (datmesh.Mesh.HasUVs ? new OpenTK.Vector2(datmesh.Mesh.UVs[face.UV2].X, datmesh.Mesh.UVs[face.UV2].Y) : OpenTK.Vector2.Zero),
                            (datmesh.Mesh.HasUVs ? new OpenTK.Vector2(datmesh.Mesh.UVs[face.UV3].X, datmesh.Mesh.UVs[face.UV3].Y) : OpenTK.Vector2.Zero)
                        }
                    );
                }

                for (int i = mesh.MeshParts.Count - 1; i >= 0; i--)
                {
                    if (mesh.MeshParts[i].VertexCount == 0)
                    {
                        mesh.MeshParts.RemoveAt(i);
                    }
                    else
                    {
                        mesh.MeshParts[i].Finalise();
                    }
                }

                model.SetName(mesh.Name, model.AddMesh(mesh));
            }

            return model;
        }
    }
}
