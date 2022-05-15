using System;
using System.IO;
using System.Linq;

using ToxicRagers.Carmageddon2.Formats;
using ToxicRagers.Helpers;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.CarmageddonClassic.ContentPipeline
{
    class DATImporter : ContentImporter
    {
        public override string GetExtension() { return "dat"; }

        public override string GetHints(string currentPath)
        {
            string hints = string.Empty;

            if (currentPath != null && Directory.Exists(currentPath))
            {
                hints = $"{currentPath};";

                if (Directory.Exists(Path.Combine(Directory.GetParent(currentPath).FullName, "MODELS")))
                {
                    hints += $"{Path.Combine(Directory.GetParent(currentPath).FullName, "MODELS")};";
                }
            }

            return hints;
        }

        public override Asset Import(string path)
        {
            DAT dat = DAT.Load(path);
            SceneManager.Current.Content.LoadMany<MaterialList, MATImporter>($"{Path.GetFileNameWithoutExtension(path)}.mat", Path.GetDirectoryName(path), true);
            Model model = new Model();

            model.SupportingDocuments.Add("Source", dat);

            foreach (DatMesh datmesh in dat.DatMeshes)
            {
                Console.WriteLine(datmesh.Name);
                datmesh.Mesh.GenerateNormals();

                ModelMesh mesh = new ModelMesh
                {
                    Name = datmesh.Name
                };

                SceneManager.Current.UpdateProgress($"Processing {mesh.Name}");

                for (int i = -1; i < datmesh.Mesh.Materials.Count; i++)
                {
                    ModelMeshPart meshpart = new ModelMeshPart();

                    if (i > -1)
                    {
                        Asset material = SceneManager.Current.Materials.Entries.Find(m => m != null && m.Name == datmesh.Mesh.Materials[i]);

                        if (material == null)
                        {
                            material = new Material { Name = datmesh.Mesh.Materials[i] };
                            SceneManager.Current.Add(material);
                        }

                        meshpart.Material = (Material)material;
                    }

                    foreach (ToxicRagers.Carmageddon2.Helpers.C2Face face in datmesh.Mesh.Faces.Where(f => f.MaterialID == i))
                    {
                        int smoothingGroup = face.SmoothingGroup << 8;

                        meshpart.AddFace(
                            new Vector3[] 
                            {
                                datmesh.Mesh.Verts[face.V1],
                                datmesh.Mesh.Verts[face.V2],
                                datmesh.Mesh.Verts[face.V3]
                            },
                            new Vector3[] 
                            {
                                datmesh.Mesh.Normals[smoothingGroup + face.V1],
                                datmesh.Mesh.Normals[smoothingGroup + face.V2],
                                datmesh.Mesh.Normals[smoothingGroup + face.V3]
                            },
                            new Vector2[] 
                            {
                                datmesh.Mesh.HasUVs ? datmesh.Mesh.UVs[face.UV1] : Vector2.Zero,
                                datmesh.Mesh.HasUVs ? datmesh.Mesh.UVs[face.UV2] : Vector2.Zero,
                                datmesh.Mesh.HasUVs ? datmesh.Mesh.UVs[face.UV3] : Vector2.Zero
                            },
                            new int[]
                            {
                                face.V1,
                                face.V2,
                                face.V3
                            }
                        );
                    }

                    mesh.AddModelMeshPart(meshpart, false);
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
