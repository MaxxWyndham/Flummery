using System;
using System.Collections.Generic;
using System.IO;

using OpenTK;
using thatGameEngine;
using thatGameEngine.ContentPipeline;
using ToxicRagers.BurnoutParadise.Formats;

namespace Flummery.ContentPipeline.BurnoutParadise
{
    class BOMImporter : ContentImporter
    {
        public override string GetExtension() { return ""; }

        public override Asset Import(string path)
        {
            BOM bom = BOM.Load(path);
            Model model = new Model();

            model.SupportingDocuments["Source"] = bom;

            for (int i = 0; i < bom.Meshes.Count; i++)
            {
                var bommesh = bom.Meshes[i];
                ModelMesh mesh = new ModelMesh();
                ModelMeshPart meshpart = new ModelMeshPart();

                if (i < 4)
                {
                    for (int j = 0; j < bommesh.IndexBuffer.Count; j += 3)
                    {
                        int p0 = bommesh.IndexBuffer[j + 0];
                        int p1 = bommesh.IndexBuffer[j + 1];
                        int p2 = bommesh.IndexBuffer[j + 2];

                        meshpart.AddFace(
                            new Vector3[] {
                                new Vector3(bom.Verts[p0].Position.X, bom.Verts[p0].Position.Y, bom.Verts[p0].Position.Z),
                                new Vector3(bom.Verts[p1].Position.X, bom.Verts[p1].Position.Y, bom.Verts[p1].Position.Z),
                                new Vector3(bom.Verts[p2].Position.X, bom.Verts[p2].Position.Y, bom.Verts[p2].Position.Z),
                            },
                            new Vector3[] {
                                new Vector3(bom.Verts[p0].Normal.X, bom.Verts[p0].Normal.Y, bom.Verts[p0].Normal.Z),
                                new Vector3(bom.Verts[p1].Normal.X, bom.Verts[p1].Normal.Y, bom.Verts[p1].Normal.Z),
                                new Vector3(bom.Verts[p2].Normal.X, bom.Verts[p2].Normal.Y, bom.Verts[p2].Normal.Z),
                            },
                            new Vector2[] {
                                Vector2.Zero,
                                Vector2.Zero,
                                Vector2.Zero
                            }
                        );
                    }
                }
                else
                {
                    // Process triangle strip
                    for (int j = 0; j < bommesh.IndexBuffer.Count - 2; j++)
                    {
                        BOMVertex v0, v1, v2;

                        v0 = bom.Verts[bommesh.IndexBuffer[j + 0]];

                        if (j % 2 != 0)
                        {
                            v1 = bom.Verts[bommesh.IndexBuffer[j + 1]];
                            v2 = bom.Verts[bommesh.IndexBuffer[j + 2]];
                        }
                        else
                        {
                            v1 = bom.Verts[bommesh.IndexBuffer[j + 2]];
                            v2 = bom.Verts[bommesh.IndexBuffer[j + 1]];
                        }

                        meshpart.AddFace(
                            new Vector3[] {
                                new Vector3(v0.Position.X, v0.Position.Y, v0.Position.Z),
                                new Vector3(v1.Position.X, v1.Position.Y, v1.Position.Z),
                                new Vector3(v2.Position.X, v2.Position.Y, v2.Position.Z)
                            },
                            new Vector3[] {
                                new Vector3(v0.Normal.X, v0.Normal.Y, v0.Normal.Z),
                                new Vector3(v1.Normal.X, v1.Normal.Y, v1.Normal.Z),
                                new Vector3(v2.Normal.X, v2.Normal.Y, v2.Normal.Z)
                            },
                            new Vector2[] {
                                Vector2.Zero,
                                Vector2.Zero,
                                Vector2.Zero
                            }
                        );
                    }
                }

                mesh.AddModelMeshPart(meshpart);

                mesh.Name = bom.Name + "_" + i;
                model.SetName(bom.Name, model.AddMesh(mesh));
            }

            return model;
        }
    }
}
