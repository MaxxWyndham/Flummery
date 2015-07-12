using System;
using System.IO;
using ToxicRagers.Helpers;
using ToxicRagers.TDR2000.Formats;
using OpenTK;

namespace Flummery.ContentPipeline.TDR2000
{
    class HIEImporter : ContentImporter
    {
        public override string GetExtension() { return "hie"; }

        public override Asset Import(string path)
        {
            HIE hie = HIE.Load(path);
            Model model = new Model();
            Model mshses = new Model();

            foreach (string mesh in hie.Meshes)
            {
                var mshs = SceneManager.Current.Content.Load<Model, MSHSImporter>(Path.GetFileNameWithoutExtension(mesh), Path.GetDirectoryName(path) + "\\");
                foreach (var part in mshs.Meshes) { mshses.AddMesh(part); }
            }

            foreach (string texture in hie.Textures)
            {
                SceneManager.Current.Content.Load<Material, TXImporter>(texture, Path.GetDirectoryName(path) + "\\", true);
            }

            ProcessNode(hie.Root, model, mshses, hie);

            //ModelMesh mesh = new ModelMesh();
            //mesh.Name = "DEFAULT";

            //foreach (var tdrmesh in mshs.Meshes)
            //{
            //    ModelMeshPart meshpart = new ModelMeshPart();
            //    meshpart.PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType.Triangles;

            //    SceneManager.Current.UpdateProgress(string.Format("Processing {0}", mesh.Name));

            //    for (int i = 0; i < tdrmesh.Faces.Count; i++)
            //    {
            //        var face = tdrmesh.Faces[i];
            //        var v1 = tdrmesh.Vertexes[face.V1];
            //        var v2 = tdrmesh.Vertexes[face.V2];
            //        var v3 = tdrmesh.Vertexes[face.V3];

            //        meshpart.AddFace(
            //            new OpenTK.Vector3[] {
            //                new OpenTK.Vector3(v1.Position.X, v1.Position.Y, v1.Position.Z),
            //                new OpenTK.Vector3(v2.Position.X, v2.Position.Y, v2.Position.Z),
            //                new OpenTK.Vector3(v3.Position.X, v3.Position.Y, v3.Position.Z)
            //            },
            //            new OpenTK.Vector3[] {
            //                new OpenTK.Vector3(v1.Normal.X, v1.Normal.Y, v1.Normal.Z),
            //                new OpenTK.Vector3(v2.Normal.X, v2.Normal.Y, v2.Normal.Z),
            //                new OpenTK.Vector3(v3.Normal.X, v3.Normal.Y, v3.Normal.Z)
            //            },
            //            new OpenTK.Vector2[] {
            //                new OpenTK.Vector2(v1.UV.X, v1.UV.Y),
            //                new OpenTK.Vector2(v2.UV.X, v2.UV.Y),
            //                new OpenTK.Vector2(v3.UV.X, v3.UV.Y)
            //            }
            //        );
            //    }

            //    mesh.AddModelMeshPart(meshpart);
            //}

            //model.SetName(mesh.Name, model.AddMesh(mesh));
            return model;
        }

        protected static Material material;
        protected static string texture;
        protected static bool exit = false;

        static void ProcessNode(TDRNode node, Model model, Model mshses, HIE hie, int ParentBoneIndex = 0)
        {
            int boneIndex = ParentBoneIndex;

            if (exit) { return; }

            switch (node.Type)
            {
                case TDRNode.NodeType.Matrix:
                    boneIndex = model.AddMesh(null, boneIndex);

                    model.SetName(node.Name, boneIndex);
                    model.SetTransform(
                        new Matrix4 (
                            node.Transform.M11, node.Transform.M12, node.Transform.M13, 0,
                            node.Transform.M21, node.Transform.M22, node.Transform.M23, 0,
                            node.Transform.M31, node.Transform.M32, node.Transform.M33, 0,
                            node.Transform.M41, node.Transform.M42, node.Transform.M43, 1
                        ), boneIndex);
                    break;

                case TDRNode.NodeType.Mesh:
                    int index = node.Index;
                    mshses.Meshes[index].MeshParts[0].Material = material;

                    if (model.Bones[ParentBoneIndex].Mesh == null)
                    {
                        model.SetMesh(mshses.Meshes[index], boneIndex);
                        //exit = true;
                        //Console.WriteLine("Adding mesh #{0} \"{1}\" to bone #{2} \"{3}\"", index, mshses.Meshes[index].Name, boneIndex, model.Bones[boneIndex].Name);
                    }
                    else
                    {
                        boneIndex = model.AddMesh(mshses.Meshes[index], ParentBoneIndex);
                        model.SetName(mshses.Meshes[index].Name, boneIndex);

                        //model.SetName(mshses.Meshes[index].Name, model.AddMesh(mshses.Meshes[index], ParentBoneIndex));
                        //Console.WriteLine("Adding mesh #{0} \"{1}\" to brand new bone", index, mshses.Meshes[index].Name);
                    }
                    break;

                case TDRNode.NodeType.Texture:
                    if (node.Index > -1)
                    {
                        material = SceneManager.Current.Content.Load<Material, TXImporter>(hie.Textures[node.Index]);
                    }
                    else
                    {
                        material = null;
                    }
                    break;
            }

            foreach (var child in node.Children)
            {
                ProcessNode(child, model, mshses, hie, boneIndex);
            }
        }
    }
}
