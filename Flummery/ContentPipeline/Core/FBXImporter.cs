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
            Dictionary<long, object> components = new Dictionary<long, object>();
            Dictionary<long, Matrix4> transforms = new Dictionary<long, Matrix4>();

            string name = Path.GetFileNameWithoutExtension(path);

            var objects = fbx.Elements.Find(e => e.ID == "Objects");

            foreach (var material in objects.Children.Where(e => e.ID == "Material"))
            {
                string matName = material.Properties[1].Value.ToString();
                matName = matName.Substring(0, matName.IndexOf("::"));
                var m = new Material { Name = matName };
                components.Add((long)material.Properties[0].Value, m);
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

                    case ".dds":
                    case ".psd":
                        t = new Texture();
                        break;

                    default:
                        throw new NotImplementedException("Can't load texture \"" + file + "\"");
                }

                components.Add((long)texture.Properties[0].Value, t);
            }

            foreach (var element in objects.Children.Where(e => e.ID == "Model"))
            {
                string modelName = element.Properties[1].Value.ToString();
                modelName = modelName.Substring(0, modelName.IndexOf("::"));
                components.Add((long)element.Properties[0].Value, new ModelMesh { Name = modelName, Tag = (long)element.Properties[0].Value });

                var properties = element.Children.Find(c => c.ID == "Properties70");
                var m = Matrix4.Identity;

                foreach (var property in properties.Children)
                {
                    //if (property.Properties.Any(pv => pv.Value.ToString() == "PreRotation"))
                    //{
                    //    m *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Convert.ToSingle(property.Properties[4].Value)));
                    //    m *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Convert.ToSingle(property.Properties[5].Value)));
                    //    m *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Convert.ToSingle(property.Properties[6].Value)));
                    //}

                    if (property.Properties.Any(pv => pv.Value.ToString() == "Lcl Translation"))
                    {
                        m.M41 = Convert.ToSingle(property.Properties[4].Value);
                        m.M42 = Convert.ToSingle(property.Properties[5].Value);
                        m.M43 = Convert.ToSingle(property.Properties[6].Value);
                    }

                    //if (property.Properties.Any(pv => pv.Value.ToString() == "Lcl Rotation"))
                    //{
                    //    m *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Convert.ToSingle(property.Properties[4].Value)));
                    //    m *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Convert.ToSingle(property.Properties[5].Value)));
                    //    m *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Convert.ToSingle(property.Properties[6].Value)));
                    //}

                    //if (property.Properties.Any(pv => pv.Value.ToString() == "Lcl Translation"))
                    //{
                    //    m.M41 = Convert.ToSingle(property.Properties[4].Value);
                    //    m.M42 = Convert.ToSingle(property.Properties[5].Value);
                    //    m.M43 = Convert.ToSingle(property.Properties[6].Value);
                    //}
                }

                if (m != Matrix4.Identity) { transforms.Add((long)element.Properties[0].Value, m); }
            }

            foreach (var element in objects.Children.Where(e => e.ID == "Geometry"))
            {
                bool bUVs = true;
                bool bNorms = true;
                bool bUseIndexNorm = false;

                var verts = new List<OpenTK.Vector3>();
                var norms = new List<OpenTK.Vector3>();
                var uvs = new List<OpenTK.Vector2>();

                var vertParts = (double[])element.Children.Find(e => e.ID == "Vertices").Properties[0].Value;
                for (int i = 0; i < vertParts.Length; i += 3) { verts.Add(new OpenTK.Vector3((float)vertParts[i + 0], (float)vertParts[i + 1], (float)vertParts[i + 2])); }

                var normElem = element.Children.Find(e => e.ID == "LayerElementNormal");
                if (normElem != null)
                {
                    var normParts = (double[])normElem.Children.Find(e => e.ID == "Normals").Properties[0].Value;
                    for (int i = 0; i < normParts.Length; i += 3)
                    {
                        norms.Add(new OpenTK.Vector3((float)normParts[i + 0], (float)normParts[i + 1], (float)normParts[i + 2]));
                    }

                    bUseIndexNorm = (normElem.Children.Find(e => e.ID == "MappingInformationType").Properties[0].Value.ToString() == "ByVertice");
                }
                else
                {
                    bNorms = false;
                }

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
                        for (int i = 0; i < uvindicies.Length; i++)
                        {
                            if (uvindicies[i] == -1)
                            {
                                uvs.Add(OpenTK.Vector2.Zero);
                            }
                            else
                            {
                                uvs.Add(luvs[uvindicies[i]]);
                            }
                        }
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
                var faces = new List<FBXFace>();
                var face = new FBXFace();

                for (int i = 0; i < indicies.Length; i++)
                {
                    bool bFace = false;
                    int index = indicies[i];

                    if (index < 0)
                    {
                        bFace = true;
                        index = (index * -1) - 1;
                    }

                    face.AddVertex(verts[index], (bNorms ? norms[(bUseIndexNorm ? index : i)] : OpenTK.Vector3.Zero), (bUVs ? uvs[i] : OpenTK.Vector2.Zero));

                    if (bFace)
                    {
                        faces.Add(face);
                        face = new FBXFace();
                    }
                }

                var elemMaterial = element.Children.Find(e => e.ID == "LayerElementMaterial");
                if (elemMaterial != null)
                {
                    var faceMaterials = (int[])elemMaterial.Children.Find(e => e.ID == "Materials").Properties[0].Value;
                    for (int i = 0; i < faceMaterials.Length; i++)
                    {
                        faces[i].MaterialID = faceMaterials[i];
                    }
                }

                var parts = new List<ModelMeshPart>();

                foreach (var materialGroup in faces.GroupBy(f => f.MaterialID))
                {
                    foreach (var smoothingGroup in materialGroup.GroupBy(f => f.SmoothingGroup))
                    {
                        var meshpart = new ModelMeshPart { PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType.Triangles };

                        foreach (var groupface in smoothingGroup)
                        {
                            foreach (var vert in groupface.Vertices)
                            {
                                meshpart.AddVertex(vert.Position, vert.Normal, vert.UV);
                            }
                        }

                        var materialLookup = components.Where(c => c.Value.GetType().ToString() == "Flummery.Material").ToList();
                        if (materialLookup.Count > 0) { meshpart.Key = materialLookup[materialGroup.Key].Key; }

                        parts.Add(meshpart);
                    }
                }

                components.Add((long)element.Properties[0].Value, parts);
            }

            string[] connectionOrder = new string[] { "System.Collections.Generic.List`1[Flummery.ModelMeshPart]", "Flummery.Texture", "Flummery.Material", "Flummery.ModelMesh" };
            var connections = fbx.Elements.Find(e => e.ID == "Connections");

            foreach (var connectionType in connectionOrder)
            {
                foreach (var connection in connections.Children.Where(c => components.ContainsKey((long)c.Properties[1].Value) && components[(long)c.Properties[1].Value].GetType().ToString() == connectionType))
                {
                    long keyA = (long)connection.Properties[1].Value;
                    long keyB = (long)connection.Properties[2].Value;

                    switch (connectionType)
                    {
                        case "Flummery.ModelMesh":
                            int boneID;

                            if (keyB == 0)
                            {
                                boneID = model.AddMesh((ModelMesh)components[keyA]);
                                model.SetName(((ModelMesh)components[keyA]).Name, boneID);
                                if (transforms.ContainsKey(keyA)) { model.SetTransform(transforms[keyA], boneID); }
                            }
                            else
                            {
                                var parent = model.FindMesh(keyB);
                                if (parent != null)
                                {
                                    boneID = model.AddMesh((ModelMesh)components[keyA], parent.Parent.Index);
                                    model.SetName(((ModelMesh)components[keyA]).Name, boneID);
                                    if (transforms.ContainsKey(keyA)) { model.SetTransform(transforms[keyA], boneID); }
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

                        case "System.Collections.Generic.List`1[Flummery.ModelMeshPart]":
                            if (components.ContainsKey(keyB) && components[keyB].GetType().ToString() == "Flummery.ModelMesh")
                            {
                                foreach (var part in (List<ModelMeshPart>)components[keyA])
                                {
                                    ((ModelMesh)components[keyB]).AddModelMeshPart(part);
                                }
                            }
                            break;

                        case "Flummery.Material":
                            if (components.ContainsKey(keyB) && components[keyB].GetType().ToString() == "Flummery.ModelMesh")
                            {
                                foreach (var part in ((ModelMesh)components[keyB]).MeshParts)
                                {
                                    if ((long)part.Key == keyA)
                                    {
                                        part.Material = (Material)components[keyA];
                                        //SceneManager.Current.Add(part.Material);
                                    }
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

    public class FBXFace
    {
        private List<Vertex> verts;
        private int materialID = 0;
        private int smoothingGroup = 0;

        public int MaterialID
        {
            get { return materialID; }
            set { materialID = value; }
        }

        public int SmoothingGroup
        {
            get { return smoothingGroup; }
            set { smoothingGroup = value; }
        }

        public List<Vertex> Vertices
        {
            get { return verts; }
        }

        public FBXFace()
        {
            verts = new List<Vertex>();
        }

        public void AddVertex(OpenTK.Vector3 position, OpenTK.Vector3 normal, OpenTK.Vector2 texcoords)
        {
            var v = new Vertex();
            v.Position = position;
            v.Normal = normal;
            v.UV = texcoords;

            verts.Add(v);
        }
    }
}
