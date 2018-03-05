using System;
using System.IO;
using System.Linq;

using ToxicRagers.Carmageddon2.Formats;

namespace Flummery.ContentPipeline.CarmaClassic
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
            SceneManager.Current.Content.LoadMany<MaterialList, MATImporter>($"{Path.GetFileNameWithoutExtension(path)}.mat", Path.GetDirectoryName(path), true);
            Model model = new Model();

            foreach (DatMesh datmesh in dat.DatMeshes)
            {
                Console.WriteLine(datmesh.Name);
                datmesh.Mesh.GenerateNormals();

                ModelMesh mesh = new ModelMesh
                {
                    Name = (datmesh.Name.Contains(".") ? datmesh.Name.Substring(0, datmesh.Name.IndexOf(".")) : datmesh.Name)
                };

                SceneManager.Current.UpdateProgress(string.Format("Processing {0}", mesh.Name));

                for (int i = -1; i < datmesh.Mesh.Materials.Count; i++)
                {
                    ModelMeshPart meshpart = new ModelMeshPart();

                    if (i > -1)
                    {
                        Asset material = SceneManager.Current.Materials.Entries.Find(m => m.Name == datmesh.Mesh.Materials[i]);

                        if (material == null)
                        {
                            material = new Material { Name = datmesh.Mesh.Materials[i] };
                            SceneManager.Current.Add(material);
                        }

                        meshpart.Material = (Material)material;
                    }

                    foreach (ToxicRagers.Carmageddon2.Helpers.C2Face face in datmesh.Mesh.Faces.Where(f => f.MaterialID == i))
                    {
                        int smoothingGroup = (face.SmoothingGroup << 8);

                        meshpart.AddFace(
                            new OpenTK.Vector3[] {
                                    new OpenTK.Vector3(datmesh.Mesh.Verts[face.V1].X, datmesh.Mesh.Verts[face.V1].Y, datmesh.Mesh.Verts[face.V1].Z),
                                    new OpenTK.Vector3(datmesh.Mesh.Verts[face.V2].X, datmesh.Mesh.Verts[face.V2].Y, datmesh.Mesh.Verts[face.V2].Z),
                                    new OpenTK.Vector3(datmesh.Mesh.Verts[face.V3].X, datmesh.Mesh.Verts[face.V3].Y, datmesh.Mesh.Verts[face.V3].Z)
                                },
                            new OpenTK.Vector3[] {
                                    new OpenTK.Vector3(datmesh.Mesh.Normals[smoothingGroup + face.V1].X, datmesh.Mesh.Normals[smoothingGroup + face.V1].Y, datmesh.Mesh.Normals[smoothingGroup + face.V1].Z),
                                    new OpenTK.Vector3(datmesh.Mesh.Normals[smoothingGroup + face.V2].X, datmesh.Mesh.Normals[smoothingGroup + face.V2].Y, datmesh.Mesh.Normals[smoothingGroup + face.V2].Z),
                                    new OpenTK.Vector3(datmesh.Mesh.Normals[smoothingGroup + face.V3].X, datmesh.Mesh.Normals[smoothingGroup + face.V3].Y, datmesh.Mesh.Normals[smoothingGroup + face.V3].Z)
                            },
                            new OpenTK.Vector2[] {
                                    (datmesh.Mesh.HasUVs ? new OpenTK.Vector2(datmesh.Mesh.UVs[face.UV1].X, datmesh.Mesh.UVs[face.UV1].Y) : OpenTK.Vector2.Zero),
                                    (datmesh.Mesh.HasUVs ? new OpenTK.Vector2(datmesh.Mesh.UVs[face.UV2].X, datmesh.Mesh.UVs[face.UV2].Y) : OpenTK.Vector2.Zero),
                                    (datmesh.Mesh.HasUVs ? new OpenTK.Vector2(datmesh.Mesh.UVs[face.UV3].X, datmesh.Mesh.UVs[face.UV3].Y) : OpenTK.Vector2.Zero)
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
