using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ToxicRagers.Core.Formats;
using OpenTK;

namespace Flummery.ContentPipeline.Core
{
    class FBXExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            var model = (asset as Model);
            FBX fbx = new FBX();
            fbx.Version = 7400;

            fbx.Elements.Add(
                new FBXElem
                {
                    ID = "FBXHeaderExtension",
                    Children =
                    {
                        new FBXElem { ID = "FBXHeaderVersion", Properties = { new FBXProperty { Type = 73, Value = 1003 } } },
                        new FBXElem { ID = "FBXVersion", Properties = { new FBXProperty { Type = 73, Value = fbx.Version } } },
                        new FBXElem { ID = "EncryptionType", Properties = { new FBXProperty { Type = 73, Value = 0 } } },
                        new FBXElem { ID = "CreationTimeStamp", 
                            Children = 
                            { 
                                new FBXElem { ID = "Version", Properties = { new FBXProperty { Type = 73, Value = 1000 } } },
                                new FBXElem { ID = "Year", Properties = { new FBXProperty { Type = 73, Value = DateTime.Now.Year } } },
                                new FBXElem { ID = "Month", Properties = { new FBXProperty { Type = 73, Value = DateTime.Now.Month } } },
                                new FBXElem { ID = "Day", Properties = { new FBXProperty { Type = 73, Value = DateTime.Now.Day } } },
                                new FBXElem { ID = "Hour", Properties = { new FBXProperty { Type = 73, Value = DateTime.Now.Hour } } },
                                new FBXElem { ID = "Minute", Properties = { new FBXProperty { Type = 73, Value = DateTime.Now.Minute } } },
                                new FBXElem { ID = "Second", Properties = { new FBXProperty { Type = 73, Value = DateTime.Now.Second } } },
                                new FBXElem { ID = "Millisecond", Properties = { new FBXProperty { Type = 73, Value = DateTime.Now.Millisecond } } }
                            }
                        },
                        new FBXElem { ID = "Creator", Properties = { new FBXProperty { Type = 83, Value = "Flummery v" + Flummery.Version } } },
                        new FBXElem { ID = "SceneInfo",                    
                            Properties = 
                            {
                                new FBXProperty { Type = 83, Value = "GlobalInfo::SceneInfo" },
                                new FBXProperty { Type = 83, Value = "UserData" }
                            },
                            Children = 
                            { 
                                new FBXElem { ID = "Type", Properties = { new FBXProperty { Type = 83, Value = "UserData" } } },
                                new FBXElem { ID = "Version", Properties = { new FBXProperty { Type = 73, Value = 100 } } },
                                new FBXElem { ID = "MetaData", 
                                    Children = 
                                    { 
                                        new FBXElem { ID = "Version", Properties = { new FBXProperty { Type = 73, Value = 100 } } },
                                        new FBXElem { ID = "Title", Properties = { new FBXProperty { Type = 83, Value = "" } } },
                                        new FBXElem { ID = "Subject", Properties = { new FBXProperty { Type = 83, Value = "" } } },
                                        new FBXElem { ID = "Author", Properties = { new FBXProperty { Type = 83, Value = "" } } },
                                        new FBXElem { ID = "Keywords", Properties = { new FBXProperty { Type = 83, Value = "" } } },
                                        new FBXElem { ID = "Revision", Properties = { new FBXProperty { Type = 83, Value = "" } } },
                                        new FBXElem { ID = "Comment", Properties = { new FBXProperty { Type = 83, Value = "" } } }
                                    } 
                                },
                                new FBXElem { ID = "Properties70", 
                                    Children = 
                                    {
                                        FBXPropertyElement(FBXPropertyType.String, "DocumentUrl", "KString", "Url", "", path),
                                        FBXPropertyElement(FBXPropertyType.String, "SrcDocumentUrl", "KString", "Url", "", path),
                                        FBXPropertyElement(FBXPropertyType.String, "Original", "Compound", "", ""),
                                        FBXPropertyElement(FBXPropertyType.String, "Original|ApplicationVendor", "KString", "", "", "Toxic Ragers"),
                                        FBXPropertyElement(FBXPropertyType.String, "Original|ApplicationName", "KString", "", "", "Flummery"),
                                        FBXPropertyElement(FBXPropertyType.String, "Original|ApplicationVersion", "KString", "", "", Flummery.Version),
                                        FBXPropertyElement(FBXPropertyType.String, "Original|DateTime_GMT", "KString", "", "", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff")),
                                        FBXPropertyElement(FBXPropertyType.String, "Original|FileName", "KString", "", "", path),
                                        FBXPropertyElement(FBXPropertyType.String, "LastSaved", "Compound", "", ""),
                                        FBXPropertyElement(FBXPropertyType.String, "LastSaved|ApplicationVendor", "KString", "", "", "Toxic Ragers"),
                                        FBXPropertyElement(FBXPropertyType.String, "LastSaved|ApplicationName", "KString", "", "", "Flummery"),
                                        FBXPropertyElement(FBXPropertyType.String, "LastSaved|ApplicationVersion", "KString", "", "", Flummery.Version),
                                        FBXPropertyElement(FBXPropertyType.String, "LastSaved|DateTime_GMT", "KString", "", "", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff"))
                                    }
                                }
                            }
                        }
                    }
                }
            );

            fbx.Elements.Add(new FBXElem { ID = "FileId", Properties = { new FBXProperty { Type = 82, Value = new byte[] { 0x28, 0xb3, 0x2a, 0xeb, 0xb6, 0x24, 0xcc, 0xc2, 0xbf, 0xc8, 0xb0, 0x2a, 0xa9, 0x2b, 0xfc, 0xf1 } } } });
            fbx.Elements.Add(new FBXElem { ID = "CreationTime", Properties = { new FBXProperty { Type = 83, Value = "1970-01-01 10:00:00:000" } } });
            fbx.Elements.Add(new FBXElem { ID = "Creator", Properties = { new FBXProperty { Type = 83, Value = "Flummery v" + Flummery.Version } } });

            fbx.Elements.Add(
                new FBXElem
                {
                    ID = "GlobalSettings",
                    Children =
                    {
                        new FBXElem { ID = "Version", Properties = { new FBXProperty { Type = 73, Value = 1000 } } },
                        new FBXElem { ID = "Properties70", 
                            Children = 
                            {
                                FBXPropertyElement(FBXPropertyType.Integer, "UpAxis", "int", "Integer", "", 1),
                                FBXPropertyElement(FBXPropertyType.Integer, "UpAxisSign", "int", "Integer", "", 1),
                                FBXPropertyElement(FBXPropertyType.Integer, "FrontAxis", "int", "Integer", "", 2),
                                FBXPropertyElement(FBXPropertyType.Integer, "FrontAxisSign", "int", "Integer", "", 0),
                                FBXPropertyElement(FBXPropertyType.Integer, "CoordAxis", "int", "Integer", "", 0),
                                FBXPropertyElement(FBXPropertyType.Integer, "CoordAxisSign", "int", "Integer", "", 1),
                                FBXPropertyElement(FBXPropertyType.Integer, "OriginalUpAxis", "int", "Integer", "", 1),
                                FBXPropertyElement(FBXPropertyType.Integer, "OriginalUpAxisSign", "int", "Integer", "", 1),
                                FBXPropertyElement(FBXPropertyType.Double, "UnitScaleFactor", "double", "Number", "", (double)1),
                                FBXPropertyElement(FBXPropertyType.Double, "OriginalUnitScaleFactor", "double", "Number", "", (double)1),
                                FBXPropertyElement(FBXPropertyType.Double, "AmbientColor", "ColorRGB", "Color", "", (double)0.0, (double)0.0, (double)0.0),
                                FBXPropertyElement(FBXPropertyType.String, "DefaultCamera", "KString", "", "", "Producer Front"),
                                FBXPropertyElement(FBXPropertyType.Integer, "TimeMode", "enum", "", "", 6),
                                FBXPropertyElement(FBXPropertyType.Integer, "TimeProtocol", "enum", "", "", 2),
                                FBXPropertyElement(FBXPropertyType.Integer, "SnapOnFrameMode", "enum", "", "", 0),
                                FBXPropertyElement(FBXPropertyType.Long, "TimeSpanStart", "KTime", "Time", "", (long)0),
                                FBXPropertyElement(FBXPropertyType.Long, "TimeSpanStop", "KTime", "Time", "", (long)153953860000),
                                FBXPropertyElement(FBXPropertyType.Double, "CustomFrameRate", "double", "Number", "", (double)(-1.0)),
                                FBXPropertyElement(FBXPropertyType.String, "TimeMarker", "Compound", "", ""),
                                FBXPropertyElement(FBXPropertyType.Integer, "CurrentTimeMarker", "int", "Integer", "", -1)
                            }
                        }
                    }
                }
            );

            long sceneRoot = (long)8008135;

            fbx.Elements.Add(
                new FBXElem
                {
                    ID = "Documents",
                    Children =
                    {
                        new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = 1 } } },
                        new FBXElem { ID = "Document", 
                            Properties = 
                            {  
                                new FBXProperty { Type = 76, Value = sceneRoot },
                                new FBXProperty { Type = 83, Value = "" },
                                new FBXProperty { Type = 83, Value = "Scene" }
                            },
                            Children = 
                            {
                                new FBXElem { ID = "Properties70", 
                                    Children = 
                                    {
                                        FBXPropertyElement(FBXPropertyType.String, "SourceObject", "object", "", ""),
                                        FBXPropertyElement(FBXPropertyType.String, "ActiveAnimStackName", "KString", "", "", "")
                                    }
                                },
                                new FBXElem { ID = "RootNode", Properties = { new FBXProperty { Type = 76, Value = (long)0 } } }
                            }
                        }
                    }
                }
            );

            fbx.Elements.Add(new FBXElem { ID = "References" });

            var fbxObjects = new FBXElem { ID = "Objects" };
            var fbxConnections = new FBXElem { ID = "Connections" };

            foreach (var material in model.GetMaterials())
            {
                var fbxMaterial = new FBXElem { ID = "Material", Properties = { new FBXProperty { Type = 76, Value = material.Key }, new FBXProperty { Type = 83, Value = material.Name + "::Material" }, new FBXProperty { Type = 83, Value = "" } } };
                fbxMaterial.Children.Add(new FBXElem { ID = "Version", Properties = { new FBXProperty { Type = 73, Value = 102 } } });
                fbxMaterial.Children.Add(new FBXElem { ID = "ShadingModel", Properties = { new FBXProperty { Type = 83, Value = "phong" } } });
                fbxMaterial.Children.Add(new FBXElem { ID = "MultiLayer", Properties = { new FBXProperty { Type = 73, Value = 0 } } });
                fbxMaterial.Children.Add(
                    new FBXElem
                    {
                        ID = "Properties70",
                        Children = 
                        { 
                            FBXPropertyElement(FBXPropertyType.Double, "EmissiveColor", "Color", "", "A", (double)0.800000011920929, (double)0.800000011920929, (double)0.800000011920929),
                            FBXPropertyElement(FBXPropertyType.Double, "DiffuseColor", "Color", "", "A", (double)0.800000011920929, (double)0.800000011920929, (double)0.800000011920929),
                            FBXPropertyElement(FBXPropertyType.Double, "DiffuseFactor", "Number", "", "A", (double)0.800000011920929),
                            FBXPropertyElement(FBXPropertyType.Double, "DiffuseColor", "Color", "", "A", (double)1, (double)1, (double)1)
                        }
                    }
                );

                string ddsPath = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(material.Texture.FileName);
                var tdx = (material.Texture.Tag as ToxicRagers.CarmageddonReincarnation.Formats.TDX);
                if (tdx != null)
                {
                    tdx.SaveAsDDS(ddsPath);
                    ddsPath += ".dds";

                    var fbxTexture = new FBXElem { ID = "Texture", Properties = { new FBXProperty { Type = 76, Value = material.Texture.Key }, new FBXProperty { Type = 83, Value = material.Texture.Name + "::Texture" }, new FBXProperty { Type = 83, Value = "" } } };
                    fbxTexture.Children.Add(new FBXElem { ID = "Type", Properties = { new FBXProperty { Type = 83, Value = "TextureVideoClip" } } });
                    fbxTexture.Children.Add(new FBXElem { ID = "Version", Properties = { new FBXProperty { Type = 73, Value = 202 } } });
                    fbxTexture.Children.Add(new FBXElem { ID = "TextureName", Properties = { new FBXProperty { Type = 83, Value = material.Texture.Name + "::Texture" } } });
                    fbxTexture.Children.Add(new FBXElem { ID = "Media", Properties = { new FBXProperty { Type = 83, Value = material.Texture.Name + "::Video" } } });
                    fbxTexture.Children.Add(new FBXElem { ID = "FileName", Properties = { new FBXProperty { Type = 83, Value = ddsPath } } });
                    fbxTexture.Children.Add(new FBXElem { ID = "RelativeFilename", Properties = { new FBXProperty { Type = 83, Value = Path.GetFileName(ddsPath) } } });
                    fbxTexture.Children.Add(
                        new FBXElem
                        {
                            ID = "Properties70",
                            Children = 
                        { 
                            FBXPropertyElement(FBXPropertyType.Integer, "PremultiplyAlpha", "bool", "", "", 1),
                            FBXPropertyElement(FBXPropertyType.Integer, "CurrentMappingType", "enum", "", "", 6),
                            FBXPropertyElement(FBXPropertyType.Integer, "UseMipMap", "bool", "", "", 0)
                        }
                        }
                    );

                    fbxConnections.Children.Add(FBXConnection("Material", material.Key, "Texture", material.Texture.Key, FBXPropertyType.String, "DiffuseColor"));

                    var fbxVideo = new FBXElem { ID = "Video", Properties = { new FBXProperty { Type = 76, Value = material.Key | material.Texture.Key }, new FBXProperty { Type = 83, Value = material.Texture.Name + "::Video" }, new FBXProperty { Type = 83, Value = "Clip" } } };
                    fbxVideo.Children.Add(new FBXElem { ID = "Type", Properties = { new FBXProperty { Type = 83, Value = "Clip" } } });
                    fbxVideo.Children.Add(
                        new FBXElem
                        {
                            ID = "Properties70",
                            Children = 
                        { 
                            FBXPropertyElement(FBXPropertyType.String, "Path", "KString", "Url", "", ddsPath)
                        }
                        }
                    );
                    fbxVideo.Children.Add(new FBXElem { ID = "UseMipMap", Properties = { new FBXProperty { Type = 73, Value = 0 } } });
                    fbxVideo.Children.Add(new FBXElem { ID = "FileName", Properties = { new FBXProperty { Type = 83, Value = ddsPath } } });
                    fbxVideo.Children.Add(new FBXElem { ID = "RelativeFilename", Properties = { new FBXProperty { Type = 83, Value = Path.GetFileName(ddsPath) } } });
                    fbxVideo.Children.Add(new FBXElem { ID = "Content", Properties = { new FBXProperty { Type = 82, Value = new byte[] { } } } });

                    fbxConnections.Children.Add(FBXConnection("Texture", material.Texture.Key, "Video", material.Key | material.Texture.Key));

                    fbxObjects.Children.Add(fbxTexture);
                    fbxObjects.Children.Add(fbxVideo);
                }

                fbxObjects.Children.Add(fbxMaterial);
            }

            long rootKey = DateTime.Now.Ticks;

            foreach (var mesh in model.Meshes)
            {
                var vects = new List<Vertex>();
                var verts = new List<Vector3>();
                var norms = new List<Vector3>();
                var uvs = new List<Vector2>();

                var ivt = new List<int>();
                var inm = new List<int>();
                var iuv = new List<int>();
                var materials = new List<int>();
                var smoothingGroups = new List<int>();

                int materialIndex = 0;
                int smoothingGroup = 0;

                bool bBlender = false;

                var materialList = mesh.GetMaterials();

                foreach (var part in mesh.MeshParts)
                {
                    int ixvt, ixnm, ixuv;
                    materialIndex = materialList.FindIndex(m => m.Key == part.Material.Key);

                    for (int i = 0; i < part.IndexBuffer.Data.Length; i ++)
                    {
                        int p = part.IndexBuffer.Data[i];
                        var v = part.VertexBuffer.Data[p];

                        if (bBlender)
                        {
                            ixvt = vects.FindIndex(vect => vect.Position.X == v.Position.X &&
                                                           vect.Position.Y == v.Position.Y &&
                                                           vect.Position.Z == v.Position.Z &&
                                                           vect.Normal.X == v.Normal.X &&
                                                           vect.Normal.Y == v.Normal.Y &&
                                                           vect.Normal.Z == v.Normal.Z);

                            if (ixvt == -1)
                            {
                                ixvt = verts.Count;

                                verts.Add(v.Position);
                                norms.Add(v.Normal);
                                vects.Add(v);
                            }

                            ixnm = ixvt;
                        }
                        else
                        {
                            ixvt = verts.FindIndex(vert => vert.X == v.Position.X &&
                                                           vert.Y == v.Position.Y &&
                                                           vert.Z == v.Position.Z);

                            if (ixvt == -1)
                            {
                                ixvt = verts.Count;
                                verts.Add(v.Position);
                            }

                            ixnm = norms.FindIndex(norm => norm.X == v.Normal.X &&
                                                           norm.Y == v.Normal.Y &&
                                                           norm.Z == v.Normal.Z);

                            if (ixnm == -1)
                            {
                                ixnm = norms.Count;
                                norms.Add(v.Normal);
                            }
                        }

                        ixuv = uvs.FindIndex(uv => uv.X == v.UV.X &&
                                                    uv.Y == v.UV.Y);

                        if (ixuv == -1)
                        {
                            ixuv = uvs.Count;
                            uvs.Add(v.UV);
                        }

                        if ((i + 1) % 3 == 0)
                        {
                            smoothingGroups.Add(smoothingGroup);
                            materials.Add(materialIndex);
                            ixvt = (ixvt + 1) * -1;
                        }

                        ivt.Add(ixvt);
                        inm.Add(ixnm);
                        iuv.Add(ixuv);
                    }
                }

                smoothingGroup++;

                var vertvalues = new double[verts.Count * 3];
                for (var i = 0; i < verts.Count; i++)
                {
                    vertvalues[(i * 3) + 0] = verts[i].X;
                    vertvalues[(i * 3) + 1] = verts[i].Y;
                    vertvalues[(i * 3) + 2] = verts[i].Z;
                }

                var normvalues = new double[inm.Count * 3];
                for (var i = 0; i < inm.Count; i++)
                {
                    normvalues[(i * 3) + 0] = norms[inm[i]].X;
                    normvalues[(i * 3) + 1] = norms[inm[i]].Y;
                    normvalues[(i * 3) + 2] = norms[inm[i]].Z;
                }

                var uvvalues = new double[uvs.Count * 2];
                for (var i = 0; i < uvs.Count; i++)
                {
                    uvvalues[(i * 2) + 0] =  uvs[i].X;
                    uvvalues[(i * 2) + 1] = 1 - uvs[i].Y;
                }

                rootKey += verts.Count + 1;

                fbxConnections.Children.Add(FBXConnection("Model", (long)Math.Abs(mesh.Name.GetHashCode()), "Geometry", rootKey));

                var geometry = new FBXElem { ID = "Geometry", Properties = { new FBXProperty { Type = 76, Value = rootKey }, new FBXProperty { Type = 83, Value = "::Geometry" }, new FBXProperty { Type = 83, Value = "Mesh" } } };
                geometry.Children.Add(new FBXElem { ID = "Properties70" });
                geometry.Children.Add(new FBXElem { ID = "GeometryVersion", Properties = { new FBXProperty { Type = 73, Value = 124 } } });
                geometry.Children.Add(new FBXElem { ID = "Vertices", Properties = { new FBXProperty { Type = 100, Value = vertvalues } } });
                geometry.Children.Add(new FBXElem { ID = "PolygonVertexIndex", Properties = { new FBXProperty { Type = 105, Value = ivt.ToArray() } } });
                geometry.Children.Add(
                    new FBXElem
                    {
                        ID = "LayerElementSmoothing",
                        Properties = 
                        { 
                            new FBXProperty { Type = 73, Value = 0 } 
                        },
                        Children = 
                        { 
                            new FBXElem { ID = "Version", Properties = { new FBXProperty { Type = 73, Value = 101 } } },
                            new FBXElem { ID = "Name", Properties = { new FBXProperty { Type = 83, Value = "" } } },
                            new FBXElem { ID = "MappingInformationType", Properties = { new FBXProperty { Type = 83, Value = "ByPolygon" } } },
                            new FBXElem { ID = "ReferenceInformationType", Properties = { new FBXProperty { Type = 83, Value = "Direct" } } },
                            new FBXElem { ID = "Smoothing", Properties = { new FBXProperty { Type = 105, Value = smoothingGroups.ToArray() } } }
                        }
                    }
                );
                geometry.Children.Add(
                    new FBXElem
                    {
                        ID = "LayerElementNormal",
                        Properties = 
                        { 
                            new FBXProperty { Type = 73, Value = 0 } 
                        },
                        Children = 
                        { 
                            new FBXElem { ID = "Version", Properties = { new FBXProperty { Type = 73, Value = 101 } } },
                            new FBXElem { ID = "Name", Properties = { new FBXProperty { Type = 83, Value = "" } } },
                            new FBXElem { ID = "MappingInformationType", Properties = { new FBXProperty { Type = 83, Value = "ByPolygonVertex" } } },
                            new FBXElem { ID = "ReferenceInformationType", Properties = { new FBXProperty { Type = 83, Value = "Direct" } } },
                            new FBXElem { ID = "Normals", Properties = { new FBXProperty { Type = 100, Value = normvalues } } }
                        }
                    }
                );
                geometry.Children.Add(
                    new FBXElem
                    {
                        ID = "LayerElementUV",
                        Properties = 
                        { 
                            new FBXProperty { Type = 73, Value = 0 } 
                        },
                        Children = 
                        { 
                            new FBXElem { ID = "Version", Properties = { new FBXProperty { Type = 73, Value = 101 } } },
                            new FBXElem { ID = "Name", Properties = { new FBXProperty { Type = 83, Value = "" } } },
                            new FBXElem { ID = "MappingInformationType", Properties = { new FBXProperty { Type = 83, Value = "ByPolygonVertex" } } },
                            new FBXElem { ID = "ReferenceInformationType", Properties = { new FBXProperty { Type = 83, Value = "IndexToDirect" } } },
                            new FBXElem { ID = "UV", Properties = { new FBXProperty { Type = 100, Value = uvvalues } } },
                            new FBXElem { ID = "UVIndex", Properties = { new FBXProperty { Type = 105, Value = iuv.ToArray() } } }
                        }
                    }
                );
                geometry.Children.Add(
                    new FBXElem
                    {
                        ID = "LayerElementMaterial",
                        Properties = 
                        { 
                            new FBXProperty { Type = 73, Value = 0 } 
                        },
                        Children = 
                        { 
                            new FBXElem { ID = "Version", Properties = { new FBXProperty { Type = 73, Value = 101 } } },
                            new FBXElem { ID = "Name", Properties = { new FBXProperty { Type = 83, Value = "" } } },
                            new FBXElem { ID = "MappingInformationType", Properties = { new FBXProperty { Type = 83, Value = "ByPolygon" } } },
                            new FBXElem { ID = "ReferenceInformationType", Properties = { new FBXProperty { Type = 83, Value = "IndexToDirect" } } },
                            new FBXElem { ID = "Materials", Properties = { new FBXProperty { Type = 105, Value = materials.ToArray() } } }
                        }
                    }
                );
                geometry.Children.Add(
                    new FBXElem
                    {
                        ID = "Layer",
                        Properties = 
                        { 
                            new FBXProperty { Type = 73, Value = 0 } 
                        },
                        Children = 
                        { 
                            new FBXElem { ID = "Version", 
                                Properties = 
                                {
                                    new FBXProperty { Type = 73, Value = 100 } 
                                } 
                            },
                            new FBXElem { ID = "LayerElement", 
                                Children = 
                                { 
                                    new FBXElem { ID = "Type", Properties = { new FBXProperty { Type = 83, Value = "LayerElementNormal" } } },
                                    new FBXElem { ID = "TypedIndex", Properties = { new FBXProperty { Type = 73, Value = 0 } } }
                                }
                            },
                            new FBXElem { ID = "LayerElement", 
                                Children = 
                                { 
                                    new FBXElem { ID = "Type", Properties = { new FBXProperty { Type = 83, Value = "LayerElementMaterial" } } },
                                    new FBXElem { ID = "TypedIndex", Properties = { new FBXProperty { Type = 73, Value = 0 } } }
                                }
                            },
                            new FBXElem { ID = "LayerElement", 
                                Children = 
                                { 
                                    new FBXElem { ID = "Type", Properties = { new FBXProperty { Type = 83, Value = "LayerElementSmoothing" } } },
                                    new FBXElem { ID = "TypedIndex", Properties = { new FBXProperty { Type = 73, Value = 0 } } }
                                }
                            },
                            new FBXElem { ID = "LayerElement", 
                                Children = 
                                { 
                                    new FBXElem { ID = "Type", Properties = { new FBXProperty { Type = 83, Value = "LayerElementUV" } } },
                                    new FBXElem { ID = "TypedIndex", Properties = { new FBXProperty { Type = 73, Value = 0 } } }
                                }
                            } 
                        }
                    }
                );

                fbxObjects.Children.Add(geometry);
            }

            foreach (var mesh in model.Meshes)
            {
                foreach (var material in mesh.GetMaterials())
                {
                    fbxConnections.Children.Add(FBXConnection("Model", (long)Math.Abs(mesh.Name.GetHashCode()), "Material", material.Key));
                }

                fbxConnections.Children.Add(FBXConnection("Root", (long)0, "Model", (long)Math.Abs(mesh.Name.GetHashCode())));

                fbxObjects.Children.Add(
                    new FBXElem
                    {
                        ID = "Model",
                        Properties = 
                        { 
                            new FBXProperty { Type = 76, Value = (long)Math.Abs(mesh.Name.GetHashCode()) }, 
                            new FBXProperty { Type = 83, Value = mesh.Name + "::Model" }, 
                            new FBXProperty { Type = 83, Value = "Mesh" } 
                        },
                        Children = 
                        { 
                            new FBXElem { ID = "Version", 
                                Properties = 
                                { 
                                    new FBXProperty { Type = 73, Value = 232 } 
                                } 
                            }, 
                            new FBXElem { ID = "Properties70", 
                                Children = 
                                { 
                                    new FBXElem { ID = "P", 
                                        Properties = 
                                        { 
                                            new FBXProperty { Type = 83, Value = "PreRotation" }, 
                                            new FBXProperty { Type = 83, Value = "Vector3D" }, 
                                            new FBXProperty { Type = 83, Value = "Vector" }, 
                                            new FBXProperty { Type = 83, Value = "" }, 
                                            new FBXProperty { Type = 68, Value = (double)0 }, 
                                            new FBXProperty { Type = 68, Value = (double)0 }, 
                                            new FBXProperty { Type = 68, Value = (double)0 } 
                                        } 
                                    },
                                    new FBXElem { ID = "P", 
                                        Properties = 
                                        { 
                                            new FBXProperty { Type = 83, Value = "RotationActive" }, 
                                            new FBXProperty { Type = 83, Value = "bool" }, 
                                            new FBXProperty { Type = 83, Value = "" }, 
                                            new FBXProperty { Type = 83, Value = "" }, 
                                            new FBXProperty { Type = 73, Value = 1 } 
                                        } 
                                    },
                                    new FBXElem { ID = "P", 
                                        Properties = 
                                        { 
                                            new FBXProperty { Type = 83, Value = "InheritType" }, 
                                            new FBXProperty { Type = 83, Value = "enum" }, 
                                            new FBXProperty { Type = 83, Value = "" }, 
                                            new FBXProperty { Type = 83, Value = "" }, 
                                            new FBXProperty { Type = 73, Value = 1 } 
                                        } 
                                    },
                                    new FBXElem { ID = "P", 
                                        Properties = 
                                        { 
                                            new FBXProperty { Type = 83, Value = "ScalingMax" }, 
                                            new FBXProperty { Type = 83, Value = "Vector3D" }, 
                                            new FBXProperty { Type = 83, Value = "Vector" }, 
                                            new FBXProperty { Type = 83, Value = "" }, 
                                            new FBXProperty { Type = 68, Value = (double)0 }, 
                                            new FBXProperty { Type = 68, Value = (double)0 }, 
                                            new FBXProperty { Type = 68, Value = (double)0 } 
                                        } 
                                    },
                                    new FBXElem { ID = "P", 
                                        Properties = 
                                        { 
                                            new FBXProperty { Type = 83, Value = "DefaultAttributeIndex" }, 
                                            new FBXProperty { Type = 83, Value = "int" }, 
                                            new FBXProperty { Type = 83, Value = "Integer" }, 
                                            new FBXProperty { Type = 83, Value = "" }, 
                                            new FBXProperty { Type = 73, Value = 0 } 
                                        } 
                                    } 
                                } 
                            },
                            new FBXElem { ID = "Shading", 
                                Properties = 
                                { 
                                    new FBXProperty { Type = 67, Value = false } 
                                } 
                            },
                            new FBXElem { ID = "Culling", 
                                Properties = 
                                { 
                                    new FBXProperty { Type = 83, Value = "CullingOff" } 
                                } 
                            }
                        }
                    }
                );
            }

            var fbxDefinitions = new FBXElem { ID = "Definitions" };
            fbxDefinitions.Children.Add(new FBXElem { ID = "Version", Properties = { new FBXProperty { Type = 73, Value = 100 } } });
            fbxDefinitions.Children.Add(new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = 1 + fbxObjects.Children.Count } } });
            fbxDefinitions.Children.Add(new FBXElem { ID = "ObjectType", Properties = { new FBXProperty { Type = 83, Value = "GlobalSettings" } }, Children = { new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = 1 } } } } });
            #region Definitions :: AnimationStack
            if (fbxObjects.Children.Any(e => e.ID == "AnimationStack"))
            {
                fbxDefinitions.Children.Add(
                    new FBXElem
                    {
                        ID = "ObjectType",
                        Properties = 
                        { 
                            new FBXProperty { Type = 83, Value = "AnimationStack" } 
                        },
                        Children = 
                        {
                            new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = fbxObjects.Children.Count(e => e.ID == "AnimationStack") } } },
                            new FBXElem { ID = "PropertyTemplate", 
                                Properties = 
                                { 
                                    new FBXProperty { Type = 83, Value = "FbxAnimStack" } 
                                },
                                Children = 
                                {
                                    new FBXElem { ID = "Properties70", 
                                        Children = 
                                        {
                                            FBXPropertyElement(FBXPropertyType.String, "Description", "KString", "", "", ""),
                                            FBXPropertyElement(FBXPropertyType.Long, "LocalStart", "KTime", "Time", "", (long)0),
                                            FBXPropertyElement(FBXPropertyType.Long, "LocalStop", "KTime", "Time", "", (long)0),
                                            FBXPropertyElement(FBXPropertyType.Long, "ReferenceStart", "KTime", "Time", "", (long)0),
                                            FBXPropertyElement(FBXPropertyType.Long, "ReferenceStop", "KTime", "Time", "", (long)0)
                                        }
                                    }
                                }
                            }
                        }
                    }
                );
            }
            #endregion
            #region Definitions :: AnimationLayer
            if (fbxObjects.Children.Any(e => e.ID == "AnimationLayer"))
            {
                fbxDefinitions.Children.Add(
                    new FBXElem
                    {
                        ID = "ObjectType",
                        Properties = 
                        { 
                            new FBXProperty { Type = 83, Value = "AnimationLayer" } 
                        },
                        Children = 
                        {
                            new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = fbxObjects.Children.Count(e => e.ID == "AnimationLayer") } } },
                            new FBXElem { ID = "PropertyTemplate", 
                                Properties = 
                                { 
                                    new FBXProperty { Type = 83, Value = "FbxAnimLayer" } 
                                },
                                Children = 
                                {
                                    new FBXElem { ID = "Properties70", 
                                        Children = 
                                        {
                                            FBXPropertyElement(FBXPropertyType.Double, "Weight", "Number", "", "A", (double)100),
                                            FBXPropertyElement(FBXPropertyType.Integer, "Mute", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "Solo", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "Lock", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Double, "Color", "ColorRGB", "Color", "", (double)0.8, (double)0.8, (double)0.8),
                                            FBXPropertyElement(FBXPropertyType.Integer, "BlendMode", "enum", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "RotationAccumulationMode", "enum", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "ScaleAccumulationMode", "enum", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Long, "BlendModeBypass", "ULongLong", "", "", (long)0)
                                        }
                                    }
                                }
                            }
                        }
                    }
                );
            }
            #endregion
            #region Definitions :: NodeAttribute
            if (fbxObjects.Children.Any(e => e.ID == "NodeAttribute"))
            {
                fbxDefinitions.Children.Add(
                    new FBXElem
                    {
                        ID = "ObjectType",
                        Properties = 
                        { 
                            new FBXProperty { Type = 83, Value = "NodeAttribute" } 
                        },
                        Children = 
                        {
                            new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = fbxObjects.Children.Count(e => e.ID == "NodeAttribute") } } },
                            new FBXElem { ID = "PropertyTemplate", 
                                Properties = 
                                { 
                                    new FBXProperty { Type = 83, Value = "FbxNull" } 
                                },
                                Children = 
                                {
                                    new FBXElem { ID = "Properties70", 
                                        Children = 
                                        {
                                            FBXPropertyElement(FBXPropertyType.Double, "Color", "ColorRGB", "Color", "", (double)0.8, (double)0.8, (double)0.8),
                                            FBXPropertyElement(FBXPropertyType.Double, "Size", "double", "Number", "", (double)100),
                                            FBXPropertyElement(FBXPropertyType.Integer, "Look", "enum", "", "", 1)
                                        }
                                    }
                                }
                            }
                        }
                    }
                );
            }
            #endregion
            #region Definitions :: Model
            if (fbxObjects.Children.Any(e => e.ID == "Model"))
            {
                fbxDefinitions.Children.Add(
                    new FBXElem { ID = "ObjectType", 
                        Properties = 
                        { 
                            new FBXProperty { Type = 83, Value = "Model" } 
                        },
                        Children = 
                        {
                            // MODEL COUNT
                            new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = fbxObjects.Children.Count(e => e.ID == "Model") } } },
                            new FBXElem { ID = "PropertyTemplate", 
                                Properties = 
                                { 
                                    new FBXProperty { Type = 83, Value = "FbxNode" } 
                                },
                                Children = 
                                {
                                    new FBXElem { ID = "Properties70", 
                                        Children = 
                                        {
                                            FBXPropertyElement(FBXPropertyType.Integer, "QuaternionInterpolate", "enum", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Double, "RotationOffset", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "RotationPivot", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "ScalingOffset", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "ScalingPivot", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "TranslationActive", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Double, "TranslationMin", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "TranslationMax", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "TranslationMinX", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "TranslationMinY", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "TranslationMinZ", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "TranslationMaxX", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "TranslationMaxY", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "TranslationMaxZ", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "RotationOrder", "enum", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "RotationSpaceForLimitOnly", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Double, "RotationStiffnessX", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "RotationStiffnessY", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "RotationStiffnessZ", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "AxisLen", "double", "Number", "", (double)10),
                                            FBXPropertyElement(FBXPropertyType.Double, "PreRotation", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "PostRotation", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "RotationActive", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Double, "RotationMin", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "RotationMax", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "RotationMinX", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "RotationMinY", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "RotationMinZ", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "RotationMaxX", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "RotationMaxY", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "RotationMaxZ", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "InheritType", "enum", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "ScalingActive", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Double, "ScalingMin", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "ScalingMax", "Vector3D", "Vector", "", (double)1, (double)1, (double)1),
                                            FBXPropertyElement(FBXPropertyType.Integer, "ScalingMinX", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "ScalingMinY", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "ScalingMinZ", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "ScalingMaxX", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "ScalingMaxY", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "ScalingMaxZ", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Double, "GeometricTranslation", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "GeometricRotation", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "GeometricScaling", "Vector3D", "Vector", "", (double)1, (double)1, (double)1),
                                            FBXPropertyElement(FBXPropertyType.Double, "MinDampRangeX", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "MinDampRangeY", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "MinDampRangeZ", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "MaxDampRangeX", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "MaxDampRangeY", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "MaxDampRangeZ", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "MinDampStrengthX", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "MinDampStrengthY", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "MinDampStrengthZ", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "MaxDampStrengthX", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "MaxDampStrengthY", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "MaxDampStrengthZ", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "PreferedAngleX", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "PreferedAngleY", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "PreferedAngleZ", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "LookAtProperty", "object", "", ""),
                                            FBXPropertyElement(FBXPropertyType.Integer, "UpVectorProperty", "object", "", ""),
                                            FBXPropertyElement(FBXPropertyType.Integer, "Show", "bool", "", "", 1),
                                            FBXPropertyElement(FBXPropertyType.Integer, "NegativePercentShapeSupport", "bool", "", "", 1),
                                            FBXPropertyElement(FBXPropertyType.Integer, "DefaultAttributeIndex", "int", "Integer", "", -1),
                                            FBXPropertyElement(FBXPropertyType.Integer, "Freeze", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "LODBox", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Double, "Lcl Translation", "Lcl Translation", "", "A", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "Lcl Rotation", "Lcl Rotation", "", "A", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "Lcl Scaling", "Lcl Scaling", "", "A", (double)1, (double)1, (double)1),
                                            FBXPropertyElement(FBXPropertyType.Double, "Visibility", "Visibility", "", "A", (double)1),
                                            FBXPropertyElement(FBXPropertyType.Integer, "Visibility Inheritance", "Visibility Inheritance", "", "", 1)
                                        }
                                    }
                                }
                            }
                        }
                    }
                );
            }
            #endregion
            #region Definitions :: Material
            if (fbxObjects.Children.Any(e => e.ID == "Material"))
            {
                fbxDefinitions.Children.Add(
                    new FBXElem { ID = "ObjectType", 
                        Properties = 
                        { 
                            new FBXProperty { Type = 83, Value = "Material" } 
                        },
                        Children = 
                        {
                            new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = fbxObjects.Children.Count(e => e.ID == "Material") } } },
                            new FBXElem { ID = "PropertyTemplate", 
                                Properties = 
                                { 
                                    new FBXProperty { Type = 83, Value = "FbxSurfacePhong" } 
                                },
                                Children = 
                                {
                                    new FBXElem { ID = "Properties70", 
                                        Children = 
                                        {
                                            FBXPropertyElement(FBXPropertyType.String, "ShadingModel", "KString", "", "", "Phong"),
                                            FBXPropertyElement(FBXPropertyType.Integer, "MultiLayer", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Double, "EmissiveColor", "Color", "", "A", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "EmissiveFactor", "Number", "", "A", (double)1),
                                            FBXPropertyElement(FBXPropertyType.Double, "AmbientColor", "Color", "", "A", (double)0.2, (double)0.2, (double)0.2),
                                            FBXPropertyElement(FBXPropertyType.Double, "AmbientFactor", "Number", "", "A", (double)1),
                                            FBXPropertyElement(FBXPropertyType.Double, "DiffuseColor", "Color", "", "A", (double)0.8, (double)0.8, (double)0.8),
                                            FBXPropertyElement(FBXPropertyType.Double, "DiffuseFactor", "Number", "", "A", (double)1),
                                            FBXPropertyElement(FBXPropertyType.Double, "Bump", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "NormalMap", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "BumpFactor", "double", "Number", "", (double)1),
                                            FBXPropertyElement(FBXPropertyType.Double, "TransparentColor", "Color", "", "A", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "TransparencyFactor", "Number", "", "A", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "DisplacementColor", "ColorRGB", "Color", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "DisplacementFactor", "double", "Number", "", (double)1),
                                            FBXPropertyElement(FBXPropertyType.Double, "VectorDisplacementColor", "ColorRGB", "Color", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "VectorDisplacementFactor", "double", "Number", "", (double)1),
                                            FBXPropertyElement(FBXPropertyType.Double, "SpecularColor", "Color", "", "A", (double)0.2, (double)0.2, (double)0.2),
                                            FBXPropertyElement(FBXPropertyType.Double, "SpecularFactor", "Number", "", "A", (double)1),
                                            FBXPropertyElement(FBXPropertyType.Double, "ShininessExponent", "Number", "", "A", (double)20),
                                            FBXPropertyElement(FBXPropertyType.Double, "ReflectionColor", "Color", "", "A", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "ReflectionFactor", "Number", "", "A", (double)1)
                                        }
                                    }
                                }
                            }
                        }
                    }
                );
            }
            #endregion
            #region Definitions :: Geometry
            if (fbxObjects.Children.Any(e => e.ID == "Geometry"))
            {
                fbxDefinitions.Children.Add(
                    new FBXElem { ID = "ObjectType", 
                        Properties = 
                        { 
                            new FBXProperty { Type = 83, Value = "Geometry" } 
                        },
                        Children = 
                        {
                            new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = fbxObjects.Children.Count(e => e.ID == "Geometry") } } },
                            new FBXElem { ID = "PropertyTemplate", 
                                Properties = 
                                { 
                                    new FBXProperty { Type = 83, Value = "FbxMesh" } 
                                },
                                Children = 
                                {
                                    new FBXElem { ID = "Properties70", 
                                        Children = 
                                        {
                                            FBXPropertyElement(FBXPropertyType.Double, "Color", "ColorRGB", "Color", "", (double)0.8, (double)0.8, (double)0.8),
                                            FBXPropertyElement(FBXPropertyType.Double, "BBoxMin", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "BBoxMax", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "Primary Visibility", "bool", "", "", 1),
                                            FBXPropertyElement(FBXPropertyType.Integer, "Casts Shadows", "bool", "", "", 1),
                                            FBXPropertyElement(FBXPropertyType.Integer, "Receive Shadows", "bool", "", "", 1)
                                        }
                                    }
                                }
                            }
                        }
                    }
                );
            }
            #endregion
            #region Definitions :: Texture
            if (fbxObjects.Children.Any(e => e.ID == "Texture"))
            {
                fbxDefinitions.Children.Add(
                    new FBXElem
                    {
                        ID = "ObjectType",
                        Properties = 
                        { 
                            new FBXProperty { Type = 83, Value = "Texture" } 
                        },
                        Children = 
                        {
                            new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = fbxObjects.Children.Count(e => e.ID == "Texture") } } },
                            new FBXElem { ID = "PropertyTemplate", 
                                Properties = 
                                { 
                                    new FBXProperty { Type = 83, Value = "FbxFileTexture" } 
                                },
                                Children = 
                                {
                                    new FBXElem { ID = "Properties70", 
                                        Children = 
                                        {
                                            FBXPropertyElement(FBXPropertyType.Integer, "TextureTypeUse", "enum", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Double, "Texture alpha", "Number", "", "A", (double)1),
                                            FBXPropertyElement(FBXPropertyType.Integer, "CurrentMappingType", "enum", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "WrapModeU", "enum", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "WrapModeV", "enum", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "UVSwap", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "PremultiplyAlpha", "bool", "", "", 1),
                                            FBXPropertyElement(FBXPropertyType.Double, "Translation", "Vector", "", "A", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "Rotation", "Vector", "", "A", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "Scaling", "Vector", "", "A", (double)1, (double)1, (double)1),
                                            FBXPropertyElement(FBXPropertyType.Double, "TextureRotationPivot", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Double, "TextureScalingPivot", "Vector3D", "Vector", "", (double)0, (double)0, (double)0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "CurrentTextureBlendMode", "enum", "", "", 1),
                                            FBXPropertyElement(FBXPropertyType.String, "UVSet", "KString", "", "", "default"),
                                            FBXPropertyElement(FBXPropertyType.Integer, "UseMaterial", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "UseMipMap", "bool", "", "", 0)
                                        }
                                    }
                                }
                            }
                        }
                    }
                );
            }
            #endregion
            #region Definitions :: CollectionExclusive
            if (fbxObjects.Children.Any(e => e.ID == "CollectionExclusive"))
            {
                fbxDefinitions.Children.Add(
                    new FBXElem
                    {
                        ID = "ObjectType",
                        Properties = 
                        { 
                            new FBXProperty { Type = 83, Value = "CollectionExclusive" } 
                        },
                        Children = 
                        {
                            new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = fbxObjects.Children.Count(e => e.ID == "CollectionExclusive") } } },
                            new FBXElem { ID = "PropertyTemplate", 
                                Properties = 
                                { 
                                    new FBXProperty { Type = 83, Value = "FbxDisplayLayer" } 
                                },
                                Children = 
                                {
                                    new FBXElem { ID = "Properties70", 
                                        Children = 
                                        {
                                            FBXPropertyElement(FBXPropertyType.Double, "Color", "ColorRGB", "Color", "", (double)0.8, (double)0.8, (double)0.8),
                                            FBXPropertyElement(FBXPropertyType.Integer, "Show", "bool", "", "", 1),
                                            FBXPropertyElement(FBXPropertyType.Integer, "Freeze", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "LODBox", "bool", "", "", 0)
                                        }
                                    }
                                }
                            }
                        }
                    }
                );
            }
            #endregion
            #region Definitions :: Video
            if (fbxObjects.Children.Any(e => e.ID == "Video"))
            {
                fbxDefinitions.Children.Add(
                    new FBXElem
                    {
                        ID = "ObjectType",
                        Properties = 
                        { 
                            new FBXProperty { Type = 83, Value = "Video" } 
                        },
                        Children = 
                        {
                            new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = fbxObjects.Children.Count(e => e.ID == "Video") } } },
                            new FBXElem { ID = "PropertyTemplate", 
                                Properties = 
                                { 
                                    new FBXProperty { Type = 83, Value = "FbxVideo" } 
                                },
                                Children = 
                                {
                                    new FBXElem { ID = "Properties70", 
                                        Children = 
                                        {
                                            FBXPropertyElement(FBXPropertyType.Integer, "ImageSequence", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "ImageSequenceOffset", "int", "Integer", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Double, "FrameRate", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "LastFrame", "int", "Integer", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "Width", "int", "Integer", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "Height", "int", "Integer", "", 0),
                                            FBXPropertyElement(FBXPropertyType.String, "Path", "KString", "XRefUrl", "", ""),
                                            FBXPropertyElement(FBXPropertyType.Integer, "StartFrame", "int", "Integer", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "StopFrame", "int", "Integer", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Double, "PlaySpeed", "double", "Number", "", (double)0),
                                            FBXPropertyElement(FBXPropertyType.Long, "Offset", "KTime", "Time", "", (long)0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "InterlaceMode", "enum", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "FreeRunning", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "Loop", "bool", "", "", 0),
                                            FBXPropertyElement(FBXPropertyType.Integer, "AccessMode", "enum", "", "", 0)
                                        }
                                    }
                                }
                            }
                        }
                    }
                );
            }
            #endregion

            fbx.Elements.Add(fbxDefinitions);
            fbx.Elements.Add(fbxObjects);

            //// HARDCODED MODEL TO SCENE
            //fbxConnections.Children.Add(
            //    new FBXElem
            //    {
            //        ID = "C",
            //        Properties = 
            //        {  
            //            new FBXProperty { Type = 83, Value = "OO" },
            //            new FBXProperty { Type = 76, Value = (long)1037079952 },
            //            new FBXProperty { Type = 76, Value = (long)0 }
            //        }
            //    }
            //);

            //// HARDCODED GEOMETRY TO MODEL
            //fbxConnections.Children.Add(
            //    new FBXElem
            //    {
            //        ID = "C",
            //        Properties = 
            //        {  
            //            new FBXProperty { Type = 83, Value = "OO" },
            //            new FBXProperty { Type = 76, Value = (long)1033522512 },
            //            new FBXProperty { Type = 76, Value = (long)1037079952 }
            //        }
            //    }
            //);

            //foreach (var child in fbxObjects.Children)
            //{
            //    if (child.ID == "Material")
            //    {
            //        fbxConnections.Children.Add(
            //            new FBXElem
            //            {
            //                ID = "C",
            //                Properties = 
            //                {  
            //                    new FBXProperty { Type = 83, Value = "OO" },
            //                    new FBXProperty { Type = 76, Value = (long)child.Properties[0].Value },
            //                    new FBXProperty { Type = 76, Value = (long)1037079952 }
            //                }
            //            }
            //        );
            //    }
            //}

            fbx.Elements.Add(fbxConnections);

            fbx.Save(path);
        }

        public enum FBXPropertyType : byte
        {
            Double = 68,
            Integer = 73,
            Long = 76,
            String = 83
        }

        public static FBXElem FBXPropertyElement(FBXPropertyType PropertyType, string Name, string A, string B, string C)
        {
            return new FBXElem
            {
                ID = "P",
                Properties = 
                    {  
                        new FBXProperty { Type = 83, Value = Name },
                        new FBXProperty { Type = 83, Value = A },
                        new FBXProperty { Type = 83, Value = B },
                        new FBXProperty { Type = 83, Value = C }
                    }
            };
        }

        public static FBXElem FBXPropertyElement(FBXPropertyType PropertyType, string Name, string A, string B, string C, object PropertyValue)
        {
            return new FBXElem
            {
                ID = "P",
                Properties = 
                    {  
                        new FBXProperty { Type = 83, Value = Name },
                        new FBXProperty { Type = 83, Value = A },
                        new FBXProperty { Type = 83, Value = B },
                        new FBXProperty { Type = 83, Value = C },
                        new FBXProperty { Type = (byte)PropertyType, Value = PropertyValue }
                    }
            };
        }

        public static FBXElem FBXPropertyElement(FBXPropertyType PropertyType, string Name, string A, string B, string C, object PVA, object PVB, object PVC)
        {
            return new FBXElem
            {
                ID = "P",
                Properties = 
                    {  
                        new FBXProperty { Type = 83, Value = Name },
                        new FBXProperty { Type = 83, Value = A },
                        new FBXProperty { Type = 83, Value = B },
                        new FBXProperty { Type = 83, Value = C },
                        new FBXProperty { Type = (byte)PropertyType, Value = PVA },
                        new FBXProperty { Type = (byte)PropertyType, Value = PVB },
                        new FBXProperty { Type = (byte)PropertyType, Value = PVC }
                    }
            };
        }

        public static FBXElem FBXConnection(string parentType, long parent, string childType, long child)
        {
            Console.WriteLine("Connecting {0} {1} to {2} {3}", childType, child, parentType, parent);
            return new FBXElem
            {
                ID = "C",
                Properties = 
                {  
                    new FBXProperty { Type = 83, Value = "OO" },
                    new FBXProperty { Type = 76, Value = child },
                    new FBXProperty { Type = 76, Value = parent }
                }
            };
        }

        public static FBXElem FBXConnection(string parentType, long parent, string childType, long child, FBXPropertyType propertyType, string propertyName)
        {
            Console.WriteLine("Connecting {0} {1} to {2}.{4} {3}", childType, child, parentType, parent, propertyName);
            return new FBXElem
            {
                ID = "C",
                Properties = 
                {  
                    new FBXProperty { Type = 83, Value = "OP" },
                    new FBXProperty { Type = 76, Value = child },
                    new FBXProperty { Type = 76, Value = parent },
                    new FBXProperty { Type = (byte)propertyType, Value = propertyName },
                }
            };
        }
    }
}
