using System;
using System.Collections.Generic;
using ToxicRagers.Helpers;
using ToxicRagers.Carmageddon2.Formats;
using OpenTK;

namespace Flummery.ContentPipeline.Stainless
{
    class DATImporter : ContentImporter
    {
        public override Asset Import(string path)
        {
            DAT dat = DAT.Load(path);
            MAT mat = MAT.Load(path.Replace(".dat", ".mat", StringComparison.OrdinalIgnoreCase));
            Model model = new Model();

            foreach (var datmesh in dat.DatMeshes)
            {
                datmesh.Mesh.GenerateNormals();
                datmesh.Mesh.AssignUVs();

                ModelMesh mesh = new ModelMesh();

                mesh.Name = (datmesh.Name.Contains(".") ? datmesh.Name.Substring(0, datmesh.Name.IndexOf(".")) : datmesh.Name);

                SceneManager.Scene.UpdateProgress(string.Format("Processing {0}", mesh.Name));

                var pLookup = new Dictionary<int, Dictionary<int, int>>();
                var nLookup = new Dictionary<int, Dictionary<int, int>>();
                var tLookup = new Dictionary<int, Dictionary<int, int>>();

                // Always create at least one mesh
                for (int i = 0; i < datmesh.Mesh.Materials.Count + 1; i++)
                {
                    mesh.AddModelMeshPart(new ModelMeshPart(), false);

                    pLookup[i] = new Dictionary<int, int>();
                    nLookup[i] = new Dictionary<int, int>();
                    tLookup[i] = new Dictionary<int, int>();
                }

                for (int i = 0; i < datmesh.Mesh.Faces.Count; i++)
                {
                    var face = datmesh.Mesh.Faces[i];
                    var materialID = face.MaterialID + 1;

                    for (int j = 0; j < face.Verts.Length; j++)
                    {
                        pLookup[materialID][face.Verts[j]] = mesh.MeshParts[materialID].CreatePosition(datmesh.Mesh.Verts[face.Verts[j]].X, datmesh.Mesh.Verts[face.Verts[j]].Y, datmesh.Mesh.Verts[face.Verts[j]].Z);
                        nLookup[materialID][face.Verts[j]] = mesh.MeshParts[materialID].CreateNormal(datmesh.Mesh.Normals[face.Verts[j]].X, datmesh.Mesh.Normals[face.Verts[j]].Y, datmesh.Mesh.Normals[face.Verts[j]].Z);
                        tLookup[materialID][face.UVs[j]] = mesh.MeshParts[materialID].CreateUV(datmesh.Mesh.UVs[face.UVs[j]].X, datmesh.Mesh.UVs[face.UVs[j]].Y);
                    }

                    if (mat != null && face.MaterialID > -1 && mesh.MeshParts[materialID].Texture == null)
                    {
                        var textureName = mat.Materials.Find(m => m.Name == datmesh.Mesh.Materials[face.MaterialID]).Texture;
                        mesh.MeshParts[materialID].Texture = SceneManager.Scene.Content.Load<Texture, TIFImporter>(textureName, path.Substring(0, path.LastIndexOf("\\") + 1), true);
                    }

                    mesh.MeshParts[materialID].AddFace(
                            new int[] {
                                pLookup[materialID][face.V1],
                                pLookup[materialID][face.V2],
                                pLookup[materialID][face.V3]
                            },
                            new int[] {
                                nLookup[materialID][face.V1],
                                nLookup[materialID][face.V2],
                                nLookup[materialID][face.V3]
                            },
                            new int[] {
                                tLookup[materialID][face.UV1],
                                tLookup[materialID][face.UV2],
                                tLookup[materialID][face.UV3]
                            }
                        );
                }

                for (int i = 0; i < datmesh.Mesh.Materials.Count + 1; i++) { mesh.MeshParts[i].Finalise(); }

                model.SetName(mesh.Name, model.AddMesh(mesh));
            }

            return model;
        }
    }
}
