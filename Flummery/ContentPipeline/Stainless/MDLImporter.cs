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
                var vLookup = new Dictionary<int, int>();

                // Process triangle strip
                for (int j = 0; j < mdlmesh.StripList.Count; j++)
                {
                    vLookup[mdlmesh.StripList[j].Index] = meshpart.CreatePosition(mdl.Vertices[mdlmesh.StripList[j].Index].Position.X, mdl.Vertices[mdlmesh.StripList[j].Index].Position.Y, mdl.Vertices[mdlmesh.StripList[j].Index].Position.Z);
                }

                for (int j = 0; j < mdlmesh.StripList.Count - 2; j++)
                {
                    if (j % 2 == 0)
                    {
                        meshpart.AddTriangleVertex(vLookup[mdlmesh.StripList[j + 0].Index]);
                        meshpart.AddTriangleVertex(vLookup[mdlmesh.StripList[j + 1].Index]);
                        meshpart.AddTriangleVertex(vLookup[mdlmesh.StripList[j + 2].Index]);

                        meshpart.AddVertexNormal(new Vector3(mdl.Vertices[mdlmesh.StripList[j + 0].Index].Normal.X, mdl.Vertices[mdlmesh.StripList[j + 0].Index].Normal.Y, mdl.Vertices[mdlmesh.StripList[j + 0].Index].Normal.Z));
                        meshpart.AddVertexNormal(new Vector3(mdl.Vertices[mdlmesh.StripList[j + 1].Index].Normal.X, mdl.Vertices[mdlmesh.StripList[j + 1].Index].Normal.Y, mdl.Vertices[mdlmesh.StripList[j + 1].Index].Normal.Z));
                        meshpart.AddVertexNormal(new Vector3(mdl.Vertices[mdlmesh.StripList[j + 2].Index].Normal.X, mdl.Vertices[mdlmesh.StripList[j + 2].Index].Normal.Y, mdl.Vertices[mdlmesh.StripList[j + 2].Index].Normal.Z));

                        meshpart.AddVertexUV(new Vector2(mdl.Vertices[mdlmesh.StripList[j + 0].Index].UV.X, mdl.Vertices[mdlmesh.StripList[j + 0].Index].UV.Y));
                        meshpart.AddVertexUV(new Vector2(mdl.Vertices[mdlmesh.StripList[j + 1].Index].UV.X, mdl.Vertices[mdlmesh.StripList[j + 1].Index].UV.Y));
                        meshpart.AddVertexUV(new Vector2(mdl.Vertices[mdlmesh.StripList[j + 2].Index].UV.X, mdl.Vertices[mdlmesh.StripList[j + 2].Index].UV.Y));
                    }
                    else
                    {
                        meshpart.AddTriangleVertex(vLookup[mdlmesh.StripList[j + 0].Index]);
                        meshpart.AddTriangleVertex(vLookup[mdlmesh.StripList[j + 2].Index]);
                        meshpart.AddTriangleVertex(vLookup[mdlmesh.StripList[j + 1].Index]);

                        meshpart.AddVertexNormal(new Vector3(mdl.Vertices[mdlmesh.StripList[j + 0].Index].Normal.X, mdl.Vertices[mdlmesh.StripList[j + 0].Index].Normal.Y, mdl.Vertices[mdlmesh.StripList[j + 0].Index].Normal.Z));
                        meshpart.AddVertexNormal(new Vector3(mdl.Vertices[mdlmesh.StripList[j + 2].Index].Normal.X, mdl.Vertices[mdlmesh.StripList[j + 2].Index].Normal.Y, mdl.Vertices[mdlmesh.StripList[j + 2].Index].Normal.Z));
                        meshpart.AddVertexNormal(new Vector3(mdl.Vertices[mdlmesh.StripList[j + 1].Index].Normal.X, mdl.Vertices[mdlmesh.StripList[j + 1].Index].Normal.Y, mdl.Vertices[mdlmesh.StripList[j + 1].Index].Normal.Z));

                        meshpart.AddVertexUV(new Vector2(mdl.Vertices[mdlmesh.StripList[j + 0].Index].UV.X, mdl.Vertices[mdlmesh.StripList[j + 0].Index].UV.Y));
                        meshpart.AddVertexUV(new Vector2(mdl.Vertices[mdlmesh.StripList[j + 2].Index].UV.X, mdl.Vertices[mdlmesh.StripList[j + 2].Index].UV.Y));
                        meshpart.AddVertexUV(new Vector2(mdl.Vertices[mdlmesh.StripList[j + 1].Index].UV.X, mdl.Vertices[mdlmesh.StripList[j + 1].Index].UV.Y));
                    }
                }

                // Process patch list
                for (int j = 0; j < mdlmesh.PatchList.Count; j++)
                {
                    vLookup[mdlmesh.PatchList[j].Index] = meshpart.CreatePosition(mdl.Vertices[mdlmesh.PatchList[j].Index].Position.X, mdl.Vertices[mdlmesh.PatchList[j].Index].Position.Y, mdl.Vertices[mdlmesh.PatchList[j].Index].Position.Z);
                }

                for (int j = 0; j < mdlmesh.PatchList.Count; j += 3)
                {
                    meshpart.AddTriangleVertex(vLookup[mdlmesh.PatchList[j + 0].Index]);
                    meshpart.AddTriangleVertex(vLookup[mdlmesh.PatchList[j + 1].Index]);
                    meshpart.AddTriangleVertex(vLookup[mdlmesh.PatchList[j + 2].Index]);

                    meshpart.AddVertexNormal(new Vector3(mdl.Vertices[mdlmesh.PatchList[j + 0].Index].Normal.X, mdl.Vertices[mdlmesh.PatchList[j + 0].Index].Normal.Y, mdl.Vertices[mdlmesh.PatchList[j + 0].Index].Normal.Z));
                    meshpart.AddVertexNormal(new Vector3(mdl.Vertices[mdlmesh.PatchList[j + 1].Index].Normal.X, mdl.Vertices[mdlmesh.PatchList[j + 1].Index].Normal.Y, mdl.Vertices[mdlmesh.PatchList[j + 1].Index].Normal.Z));
                    meshpart.AddVertexNormal(new Vector3(mdl.Vertices[mdlmesh.PatchList[j + 2].Index].Normal.X, mdl.Vertices[mdlmesh.PatchList[j + 2].Index].Normal.Y, mdl.Vertices[mdlmesh.PatchList[j + 2].Index].Normal.Z));

                    meshpart.AddVertexUV(new Vector2(mdl.Vertices[mdlmesh.PatchList[j + 0].Index].UV.X, mdl.Vertices[mdlmesh.PatchList[j + 0].Index].UV.Y));
                    meshpart.AddVertexUV(new Vector2(mdl.Vertices[mdlmesh.PatchList[j + 1].Index].UV.X, mdl.Vertices[mdlmesh.PatchList[j + 1].Index].UV.Y));
                    meshpart.AddVertexUV(new Vector2(mdl.Vertices[mdlmesh.PatchList[j + 2].Index].UV.X, mdl.Vertices[mdlmesh.PatchList[j + 2].Index].UV.Y));
                }

                mesh.AddModelMeshPart(meshpart);
            }

            model.AddMesh(mesh);

            return model;
        }
    }
}
