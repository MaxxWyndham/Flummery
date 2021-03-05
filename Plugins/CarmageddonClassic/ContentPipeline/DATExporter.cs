using System.Collections.Generic;

using ToxicRagers.Carmageddon2.Formats;
using ToxicRagers.Carmageddon2.Helpers;
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
            DAT dat = new DAT();

            foreach (ModelMesh mesh in model.Meshes)
            {
                C2Mesh m = new C2Mesh();

                foreach (ModelMeshPart meshpart in mesh.MeshParts)
                {
                    m.AddListMaterial((meshpart.Material == null || meshpart.Material.Name == null ? "DEFAULT" : meshpart.Material.Name));

                    List<int> data = meshpart.IndexBuffer.Data;

                    for (int i = 0; i < data.Count; i += 3)
                    {
                        Vertex v0 = meshpart.VertexBuffer.Data[data[i + 0]];
                        Vertex v1 = meshpart.VertexBuffer.Data[data[i + 1]];
                        Vertex v2 = meshpart.VertexBuffer.Data[data[i + 2]];

                        m.AddFace(
                            new Vector3(v0.Position.X, v0.Position.Y, v0.Position.Z),
                            new Vector3(v1.Position.X, v1.Position.Y, v1.Position.Z),
                            new Vector3(v2.Position.X, v2.Position.Y, v2.Position.Z),
                            new Vector2(v0.UV.X, v0.UV.Y),
                            new Vector2(v1.UV.X, v1.UV.Y),
                            new Vector2(v2.UV.X, v2.UV.Y),
                            m.Materials.Count - 1
                        );
                    }
                }

                m.Optimise();
                m.ProcessMesh();

                dat.AddMesh(mesh.Name, 0, m);
            }

            dat.Save(path);
        }
    }
}