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
            var exportTransform = (settings.Transform != null ? (Matrix4)(settings.Transform) : Matrix4.Identity);

            var model = (asset as Model);

            int materialIndex = 1;
            bool bLeftHanded = (model.Handedness == Model.CoordinateSystem.LeftHanded);

            foreach (var mesh in model.Meshes)
            {
                var mdl = new MDL();

                materialIndex = 0;

                foreach (var meshpart in mesh.MeshParts)
                {
                    var mdlmesh = new MDLMesh((meshpart.Material != null ? meshpart.Material.Name : "DEFAULT"));
                    bool bUseTrianglestrips = false;

                    if (bUseTrianglestrips)
                    {
                        var masterStrip = new List<int>();
                        var masterPatch = new List<int>();

                        int masterVertOffset = mdl.Vertices.Count;
                        int masterPatchOffset = int.MaxValue;

                        foreach (var v in meshpart.VertexBuffer.Data)
                        {
                            var vp = Vector3.TransformVector(v.Position, exportTransform);

                            mdl.Vertices.Add(
                                new MDLVertex(
                                    vp.X, vp.Y, vp.Z,
                                    v.Normal.X, v.Normal.Y, v.Normal.Z,
                                    v.UV.X, v.UV.Y,
                                    0, 0,
                                    0, 0, 0, 0
                                )
                            );
                        }

                        var stripper = new Stripper.Stripper(meshpart.IndexBuffer.Data.Length / 3, meshpart.IndexBuffer.Data);
                        stripper.OneSided = true;
                        stripper.ShakeItBaby();

                        for (int i = 0; i < stripper.Strips.Count; i++)
                        {
                            var strip = stripper.Strips[i];

                            if (strip.Count == 3)
                            {
                                foreach (var point in strip)
                                {
                                    masterPatchOffset = Math.Min(masterPatchOffset, point);
                                    masterPatch.Add(point);
                                }
                            }
                            else
                            {
                                if (i > 0)
                                {
                                    if (stripper.Strips[i - 1].Count % 2 != 0) { masterStrip.Add(strip[0]); }
                                    masterStrip.Add(strip[0]);
                                }

                                foreach (var point in strip) { masterStrip.Add(point); }

                                if (i + 1 != stripper.Strips.Count) { masterStrip.Add(strip[strip.Count - 1]); }
                            }
                        }

                        if (masterStrip.Count > 0)
                        {
                            mdlmesh.StripOffset = masterVertOffset;
                            mdlmesh.StripList.Add(new MDLPoint(masterStrip[0], false));
                            mdlmesh.StripList.Add(new MDLPoint(masterStrip[1], false));
                            for (int i = 2; i < masterStrip.Count; i++)
                            {
                                var point = new MDLPoint(masterStrip[i], (masterStrip.GetRange(i - 2, 3).Distinct().Count() != 3));

                                mdlmesh.StripList.Add(point);

                                if (!point.Degenerate) { mdl.Faces.Add(new MDLFace(materialIndex, mdlmesh.StripOffset + masterStrip[i - 2], mdlmesh.StripOffset + masterStrip[i - 1], mdlmesh.StripOffset + masterStrip[i - 0])); }
                            }

                            mdlmesh.StripVertCount = masterVertOffset;
                        }

                        if (masterPatch.Count > 0)
                        {
                            mdlmesh.PatchOffset = masterVertOffset + masterPatchOffset;
                            for (int i = 0; i < masterPatch.Count; i++)
                            {
                                mdlmesh.PatchList.Add(new MDLPoint(masterPatch[i] - masterPatchOffset));
                                if ((i & 3) == 3) { mdl.Faces.Add(new MDLFace(materialIndex, masterPatch[i - 2], masterPatch[i - 1], masterPatch[i - 0])); }
                            }

                            mdlmesh.PatchVertCount = masterPatchOffset + masterPatchOffset;
                        }

                    }
                    else
                    {
                        var data = meshpart.IndexBuffer.Data;

                        mdlmesh.PatchOffset = mdl.Vertices.Count;

                        for (int i = 0; i < data.Length; i += 3)
                        {
                            mdl.Faces.Add(new MDLFace(materialIndex, mdlmesh.PatchOffset + data[i + 0], mdlmesh.PatchOffset + data[i + 2], mdlmesh.PatchOffset + data[i + 1]));

                            mdlmesh.PatchList.Add(new MDLPoint(data[i + 0]));
                            mdlmesh.PatchList.Add(new MDLPoint(data[i + 2]));
                            mdlmesh.PatchList.Add(new MDLPoint(data[i + 1]));
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
                                    v.UV.X, v.UV.Y,
                                    255, 255, 255, 255
                                )
                            );
                        }

                        mdlmesh.PatchVertCount = mdl.Vertices.Count - mdlmesh.PatchOffset;
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
