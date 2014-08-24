using System;
using System.Collections.Generic;
using System.IO;
using ToxicRagers.Stainless.Formats;
using OpenTK;

namespace Flummery.ContentPipeline.Stainless
{
    class MDLImporter : ContentImporter
    {
        public override string GetExtension() { return "mdl"; }

        public override Asset Import(string path)
        {
            MDL mdl = MDL.Load(path);
            Model model = new Model();

            model.Tag = mdl;

            ModelMesh mesh = new ModelMesh();

            for (int i = 0; i < mdl.Meshes.Count; i++)
            {
                ModelMeshPart meshpart = new ModelMeshPart();

                var mdlmesh = mdl.GetMesh(i);

                meshpart.Material = SceneManager.Current.Content.Load<Material, MaterialImporter>(mdlmesh.Name, Path.GetDirectoryName(path), true);

                foreach (var v in mdl.Vertices)
                {
                    meshpart.AddVertex(
                        new Vector3(v.Position.X, v.Position.Y, v.Position.Z),
                        new Vector3(v.Normal.X, v.Normal.Y, v.Normal.Z),
                        new Vector2(v.UV.X, v.UV.Y),
                        new Vector2(v.UV2.X, v.UV2.Y),
                        v.Colour,
                        false
                    );
                }

                // Process triangle strip
                for (int j = 0; j < mdlmesh.StripList.Count - 2; j++)
                {
                    if (mdlmesh.StripList[j + 2].Degenerate) { continue; }

                    int v0, v1, v2;

                    v0 = mdlmesh.StripList[j + 0].Index;

                    if (j % 2 == 0)
                    {
                        v1 = mdlmesh.StripList[j + 1].Index;
                        v2 = mdlmesh.StripList[j + 2].Index;
                    }
                    else
                    {
                        v1 = mdlmesh.StripList[j + 2].Index;
                        v2 = mdlmesh.StripList[j + 1].Index;
                    }

                    meshpart.AddFace(v0, v1, v2);
                }

                // Process patch list
                for (int j = 0; j < mdlmesh.TriList.Count; j += 3)
                {
                    int v0, v1, v2;

                    v0 = mdlmesh.TriList[j + 0].Index;
                    v1 = mdlmesh.TriList[j + 1].Index;
                    v2 = mdlmesh.TriList[j + 2].Index;

                    meshpart.AddFace(v0, v1, v2);
                }

                mesh.AddModelMeshPart(meshpart);

                Console.WriteLine(meshpart.VertexCount / 3);
            }

            mesh.Name = mdl.Name;
            model.SetName(mdl.Name, model.AddMesh(mesh));

            return model;
        }
    }
}
