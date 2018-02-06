using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.Core.Formats;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

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

            Dictionary<long, string> triangulationErrors = new Dictionary<long, string>();

            string name = Path.GetFileNameWithoutExtension(path);

            if (fbx == null)
            {
                SceneManager.Current.RaiseError($"File \"{name}\" could not be opened.  Please ensure this is a binary FBX file.");
                return null;
            }

            FBXElem objects = fbx.Elements.Find(e => e.ID == "Objects");

            Matrix4 worldMatrix = createTransformFor(fbx.Elements.Find(e => e.ID == "GlobalSettings").Children[1], out RotationOrder order);

            foreach (FBXElem material in objects.Children.Where(e => e.ID == "Material"))
            {
                string matName = material.Properties[1].Value.ToString();
                matName = matName.Substring(0, matName.IndexOf("::"));
                Material m = new Material { Name = matName };
                components.Add((long)material.Properties[0].Value, m);

                Console.WriteLine("Added material \"{0}\" ({1})", matName, material.Properties[0].Value);
            }

            IEnumerable<FBXElem> textures = objects.Children.Where(e => e.ID == "Texture");
            foreach (FBXElem texture in textures)
            {
                Texture t = null;
                string fullFile = texture.Children.Find(e => e.ID == "FileName").Properties[0].Value.ToString();

                if (fullFile.IndexOf('.') == -1) { continue; }

                string file = Path.GetFileName(fullFile);

                switch (Path.GetExtension(file))
                {
                    case ".bmp":
                        t = SceneManager.Current.Content.Load<Texture, BMPImporter>(Path.GetFileNameWithoutExtension(file));
                        break;

                    case ".png":
                        t = SceneManager.Current.Content.Load<Texture, PNGImporter>(Path.GetFileNameWithoutExtension(file));
                        break;

                    case ".tif":
                        t = SceneManager.Current.Content.Load<Texture, TIFImporter>(Path.GetFileNameWithoutExtension(file));
                        break;

                    case ".tga":
                        t = SceneManager.Current.Content.Load<Texture, TGAImporter>(Path.GetFileNameWithoutExtension(file));
                        break;

                    default:
                        t = new Texture();
                        break;
                }

                if (!components.ContainsKey((long)texture.Properties[0].Value))
                {
                    components.Add((long)texture.Properties[0].Value, t);

                    Console.WriteLine("Added texture \"{0}\" ({1})", file, texture.Properties[0].Value);
                }
            }

            foreach (FBXElem element in objects.Children.Where(e => e.ID == "Model"))
            {
                string modelName = element.Properties[1].Value.ToString();
                modelName = modelName.Substring(0, modelName.IndexOf("::"));

                components.Add((long)element.Properties[0].Value, new ModelMesh { Name = modelName, Tag = (long)element.Properties[0].Value });

                Console.WriteLine("Added model \"{0}\" ({1})", modelName, element.Properties[0].Value);

                FBXElem properties = element.Children.Find(c => c.ID == "Properties70");
                Matrix4 m = Matrix4.Identity;
                bool bRotationActive = false;

                Vector3 lclTranslation = Vector3.Zero;
                Quaternion lclRotation = Quaternion.Identity;
                Quaternion preRotation = Quaternion.Identity;
                Quaternion postRotation = Quaternion.Identity;
                Vector3 rotationPivot = Vector3.Zero;
                Vector3 rotationOffset = Vector3.Zero;
                Vector3 lclScaling = Vector3.One;
                Vector3 scalingPivot = Vector3.Zero;
                Vector3 scalingOffset = Vector3.Zero;

                Vector3 geoPosition = Vector3.Zero;
                Quaternion geoRotation = Quaternion.Identity;
                Vector3 geoScale = Vector3.One;

                FBXElem property;

                property = properties.Children.GetProperty("RotationActive");
                if (property != null) { bRotationActive = ((int)property.Properties[4].Value == 1); }

                property = properties.Children.GetProperty("ScalingPivot");
                if (property != null)
                {
                    scalingPivot = new Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );
                }

                property = properties.Children.GetProperty("Lcl Scaling");
                if (property != null)
                {
                    lclScaling = new Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );
                }

                property = properties.Children.GetProperty("ScalingOffset");
                if (property != null)
                {
                    scalingOffset = new Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );
                }

                property = properties.Children.GetProperty("RotationPivot");
                if (property != null)
                {
                    rotationPivot = new Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );
                }

                property = properties.Children.GetProperty("PostRotation");
                if (property != null)
                {
                    postRotation = MakeQuaternion(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value),
                        order
                    );
                }

                property = properties.Children.GetProperty("Lcl Rotation");
                if (property != null)
                {
                    lclRotation = MakeQuaternion(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value),
                        order
                    );
                }

                property = properties.Children.GetProperty("PreRotation");
                if (property != null)
                {
                    preRotation = MakeQuaternion(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value),
                        order
                    );
                }

                property = properties.Children.GetProperty("RotationOffset");
                if (property != null)
                {
                    rotationOffset = new Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );
                }

                property = properties.Children.GetProperty("Lcl Translation");
                if (property != null)
                {
                    lclTranslation = new Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );
                }

                property = properties.Children.GetProperty("GeometricTranslation");
                if (property != null)
                {
                    geoPosition = new Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );
                }

                property = properties.Children.GetProperty("GeometricRotation");
                if (property != null)
                {
                    geoRotation = MakeQuaternion(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value),
                        order
                    );
                }

                property = properties.Children.GetProperty("GeometricScaling");
                if (property != null)
                {
                    geoScale = new Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );
                }

                m =
                    Matrix4.CreateTranslation(scalingPivot).Inverted() *
                    Matrix4.CreateScale(lclScaling) *
                    Matrix4.CreateTranslation(scalingPivot) *
                    Matrix4.CreateTranslation(scalingOffset) *
                    Matrix4.CreateTranslation(rotationPivot).Inverted() *
                    Matrix4.CreateFromQuaternion(postRotation) *
                    Matrix4.CreateFromQuaternion(lclRotation) *
                    Matrix4.CreateFromQuaternion(preRotation) *
                    Matrix4.CreateTranslation(rotationPivot) *
                    Matrix4.CreateTranslation(rotationOffset) *
                    Matrix4.CreateTranslation(lclTranslation);

                if (m != Matrix4.Identity) { transforms.Add((long)element.Properties[0].Value, m); }
            }

            foreach (FBXElem element in objects.Children.Where(e => e.ID == "Geometry"))
            {
                bool bUVs = true;
                bool bNorms = true;
                bool bColours = true;
                bool bUseIndexNorm = false;

                bool bNeedsTriangulating = false;

                string geometryName = element.Properties[1].Value.ToString();
                geometryName = geometryName.Substring(0, geometryName.IndexOf("::"));

                List<Vector3> verts = new List<Vector3>();
                List<Vector3> norms = new List<Vector3>();
                List<Vector2> uvs = new List<Vector2>();
                List<Color4> colours = new List<Color4>();

                double[] vertParts = (double[])element.Children.Find(e => e.ID == "Vertices").Properties[0].Value;
                for (int i = 0; i < vertParts.Length; i += 3)
                {
                    verts.Add(new Vector3((float)vertParts[i + 0], (float)vertParts[i + 1], (float)vertParts[i + 2]));
                }

                SceneManager.Current.UpdateProgress($"Processed {element.Properties[1].Value}->Vertices");

                FBXElem normElem = element.Children.Find(e => e.ID == "LayerElementNormal");
                if (normElem != null)
                {
                    double[] normParts = (double[])normElem.Children.Find(e => e.ID == "Normals").Properties[0].Value;
                    for (int i = 0; i < normParts.Length; i += 3)
                    {
                        norms.Add(new Vector3((float)normParts[i + 0], (float)normParts[i + 1], (float)normParts[i + 2]));
                    }

                    bUseIndexNorm = (normElem.Children.Find(e => e.ID == "MappingInformationType").Properties[0].Value.ToString() == "ByVertice");

                    SceneManager.Current.UpdateProgress($"Processed {element.Properties[1].Value}->Normals");
                }
                else
                {
                    bNorms = false;
                }

                FBXElem colourElem = element.Children.Find(e => e.ID == "LayerElementColor");
                if (colourElem != null)
                {
                    double[] colourParts = (double[])colourElem.Children.Find(e => e.ID == "Colors").Properties[0].Value;

                    FBXElem colourReferenceType = colourElem.Children.Find(e => e.ID == "ReferenceInformationType");

                    switch (colourReferenceType.Properties[0].Value.ToString())
                    {
                        case "IndexToDirect":
                            int[] colourIndicies = (int[])colourElem.Children.Find(e => e.ID == "ColorIndex").Properties[0].Value;
                            for (int i = 0; i < colourIndicies.Length; i++)
                            {
                                int offset = colourIndicies[i] * 4;
                                colours.Add(new Color4(
                                    (float)colourParts[offset + 0],
                                    (float)colourParts[offset + 1],
                                    (float)colourParts[offset + 2],
                                    (float)colourParts[offset + 3])
                                );
                            }
                            break;

                        case "Direct":
                            bColours = false;
                            break;

                        default:
                            throw new NotImplementedException($"Unsupported Colour Reference Type: {colourReferenceType.Properties[0].Value}");
                    }

                    SceneManager.Current.UpdateProgress($"Processed {element.Properties[1].Value}->Colours");
                }
                else
                {
                    bColours = false;
                }

                FBXElem uvElem = element.Children.Find(e => e.ID == "LayerElementUV");
                if (uvElem != null)
                {
                    double[] uvParts = (double[])uvElem.Children.Find(e => e.ID == "UV").Properties[0].Value;

                    FBXElem uvReferenceType = uvElem.Children.Find(e => e.ID == "ReferenceInformationType");
                    if (uvReferenceType.Properties[0].Value.ToString() == "IndexToDirect")
                    {
                        List<Vector2> luvs = new List<Vector2>();
                        for (int i = 0; i < uvParts.Length; i += 2) { luvs.Add(new Vector2((float)uvParts[i + 0], 1 - (float)uvParts[i + 1])); }

                        int[] uvindicies = (int[])uvElem.Children.Find(e => e.ID == "UVIndex").Properties[0].Value;
                        for (int i = 0; i < uvindicies.Length; i++)
                        {
                            if (uvindicies[i] == -1)
                            {
                                uvs.Add(Vector2.Zero);
                            }
                            else
                            {
                                uvs.Add(luvs[uvindicies[i]]);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < uvParts.Length; i += 2) { uvs.Add(new Vector2((float)uvParts[i + 0], (float)uvParts[i + 1])); }
                    }

                    SceneManager.Current.UpdateProgress($"Processed {element.Properties[1].Value}->UVs");
                }
                else
                {
                    bUVs = false;
                }

                int[] indicies = (int[])element.Children.Find(e => e.ID == "PolygonVertexIndex").Properties[0].Value;
                List<FBXFace> faces = new List<FBXFace>();
                FBXFace face = new FBXFace();
                int j = 0;

                for (int i = 0; i < indicies.Length; i++)
                {
                    bool bFace = false;
                    int index = indicies[i];

                    if (index < 0)
                    {
                        bFace = true;
                        index = (index * -1) - 1;
                    }

                    j++;
                    face.AddVertex(verts[index], (bNorms ? norms[(bUseIndexNorm ? index : i)] : Vector3.Zero), (bUVs ? uvs[i] : Vector2.Zero), (bColours ? colours[i] : Color4.White));

                    if (bFace)
                    {
                        if (j > 3)
                        {
                            triangulationErrors.Add((long)element.Properties[0].Value, geometryName);
                            bNeedsTriangulating = true;
                            break;
                        }

                        faces.Add(face);
                        face = new FBXFace();
                        j = 0;
                    }
                }

                List<ModelMeshPart> parts = new List<ModelMeshPart>();

                if (!bNeedsTriangulating)
                {
                    SceneManager.Current.UpdateProgress($"Processed {element.Properties[1].Value}->Faces");

                    FBXElem elemMaterial = element.Children.Find(e => e.ID == "LayerElementMaterial");
                    if (elemMaterial != null)
                    {
                        int[] faceMaterials = (int[])elemMaterial.Children.Find(e => e.ID == "Materials").Properties[0].Value;
                        for (int i = 0; i < faceMaterials.Length; i++)
                        {
                            faces[i].MaterialID = faceMaterials[i];
                        }

                        SceneManager.Current.UpdateProgress($"Processed {element.Properties[1].Value}->Materials");
                    }


                    IEnumerable<IGrouping<int, FBXFace>> materialGroups = faces.GroupBy(f => f.MaterialID);

                    int processedFaceCount = 0,
                        processedGroupCount = 0;

                    foreach (IGrouping<int, FBXFace> materialGroup in materialGroups)
                    {
                        IEnumerable<IGrouping<int, FBXFace>> smoothingGroups = materialGroup.GroupBy(f => f.SmoothingGroup);

                        foreach (IGrouping<int, FBXFace> smoothingGroup in smoothingGroups)
                        {
                            ModelMeshPart meshpart = new ModelMeshPart { PrimitiveType = PrimitiveType.Triangles };
                            processedFaceCount = 0;

                            foreach (FBXFace groupface in smoothingGroup)
                            {
                                foreach (Vertex vert in groupface.Vertices)
                                {
                                    meshpart.AddVertex(vert.Position, vert.Normal, vert.UV, vert.Colour);
                                }

                                processedFaceCount++;

                                if (processedFaceCount % 250 == 0) { SceneManager.Current.UpdateProgress($"Processed {element.Properties[1].Value}->MeshPart[{processedGroupCount}]->Face[{processedFaceCount}]"); }
                            }

                            meshpart.Key = materialGroup.Key;

                            parts.Add(meshpart);
                            SceneManager.Current.UpdateProgress($"Processed {element.Properties[1].Value}->MeshPart");

                            processedGroupCount++;
                        }
                    }
                }

                components.Add((long)element.Properties[0].Value, parts);
                SceneManager.Current.UpdateProgress($"Processed {element.Properties[1].Value}");
            }

            Dictionary<long, BoneType> nodeAttributes = new Dictionary<long, BoneType>();
            Dictionary<long, object> nodeAttachments = new Dictionary<long, object>();

            foreach (FBXElem nodeAttribute in objects.Children.Where(e => e.ID == "NodeAttribute"))
            {
                FBXElem typeFlags = nodeAttribute.Children.Find(e => e.ID == "TypeFlags");
                if (typeFlags != null)
                {
                    switch (typeFlags.Properties[0].Value.ToString().ToLower())
                    {
                        case "light":
                            LIGHT light = new LIGHT();

                            FBXElem lightType = nodeAttribute.Children.Find(c => c.ID == "Properties70").Children.GetProperty("LightType");
                            light.Type = (LIGHT.LightType)(lightType == null ? 0 : lightType.Properties[4].Value);

                            nodeAttributes.Add((long)nodeAttribute.Properties[0].Value, BoneType.Light);
                            nodeAttachments.Add((long)nodeAttribute.Properties[0].Value, light);
                            break;

                        default:
                            // null node
                            break;
                    }
                }
            }

            string[] connectionOrder = new string[] { "System.Collections.Generic.List`1[Flummery.ModelMeshPart]", "Flummery.Texture", "Flummery.Material", "Flummery.ModelMesh" };
            FBXElem connections = fbx.Elements.Find(e => e.ID == "Connections");

            HashSet<long> loaded = new HashSet<long>();

            foreach (string connectionType in connectionOrder)
            {
                IEnumerable<FBXElem> connectionsOfType = connections.Children.Where(c => components.ContainsKey((long)c.Properties[1].Value) && components[(long)c.Properties[1].Value].GetType().ToString() == connectionType);

                foreach (FBXElem connection in connectionsOfType)
                {
                    long keyA = (long)connection.Properties[1].Value;
                    long keyB = (long)connection.Properties[2].Value;

                    Console.WriteLine("{0} is connected to {1} :: {2}", keyA, keyB, connectionType);

                    switch (connectionType)
                    {
                        case "Flummery.ModelMesh":
                            int boneID;

                            if (keyB == 0)
                            {
                                boneID = model.AddMesh((ModelMesh)components[keyA]);
                                model.SetName(((ModelMesh)components[keyA]).Name, boneID);
                                if (transforms.ContainsKey(keyA)) { model.SetTransform(transforms[keyA], boneID); }

                                FBXElem attribute = connections.Children.FirstOrDefault(c => nodeAttributes.ContainsKey((long)c.Properties[1].Value) && (long)c.Properties[2].Value == keyA);
                                if (attribute != null)
                                {
                                    keyA = (long)attribute.Properties[1].Value;

                                    if (nodeAttributes.ContainsKey(keyA)) { model.Bones[boneID].Type = nodeAttributes[keyA]; }
                                    if (nodeAttachments.ContainsKey(keyA)) { model.Bones[boneID].Attachment = nodeAttachments[keyA]; }
                                }
                            }
                            else
                            {
                                ModelMesh parent = model.FindMesh(keyB);
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
                                if (loaded.Add(keyB))
                                {
                                    ((Material)components[keyB]).Texture = (Texture)components[keyA];
                                    //SceneManager.Current.Add((Material)components[keyB]);
                                }
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
                                if (triangulationErrors.ContainsKey(keyA))
                                {
                                    triangulationErrors[keyA] += " (geometry of " + ((ModelMesh)components[keyB]).Name + ")";
                                }

                                foreach (ModelMeshPart part in (List<ModelMeshPart>)components[keyA])
                                {
                                    ((ModelMesh)components[keyB]).AddModelMeshPart(part);
                                }
                            }
                            break;

                        case "Flummery.Material":
                            if (components.ContainsKey(keyB) && components[keyB].GetType().ToString() == "Flummery.ModelMesh")
                            {
                                List<FBXElem> materialLookup = connections.Children.Where(c => (long)c.Properties[2].Value == keyB).ToList();
                                for (int i = materialLookup.Count - 1; i > -1; i--) { if (!connectionsOfType.Any(c => (long)c.Properties[1].Value == (long)materialLookup[i].Properties[1].Value)) { materialLookup.RemoveAt(i); } }

                                foreach (ModelMeshPart part in ((ModelMesh)components[keyB]).MeshParts)
                                {
                                    if ((long)materialLookup[(int)part.Key].Properties[1].Value == keyA)
                                    {
                                        part.Material = (Material)components[keyA];
                                        SceneManager.Current.Add(part.Material);
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

            if (triangulationErrors.Count > 0)
            {
                SceneManager.Current.UpdateProgress($"Failed to load {name}");

                string error = $"File \"{name}\" has part{(triangulationErrors.Count > 1 ? "s" : "")} that need been triangulating!  Please triangulate the following:";
                foreach (KeyValuePair<long, string> kvp in triangulationErrors)
                {
                    error += $"\r\n{kvp.Value}";
                }

                SceneManager.Current.RaiseError(error);

                return null;
            }
            else
            {
                SceneManager.Current.UpdateProgress($"Loaded {name}");

                model.Santise();

                if (worldMatrix != Matrix4.Identity) { ModelManipulator.Freeze(model, worldMatrix); }
                ModelManipulator.FlipAxis(model.Root.Mesh, Axis.X, true);

                return model;
            }
        }

        public Quaternion MakeQuaternion(float x, float y, float z, RotationOrder order)
        {
            Quaternion q = Quaternion.Identity;

            switch (order)
            {
                case RotationOrder.OrderXYZ:
                    q = Quaternion.FromAxisAngle(Vector3.UnitZ, MathHelper.DegreesToRadians(z)) *
                        Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.DegreesToRadians(y)) *
                        Quaternion.FromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(x));
                    break;

                default:
                    throw new NotImplementedException($"Unhandled RotationOrder: {order}");
            }

            return q;
        }

        public enum CoordinateSystem
        {
            // X Y Z
            nXnYnZ = (0 + (2 << 3) + (4 << 6)),
            nXnYpZ = (0 + (2 << 3) + (5 << 6)),
            nXpYnZ = (0 + (3 << 3) + (4 << 6)),
            nXpYpZ = (0 + (3 << 3) + (5 << 6)),
            pXnYnZ = (1 + (2 << 3) + (4 << 6)),
            pXnYpZ = (1 + (2 << 3) + (5 << 6)),
            pXpYnZ = (1 + (3 << 3) + (4 << 6)),
            pXpYpZ = (1 + (3 << 3) + (5 << 6)),

            // X Z Y
            nXnZnY = (0 + (4 << 3) + (2 << 6)),
            nXnZpY = (0 + (4 << 3) + (3 << 6)),
            nXpZnY = (0 + (5 << 3) + (2 << 6)),
            nXpZpY = (0 + (5 << 3) + (3 << 6)),
            pXnZnY = (1 + (4 << 3) + (2 << 6)),
            pXnZpY = (1 + (4 << 3) + (3 << 6)),
            pXpZnY = (1 + (5 << 3) + (2 << 6)),
            pXpZpY = (1 + (5 << 3) + (3 << 6)),

            // Y X Z
            nYnXnZ = (2 + (0 << 3) + (4 << 6)),
            nYnXpZ = (2 + (0 << 3) + (5 << 6)),
            nYpXnZ = (2 + (1 << 3) + (4 << 6)),
            nYpXpZ = (2 + (1 << 3) + (5 << 6)),
            pYnXnZ = (3 + (0 << 3) + (4 << 6)),
            pYnXpZ = (3 + (0 << 3) + (5 << 6)),
            pYpXnZ = (3 + (1 << 3) + (4 << 6)),
            pYpXpZ = (3 + (1 << 3) + (5 << 6)),

            // Y Z X
            nYnZnX = (2 + (4 << 3) + (0 << 6)),
            nYnZpX = (2 + (4 << 3) + (1 << 6)),
            nYpZnX = (2 + (5 << 3) + (0 << 6)),
            nYpZpX = (2 + (5 << 3) + (1 << 6)),
            pYnZnX = (3 + (4 << 3) + (0 << 6)),
            pYnZpX = (3 + (4 << 3) + (1 << 6)),
            pYpZnX = (3 + (5 << 3) + (0 << 6)),
            pYpZpX = (3 + (5 << 3) + (1 << 6)),

            // Z X Y
            nZnXnY = (4 + (0 << 3) + (2 << 6)),
            nZnXpY = (4 + (0 << 3) + (3 << 6)),
            nZpXnY = (4 + (1 << 3) + (2 << 6)),
            nZpXpY = (4 + (1 << 3) + (3 << 6)),
            pZnXnY = (5 + (0 << 3) + (2 << 6)),
            pZnXpY = (5 + (0 << 3) + (3 << 6)),
            pZpXnY = (5 + (1 << 3) + (2 << 6)),
            pZpXpY = (5 + (1 << 3) + (3 << 6)),

            // Z Y X
            nZnYnX = (4 + (2 << 3) + (0 << 6)),
            nZnYpX = (4 + (2 << 3) + (1 << 6)),
            nZpYnX = (4 + (3 << 3) + (0 << 6)),
            nZpYpX = (4 + (3 << 3) + (1 << 6)),
            pZnYnX = (5 + (2 << 3) + (0 << 6)),
            pZnYpX = (5 + (2 << 3) + (1 << 6)),
            pZpYnX = (5 + (3 << 3) + (0 << 6)),
            pZpYpX = (5 + (3 << 3) + (1 << 6))
        }

        private Matrix4 createTransformFor(FBXElem globalSettings, out RotationOrder order)
        {
            order = RotationOrder.OrderXYZ;

            int frontAxis = (int)globalSettings.Children.GetProperty("FrontAxis").Properties[4].Value;
            int frontAxisSign = (int)globalSettings.Children.GetProperty("FrontAxisSign").Properties[4].Value;
            int upAxis = (int)globalSettings.Children.GetProperty("UpAxis").Properties[4].Value;
            int upAxisSign = (int)globalSettings.Children.GetProperty("UpAxisSign").Properties[4].Value;
            int coordAxis = (int)globalSettings.Children.GetProperty("CoordAxis").Properties[4].Value;
            int coordAxisSign = (int)globalSettings.Children.GetProperty("CoordAxisSign").Properties[4].Value;

            int front = (frontAxis * 2) + Math.Max(frontAxisSign, 0);
            int up = (upAxis * 2) + Math.Max(upAxisSign, 0) << 3;
            int coord = (coordAxis * 2) + Math.Max(coordAxisSign, 0) << 6;

            CoordinateSystem coords = (CoordinateSystem)(front + up + coord);

            switch (coords)
            {
                // Blender 2.71 tells us that -Y is forward but the UI suggest +Y is forward.
                case CoordinateSystem.nYpZpX:
                    order = RotationOrder.OrderXYZ;
                    return Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-90));

                case CoordinateSystem.pZpYpX:
                    order = RotationOrder.OrderXYZ;
                    return Matrix4.Identity;

                default:
                    throw new NotImplementedException($"Unsupported World Transformation Matrix: {coords}");
            }
        }
    }

    public class FBXFace
    {
        private List<Vertex> verts;
        private int materialID = 0;
        private int smoothingGroup = 0;

        public int MaterialID
        {
            get => materialID;
            set => materialID = value;
        }

        public int SmoothingGroup
        {
            get => smoothingGroup;
            set => smoothingGroup = value;
        }

        public List<Vertex> Vertices => verts;

        public FBXFace()
        {
            verts = new List<Vertex>();
        }

        public void AddVertex(Vector3 position, Vector3 normal, Vector2 texcoords, Color4 colour)
        {
            Vertex v = new Vertex
            {
                Position = position,
                Normal = normal,
                UV = new Vector4(texcoords.X, texcoords.Y, 0, 0),
                Colour = colour
            };

            verts.Add(v);
        }
    }

    public static class FBXExtensionMethods
    {
        public static FBXElem GetProperty(this List<FBXElem> propertyList, string propertyName)
        {
            foreach (FBXElem property in propertyList)
            {
                if (string.Equals(property.ID, "P", StringComparison.InvariantCultureIgnoreCase) && property.Properties.Count > 0 && property.Properties[0].Value.ToString() == propertyName)
                {
                    return property;
                }
            }

            return null;
        }
    }
}