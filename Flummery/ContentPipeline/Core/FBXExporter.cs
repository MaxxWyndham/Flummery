using System;
using System.Collections.Generic;
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
                                new FBXElem { ID = "Year", Properties = { new FBXProperty { Type = 73, Value = 2014 } } },
                                new FBXElem { ID = "Month", Properties = { new FBXProperty { Type = 73, Value = 5 } } },
                                new FBXElem { ID = "Day", Properties = { new FBXProperty { Type = 73, Value = 31 } } },
                                new FBXElem { ID = "Hour", Properties = { new FBXProperty { Type = 73, Value = 17 } } },
                                new FBXElem { ID = "Minute", Properties = { new FBXProperty { Type = 73, Value = 28 } } },
                                new FBXElem { ID = "Second", Properties = { new FBXProperty { Type = 73, Value = 14 } } },
                                new FBXElem { ID = "Millisecond", Properties = { new FBXProperty { Type = 73, Value = 839 } } }
                            }
                        },
                        new FBXElem { ID = "Creator", Properties = { new FBXProperty { Type = 83, Value = "FBX SDK/FBX Plugins version 2014.0.1" } } },
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
                                        new FBXElem { ID = "P", 
                                            Properties = 
                                            {  
                                                new FBXProperty { Type = 83, Value = "DocumentUrl" },
                                                new FBXProperty { Type = 83, Value = "KString" },
                                                new FBXProperty { Type = 83, Value = "Url" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "C:\\Users\\User\\Documents\\3dsMax\\export\\HoverCountslash3.FBX" }
                                            }
                                        },
                                        new FBXElem { ID = "P", 
                                            Properties = 
                                            {  
                                                new FBXProperty { Type = 83, Value = "SrcDocumentUrl" },
                                                new FBXProperty { Type = 83, Value = "KString" },
                                                new FBXProperty { Type = 83, Value = "Url" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "C:\\Users\\User\\Documents\\3dsMax\\export\\HoverCountslash3.FBX" }
                                            }
                                        },
                                        new FBXElem { ID = "P", 
                                            Properties = 
                                            {  
                                                new FBXProperty { Type = 83, Value = "Original" },
                                                new FBXProperty { Type = 83, Value = "Compound" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "" }
                                            }
                                        },
                                        new FBXElem { ID = "P", 
                                            Properties = 
                                            {  
                                                new FBXProperty { Type = 83, Value = "Original|ApplicationVendor" },
                                                new FBXProperty { Type = 83, Value = "KString" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "Autodesk" }
                                            }
                                        },
                                        new FBXElem { ID = "P", 
                                            Properties = 
                                            {  
                                                new FBXProperty { Type = 83, Value = "Original|ApplicationName" },
                                                new FBXProperty { Type = 83, Value = "KString" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "3ds Max" }
                                            }
                                        },
                                        new FBXElem { ID = "P", 
                                            Properties = 
                                            {  
                                                new FBXProperty { Type = 83, Value = "Original|ApplicationVersion" },
                                                new FBXProperty { Type = 83, Value = "KString" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "2014" }
                                            }
                                        },
                                        new FBXElem { ID = "P", 
                                            Properties = 
                                            {  
                                                new FBXProperty { Type = 83, Value = "Original|DateTime_GMT" },
                                                new FBXProperty { Type = 83, Value = "DateTime" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "31/05/2014 16:28:14.839" }
                                            }
                                        },
                                        new FBXElem { ID = "P", 
                                            Properties = 
                                            {  
                                                new FBXProperty { Type = 83, Value = "Original|FileName" },
                                                new FBXProperty { Type = 83, Value = "KString" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "C:\\Users\\User\\Documents\\3dsMax\\export\\HoverCountslash3.FBX" }
                                            }
                                        },
                                        new FBXElem { ID = "P", 
                                            Properties = 
                                            {  
                                                new FBXProperty { Type = 83, Value = "LastSaved" },
                                                new FBXProperty { Type = 83, Value = "Compound" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "" }
                                            }
                                        },
                                        new FBXElem { ID = "P", 
                                            Properties = 
                                            {  
                                                new FBXProperty { Type = 83, Value = "LastSaved|ApplicationVendor" },
                                                new FBXProperty { Type = 83, Value = "KString" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "Autodesk" }
                                            }
                                        },
                                        new FBXElem { ID = "P", 
                                            Properties = 
                                            {  
                                                new FBXProperty { Type = 83, Value = "LastSaved|ApplicationName" },
                                                new FBXProperty { Type = 83, Value = "KString" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "3ds Max" }
                                            }
                                        },
                                        new FBXElem { ID = "P", 
                                            Properties = 
                                            {  
                                                new FBXProperty { Type = 83, Value = "LastSaved|ApplicationVersion" },
                                                new FBXProperty { Type = 83, Value = "KString" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "2014" }
                                            }
                                        },
                                        new FBXElem { ID = "P", 
                                            Properties = 
                                            {  
                                                new FBXProperty { Type = 83, Value = "LastSaved|DateTime_GMT" },
                                                new FBXProperty { Type = 83, Value = "DateTime" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "31/05/2014 16:28:14.839" }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            );

            fbx.Elements.Add(new FBXElem { ID = "FileId", Properties = { new FBXProperty { Type = 82, Value = new byte[] { 41, 182, 47, 234, 183, 34, 201, 199, 178, 198, 189, 46, 171, 45, 248, 253 } } } });
            fbx.Elements.Add(new FBXElem { ID = "CreationTime", Properties = { new FBXProperty { Type = 83, Value = "2014-05-31 17:28:14:839" } } });
            fbx.Elements.Add(new FBXElem { ID = "Creator", Properties = { new FBXProperty { Type = 83, Value = "FBX SDK/FBX Plugins version 2014.0.1 build=20130205" } } });

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
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "UpAxis" },
                                        new FBXProperty { Type = 83, Value = "int" },
                                        new FBXProperty { Type = 83, Value = "Integer" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 73, Value = 1 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "UpAxisSign" },
                                        new FBXProperty { Type = 83, Value = "int" },
                                        new FBXProperty { Type = 83, Value = "Integer" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 73, Value = 1 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "FrontAxis" },
                                        new FBXProperty { Type = 83, Value = "int" },
                                        new FBXProperty { Type = 83, Value = "Integer" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 73, Value = 2 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "FrontAxisSign" },
                                        new FBXProperty { Type = 83, Value = "int" },
                                        new FBXProperty { Type = 83, Value = "Integer" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 73, Value = 1 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "CoordAxis" },
                                        new FBXProperty { Type = 83, Value = "int" },
                                        new FBXProperty { Type = 83, Value = "Integer" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 73, Value = 0 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "CoordAxisSign" },
                                        new FBXProperty { Type = 83, Value = "int" },
                                        new FBXProperty { Type = 83, Value = "Integer" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 73, Value = 1 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "OriginalUpAxis" },
                                        new FBXProperty { Type = 83, Value = "int" },
                                        new FBXProperty { Type = 83, Value = "Integer" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 73, Value = 2 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "OriginalUpAxisSign" },
                                        new FBXProperty { Type = 83, Value = "int" },
                                        new FBXProperty { Type = 83, Value = "Integer" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 73, Value = 1 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "UnitScaleFactor" },
                                        new FBXProperty { Type = 83, Value = "double" },
                                        new FBXProperty { Type = 83, Value = "Number" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 68, Value = (double)2.54 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "OriginalUnitScaleFactor" },
                                        new FBXProperty { Type = 83, Value = "double" },
                                        new FBXProperty { Type = 83, Value = "Number" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 68, Value = (double)2.54 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "AmbientColor" },
                                        new FBXProperty { Type = 83, Value = "ColorRGB" },
                                        new FBXProperty { Type = 83, Value = "Color" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 68, Value = (double)0.0 },
                                        new FBXProperty { Type = 68, Value = (double)0.0 },
                                        new FBXProperty { Type = 68, Value = (double)0.0 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "DefaultCamera" },
                                        new FBXProperty { Type = 83, Value = "KString" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 83, Value = "Producer Front" }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "TimeMode" },
                                        new FBXProperty { Type = 83, Value = "enum" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 73, Value = 6 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "TimeProtocol" },
                                        new FBXProperty { Type = 83, Value = "enum" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 73, Value = 2 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "SnapOnFrameMode" },
                                        new FBXProperty { Type = 83, Value = "enum" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 73, Value = 0 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "TimeSpanStart" },
                                        new FBXProperty { Type = 83, Value = "KTime" },
                                        new FBXProperty { Type = 83, Value = "Time" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 76, Value = (long)0 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "TimeSpanStop" },
                                        new FBXProperty { Type = 83, Value = "KTime" },
                                        new FBXProperty { Type = 83, Value = "Time" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 76, Value = (long)153953860000 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "CustomFrameRate" },
                                        new FBXProperty { Type = 83, Value = "double" },
                                        new FBXProperty { Type = 83, Value = "Number" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 68, Value = (double)(-1.0) }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "TimeMarker" },
                                        new FBXProperty { Type = 83, Value = "Compound" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 83, Value = "" }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "CurrentTimeMarker" },
                                        new FBXProperty { Type = 83, Value = "int" },
                                        new FBXProperty { Type = 83, Value = "Integer" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 73, Value = -1 }
                                    }
                                }
                            }
                        }
                    }
                }
            );

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
                                new FBXProperty { Type = 76, Value = (long)432026112 },
                                new FBXProperty { Type = 83, Value = "" },
                                new FBXProperty { Type = 83, Value = "Scene" }
                            },
                            Children = 
                            {
                                new FBXElem { ID = "Properties70", 
                                    Children = 
                                    {
                                        new FBXElem { ID = "P", 
                                            Properties = 
                                            {  
                                                new FBXProperty { Type = 83, Value = "SourceObject" },
                                                new FBXProperty { Type = 83, Value = "object" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "" }
                                            }
                                        },
                                        new FBXElem { ID = "P", 
                                            Properties = 
                                            {  
                                                new FBXProperty { Type = 83, Value = "ActiveAnimStackName" },
                                                new FBXProperty { Type = 83, Value = "KString" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "" },
                                                new FBXProperty { Type = 83, Value = "" }
                                            }
                                        }
                                    }
                                },
                                new FBXElem { ID = "RootNode", Properties = { new FBXProperty { Type = 76, Value = (long)0 } } }
                            }
                        }
                    }
                }
            );

            fbx.Elements.Add(new FBXElem { ID = "References" });

            fbx.Elements.Add(
                new FBXElem
                {
                    ID = "Definitions",
                    Children =
                    {
                        new FBXElem { ID = "Version", Properties = { new FBXProperty { Type = 73, Value = 100 } } },
                        new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = 93 } } },
                        new FBXElem { ID = "ObjectType", 
                            Properties = 
                            { 
                                new FBXProperty { Type = 83, Value = "GlobalSettings" } 
                            },
                            Children = 
                            {
                                new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = 1 } } }
                            }
                        },
                        new FBXElem { ID = "ObjectType", 
                            Properties = 
                            { 
                                new FBXProperty { Type = 83, Value = "AnimationStack" } 
                            },
                            Children = 
                            {
                                new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = 1 } } },
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
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Description" },
                                                        new FBXProperty { Type = 83, Value = "KString" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "LocalStart" },
                                                        new FBXProperty { Type = 83, Value = "KTime" },
                                                        new FBXProperty { Type = 83, Value = "Time" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 76, Value = (long)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "LocalStop" },
                                                        new FBXProperty { Type = 83, Value = "KTime" },
                                                        new FBXProperty { Type = 83, Value = "Time" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 76, Value = (long)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ReferenceStart" },
                                                        new FBXProperty { Type = 83, Value = "KTime" },
                                                        new FBXProperty { Type = 83, Value = "Time" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 76, Value = (long)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ReferenceStop" },
                                                        new FBXProperty { Type = 83, Value = "KTime" },
                                                        new FBXProperty { Type = 83, Value = "Time" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 76, Value = (long)0 }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new FBXElem { ID = "ObjectType", 
                            Properties = 
                            { 
                                new FBXProperty { Type = 83, Value = "AnimationLayer" } 
                            },
                            Children = 
                            {
                                new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = 1 } } },
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
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Weight" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)100 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Mute" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Solo" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Lock" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "ColorRGB" },
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0.8 },
                                                        new FBXProperty { Type = 68, Value = (double)0.8 },
                                                        new FBXProperty { Type = 68, Value = (double)0.8 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "BlendMode" },
                                                        new FBXProperty { Type = 83, Value = "enum" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "RotationAccumulationMode" },
                                                        new FBXProperty { Type = 83, Value = "enum" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ScaleAccumulationMode" },
                                                        new FBXProperty { Type = 83, Value = "enum" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "BlendModeBypass" },
                                                        new FBXProperty { Type = 83, Value = "ULongLong" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 76, Value = (long)0 }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new FBXElem { ID = "ObjectType", 
                            Properties = 
                            { 
                                new FBXProperty { Type = 83, Value = "Model" } 
                            },
                            Children = 
                            {
                                new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = 12 } } },
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
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "QuaternionInterpolate" },
                                                        new FBXProperty { Type = 83, Value = "enum" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "RotationOffset" },
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
                                                        new FBXProperty { Type = 83, Value = "RotationPivot" },
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
                                                        new FBXProperty { Type = 83, Value = "ScalingOffset" },
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
                                                        new FBXProperty { Type = 83, Value = "ScalingPivot" },
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
                                                        new FBXProperty { Type = 83, Value = "TranslationActive" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "TranslationMin" },
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
                                                        new FBXProperty { Type = 83, Value = "TranslationMax" },
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
                                                        new FBXProperty { Type = 83, Value = "TranslationMinX" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "TranslationMinY" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "TranslationMinZ" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "TranslationMaxX" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "TranslationMaxY" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "TranslationMaxZ" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "RotationOrder" },
                                                        new FBXProperty { Type = 83, Value = "enum" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "RotationSpaceForLimitOnly" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "RotationStiffnessX" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "RotationStiffnessY" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "RotationStiffnessZ" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "AxisLen" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)10 }
                                                    }
                                                },
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
                                                        new FBXProperty { Type = 83, Value = "PostRotation" },
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
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "RotationMin" },
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
                                                        new FBXProperty { Type = 83, Value = "RotationMax" },
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
                                                        new FBXProperty { Type = 83, Value = "RotationMinX" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "RotationMinY" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "RotationMinZ" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "RotationMaxX" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "RotationMaxY" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "RotationMaxZ" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "InheritType" },
                                                        new FBXProperty { Type = 83, Value = "enum" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ScalingActive" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ScalingMin" },
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
                                                        new FBXProperty { Type = 83, Value = "ScalingMax" },
                                                        new FBXProperty { Type = 83, Value = "Vector3D" },
                                                        new FBXProperty { Type = 83, Value = "Vector" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)1 },
                                                        new FBXProperty { Type = 68, Value = (double)1 },
                                                        new FBXProperty { Type = 68, Value = (double)1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ScalingMinX" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ScalingMinY" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ScalingMinZ" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ScalingMaxX" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ScalingMaxY" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ScalingMaxZ" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "GeometricTranslation" },
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
                                                        new FBXProperty { Type = 83, Value = "GeometricRotation" },
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
                                                        new FBXProperty { Type = 83, Value = "GeometricScaling" },
                                                        new FBXProperty { Type = 83, Value = "Vector3D" },
                                                        new FBXProperty { Type = 83, Value = "Vector" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)1 },
                                                        new FBXProperty { Type = 68, Value = (double)1 },
                                                        new FBXProperty { Type = 68, Value = (double)1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "MinDampRangeX" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "MinDampRangeY" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "MinDampRangeZ" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "MaxDampRangeX" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "MaxDampRangeY" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "MaxDampRangeZ" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "MinDampStrengthX" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "MinDampStrengthY" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "MinDampStrengthZ" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "MaxDampStrengthX" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "MaxDampStrengthY" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "MaxDampStrengthZ" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "PreferedAngleX" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "PreferedAngleY" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "PreferedAngleZ" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "LookAtProperty" },
                                                        new FBXProperty { Type = 83, Value = "object" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "UpVectorProperty" },
                                                        new FBXProperty { Type = 83, Value = "object" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Show" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "NegativePercentShapeSupport" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "DefaultAttributeIndex" },
                                                        new FBXProperty { Type = 83, Value = "int" },
                                                        new FBXProperty { Type = 83, Value = "Integer" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = -1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Freeze" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "LODBox" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Lcl Translation" },
                                                        new FBXProperty { Type = 83, Value = "Lcl Translation" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Lcl Rotation" },
                                                        new FBXProperty { Type = 83, Value = "Lcl Rotation" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Lcl Scaling" },
                                                        new FBXProperty { Type = 83, Value = "Lcl Scaling" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)1 },
                                                        new FBXProperty { Type = 68, Value = (double)1 },
                                                        new FBXProperty { Type = 68, Value = (double)1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Visibility" },
                                                        new FBXProperty { Type = 83, Value = "Visibility" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Visibility Inheritance" },
                                                        new FBXProperty { Type = 83, Value = "Visibility Inheritance" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 1 }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new FBXElem { ID = "ObjectType", 
                            Properties = 
                            { 
                                new FBXProperty { Type = 83, Value = "Geometry" } 
                            },
                            Children = 
                            {
                                new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = 8 } } },
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
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "ColorRGB" },
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0.8 },
                                                        new FBXProperty { Type = 68, Value = (double)0.8 },
                                                        new FBXProperty { Type = 68, Value = (double)0.8 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "BBoxMin" },
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
                                                        new FBXProperty { Type = 83, Value = "BBoxMax" },
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
                                                        new FBXProperty { Type = 83, Value = "Primary Visibility" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Casts Shadows" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Receive Shadows" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 1 }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new FBXElem { ID = "ObjectType", 
                            Properties = 
                            { 
                                new FBXProperty { Type = 83, Value = "Material" } 
                            },
                            Children = 
                            {
                                new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = 52 } } },
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
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ShadingModel" },
                                                        new FBXProperty { Type = 83, Value = "KString" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "Phong" }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "MultiLayer" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "EmissiveColor" },
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "EmissiveFactor" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "AmbientColor" },
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)0.2 },
                                                        new FBXProperty { Type = 68, Value = (double)0.2 },
                                                        new FBXProperty { Type = 68, Value = (double)0.2 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "AmbientFactor" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "DiffuseColor" },
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)0.8 },
                                                        new FBXProperty { Type = 68, Value = (double)0.8 },
                                                        new FBXProperty { Type = 68, Value = (double)0.8 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "DiffuseFactor" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Bump" },
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
                                                        new FBXProperty { Type = 83, Value = "NormalMap" },
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
                                                        new FBXProperty { Type = 83, Value = "BumpFactor" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "TransparentColor" },
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "TransparencyFactor" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "DisplacementColor" },
                                                        new FBXProperty { Type = 83, Value = "ColorRGB" },
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "DisplacementFactor" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "VectorDisplacementColor" },
                                                        new FBXProperty { Type = 83, Value = "ColorRGB" },
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "VectorDisplacementFactor" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "SpecularColor" },
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)0.2 },
                                                        new FBXProperty { Type = 68, Value = (double)0.2 },
                                                        new FBXProperty { Type = 68, Value = (double)0.2 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "SpecularFactor" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ShininessExponent" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)20 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ReflectionColor" },
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ReflectionFactor" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)1 }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new FBXElem { ID = "ObjectType", 
                            Properties = 
                            { 
                                new FBXProperty { Type = 83, Value = "Texture" } 
                            },
                            Children = 
                            {
                                new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = 4 } } },
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
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "TextureTypeUse" },
                                                        new FBXProperty { Type = 83, Value = "enum" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Texture alpha" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "CurrentMappingType" },
                                                        new FBXProperty { Type = 83, Value = "enum" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "WrapModeU" },
                                                        new FBXProperty { Type = 83, Value = "enum" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "WrapModeV" },
                                                        new FBXProperty { Type = 83, Value = "enum" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "UVSwap" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "PremultiplyAlpha" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Translation" },
                                                        new FBXProperty { Type = 83, Value = "Vector" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Rotation" },
                                                        new FBXProperty { Type = 83, Value = "Vector" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Scaling" },
                                                        new FBXProperty { Type = 83, Value = "Vector" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "A" },
                                                        new FBXProperty { Type = 68, Value = (double)1 },
                                                        new FBXProperty { Type = 68, Value = (double)1 },
                                                        new FBXProperty { Type = 68, Value = (double)1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "TextureRotationPivot" },
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
                                                        new FBXProperty { Type = 83, Value = "TextureScalingPivot" },
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
                                                        new FBXProperty { Type = 83, Value = "CurrentTextureBlendMode" },
                                                        new FBXProperty { Type = 83, Value = "enum" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "UVSet" },
                                                        new FBXProperty { Type = 83, Value = "KString" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "default" }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "UseMaterial" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "UseMipMap" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new FBXElem { ID = "ObjectType", 
                            Properties = 
                            { 
                                new FBXProperty { Type = 83, Value = "NodeAttribute" } 
                            },
                            Children = 
                            {
                                new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = 4 } } },
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
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "ColorRGB" },
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0.8 },
                                                        new FBXProperty { Type = 68, Value = (double)0.8 },
                                                        new FBXProperty { Type = 68, Value = (double)0.8 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Size" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)100 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Look" },
                                                        new FBXProperty { Type = 83, Value = "enum" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 1 }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new FBXElem { ID = "ObjectType", 
                            Properties = 
                            { 
                                new FBXProperty { Type = 83, Value = "CollectionExclusive" } 
                            },
                            Children = 
                            {
                                new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = 3 } } },
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
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "ColorRGB" },
                                                        new FBXProperty { Type = 83, Value = "Color" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0.8 },
                                                        new FBXProperty { Type = 68, Value = (double)0.8 },
                                                        new FBXProperty { Type = 68, Value = (double)0.8 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Show" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 1 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Freeze" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "LODBox" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new FBXElem { ID = "ObjectType", 
                            Properties = 
                            { 
                                new FBXProperty { Type = 83, Value = "Video" } 
                            },
                            Children = 
                            {
                                new FBXElem { ID = "Count", Properties = { new FBXProperty { Type = 73, Value = 4 } } },
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
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ImageSequence" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "ImageSequenceOffset" },
                                                        new FBXProperty { Type = 83, Value = "int" },
                                                        new FBXProperty { Type = 83, Value = "Integer" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "FrameRate" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "LastFrame" },
                                                        new FBXProperty { Type = 83, Value = "int" },
                                                        new FBXProperty { Type = 83, Value = "Integer" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Width" },
                                                        new FBXProperty { Type = 83, Value = "int" },
                                                        new FBXProperty { Type = 83, Value = "Integer" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Height" },
                                                        new FBXProperty { Type = 83, Value = "int" },
                                                        new FBXProperty { Type = 83, Value = "Integer" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Path" },
                                                        new FBXProperty { Type = 83, Value = "KString" },
                                                        new FBXProperty { Type = 83, Value = "XRefUrl" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "StartFrame" },
                                                        new FBXProperty { Type = 83, Value = "int" },
                                                        new FBXProperty { Type = 83, Value = "Integer" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "StopFrame" },
                                                        new FBXProperty { Type = 83, Value = "int" },
                                                        new FBXProperty { Type = 83, Value = "Integer" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "PlaySpeed" },
                                                        new FBXProperty { Type = 83, Value = "double" },
                                                        new FBXProperty { Type = 83, Value = "Number" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 68, Value = (double)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Offset" },
                                                        new FBXProperty { Type = 83, Value = "KTime" },
                                                        new FBXProperty { Type = 83, Value = "Time" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 76, Value = (long)0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "InterlaceMode" },
                                                        new FBXProperty { Type = 83, Value = "enum" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "FreeRunning" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "Loop" },
                                                        new FBXProperty { Type = 83, Value = "bool" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                },
                                                new FBXElem { ID = "P", 
                                                    Properties = 
                                                    {  
                                                        new FBXProperty { Type = 83, Value = "AccessMode" },
                                                        new FBXProperty { Type = 83, Value = "enum" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 83, Value = "" },
                                                        new FBXProperty { Type = 73, Value = 0 }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            );

            fbx.Save(path);
        }
    }
}
