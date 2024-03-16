using ToxicRagers.Brender.Formats;
using ToxicRagers.Helpers;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.CarmageddonClassic.ContentPipeline
{
    class DATImporter : ContentImporter
    {
        public override string GetExtension() { return "dat;dan"; }

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
            Model model = new();

            model.SupportingDocuments.Add("Source", dat);

            foreach (DatMesh datmesh in dat.DatMeshes)
            {
                Console.WriteLine(datmesh.Name);

                ModelMesh mesh = new()
                {
                    Name = datmesh.Name
                };

                SceneManager.Current.UpdateProgress($"Processing {mesh.Name}");

                List<Vector3> faceNormals = new();

                foreach (DatFace face in datmesh.Faces)
                {
                    Vector3 v0 = datmesh.Vertices[face.V1];
                    Vector3 v1 = datmesh.Vertices[face.V2];
                    Vector3 v2 = datmesh.Vertices[face.V3];

                    Vector3 u = v0 - v1;
                    Vector3 v = v0 - v2;

                    faceNormals.Add(Vector3.Cross(u, v).Normalised);
                }

                Dictionary<int, Vector3> normals = new();

                for (int j = 0; j < datmesh.Vertices.Count; j++)
                {
                    foreach (var face in datmesh.Faces
                                        .Select((f, i) => new { face = f, index = i })
                                        .Where(f => f.face.V1 == j || f.face.V2 == j || f.face.V3 == j))
                    {
                        int index = face.face.SmoothingGroup << 16;

                        if (normals.ContainsKey(index + j)) { normals[index + j] += faceNormals[face.index]; } else { normals[index + j] = faceNormals[face.index]; }
                    }
                }

                foreach (var kvp in normals)
                {
                    normals[kvp.Key] = kvp.Value.Normalised;
                }

                for (int i = 0; i <= datmesh.Materials.Count; i++)
                {
                    ModelMeshPart meshpart = new();

                    if (i > 0)
                    {
                        Asset material = SceneManager.Current.Materials.Entries.Find(m => m != null && m.Name == datmesh.Materials[i - 1]);

                        if (material == null)
                        {
                            material = new Material { Name = datmesh.Materials[i - 1] };
                            SceneManager.Current.Add(material);
                        }

                        meshpart.Material = (Material)material;
                    }

                    foreach (DatFace face in datmesh.Faces.Where(f => f.MaterialId == i))
                    {
                        int smoothingGroup = face.SmoothingGroup << 16;

                        meshpart.AddFace(
                            new Vector3[] 
                            {
                                datmesh.Vertices[face.V1],
                                datmesh.Vertices[face.V2],
                                datmesh.Vertices[face.V3]
                            },
                            new Vector3[] 
                            {
                                normals[smoothingGroup + face.V1],
                                normals[smoothingGroup + face.V2],
                                normals[smoothingGroup + face.V3]
                            },
                            new Vector2[] 
                            {
                                datmesh.UVs.Count > 0 ? datmesh.UVs[face.V1] : Vector2.Zero,
                                datmesh.UVs.Count > 0 ? datmesh.UVs[face.V2] : Vector2.Zero,
                                datmesh.UVs.Count > 0 ? datmesh.UVs[face.V3] : Vector2.Zero
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
