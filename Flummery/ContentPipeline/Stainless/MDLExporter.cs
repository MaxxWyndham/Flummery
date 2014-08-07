using System;
using System.Collections.Generic;
using System.Linq;
using ToxicRagers.Stainless.Formats;
using OpenTK;

namespace Flummery.ContentPipeline.Stainless
{
    class MDLExporter : ContentExporter
    {
        public override void Export(Asset asset, string Path)
        {
            var exportTransform = (settings.HasSetting("Transform") ? settings.GetSetting<Matrix4>("Transform") : Matrix4.Identity);
            var exportHandedness = (settings.HasSetting("Handed") ? settings.GetSetting<Model.CoordinateSystem>("Handed") : Model.CoordinateSystem.LeftHanded);

            var model = (asset as Model);
            model.Handedness = exportHandedness;

            int materialIndex = 1;
            bool bLeftHanded = (model.Handedness == Model.CoordinateSystem.LeftHanded);

            foreach (var mesh in model.Meshes)
            {
                var mdl = new MDL();
                //mdl.ModelFlags = MDL.Flags.USERData;

                materialIndex = 0;

                foreach (var meshpart in mesh.MeshParts.OrderByDescending(m => m.VertexCount).ToList())
                {
                    var mdlmesh = new MDLMaterialGroup((meshpart.Material != null ? meshpart.Material.Name : "DEFAULT"));
                    bool bUseTrianglestrips = false;

                    if (bUseTrianglestrips)
                    {
                        int masterVertOffset = mdl.Vertices.Count;

                        foreach (var v in meshpart.VertexBuffer.Data)
                        {
                            var vp = Vector3.TransformVector(v.Position, exportTransform);

                            mdl.Vertices.Add(
                                new MDLVertex(
                                    vp.X, vp.Y, vp.Z,
                                    v.Normal.X, v.Normal.Y, v.Normal.Z,
                                    v.UV.X, v.UV.Y,
                                    v.UV.Z, v.UV.W,
                                    (byte)(v.Colour.R * 255), (byte)(v.Colour.G * 255), (byte)(v.Colour.B * 255), (byte)(v.Colour.A * 255)
                                )
                            );
                        }

                        // Normalise input triangles
                        for (int i = 0; i < meshpart.IndexBuffer.Data.Count; i += 3)
                        {
                            var n = Vector3.Cross(
                                meshpart.VertexBuffer.Data[meshpart.IndexBuffer.Data[i + 1]].Position - meshpart.VertexBuffer.Data[meshpart.IndexBuffer.Data[i + 0]].Position,
                                meshpart.VertexBuffer.Data[meshpart.IndexBuffer.Data[i + 2]].Position - meshpart.VertexBuffer.Data[meshpart.IndexBuffer.Data[i + 0]].Position
                            ).Normalized();

                            if (n.X < 0 || n.Y < 0 || n.Z < 0)
                            {
                                int t = meshpart.IndexBuffer.Data[i + 1];
                                meshpart.IndexBuffer.Data[i + 1] = meshpart.IndexBuffer.Data[i + 2];
                                meshpart.IndexBuffer.Data[i + 2] = t;
                            }
                        }

                        var stripper = new Stripper.Stripper(meshpart.IndexBuffer.Data.Count / 3, meshpart.IndexBuffer.Data.ToArray());
                        stripper.OneSided = true;
                        stripper.ConnectAllStrips = true;
                        stripper.ShakeItBaby();

                        if (stripper.Strips[0].Count > 3)
                        {
                            var strip = stripper.Strips[0];

                            mdlmesh.StripOffset = masterVertOffset;
                            mdlmesh.StripList.Add(new MDLPoint(strip[0], false));
                            mdlmesh.StripList.Add(new MDLPoint(strip[1], false));
                            for (int i = 2; i < strip.Count; i++)
                            {
                                var point = new MDLPoint(strip[i], (strip.GetRange(i - 2, 3).Distinct().Count() != 3));

                                mdlmesh.StripList.Add(point);

                                if (!point.Degenerate) { mdl.Faces.Add(new MDLFace(materialIndex, 0, mdlmesh.StripOffset + strip[i - 2], mdlmesh.StripOffset + strip[i - 1], mdlmesh.StripOffset + strip[i - 0])); }
                            }

                            mdlmesh.StripVertCount = 0;
                        }

                        for (int i = 1; i < stripper.Strips.Count; i++)
                        {
                            var patchOffset = 0;
                            var patch = stripper.Strips[i];

                            if (i == 1) { patchOffset = Math.Min(patch[0], Math.Min(patch[1], patch[2])); }

                            mdlmesh.TriListOffset = masterVertOffset + patchOffset;
                            for (int j = 0; j < 3; j++) { mdlmesh.TriList.Add(new MDLPoint(patch[j] - patchOffset)); }
                            mdl.Faces.Add(new MDLFace(materialIndex, 0, patch[0], patch[1], patch[2]));
                        }
                    }
                    else
                    {
                        var data = meshpart.IndexBuffer.Data;

                        mdlmesh.TriListOffset = mdl.Vertices.Count;

                        for (int i = 0; i < data.Count; i += 3)
                        {
                            mdl.Faces.Add(new MDLFace(materialIndex, 0, mdlmesh.TriListOffset + data[i + 0], mdlmesh.TriListOffset + data[i + 2], mdlmesh.TriListOffset + data[i + 1]));

                            if (bLeftHanded)
                            {
                                mdlmesh.TriList.Add(new MDLPoint(data[i + 0]));
                                mdlmesh.TriList.Add(new MDLPoint(data[i + 2]));
                                mdlmesh.TriList.Add(new MDLPoint(data[i + 1]));
                            }
                            else
                            {
                                mdlmesh.TriList.Add(new MDLPoint(data[i + 0]));
                                mdlmesh.TriList.Add(new MDLPoint(data[i + 1]));
                                mdlmesh.TriList.Add(new MDLPoint(data[i + 2]));
                            }
                        }

                        for (int i = 0; i < meshpart.VertexBuffer.Data.Count; i++)
                        {
                            var v = meshpart.VertexBuffer.Data[i];
                            var vp = Vector3.TransformVector(v.Position, exportTransform);

                            mdl.Vertices.Add(
                                new MDLVertex(
                                    vp.X, vp.Y, vp.Z,
                                    v.Normal.X, v.Normal.Y, v.Normal.Z,
                                    v.UV.X, v.UV.Y,
                                    v.UV.Z, v.UV.W,
                                    (byte)v.Colour.R, (byte)v.Colour.G, (byte)v.Colour.B, (byte)v.Colour.A
                                )
                            );
                        }

                        mdlmesh.TriListVertCount = mdl.Vertices.Count - mdlmesh.TriListOffset;
                    }

                    mdlmesh.CalculateExtents(mdl.Vertices);
                    mdl.Meshes.Add(mdlmesh);
                    materialIndex++;

                    Console.WriteLine("Saved mesh");
                }

                mdl.Save(Path + mesh.Name + ".mdl");
            }
        }
    }
}
