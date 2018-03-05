using System;
using System.Collections.Generic;
using System.Linq;

using ToxicRagers.Stainless.Formats;

namespace Flummery.ContentPipeline.NuCarma
{
    class MDLExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            Model model = (asset as Model);

            int materialIndex = 1;

            ModelManipulator.PreProcess(model, PreProcessOptions.SplitMeshPart); //PreProcessOptions.Dedupe |  | PreProcessOptions.ResolveNonManifold

            foreach (ModelMesh mesh in model.Meshes)
            {
                MDL mdl = new MDL();
                //mdl.ModelFlags = MDL.Flags.USERData;

                materialIndex = 0;

                foreach (ModelMeshPart meshpart in mesh.MeshParts.OrderByDescending(m => m.VertexCount).ToList())
                {
                    MDLMaterialGroup mdlmesh = new MDLMaterialGroup(materialIndex, (meshpart.Material != null ? meshpart.Material.Name : "DEFAULT"));

                    int masterVertOffset = mdl.Vertices.Count;

                    foreach (Vertex v in meshpart.VertexBuffer.Data)
                    {
                        mdl.Vertices.Add(
                            new MDLVertex(
                                v.Position.X, v.Position.Y, v.Position.Z,
                                v.Normal.X, v.Normal.Y, v.Normal.Z,
                                v.UV.X, v.UV.Y,
                                v.UV.Z, v.UV.W,
                                (byte)(v.Colour.R * 255), (byte)(v.Colour.G * 255), (byte)(v.Colour.B * 255), (byte)(v.Colour.A * 255)
                            )
                        );
                    }

                    for (int i = 0; i < meshpart.IndexBuffer.Data.Count; i += 3)
                    {
                        mdl.Faces.Add(new MDLFace(materialIndex, 0, masterVertOffset + meshpart.IndexBuffer.Data[i + 0], masterVertOffset + meshpart.IndexBuffer.Data[i + 1], masterVertOffset + meshpart.IndexBuffer.Data[i + 2]));
                    }

                    Stripper.Stripper stripper = new Stripper.Stripper(meshpart.IndexBuffer.Data.Count / 3, meshpart.IndexBuffer.Data.ToArray())
                    {
                        OneSided = true,
                        ConnectAllStrips = true
                    };

                    stripper.ShakeItBaby();

                    if (stripper.Strips[0].Count > 3)
                    {
                        List<int> strip = stripper.Strips[0];

                        if ((strip.Count & 1) == 1)
                        {
                            strip.Reverse();
                        }
                        else
                        {
                            strip.Insert(0, strip[0]);
                        }

                        HashSet<int> uniqueVerts = new HashSet<int> { strip[0], strip[1] };

                        mdlmesh.StripOffset = masterVertOffset;
                        mdlmesh.StripList.Add(new MDLPoint(strip[0], false));
                        mdlmesh.StripList.Add(new MDLPoint(strip[1], false));

                        for (int i = 2; i < strip.Count; i++)
                        {
                            uniqueVerts.Add(strip[i]);

                            MDLPoint point = new MDLPoint(strip[i], (strip.GetRange(i - 2, 3).Distinct().Count() != 3));

                            mdlmesh.StripList.Add(point);
                        }

                        mdlmesh.StripVertCount = uniqueVerts.Count;
                    }

                    int patchOffset = int.MaxValue;

                    for (int i = 1; i < stripper.Strips.Count; i++) { patchOffset = Math.Min(patchOffset, stripper.Strips[i].Min()); }

                    for (int i = 1; i < stripper.Strips.Count; i++)
                    {
                        List<int> patch = stripper.Strips[i];

                        mdlmesh.TriListOffset = masterVertOffset + patchOffset;

                        for (int j = 2; j >= 0; j--)
                        {
                            int index = patch[j] - patchOffset;

                            mdlmesh.TriList.Add(new MDLPoint(index));
                            mdlmesh.TriListVertCount = Math.Max(mdlmesh.TriListVertCount, index + 1);
                        }
                    }

                    mdlmesh.CalculateExtents(mdl.Vertices);
                    mdl.Meshes.Add(mdlmesh);
                    materialIndex++;

                    Console.WriteLine("Saved mesh");
                }

                mdl.Save(path + mesh.Name + ".mdl");
                Console.WriteLine("Saved MDL");
            }
        }
    }
}