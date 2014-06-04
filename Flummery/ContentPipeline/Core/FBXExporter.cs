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
                                        new FBXProperty { Type = 76, Value = (Int64)0 }
                                    }
                                },
                                new FBXElem { ID = "P", 
                                    Properties = 
                                    {  
                                        new FBXProperty { Type = 83, Value = "TimeSpanStop" },
                                        new FBXProperty { Type = 83, Value = "KTime" },
                                        new FBXProperty { Type = 83, Value = "Time" },
                                        new FBXProperty { Type = 83, Value = "" },
                                        new FBXProperty { Type = 76, Value = (Int64)153953860000 }
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

            fbx.Save(path);
        }
    }
}
