using System.IO;

using ToxicRagers.Helpers;
using ToxicRagers.TDR2000.Formats;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.TDR2000.ContentPipeline
{
    public class MSHSImporter : ContentImporter
    {
        public override string GetExtension() { return "mshs;msh"; }

        public override Asset Import(string path)
        {
            MSHS mshs = MSHS.Load(path);
            Model model = new Model();

            string name = Path.GetFileNameWithoutExtension(path);
            int meshnum = 0;

            foreach (TDRMesh tdrmesh in mshs.Meshes)
            {
                ModelMesh mesh = new ModelMesh
                {
                    Name = $"{name}{meshnum++:0000}"
                };

                ModelMeshPart meshpart = new ModelMeshPart
                {
                    PrimitiveType = PrimitiveType.Triangles
                };

                SceneManager.Current.UpdateProgress($"Processing {mesh.Name}");

                TDRVertex v1 = null, v2 = null, v3 = null;

                switch (tdrmesh.Mode)
                {
                    case TDRMesh.MSHMode.NGon:
                        for (int i = 0; i < tdrmesh.Faces.Count; i++)
                        {
                            TDRFace face = tdrmesh.Faces[i];

                            for (int j = 2; j < face.VertexCount; j++)
                            {
                                int flip = j % 2;

                                v1 = face.Vertices[j - (2 + flip)];
                                v2 = face.Vertices[j - 1];
                                v3 = face.Vertices[j - 0];

                                meshpart.AddFace(
                                    new Vector3[] { v1.Position, v2.Position, v3.Position },
                                    new Vector3[] { v1.Normal, v2.Normal, v3.Normal },
                                    new Vector2[] { v1.UV, v2.UV, v3.UV }
                                );
                            }
                        }
                        break;

                    case TDRMesh.MSHMode.TriIndexedPosition:
                        for (int i = 0; i < tdrmesh.Faces.Count; i++)
                        {
                            TDRFace face = tdrmesh.Faces[i];
                            v1 = face.Vertices[0];
                            v2 = face.Vertices[1];
                            v3 = face.Vertices[2];

                            meshpart.AddFace(
                                new Vector3[] { tdrmesh.Positions[v1.PositionIndex], tdrmesh.Positions[v2.PositionIndex], tdrmesh.Positions[v3.PositionIndex] },
                                new Vector3[] { v1.Normal, v2.Normal, v3.Normal },
                                new Vector2[] { v1.UV, v2.UV, v3.UV }
                            );
                        }
                        break;

                    case TDRMesh.MSHMode.Tri:
                        for (int i = 0; i < tdrmesh.Faces.Count; i++)
                        {
                            TDRFace face = tdrmesh.Faces[i];
                            v1 = tdrmesh.Vertices[face.V1];
                            v2 = tdrmesh.Vertices[face.V2];
                            v3 = tdrmesh.Vertices[face.V3];

                            meshpart.AddFace(
                                new Vector3[] { v1.Position, v2.Position, v3.Position },
                                new Vector3[] { v1.Normal, v2.Normal, v3.Normal },
                                new Vector2[] { v1.UV, v2.UV, v3.UV }
                            );
                        }
                        break;
                }

                mesh.AddModelMeshPart(meshpart);
                model.SetName(mesh.Name, model.AddMesh(mesh));
            }

            return model;
        }
    }
}
