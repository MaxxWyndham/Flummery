using System;
using System.Collections.Generic;
using ToxicRagers.Carmageddon2.Formats;
using OpenTK;

namespace Flummery.ContentPipeline.Stainless
{
    class DATImporter : ContentImporter
    {
        public override Asset Import(string path)
        {
            DAT dat = DAT.Load(path);
            Model model = new Model();

            foreach (var datmesh in dat.DatMeshes)
            {
                datmesh.Mesh.GenerateNormals();
                datmesh.Mesh.AssignUVs();

                ModelMesh mesh = new ModelMesh();

                mesh.Name = (datmesh.Name.Contains(".") ? datmesh.Name.Substring(0, datmesh.Name.IndexOf(".")) : datmesh.Name);

                var pLookup = new Dictionary<int, Dictionary<int, int>>();
                var nLookup = new Dictionary<int, Dictionary<int, int>>();
                var tLookup = new Dictionary<int, Dictionary<int, int>>();

                for (int i = 0; i < datmesh.Mesh.Materials.Count; i++)
                {
                    mesh.AddModelMeshPart(new ModelMeshPart(), false);

                    pLookup[i] = new Dictionary<int, int>();
                    nLookup[i] = new Dictionary<int, int>();
                    tLookup[i] = new Dictionary<int, int>();
                }

                for (int i = 0; i < datmesh.Mesh.Faces.Count; i++)
                {
                    var face = datmesh.Mesh.Faces[i];

                    if (face.MaterialID == -1) { continue; }

                    for (int j = 0; j < face.Verts.Length; j++)
                    {
                        pLookup[face.MaterialID][face.Verts[j]] = mesh.MeshParts[face.MaterialID].CreatePosition(datmesh.Mesh.Verts[face.Verts[j]].X, datmesh.Mesh.Verts[face.Verts[j]].Y, datmesh.Mesh.Verts[face.Verts[j]].Z);
                        nLookup[face.MaterialID][face.Verts[j]] = mesh.MeshParts[face.MaterialID].CreateNormal(datmesh.Mesh.Normals[face.Verts[j]].X, datmesh.Mesh.Normals[face.Verts[j]].Y, datmesh.Mesh.Normals[face.Verts[j]].Z);
                        tLookup[face.MaterialID][face.UVs[j]] = mesh.MeshParts[face.MaterialID].CreateUV(datmesh.Mesh.UVs[face.UVs[j]].X, datmesh.Mesh.UVs[face.UVs[j]].Y);
                    }

                    if (mesh.MeshParts[face.MaterialID].Texture == null)
                    {
                        mesh.MeshParts[face.MaterialID].Texture = SceneManager.Scene.Content.Load<Texture, TIFImporter>(datmesh.Mesh.Materials[face.MaterialID].Replace("\\", ""), path.Substring(0, path.LastIndexOf("\\") + 1), true);
                    }

                    mesh.MeshParts[face.MaterialID].AddFace(
                            new int[] {
                                pLookup[face.MaterialID][face.V1],
                                pLookup[face.MaterialID][face.V2],
                                pLookup[face.MaterialID][face.V3]
                            },
                            new int[] {
                                nLookup[face.MaterialID][face.V1],
                                nLookup[face.MaterialID][face.V2],
                                nLookup[face.MaterialID][face.V3]
                            },
                            new int[] {
                                tLookup[face.MaterialID][face.UV1],
                                tLookup[face.MaterialID][face.UV2],
                                tLookup[face.MaterialID][face.UV3]
                            }
                        );
                }

                for (int i = 0; i < datmesh.Mesh.Materials.Count; i++) { mesh.MeshParts[i].Finalise(); }

                model.SetName(mesh.Name, model.AddMesh(mesh));
            }

            return model;
        }
    }
}
