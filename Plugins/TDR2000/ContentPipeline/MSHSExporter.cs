using System;

using ToxicRagers.Helpers;
using ToxicRagers.TDR2000.Formats;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.TDR2000.ContentPipeline
{
    public class MSHSExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            Model model = asset as Model;
            MSHS mshs = new MSHS();

            foreach (ModelMesh mesh in model.Meshes)
            {
                TDRMesh msh = new TDRMesh { Mode = TDRMesh.MSHMode.Tri };
                int offset = 0;

                foreach (ModelMeshPart meshpart in mesh.MeshParts)
                {
                    offset += msh.Vertices.Count;

                    foreach (Vertex v in meshpart.VertexBuffer.Data)
                    {
                        TDRVertex vert = new TDRVertex
                        {
                            Position = v.Position,
                            UV = new Vector2(v.UV.X, v.UV.Y),
                            Colour = new Vector4(v.Colour.R, v.Colour.G, v.Colour.B, v.Colour.A)
                        };

                        msh.Vertices.Add(vert);
                    }

                    for (int i = 0; i < meshpart.IndexBuffer.Data.Count; i += 3)
                    {
                        msh.Faces.Add(new TDRFace
                        {
                            V1 = offset + meshpart.IndexBuffer.Data[i + 0],
                            V2 = offset + meshpart.IndexBuffer.Data[i + 1],
                            V3 = offset + meshpart.IndexBuffer.Data[i + 2]
                        });
                    }

                    Console.WriteLine("Saved mesh");
                }

                mshs.Meshes.Add(msh);
            }

            mshs.Save(path);

            Console.WriteLine("Saved MSHS");
        }
    }
}