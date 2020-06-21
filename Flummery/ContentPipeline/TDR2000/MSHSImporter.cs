using System.IO;

using ToxicRagers.TDR2000.Formats;


namespace Flummery.ContentPipeline.TDR2000
{
    class MSHSImporter : ContentImporter
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
                    PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType.Triangles
                };

                SceneManager.Current.UpdateProgress($"Processing {mesh.Name}");

                for (int i = 0; i < tdrmesh.Faces.Count; i++)
                {
                    TDRFace face = tdrmesh.Faces[i];
                    TDRVertex v1 = tdrmesh.Vertexes[face.V1];
                    TDRVertex v2 = tdrmesh.Vertexes[face.V2];
                    TDRVertex v3 = tdrmesh.Vertexes[face.V3];

                    meshpart.AddFace(
                        new OpenTK.Vector3[] {
                            new OpenTK.Vector3(v1.Position.X, v1.Position.Y, v1.Position.Z),
                            new OpenTK.Vector3(v2.Position.X, v2.Position.Y, v2.Position.Z),
                            new OpenTK.Vector3(v3.Position.X, v3.Position.Y, v3.Position.Z)
                        },
                        new OpenTK.Vector3[] {
                            new OpenTK.Vector3(v1.Normal.X, v1.Normal.Y, v1.Normal.Z),
                            new OpenTK.Vector3(v2.Normal.X, v2.Normal.Y, v2.Normal.Z),
                            new OpenTK.Vector3(v3.Normal.X, v3.Normal.Y, v3.Normal.Z)
                        },
                        new OpenTK.Vector2[] {
                            new OpenTK.Vector2(v1.UV.X, v1.UV.Y),
                            new OpenTK.Vector2(v2.UV.X, v2.UV.Y),
                            new OpenTK.Vector2(v3.UV.X, v3.UV.Y)
                        }
                    );
                }

                mesh.AddModelMeshPart(meshpart);
                model.SetName(mesh.Name, model.AddMesh(mesh));
            }

            

            return model;
        }
    }
}
