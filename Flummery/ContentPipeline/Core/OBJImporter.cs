using System;
using System.IO;
using ToxicRagers.Helpers;
using ToxicRagers.Core.Formats;
using OpenTK;

namespace Flummery.ContentPipeline.Core
{
    class OBJImporter : ContentImporter
    {
        public override string GetExtension() { return "obj"; }

        public override Asset Import(string path)
        {
            OBJ obj = OBJ.Load(path);
            Model model = new Model();

            string name = Path.GetFileNameWithoutExtension(path);
            bool bHasNormals = obj.Normals.Count > 0;

            foreach (var objmesh in obj.Meshes)
            {
                ModelMesh mesh = new ModelMesh();
                mesh.Name = objmesh.Name;

                ModelMeshPart meshpart = new ModelMeshPart();
                meshpart.PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType.Triangles;

                SceneManager.Current.UpdateProgress(string.Format("Processing {0}", mesh.Name));

                for (int i = 0; i < objmesh.Faces.Count; i++)
                {
                    var face = objmesh.Faces[i];

                    //var v1 = obj.Vertices[face.P0.Vertex];
                    //var v2 = obj.Vertices[face.P1.Vertex];
                    //var v3 = obj.Vertices[face.P2.Vertex];
                    //var uv1 = obj.UVs[face.P0.UV];
                    //var uv2 = obj.UVs[face.P1.UV];
                    //var uv3 = obj.UVs[face.P2.UV];

                    //meshpart.AddFace(
                    //    new OpenTK.Vector3[] {
                    //        new OpenTK.Vector3(v1.X, v1.Y, v1.Z),
                    //        new OpenTK.Vector3(v2.X, v2.Y, v2.Z),
                    //        new OpenTK.Vector3(v3.X, v3.Y, v3.Z)
                    //    },
                    //    new OpenTK.Vector3[] {
                    //        (bHasNormals ? new OpenTK.Vector3(obj.Normals[face.P0.Normal].X, obj.Normals[face.P0.Normal].Y, obj.Normals[face.P0.Normal].Z) : OpenTK.Vector3.Zero),
                    //        (bHasNormals ? new OpenTK.Vector3(obj.Normals[face.P1.Normal].X, obj.Normals[face.P1.Normal].Y, obj.Normals[face.P1.Normal].Z) : OpenTK.Vector3.UnitY),
                    //        (bHasNormals ? new OpenTK.Vector3(obj.Normals[face.P2.Normal].X, obj.Normals[face.P2.Normal].Y, obj.Normals[face.P2.Normal].Z) : OpenTK.Vector3.Zero)
                    //    },
                    //    new OpenTK.Vector2[] {
                    //        new OpenTK.Vector2(uv1.X, uv1.Y),
                    //        new OpenTK.Vector2(uv2.X, uv2.Y),
                    //        new OpenTK.Vector2(uv3.X, uv3.Y)
                    //    }
                    //);
                }

                mesh.AddModelMeshPart(meshpart);
                model.SetName(mesh.Name, model.AddMesh(mesh));
            }

            return model;
        }
    }
}
