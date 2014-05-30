using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ToxicRagers.Helpers;
using ToxicRagers.Core.Formats;
using OpenTK;

namespace Flummery.ContentPipeline.Core
{
    class FBXImporter : ContentImporter
    {
        public override string GetExtension() { return "fbx"; }

        public override Asset Import(string path)
        {
            FBX fbx = FBX.Load(path);
            Model model = new Model();
            Dictionary<int, object> components = new Dictionary<int, object>();

            string name = Path.GetFileNameWithoutExtension(path);

            var objects = fbx.Elements.Find(e => e.ID == "Objects");

            foreach (var material in objects.Children.Where(e => e.ID == "Material"))
            {
                var m = new Material { Name = material.Properties[1].Value.ToString() };
                components.Add((int)material.Properties[0].Value, m);
            }

            foreach (var texture in objects.Children.Where(e => e.ID == "Texture"))
            {
                Texture t = null;
                string file = Path.GetFileName(texture.Children.Find(e => e.ID == "FileName").Properties[0].Value.ToString());

                switch (Path.GetExtension(file))
                {
                    case ".png":
                        t = SceneManager.Current.Content.Load<Texture, PNGImporter>(Path.GetFileNameWithoutExtension(file));
                        break;

                    case ".tga":
                        t = SceneManager.Current.Content.Load<Texture, TGAImporter>(Path.GetFileNameWithoutExtension(file));
                        break;

                    case ".psd":
                        t = new Texture();
                        break;

                    default:
                        throw new NotImplementedException("Can't load texture \"" + file + "\"");
                }

                components.Add((int)texture.Properties[0].Value, t);
            }

            foreach (var element in objects.Children.Where(e => e.ID == "Geometry"))
            {
                bool bUVs = true;
                var meshpart = new ModelMeshPart();

                meshpart.PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType.Triangles;

                var verts = new List<OpenTK.Vector3>();
                var norms = new List<OpenTK.Vector3>();
                var uvs = new List<OpenTK.Vector2>();

                var vertParts = (double[])element.Children.Find(e => e.ID == "Vertices").Properties[0].Value;
                for (int i = 0; i < vertParts.Length; i += 3) { verts.Add(new OpenTK.Vector3((float)vertParts[i + 0], (float)vertParts[i + 1], (float)vertParts[i + 2])); }

                var normElem = element.Children.Find(e => e.ID == "LayerElementNormal");
                var normParts = (double[])normElem.Children.Find(e => e.ID == "Normals").Properties[0].Value;
                for (int i = 0; i < normParts.Length; i += 3)
                {
                    norms.Add(new OpenTK.Vector3((float)normParts[i + 0], (float)normParts[i + 1], (float)normParts[i + 2]));
                }

                bool bUseIndexNorm = (normElem.Children.Find(e => e.ID == "MappingInformationType").Properties[0].Value.ToString() == "ByVertice");

                var uvElem = element.Children.Find(e => e.ID == "LayerElementUV");
                if (uvElem != null)
                {
                    var uvParts = (double[])uvElem.Children.Find(e => e.ID == "UV").Properties[0].Value;

                    var uvReferenceType = uvElem.Children.Find(e => e.ID == "ReferenceInformationType");
                    if (uvReferenceType.Properties[0].Value.ToString() == "IndexToDirect")
                    {
                        var luvs = new List<OpenTK.Vector2>();
                        for (int i = 0; i < uvParts.Length; i += 2) { luvs.Add(new OpenTK.Vector2((float)uvParts[i + 0], -(float)uvParts[i + 1])); }

                        var uvindicies = (int[])uvElem.Children.Find(e => e.ID == "UVIndex").Properties[0].Value;
                        for (int i = 0; i < uvindicies.Length; i++) { uvs.Add(luvs[uvindicies[i]]); }
                    }
                    else
                    {
                        for (int i = 0; i < uvParts.Length; i += 2) { uvs.Add(new OpenTK.Vector2((float)uvParts[i + 0], -(float)uvParts[i + 1])); }
                    }
                }
                else
                {
                    bUVs = false;
                }

                var indicies = (int[])element.Children.Find(e => e.ID == "PolygonVertexIndex").Properties[0].Value;

                for (int i = 0; i < indicies.Length; i++)
                {
                    bool bFace = false;
                    int index = indicies[i];

                    if (index < 0)
                    {
                        bFace = true;
                        index = (index * -1) - 1;
                    }

                    meshpart.AddVertex(verts[index], norms[(bUseIndexNorm ? index : i)], (bUVs ? uvs[i] : OpenTK.Vector2.Zero));
                }

                components.Add((int)element.Properties[0].Value, meshpart);
            }

            foreach (var element in objects.Children.Where(e => e.ID == "Model"))
            {
                components.Add((int)element.Properties[0].Value, new ModelMesh { Name = element.Properties[1].Value.ToString(), Tag = (int)element.Properties[0].Value });
            }

            var connections = fbx.Elements.Find(e => e.ID == "Connections");

            foreach (var connection in connections.Children)
            {
                int keyA = (int)connection.Properties[1].Value;
                int keyB = (int)connection.Properties[2].Value;

                if (components.ContainsKey(keyA))
                {
                    switch (components[keyA].GetType().ToString())
                    {
                        case "Flummery.ModelMesh":
                            if (keyB == 0)
                            {
                                model.SetName(((ModelMesh)components[keyA]).Name, model.AddMesh((ModelMesh)components[keyA]));
                            }
                            else
                            {
                                var parent = model.FindMesh(keyB);
                                if (parent != null)
                                {
                                    model.SetName(((ModelMesh)components[keyA]).Name, model.AddMesh((ModelMesh)components[keyA], parent.Parent.Index));
                                }
                                else
                                {
                                    if (!components.ContainsKey(keyB))
                                    {
                                        Console.WriteLine("Components doesn't contain {0}", keyB);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Couldn't find {0}", ((ModelMesh)components[keyB]).Name);
                                    }
                                }
                            }
                            break;

                        case "Flummery.Texture":
                            if (components.ContainsKey(keyB) && components[keyB].GetType().ToString() == "Flummery.Material")
                            {
                                ((Material)components[keyB]).Texture = (Texture)components[keyA];
                                SceneManager.Current.Add((Material)components[keyB]);
                            }
                            else
                            {
                                Console.WriteLine("{0} is of unknown type {1}", keyA, components[keyA].GetType().ToString());
                                Console.WriteLine("{0} is of unknown type {1}", keyB, components[keyB].GetType().ToString());
                            }
                            break;

                        case "Flummery.ModelMeshPart":
                            if (components.ContainsKey(keyB) && components[keyB].GetType().ToString() == "Flummery.ModelMesh")
                            {
                                ((ModelMesh)components[keyB]).AddModelMeshPart((ModelMeshPart)components[keyA]);
                            }
                            break;

                        case "Flummery.Material":
                            if (components.ContainsKey(keyB) && components[keyB].GetType().ToString() == "Flummery.ModelMesh")
                            {
                                foreach (var part in ((ModelMesh)components[keyB]).MeshParts)
                                {
                                    part.Material = (Material)components[keyA];
                                }
                            }
                            break;

                        default:
                            Console.WriteLine("{0} is of unknown type {1}", keyA, components[keyA].GetType().ToString());
                            if (components.ContainsKey(keyB)) { Console.WriteLine("{0} is of unknown type {1}", keyB, components[keyB].GetType().ToString()); }
                            Console.WriteLine("===");
                            break;
                    }
                }
            }

            return model;
        }
    }
}
