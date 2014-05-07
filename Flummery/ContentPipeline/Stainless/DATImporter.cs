using System;
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

                ModelMesh mesh = new ModelMesh();

                mesh.Name = (datmesh.Name.Contains(".") ? datmesh.Name.Substring(0, datmesh.Name.IndexOf(".")) : datmesh.Name);

                SceneManager.Scene.UpdateProgress(string.Format("Processing {0}", mesh.Name));

                for (int i = 0; i < datmesh.Mesh.Materials.Count + 1; i++) { mesh.AddModelMeshPart(new ModelMeshPart(), false); }

                for (int i = 0; i < datmesh.Mesh.Faces.Count; i++)
                {
                    var face = datmesh.Mesh.Faces[i];
                    var materialID = face.MaterialID + 1;

                    if (mat != null && face.MaterialID > -1 && mesh.MeshParts[materialID].Texture == null)
                    {
                        var textureName = mat.Materials.Find(m => m.Name == datmesh.Mesh.Materials[face.MaterialID]).Texture;
                        mesh.MeshParts[materialID].Texture = SceneManager.Scene.Content.Load<Texture, TIFImporter>(textureName, path.Substring(0, path.LastIndexOf("\\") + 1), true);
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
