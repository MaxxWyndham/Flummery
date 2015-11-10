using System;
using System.IO;

using OpenTK;
using ToxicRagers.Wreckfest.Formats;

namespace Flummery.ContentPipeline.Wreckfest
{
    class SCNEImporter : ContentImporter
    {
        public override string GetExtension() { return "scne;vhcl"; }

        public override Asset Import(string path)
        {
            SCNE scne = SCNE.Load(path);
            Model model = new Model();

            //m.Texture.CreateFromBitmap((System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(@"D:\wreckfest\paint.png"), "Paint");


            foreach (var scneBone in scne.Bones)
            {
                int boneIndex = model.AddMesh(null);
                model.SetName(scneBone.Name, boneIndex);
                model.SetTransform(
                    new Matrix4(
                        scneBone.Transform.M11, scneBone.Transform.M12, scneBone.Transform.M13, 0,
                        scneBone.Transform.M21, scneBone.Transform.M22, scneBone.Transform.M23, 0,
                        scneBone.Transform.M31, scneBone.Transform.M32, scneBone.Transform.M33, 0,
                        scneBone.Transform.M41, scneBone.Transform.M42, scneBone.Transform.M43, 1
                    ), 
                    boneIndex
                );

                foreach (var scneMesh in scneBone.Meshes)
                {
                    ModelMesh mesh = new ModelMesh();
                    mesh.Name = scneMesh.Name;

                    foreach (var scneMeshPart in scneMesh.Parts)
                    {
                        ModelMeshPart part = new ModelMeshPart();

                        Material material = (Material)SceneManager.Current.Materials.Entries.Find(m => m.Name == scneMeshPart.Materials[0]);

                        if (material == null)
                        {
                            string png = @"D:\wreckfest\01_American\" + Path.GetFileNameWithoutExtension(scneMeshPart.Textures[0].Name) + ".dxt5.png";
                            if (!File.Exists(png)) { png = @"D:\wreckfest\01_American\" + Path.GetFileNameWithoutExtension(scneMeshPart.Textures[0].Name) + ".dxt1.png"; }
                            if (!File.Exists(png)) { Console.WriteLine(scneMeshPart.Textures[0].Name); }

                                material = new Material { Name = scneMeshPart.Materials[0] };
                            if (File.Exists(png)) { material.Texture.CreateFromBitmap((System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(png), scneMeshPart.Materials[0]); }

                            SceneManager.Current.Add(material);
                        }

                        part.Material = (Material)material;

                        foreach (var scneVert in scneMeshPart.Verts)
                        {
                            part.AddVertex(
                                new Vector3(scneVert.Position.X, scneVert.Position.Y, scneVert.Position.Z),
                                new Vector3(scneVert.Normal.X, scneVert.Normal.Y, scneVert.Normal.Z),
                                new Vector2(scneVert.UV.X, scneVert.UV.Y),
                                false
                            );
                        }

                        foreach (int scneIndex in scneMeshPart.IndexBuffer)
                        {
                            part.IndexBuffer.AddIndex(scneIndex);
                        }

                        mesh.AddModelMeshPart(part);
                    }

                    model.SetMesh(mesh, boneIndex);
                    break;
                }
            }

            return model;
        }
    }
}
