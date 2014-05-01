using System;
using System.Linq;
using ToxicRagers.Stainless.Formats;

namespace Flummery.ContentPipeline.Stainless
{
    class MDLExporter : ContentExporter
    {
        public override void Export(Asset asset, string Path)
        {
            var model = (asset as Model);

            int meshno = 0;
            int meshpartno = 0;
            bool bLeftHanded = (model.Handedness == Model.CoordinateSystem.LeftHanded);

            foreach (var mesh in model.Meshes)
            {
                var mdl = new MDL();

                meshpartno = 0;

                foreach (var meshpart in mesh.MeshParts)
                {
                    var mdlmesh = new MDLMesh((meshpart.Texture != null ? meshpart.Texture.Name : meshno + "." + meshpartno));

                    var data = meshpart.IndexBuffer.Data;
                    mdlmesh.PatchOffset = mdl.Vertices.Count;

                    for (int i = 0; i < data.Length; i += 3)
                    {
                        if (bLeftHanded)
                        {
                            mdl.Faces.Add(new MDLFace(0, mdlmesh.PatchOffset + data[i + 0], mdlmesh.PatchOffset + data[i + 2], mdlmesh.PatchOffset + data[i + 1]));

                            mdlmesh.PatchList.Add(new MDLPoint(data[i + 0]));
                            mdlmesh.PatchList.Add(new MDLPoint(data[i + 2]));
                            mdlmesh.PatchList.Add(new MDLPoint(data[i + 1]));
                        }
                        else
                        {
                            mdl.Faces.Add(new MDLFace(0, mdlmesh.PatchOffset + data[i + 0], mdlmesh.PatchOffset + data[i + 1], mdlmesh.PatchOffset + data[i + 2]));

                            mdlmesh.PatchList.Add(new MDLPoint(data[i + 0]));
                            mdlmesh.PatchList.Add(new MDLPoint(data[i + 1]));
                            mdlmesh.PatchList.Add(new MDLPoint(data[i + 2]));
                        }
                    }

                    for (int i = 0; i < meshpart.VertexBuffer.Data.Count; i++)
                    {
                        var v = meshpart.VertexBuffer.Data[i];

                        mdl.Vertices.Add(
                            new MDLVertex(
                                v.Position.X, v.Position.Y, -v.Position.Z,
                                v.Normal.X, v.Normal.Y, v.Normal.Z,
                                v.UV.X, v.UV.Y,
                                0, 0, 0, 0, 0, 0
                            )
                        );
                    }

                    mdl.Meshes.Add(mdlmesh);
                    meshpartno++;
                }

                meshno++;

                mdl.Save(Path + mesh.Name + ".mdl");
            }
        }
    }
}
