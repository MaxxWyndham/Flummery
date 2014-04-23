using System;
using System.Collections.Generic;
using ToxicRagers.Stainless.Formats;
using OpenTK;

namespace Flummery.ContentPipeline.Stainless
{
    class MDLImporter
    {
        public static Model Import(string path)
        {
            MDL mdl = MDL.Load(path);
            Model model = new Model();

            model.Tag = mdl;

            ModelMesh mesh = new ModelMesh();

            for (int i = 0; i < mdl.Meshes.Count; i++)
            {
                var mdlmesh = mdl.GetMesh(i);

                int p = 0;
                ModelMeshPart meshpart = new ModelMeshPart();
                var pLookup = new Dictionary<int, int>();
                var nLookup = new Dictionary<int, int>();
                var tLookup = new Dictionary<int, int>();

                // Process triangle strip
                for (int j = 0; j < mdlmesh.StripList.Count; j++)
                {
                    pLookup[mdlmesh.StripList[j].Index] = meshpart.CreatePosition(mdl.Vertices[mdlmesh.StripList[j].Index].Position.X, mdl.Vertices[mdlmesh.StripList[j].Index].Position.Y, mdl.Vertices[mdlmesh.StripList[j].Index].Position.Z);
                    nLookup[mdlmesh.StripList[j].Index] = meshpart.CreateNormal(mdl.Vertices[mdlmesh.StripList[j].Index].Normal.X, mdl.Vertices[mdlmesh.StripList[j].Index].Normal.Y, mdl.Vertices[mdlmesh.StripList[j].Index].Normal.Z);
                    tLookup[mdlmesh.StripList[j].Index] = meshpart.CreateUV(mdl.Vertices[mdlmesh.StripList[j].Index].UV.X, mdl.Vertices[mdlmesh.StripList[j].Index].UV.Y);
                }

                for (int j = 0; j < mdlmesh.StripList.Count - 2; j++)
                {
                    if (j % 2 == 0)
                    {
                        meshpart.AddFace(
                            new int[] {
                                pLookup[mdlmesh.StripList[j + 0].Index],
                                pLookup[mdlmesh.StripList[j + 1].Index],
                                pLookup[mdlmesh.StripList[j + 2].Index]
                            }, 
                            new int[]{
                                nLookup[mdlmesh.StripList[j + 0].Index],
                                nLookup[mdlmesh.StripList[j + 1].Index],
                                nLookup[mdlmesh.StripList[j + 2].Index]
                            }, 
                            new int[]{
                                tLookup[mdlmesh.StripList[j + 0].Index],
                                tLookup[mdlmesh.StripList[j + 1].Index],
                                tLookup[mdlmesh.StripList[j + 2].Index]
                            }
                        );
                    }
                    else
                    {
                        meshpart.AddFace(
                            new int[] {
                                pLookup[mdlmesh.StripList[j + 0].Index],
                                pLookup[mdlmesh.StripList[j + 2].Index],
                                pLookup[mdlmesh.StripList[j + 1].Index]
                            },
                            new int[]{
                                nLookup[mdlmesh.StripList[j + 0].Index],
                                nLookup[mdlmesh.StripList[j + 2].Index],
                                nLookup[mdlmesh.StripList[j + 1].Index]
                            },
                            new int[]{
                                tLookup[mdlmesh.StripList[j + 0].Index],
                                tLookup[mdlmesh.StripList[j + 2].Index],
                                tLookup[mdlmesh.StripList[j + 1].Index]
                            }
                        );
                    }
                }

                // Process patch list
                for (int j = 0; j < mdlmesh.PatchList.Count; j++)
                {
                    pLookup[mdlmesh.PatchList[j].Index] = meshpart.CreatePosition(mdl.Vertices[mdlmesh.PatchList[j].Index].Position.X, mdl.Vertices[mdlmesh.PatchList[j].Index].Position.Y, mdl.Vertices[mdlmesh.PatchList[j].Index].Position.Z);
                    nLookup[mdlmesh.PatchList[j].Index] = meshpart.CreateNormal(mdl.Vertices[mdlmesh.PatchList[j].Index].Normal.X, mdl.Vertices[mdlmesh.PatchList[j].Index].Normal.Y, mdl.Vertices[mdlmesh.PatchList[j].Index].Normal.Z);
                    tLookup[mdlmesh.PatchList[j].Index] = meshpart.CreateUV(mdl.Vertices[mdlmesh.PatchList[j].Index].UV.X, mdl.Vertices[mdlmesh.PatchList[j].Index].UV.Y);
                }

                for (int j = 0; j < mdlmesh.PatchList.Count; j += 3)
                {
                    meshpart.AddFace(
                        new int[] {
                                pLookup[mdlmesh.PatchList[j + 0].Index],
                                pLookup[mdlmesh.PatchList[j + 1].Index],
                                pLookup[mdlmesh.PatchList[j + 2].Index]
                            },
                        new int[]{
                                nLookup[mdlmesh.PatchList[j + 0].Index],
                                nLookup[mdlmesh.PatchList[j + 1].Index],
                                nLookup[mdlmesh.PatchList[j + 2].Index]
                            },
                        new int[]{
                                tLookup[mdlmesh.PatchList[j + 0].Index],
                                tLookup[mdlmesh.PatchList[j + 1].Index],
                                tLookup[mdlmesh.PatchList[j + 2].Index]
                            }
                    );
                }

                mesh.AddModelMeshPart(meshpart);
            }

            model.AddMesh(mesh);

            return model;
        }
    }
}
