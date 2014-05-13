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

                    var masterStrip = new List<int>();
                    var masterPatch = new List<int>();
                    bool bFirst = true;

                    for (int i = 0; i < meshpart.IndexBuffer.Data.Length; i += 3)
                    {
                        Console.WriteLine("{0}, {1}, {2},", meshpart.IndexBuffer.Data[i + 0], meshpart.IndexBuffer.Data[i + 1], meshpart.IndexBuffer.Data[i + 2]);
                    }

                    var stripper = new Stripper.Stripper(meshpart.IndexBuffer.Data.Length / 3, meshpart.IndexBuffer.Data);
                    stripper.ShakeItBaby();

                    foreach (var strip in stripper.Strips)
                    {
                        if (strip.Count == 3)
                        {
                            foreach (var point in strip)
                            {
                                masterPatch.Add(point);
                            }
                        }
                        else
                        {
                            if (!bFirst) { masterStrip.Add(strip[0]); } else { bFirst = false; }

                            foreach (var point in strip)
                            {
                                masterStrip.Add(point);
                            }

                            masterStrip.Add(strip[strip.Count - 1]);
                        }
                    }

                    if (masterStrip.Count > 3)
                    {
                        masterStrip.RemoveAt(masterStrip.Count - 1);

                        mdlmesh.StripOffset = mdl.Vertices.Count;
                        mdlmesh.StripList.Add(new MDLPoint(masterStrip[0], false));
                        mdlmesh.StripList.Add(new MDLPoint(masterStrip[1], false));
                        for (int i = 2; i < masterStrip.Count; i++) { mdlmesh.StripList.Add(new MDLPoint(masterStrip[i], (masterStrip.GetRange(i - 2, 3).Distinct().Count() != 3))); }

                        var x = mdlmesh.StripList.GroupBy(p => p.Index).Select(grp => grp.First()).Distinct().OrderBy(p => p.Index);

                        foreach (var p in x)
                        {
                            Console.WriteLine("{0}", p.Index);
                            var v = meshpart.VertexBuffer.Data[p.Index];

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

                        mdlmesh.StripVertCount = mdl.Vertices.Count - mdlmesh.StripOffset;
                    }

                    if (masterPatch.Count > 0)
                    {
                        mdlmesh.PatchOffset = mdl.Vertices.Count;
                        for (int i = 0; i < masterPatch.Count; i++) { mdlmesh.PatchList.Add(new MDLPoint(masterPatch[i])); }

                        foreach (var p in mdlmesh.PatchList.GroupBy(p => p.Index).Select(grp => grp.First()).Distinct().OrderBy(p => p.Index))
                        {
                            var v = meshpart.VertexBuffer.Data[p.Index];

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

                        mdlmesh.PatchVertCount = mdl.Vertices.Count - mdlmesh.PatchOffset;
                    }

                    Console.WriteLine();

                    //mdlmesh.StripOffset = mdl.Vertices.Count;
                    //int faceCount = 0;

                    //int offset = 0;
                    //for (int i = 0; i < stripper.Lengths.Count; i++)
                    //{
                    //    if (stripper.Lengths[i] == 3)
                    //    {
                    //        mdl.Faces.Add(new MDLFace(materialIndex, mdlmesh.PatchOffset + stripper.Strips[offset + 0], mdlmesh.PatchOffset + stripper.Strips[offset + 1], mdlmesh.PatchOffset + stripper.Strips[offset + 2]));

                    //        //mdlmesh.PatchList.Add(new MDLPoint(stripper.Strips[offset + 0]));
                    //        //mdlmesh.PatchList.Add(new MDLPoint(stripper.Strips[offset + 1]));
                    //        //mdlmesh.PatchList.Add(new MDLPoint(stripper.Strips[offset + 2]));
                    //    }
                    //    else
                    //    {
                    //        for (int j = 0; j < stripper.Lengths[i]; j++)
                    //        {
                    //            mdlmesh.StripList.Add(new MDLPoint(stripper.Strips[offset + j]));
                    //            faceCount++;
                    //        }

                    //        if (i + 1 < stripper.Lengths.Count)
                    //        {
                    //            mdlmesh.StripList.Add(new MDLPoint(stripper.Strips[offset + stripper.Lengths[i + 0] - 1], true));
                    //            mdlmesh.StripList.Add(new MDLPoint(stripper.Strips[offset + stripper.Lengths[i + 0]], true));
                    //        }
                    //    }

                    //    offset += stripper.Lengths[i];
                    //}

                    //for (int i = 0; i < meshpart.VertexBuffer.Data.Count; i++)
                    //{
                    //    var v = meshpart.VertexBuffer.Data[i];

                    //    var vp = Vector3.TransformVector(v.Position, exportTransform);

                    //    mdl.Vertices.Add(
                    //        new MDLVertex(
                    //            vp.X, vp.Y, vp.Z,
                    //            v.Normal.X, v.Normal.Y, v.Normal.Z,
                    //            v.UV.X, v.UV.Y,
                    //            0, 0,
                    //            0, 0, 0, 0
                    //        )
                    //    );
                    //}

                    //mdlmesh.StripVertCount = mdl.Vertices.Count - mdlmesh.StripOffset;



                    //var data = meshpart.IndexBuffer.Data;

                    //mdlmesh.PatchOffset = mdl.Vertices.Count;

                    //for (int i = 0; i < data.Length; i += 3)
                    //{
                    //    mdl.Faces.Add(new MDLFace(materialIndex, mdlmesh.PatchOffset + data[i + 0], mdlmesh.PatchOffset + data[i + 2], mdlmesh.PatchOffset + data[i + 1]));

                    //    mdlmesh.PatchList.Add(new MDLPoint(data[i + 0]));
                    //    mdlmesh.PatchList.Add(new MDLPoint(data[i + 2]));
                    //    mdlmesh.PatchList.Add(new MDLPoint(data[i + 1]));
                    //}

                    //for (int i = 0; i < meshpart.VertexBuffer.Data.Count; i++)
                    //{
                    //    var v = meshpart.VertexBuffer.Data[i];

                    //    var vp = Vector3.TransformVector(v.Position, exportTransform);

                    //    mdl.Vertices.Add(
                    //        new MDLVertex(
                    //            vp.X, vp.Y, vp.Z,
                    //            v.Normal.X, v.Normal.Y, v.Normal.Z,
                    //            v.UV.X, v.UV.Y,
                    //            0, 0,
                    //            0, 0, 0, 0
                    //        )
                    //    );
                    //}

                    //mdlmesh.PatchVertCount = mdl.Vertices.Count - mdlmesh.PatchOffset;

                    mdlmesh.CalculateExtents(mdl.Vertices);
                    mdl.Meshes.Add(mdlmesh);
                    materialIndex++;
                }

                mdl.Save(Path + mesh.Name + ".mdl");
            }
        }
    }
}
