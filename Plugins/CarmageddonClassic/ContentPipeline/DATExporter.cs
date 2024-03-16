using ToxicRagers.Brender.Formats;
using ToxicRagers.Helpers;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.CarmageddonClassic.ContentPipeline
{
    class DATExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            Model model = asset as Model;
            DAT dat = new();

            foreach (ModelMesh mesh in model.Meshes)
            {
                if (dat.DatMeshes.Any(d => d.Name == mesh.Name)) { continue; }

                DatMesh m = new()
                {
                    Name = mesh.Name
                };

                foreach (ModelMeshPart meshpart in mesh.MeshParts)
                {
                    m.Materials.Add(meshpart.Material?.Name ?? "DEFAULT");

                    foreach (Vertex v in meshpart.VertexBuffer.Data)
                    {
                        m.Vertices.Add(new Vector3(v.Position.X, v.Position.Y, v.Position.Z));
                        m.UVs.Add(new Vector2(v.UV.X, v.UV.Y));
                    }

                    List<int> data = meshpart.IndexBuffer.Data;

                    for (int i = 0; i < data.Count; i += 3)
                    {
                        m.Faces.Add(new DatFace
                        {
                            V1 = data[i + 0],
                            V2 = data[i + 1],
                            V3 = data[i + 2],
                            MaterialId = m.Materials.Count - 1
                        });
                    }
                }

                dat.DatMeshes.Add(m);
            }

            dat.Save(path);
        }
    }
}