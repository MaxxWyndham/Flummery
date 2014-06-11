using System;
using System.Collections.Generic;
using System.IO;
using ToxicRagers.BurnoutParadise.Formats;
using OpenTK;

namespace Flummery.ContentPipeline.BurnoutParadise
{
    class BOMImporter : ContentImporter
    {
        public override string GetExtension() { return ""; }

        public override Asset Import(string path)
        {
            BOM bom = BOM.Load(path);
            Model model = new Model();

            model.Tag = bom;

            ModelMesh mesh = new ModelMesh();
            ModelMeshPart meshpart = new ModelMeshPart();

            for (int j = 0; j < bom.Faces.Count; j++)
            {
                meshpart.AddFace(
                    new Vector3[] {
                        new Vector3(bom.Verts[bom.Faces[j].V1].Position.X, bom.Verts[bom.Faces[j].V1].Position.Y, bom.Verts[bom.Faces[j].V1].Position.Z),
                        new Vector3(bom.Verts[bom.Faces[j].V2].Position.X, bom.Verts[bom.Faces[j].V2].Position.Y, bom.Verts[bom.Faces[j].V2].Position.Z),
                        new Vector3(bom.Verts[bom.Faces[j].V3].Position.X, bom.Verts[bom.Faces[j].V3].Position.Y, bom.Verts[bom.Faces[j].V3].Position.Z),
                    },
                    new Vector3[] {
                        new Vector3(bom.Verts[bom.Faces[j].V1].Normal.X, bom.Verts[bom.Faces[j].V1].Normal.Y, bom.Verts[bom.Faces[j].V1].Normal.Z),
                        new Vector3(bom.Verts[bom.Faces[j].V2].Normal.X, bom.Verts[bom.Faces[j].V2].Normal.Y, bom.Verts[bom.Faces[j].V2].Normal.Z),
                        new Vector3(bom.Verts[bom.Faces[j].V3].Normal.X, bom.Verts[bom.Faces[j].V3].Normal.Y, bom.Verts[bom.Faces[j].V3].Normal.Z),
                    },
                    new Vector2[] {
                        Vector2.Zero,
                        Vector2.Zero,
                        Vector2.Zero
                    }
                );
            }

            mesh.AddModelMeshPart(meshpart);

            mesh.Name = bom.Name;
            model.SetName(bom.Name, model.AddMesh(mesh));

            return model;
        }
    }
}
