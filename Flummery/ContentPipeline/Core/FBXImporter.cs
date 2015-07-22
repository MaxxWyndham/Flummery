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

            Dictionary<long, string> triangulationErrors = new Dictionary<long, string>();

            string name = Path.GetFileNameWithoutExtension(path);

            if (fbx == null)
            {
                SceneManager.Current.RaiseError(string.Format("File \"{0}\" could not be opened.  Please ensure this is a binary FBX file.", name));
                return null;
            }

            var objects = fbx.Elements.Find(e => e.ID == "Objects");

            RotationOrder order;
            var worldMatrix = createTransformFor(fbx.Elements.Find(e => e.ID == "GlobalSettings").Children[1], out order);

            Console.WriteLine();
            var header = fbx.FBXHeaderExtension.Children.Find(e => e.ID == "SceneInfo").Children.Find(e => e.ID == "Properties70").Children.GetProperty("Original|ApplicationName");

            foreach (var material in objects.Children.Where(e => e.ID == "Material"))
            {
                string matName = material.Properties[1].Value.ToString();
                matName = matName.Substring(0, matName.IndexOf("::"));
                var m = new Material { Name = matName };
                components.Add((long)material.Properties[0].Value, m);

                Console.WriteLine("Added material \"{0}\" ({1})", matName, material.Properties[0].Value);
            }

            var textures = objects.Children.Where(e => e.ID == "Texture");
            foreach (var texture in textures)
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

                if (!components.ContainsKey((long)texture.Properties[0].Value))
                {
                    components.Add((long)texture.Properties[0].Value, t);

                    Console.WriteLine("Added texture \"{0}\" ({1})", file, texture.Properties[0].Value);
                }
            }

            foreach (var element in objects.Children.Where(e => e.ID == "Model"))
            {
                string modelName = element.Properties[1].Value.ToString();
                modelName = modelName.Substring(0, modelName.IndexOf("::"));

                components.Add((long)element.Properties[0].Value, new ModelMesh { Name = modelName, Tag = (long)element.Properties[0].Value });

                Console.WriteLine("Added model \"{0}\" ({1})", modelName, element.Properties[0].Value);

                var properties = element.Children.Find(c => c.ID == "Properties70");
                var m = Matrix4.Identity;
                bool bRotationActive = false;

                var lclTranslation = OpenTK.Vector3.Zero;
                var lclRotation = Quaternion.Identity;
                var preRotation = Quaternion.Identity;
                var postRotation = Quaternion.Identity;
                var rotationPivot = OpenTK.Vector3.Zero;
                var rotationOffset = OpenTK.Vector3.Zero;
                var lclScaling = OpenTK.Vector3.One;
                var scalingPivot = OpenTK.Vector3.Zero;
                var scalingOffset = OpenTK.Vector3.Zero;

                var geoPosition = OpenTK.Vector3.Zero;
                var geoRotation = Quaternion.Identity;
                var geoScale = OpenTK.Vector3.One;

                FBXElem property;

                property = properties.Children.GetProperty("RotationActive");
                if (property != null) { bRotationActive = ((int)property.Properties[4].Value == 1); }

                property = properties.Children.GetProperty("ScalingPivot");
                if (property != null)
                {
                    scalingPivot = new OpenTK.Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );

                    Console.WriteLine("scalingPivot {0}", scalingPivot);
                }

                property = properties.Children.GetProperty("Lcl Scaling");
                if (property != null)
                {
                    lclScaling = new OpenTK.Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );

                    Console.WriteLine("lclScaling {0}", lclScaling);
                }

                property = properties.Children.GetProperty("ScalingOffset");
                if (property != null)
                {
                    scalingOffset = new OpenTK.Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );

                    Console.WriteLine("scalingOffset {0}", scalingOffset);
                }

                property = properties.Children.GetProperty("RotationPivot");
                if (property != null)
                {
                    rotationPivot = new OpenTK.Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );

                    Console.WriteLine("rotationPivot {0}", rotationPivot);
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

                    Console.WriteLine("postRotation {0}", postRotation);
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

                    //lclRotation = (Matrix4.CreateFromQuaternion(lclRotation) * worldMatrix).ExtractRotation();

                    Console.WriteLine("lclRotation {0}", lclRotation);
                    Console.WriteLine("lclRotationMatrix {0}", Matrix4.CreateFromQuaternion(lclRotation));
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

                    Console.WriteLine("preRotation {0}", preRotation);
                }

                property = properties.Children.GetProperty("RotationOffset");
                if (property != null)
                {
                    rotationOffset = new OpenTK.Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );

                    Console.WriteLine("rotationOffset {0}", rotationOffset);
                }

                property = properties.Children.GetProperty("Lcl Translation");
                if (property != null)
                {
                    lclTranslation = new OpenTK.Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );

                    Console.WriteLine("lclTranslation {0}", lclTranslation);

                    //lclTranslation = OpenTK.Vector3.Transform(lclTranslation, worldMatrix);

                    Console.WriteLine("lclTranslation {0}", lclTranslation);
                }

                property = properties.Children.GetProperty("GeometricTranslation");
                if (property != null)
                {
                    geoPosition = new OpenTK.Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );

                    Console.WriteLine("geoPosition {0}", geoPosition);
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

                    Console.WriteLine("geoRotation {0}", geoRotation);
                }

                property = properties.Children.GetProperty("GeometricScaling");
                if (property != null)
                {
                    geoScale = new OpenTK.Vector3(
                        Convert.ToSingle(property.Properties[4].Value),
                        Convert.ToSingle(property.Properties[5].Value),
                        Convert.ToSingle(property.Properties[6].Value)
                    );

                    Console.WriteLine("geoScale {0}", geoScale);
                }

                Console.WriteLine("bRotationActive : {0} || Order : {1}", bRotationActive, order);

                //m *= Matrix4.CreateTranslation(-scalingPivot);
                //m *= Matrix4.CreateScale(lclScaling);
                //m *= Matrix4.CreateTranslation(scalingOffset + scalingPivot - rotationPivot);

                //if (bRotationActive)
                //{
                //    m *= worldMatrix;
                //    m *= Matrix4.CreateFromQuaternion((postRotation * lclRotation * preRotation).Normalized());
                //}
                //else
                //{
                //    m *= Matrix4.CreateFromQuaternion(lclRotation);
                //}

                //m *= Matrix4.CreateTranslation(lclTranslation + rotationOffset + rotationPivot);


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

                //m = Matrix4.CreateTranslation(lclTranslation) *
                //    Matrix4.CreateTranslation(rotationOffset) *
                //    Matrix4.CreateTranslation(rotationPivot) *
                //    Matrix4.CreateFromQuaternion(preRotation) *
                //    Matrix4.CreateFromQuaternion(lclRotation) *
                //    Matrix4.CreateFromQuaternion(postRotation) *
                //    Matrix4.CreateTranslation(rotationPivot).Inverted() *
                //    Matrix4.CreateTranslation(scalingOffset) *
                //    Matrix4.CreateTranslation(scalingPivot) *
                //    Matrix4.CreateScale(lclScaling) *
                //    Matrix4.CreateTranslation(scalingPivot).Inverted();

                
                //m *= Matrix4.CreateTranslation(-scalingPivot);
                //m *= Matrix4.CreateScale(lclScaling);
                //m *= Matrix4.CreateTranslation(scalingOffset + scalingPivot - rotationPivot);

                //if (bRotationActive)
                //{
                //    m *= worldMatrix;
                //    m *= Matrix4.CreateFromQuaternion((postRotation * lclRotation * preRotation).Normalized());
                //}
                //else
                //{
                //    m *= Matrix4.CreateFromQuaternion(lclRotation);
                //}

                

                OpenTK.Vector3 s = new OpenTK.Vector3();
                OpenTK.Vector3 t = new OpenTK.Vector3();
                Quaternion r = new Quaternion();

                if (!m.Decompose(out s, out r, out t))
                {
                    Console.WriteLine("Shit dude");
                }
                else
                {
                    Console.WriteLine("position: {0}", t);
                    Console.WriteLine("rotation: {0}", r);
                    Console.WriteLine("scale   : {0}", s);
                }

                //m = scalingPivot.Inverted() *
                //    lclScaling *
                //    scalingPivot *
                //    scalingOffset *
                //    rotationPivot.Inverted() *
                //    postRotation *
                //    lclRotation *
                //    preRotation *
                //    rotationPivot *
                //    rotationOffset *
                //    lclTranslation;

                if (m != Matrix4.Identity) { transforms.Add((long)element.Properties[0].Value, m); }
            }

            foreach (var element in objects.Children.Where(e => e.ID == "Geometry"))
            {
                bool bUVs = true;
                bool bNorms = true;
                bool bColours = true;
                bool bUseIndexNorm = false;

                bool bNeedsTriangulating = false;

                string geometryName = element.Properties[1].Value.ToString();
                geometryName = geometryName.Substring(0, geometryName.IndexOf("::"));

                var verts = new List<OpenTK.Vector3>();
                var norms = new List<OpenTK.Vector3>();
                var uvs = new List<OpenTK.Vector2>();
                var colours = new List<OpenTK.Graphics.Color4>();

                var vertParts = (double[])element.Children.Find(e => e.ID == "Vertices").Properties[0].Value;
                for (int i = 0; i < vertParts.Length; i += 3) 
                {
                    //verts.Add(OpenTK.Vector3.Transform(new OpenTK.Vector3((float)vertParts[i + 0], (float)vertParts[i + 1], (float)vertParts[i + 2]), worldMatrix)); 
                    verts.Add(new OpenTK.Vector3((float)vertParts[i + 0], (float)vertParts[i + 1], (float)vertParts[i + 2])); 
                }

                SceneManager.Current.UpdateProgress(string.Format("Processed {0}->Vertices", element.Properties[1].Value));

                var normElem = element.Children.Find(e => e.ID == "LayerElementNormal");
                if (normElem != null)
                {
                    var normParts = (double[])normElem.Children.Find(e => e.ID == "Normals").Properties[0].Value;
                    for (int i = 0; i < normParts.Length; i += 3)
                    {
                        //norms.Add(OpenTK.Vector3.Transform(new OpenTK.Vector3((float)normParts[i + 0], (float)normParts[i + 1], (float)normParts[i + 2]), worldMatrix));
                        norms.Add(new OpenTK.Vector3((float)normParts[i + 0], (float)normParts[i + 1], (float)normParts[i + 2]));
                    }

                    bUseIndexNorm = (normElem.Children.Find(e => e.ID == "MappingInformationType").Properties[0].Value.ToString() == "ByVertice");

                    SceneManager.Current.UpdateProgress(string.Format("Processed {0}->Normals", element.Properties[1].Value));
                }
                else
                {
                    bNorms = false;
                }

                var colourElem = element.Children.Find(e => e.ID == "LayerElementColor");
                if (colourElem != null)
                {
                    var colourParts = (double[])colourElem.Children.Find(e => e.ID == "Colors").Properties[0].Value;

                    var colourReferenceType = colourElem.Children.Find(e => e.ID == "ReferenceInformationType");

                    switch (colourReferenceType.Properties[0].Value.ToString())
                    {
                        case "IndexToDirect":
                            var colourIndicies = (int[])colourElem.Children.Find(e => e.ID == "ColorIndex").Properties[0].Value;
                            for (int i = 0; i < colourIndicies.Length; i++)
                            {
                                int offset = colourIndicies[i] * 4;
                                colours.Add(new OpenTK.Graphics.Color4((float)colourParts[offset + 0], (float)colourParts[offset + 1], (float)colourParts[offset + 2], (float)colourParts[offset + 3]));
                            }
                            break;

                        case "Direct":
                            bColours = false;
                            break;

                        default:
                            throw new NotImplementedException("Unsupported Colour Reference Type: " + colourReferenceType.Properties[0].Value.ToString());
                    }

                    SceneManager.Current.UpdateProgress(string.Format("Processed {0}->Colours", element.Properties[1].Value));
                }
                else
                {
                    bColours = false;
                }

                var uvElem = element.Children.Find(e => e.ID == "LayerElementUV");
                if (uvElem != null)
                {
                    var uvParts = (double[])uvElem.Children.Find(e => e.ID == "UV").Properties[0].Value;

                    var uvReferenceType = uvElem.Children.Find(e => e.ID == "ReferenceInformationType");
                    if (uvReferenceType.Properties[0].Value.ToString() == "IndexToDirect")
                    {
                        var luvs = new List<OpenTK.Vector2>();
                        for (int i = 0; i < uvParts.Length; i += 2) { luvs.Add(new OpenTK.Vector2((float)uvParts[i + 0], 1 - (float)uvParts[i + 1])); }

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
                        for (int i = 0; i < uvParts.Length; i += 2) { uvs.Add(new OpenTK.Vector2((float)uvParts[i + 0], (float)uvParts[i + 1])); }
                    }

                    SceneManager.Current.UpdateProgress(string.Format("Processed {0}->UVs", element.Properties[1].Value));
                }
                else
                {
                    bUVs = false;
                }

                var indicies = (int[])element.Children.Find(e => e.ID == "PolygonVertexIndex").Properties[0].Value;
                var faces = new List<FBXFace>();
                var face = new FBXFace();
                var j = 0;

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
                    face.AddVertex(verts[index], (bNorms ? norms[(bUseIndexNorm ? index : i)] : OpenTK.Vector3.Zero), (bUVs ? uvs[i] : OpenTK.Vector2.Zero), (bColours ? colours[i] : OpenTK.Graphics.Color4.White));

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

                var parts = new List<ModelMeshPart>();

                if (!bNeedsTriangulating)
                {
                    SceneManager.Current.UpdateProgress(string.Format("Processed {0}->Faces", element.Properties[1].Value));

                    var elemMaterial = element.Children.Find(e => e.ID == "LayerElementMaterial");
                    if (elemMaterial != null)
                    {
                        var faceMaterials = (int[])elemMaterial.Children.Find(e => e.ID == "Materials").Properties[0].Value;
                        for (int i = 0; i < faceMaterials.Length; i++)
                        {
                            faces[i].MaterialID = faceMaterials[i];
                        }

                        SceneManager.Current.UpdateProgress(string.Format("Processed {0}->Materials", element.Properties[1].Value));
                    }


                    var materialGroups = faces.GroupBy(f => f.MaterialID);

                    int processedFaceCount = 0,
                        processedGroupCount = 0;

                    foreach (var materialGroup in materialGroups)
                    {
                        var smoothingGroups = materialGroup.GroupBy(f => f.SmoothingGroup);

                        foreach (var smoothingGroup in smoothingGroups)
                        {
                            var meshpart = new ModelMeshPart { PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType.Triangles };
                            processedFaceCount = 0;

                            foreach (var groupface in smoothingGroup)
                            {
                                foreach (var vert in groupface.Vertices)
                                {
                                    meshpart.AddVertex(vert.Position, vert.Normal, vert.UV, vert.Colour);
                                }

                                processedFaceCount++;

                                if (processedFaceCount % 250 == 0) { SceneManager.Current.UpdateProgress(string.Format("Processed {0}->MeshPart[{1}]->Face[{2}]", element.Properties[1].Value, processedGroupCount, processedFaceCount)); }
                            }

                            meshpart.Key = materialGroup.Key;

                            parts.Add(meshpart);
                            SceneManager.Current.UpdateProgress(string.Format("Processed {0}->MeshPart", element.Properties[1].Value));

                            processedGroupCount++;
                        }
                    }
                }

                components.Add((long)element.Properties[0].Value, parts);
                SceneManager.Current.UpdateProgress(string.Format("Processed {0}", element.Properties[1].Value));
            }

            string[] connectionOrder = new string[] { "System.Collections.Generic.List`1[Flummery.ModelMeshPart]", "Flummery.Texture", "Flummery.Material", "Flummery.ModelMesh" };
            var connections = fbx.Elements.Find(e => e.ID == "Connections");

            HashSet<long> loaded = new HashSet<long>();

            foreach (var connectionType in connectionOrder)
            {
                var connectionsOfType = connections.Children.Where(c => components.ContainsKey((long)c.Properties[1].Value) && components[(long)c.Properties[1].Value].GetType().ToString() == connectionType);

                foreach (var connection in connectionsOfType)
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
                                if (transforms.ContainsKey(keyA)) { model.SetTransform(transforms[keyA], boneID); }// else { model.SetTransform(worldMatrix, boneID); }
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
                                if (loaded.Add(keyB))
                                {
                                    ((Material)components[keyB]).Texture = (Texture)components[keyA];
                                    SceneManager.Current.Add((Material)components[keyB]);
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

                                foreach (var part in (List<ModelMeshPart>)components[keyA])
                                {
                                    ((ModelMesh)components[keyB]).AddModelMeshPart(part);
                                }
                            }
                            break;

                        case "Flummery.Material":
                            if (components.ContainsKey(keyB) && components[keyB].GetType().ToString() == "Flummery.ModelMesh")
                            {
                                var materialLookup = connections.Children.Where(c => (long)c.Properties[2].Value == keyB).ToList();
                                for (int i = materialLookup.Count - 1; i > -1; i--) { if (!connectionsOfType.Any(c => (long)c.Properties[1].Value == (long)materialLookup[i].Properties[1].Value)) { materialLookup.RemoveAt(i); } }
                        
                                foreach (var part in ((ModelMesh)components[keyB]).MeshParts)
                                {
                                    if ((long)materialLookup[(int)part.Key].Properties[1].Value == keyA)
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

            if (triangulationErrors.Count > 0)
            {
                SceneManager.Current.UpdateProgress(string.Format("Failed to load {0}", name));

                string error = string.Format("File \"{0}\" has part{1} that need been triangulating!  Please triangulate the following:", name, (triangulationErrors.Count > 1 ? "s" : ""));
                foreach (var kvp in triangulationErrors)
                {
                    error += "\r\n" + kvp.Value;
                }

                SceneManager.Current.RaiseError(error);

                return null;
            }
            else
            {
                SceneManager.Current.UpdateProgress(string.Format("Loaded {0}", name));

                model.Santise();

                return model;
            }
        }

        public Quaternion MakeQuaternion(Single x, Single y, Single z, RotationOrder order, bool debug = true)
        {
            Console.WriteLine("Creating Quaternion :");
            Console.WriteLine("({0}, {1}, {2})", x, y, z);

            Quaternion q = Quaternion.Identity;

            switch (order)
            {
                case RotationOrder.OrderXYZ:
                    q = Quaternion.FromAxisAngle(OpenTK.Vector3.UnitZ, MathHelper.DegreesToRadians(z)) *
                        Quaternion.FromAxisAngle(OpenTK.Vector3.UnitY, MathHelper.DegreesToRadians(y)) *
                        Quaternion.FromAxisAngle(OpenTK.Vector3.UnitX, MathHelper.DegreesToRadians(x));
                    break;

                case RotationOrder.OrderXZY:
                    q = Quaternion.FromAxisAngle(OpenTK.Vector3.UnitY, MathHelper.DegreesToRadians(y)) *
                        Quaternion.FromAxisAngle(OpenTK.Vector3.UnitZ, MathHelper.DegreesToRadians(z)) *
                        Quaternion.FromAxisAngle(OpenTK.Vector3.UnitX, MathHelper.DegreesToRadians(x));
                    break;

                case RotationOrder.OrderYZX:
                    q = Quaternion.FromAxisAngle(OpenTK.Vector3.UnitX, MathHelper.DegreesToRadians(x)) *
                        Quaternion.FromAxisAngle(OpenTK.Vector3.UnitZ, MathHelper.DegreesToRadians(z)) *
                        Quaternion.FromAxisAngle(OpenTK.Vector3.UnitY, MathHelper.DegreesToRadians(y));
                    break;

                default:
                    throw new NotImplementedException(string.Format("Unhandled RotationOrder: {0}", order));
            }

            Console.WriteLine(q);

            var e = q.ToEuler(order);
            Console.WriteLine(e);
            if (debug) { MakeQuaternion(e.X, e.Y, e.Z, order, false); }

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

            var frontAxis = (int)globalSettings.Children.GetProperty("FrontAxis").Properties[4].Value;
            var frontAxisSign = (int)globalSettings.Children.GetProperty("FrontAxisSign").Properties[4].Value;
            var upAxis = (int)globalSettings.Children.GetProperty("UpAxis").Properties[4].Value;
            var upAxisSign = (int)globalSettings.Children.GetProperty("UpAxisSign").Properties[4].Value;
            var coordAxis = (int)globalSettings.Children.GetProperty("CoordAxis").Properties[4].Value;
            var coordAxisSign = (int)globalSettings.Children.GetProperty("CoordAxisSign").Properties[4].Value;

            var front = (frontAxis * 2) + Math.Max(frontAxisSign, 0);
            var up = (upAxis * 2) + Math.Max(upAxisSign, 0) << 3;
            var coord = (coordAxis * 2) + Math.Max(coordAxisSign, 0) << 6;

            var coords = (CoordinateSystem)(front + up + coord);

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
                    throw new NotImplementedException(string.Format("Unsupported World Transformation Matrix: {0}", coords));
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

        public void AddVertex(OpenTK.Vector3 position, OpenTK.Vector3 normal, OpenTK.Vector2 texcoords, OpenTK.Graphics.Color4 colour)
        {
            var v = new Vertex();
            v.Position = position;
            v.Normal = normal;
            v.UV = new OpenTK.Vector4(texcoords.X, texcoords.Y, 0, 0);
            v.Colour = colour;

            verts.Add(v);
        }
    }

    public static class FBXExtensionMethods
    {
        public static FBXElem GetProperty(this List<FBXElem> propertyList, string propertyName)
        {
            foreach (var property in propertyList)
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
