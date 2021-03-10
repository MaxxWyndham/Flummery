using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.Stainless.Formats;

using Flummery.Core;
using Flummery.Plugin.CarmageddonMaxDamage.ContentPipeline;

namespace Flummery.Plugin.CarmageddonMaxDamage
{
    [Plugin("CarmageddonMaxDamage")]
    public class CarmageddonMaxDamagePlugin : IPlugin
    {
        public string Name { get; } = "Carmageddon Max Damage";

        public List<string> Contexts { get; } = new List<string> { "Carmageddon Max Damage" };

        public List<MenuItem> FileOpenItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Accessory",
                Filter = "Carmageddon Max Damage Accessory files (accessory.cnt)|accessory.cnt",
                FileOpenAction = CarmageddonMaxDamage.OpenAccessory
            },
            new MenuItem
            {
                Name = "Environment",
                Filter = "Carmageddon Max Damage Environment files (level.cnt)|level.cnt",
                FileOpenAction = CarmageddonMaxDamage.OpenEnvironment
            },
            new MenuItem
            {
                Name = "Pedestrian",
                Filter = "Carmageddon Max Damage Pedestrians (bodyform.cnt)|bodyform.cnt",
                FileOpenAction = CarmageddonMaxDamage.OpenPedestrian
            },
            new MenuItem
            {
                Name = "Vehicle",
                Filter = "Carmageddon Max Damage Vehicles (car.cnt)|car.cnt",
                FileOpenAction = CarmageddonMaxDamage.OpenVehicle
            }
        };

        public List<MenuItem> FileImportItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Stainless CNT File",
                Filter = "Stainless CNT files (*.cnt)|*.cnt",
                FileOpenAction = CarmageddonMaxDamage.ImportCNT
            },
            new MenuItem
            {
                Name = "Stainless MDL File",
                Filter = "Stainless MDL files (*.mdl)|*.mdl",
                FileOpenAction = CarmageddonMaxDamage.ImportMDL
            },
            new MenuItem
            {
                Name = "Stainless LIGHT File",
                Filter = "Stainless LIGHT files (*.light)|*.light",
                FileOpenAction = CarmageddonMaxDamage.ImportLIGHT
            }
        };

        public List<MenuItem> FileSaveForItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Carmageddon Max Damage",
                Filter = "Stainless CNT files (*.cnt)|*.cnt",
                FileOpenAction = CarmageddonMaxDamage.SaveForCarmageddonMaxDamage
            }
        };

        public List<MenuItem> FileSaveAsItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Level",
                ToolsAction = CarmageddonMaxDamage.SaveAsLevel
            },
            new MenuItem
            {
                Name = "Vehicle",
                ToolsAction = CarmageddonMaxDamage.SaveAsVehicle
            }
        };

        public List<MenuItem> FileExportItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Stainless CNT File",
                Filter = "Stainless CNT files (*.cnt)|*.cnt",
                FileOpenAction = CarmageddonMaxDamage.ExportCNT
            }
        };

        public List<MenuItem> Tools { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Bulk UnZAD",
                ToolsAction = CarmageddonMaxDamage.BulkUnZAD
            },
            new MenuItem
            {
                Name = "Wheel Preview",
                ToolsAction = CarmageddonMaxDamage.WheelPreview
            }
        };

        public List<MenuItem> ProcessAllItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "CNT files",
                Mask = "*.cnt",
                ProcessAction = CNT.Load
            },
            new MenuItem
            {
                Name = "MDL files",
                Mask = "*.mdl",
                ProcessAction = MDL.Load
            },
            new MenuItem
            {
                Name = "MT2 files",
                Mask = "*.mt2",
                ProcessAction = MT2.Load
            },
            new MenuItem
            {
                Name = "TDX files",
                Mask = "*.tdx",
                ProcessAction = TDX.Load
            },
            new MenuItem
            {
                Name = "LIGHT files",
                Mask = "*.light",
                ProcessAction = LIGHT.Load
            },
            new MenuItem
            {
                Name = "Accessory.txt files",
                Mask = "accessory.txt",
                ProcessAction = Accessory.Load
            },
            new MenuItem
            {
                Name = "Routes.txt files",
                Mask = "routes.txt",
                ProcessAction = Routes.Load
            },
            new MenuItem
            {
                Name = "vehicle_setup.cfg files",
                Mask = "vehicle_setup.cfg",
                ProcessAction = VehicleSetupConfig.Load
            },
            new MenuItem
            {
                Name = "vehicle_setup.lol files",
                Mask = "vehicle_setup.lol",
                ProcessAction = VehicleSetup.Load
            },
            new MenuItem
            {
                Name = "Structure.xml files",
                Mask = "structure.xml",
                ProcessAction = Structure.Load
            },
            new MenuItem
            {
                Name = "SystemsDamage.xml files",
                Mask = "SystemsDamage.xml",
                ProcessAction = SystemsDamage.Load
            },
            new MenuItem
            {
                Name = "Setup.lol files",
                Mask = "Setup.lol",
                ProcessAction = Setup.Load
            },
            new MenuItem
            {
                Name = "ZAD files",
                Mask = "*.zad",
                ProcessAction = ZAD.Load
            }
        };
    }

    public static class CarmageddonMaxDamage
    {
        public static void OpenAccessory(string path)
        {
            SceneManager.Current.SetCoordinateSystem(CoordinateSystem.LeftHanded);

            SceneManager.Current.Reset();
            Asset accessory = SceneManager.Current.Add(SceneManager.Current.Content.Load<Model, CNTImporter>(Path.GetFileName(path), Path.GetDirectoryName(path)));

            string accessorytxt = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.txt");

            if (File.Exists(accessorytxt))
            {
                accessory.SupportingDocuments["Accessory"] = Accessory.Load(accessorytxt);
            }

            SceneManager.Current.SetContext("Carmageddon Max Damage", ContextMode.Accessory);
        }

        public static void OpenEnvironment(string path)
        {
            SceneManager.Current.SetCoordinateSystem(CoordinateSystem.LeftHanded);

            SceneManager.Current.Reset();
            SceneManager.Current.Content.Load<Model, CNTImporter>(Path.GetFileNameWithoutExtension(path), Path.GetDirectoryName(path), true);

            SceneManager.Current.SetContext("Carmageddon Max Damage", ContextMode.Level);
        }

        public static void OpenPedestrian(string path)
        {
            SceneManager.Current.SetCoordinateSystem(CoordinateSystem.LeftHanded);

            SceneManager.Current.Reset();
            SceneManager.Current.Content.Load<Model, CNTImporter>(Path.GetFileNameWithoutExtension(path), Path.GetDirectoryName(path), true);

            SceneManager.Current.SetContext("Carmageddon Max Damage", ContextMode.Ped);
        }

        public static void OpenVehicle(string path)
        {
            SceneManager.Current.SetCoordinateSystem(CoordinateSystem.LeftHanded);

            SceneManager.Current.Reset();

            string assetFolder = Path.GetDirectoryName(path);

            Model vehicle = (Model)SceneManager.Current.Add(SceneManager.Current.Content.Load<Model, CNTImporter>(Path.GetFileName(path), assetFolder));

            // Load supporting documents
            if (File.Exists(Path.Combine(assetFolder, "setup.lol"))) { vehicle.SupportingDocuments["Setup"] = Setup.Load(Path.Combine(assetFolder, "setup.lol")); }
            if (File.Exists(Path.Combine(assetFolder, "Structure.xml")))
            {
                List<string> findMaterials(StructurePart part)
                {
                    List<string> materials = new List<string>();

                    materials.AddRange(part.DamageSettings.Methods.Where(m => m.Name == "CrushDamageMaterial" && m.HasBeenSet).Select(m => m.Parameters[2].Value.ToString()));

                    foreach (StructurePart child in part.Parts)
                    {
                        materials.AddRange(findMaterials(child));
                    }

                    return materials;
                }

                Structure structure = Structure.Load(Path.Combine(assetFolder, "Structure.xml"));

                foreach (string material in findMaterials(structure.Root))
                {
                    SceneManager.Current.Content.Load<Material, MT2Importer>(material, assetFolder, true);
                }

                vehicle.SupportingDocuments["Structure"] = structure;
            }

            if (File.Exists(Path.Combine(assetFolder, "SystemsDamage.xml"))) { vehicle.SupportingDocuments["SystemsDamage"] = SystemsDamage.Load(Path.Combine(assetFolder, "SystemsDamage.xml")); }

            if (File.Exists(Path.Combine(assetFolder, "vehicle_setup.cfg")))
            {
                vehicle.SupportingDocuments["VehicleSetupConfig"] = VehicleSetupConfig.Load(Path.Combine(assetFolder, "vehicle_setup.cfg"));

                foreach (VehicleMaterialMap materialMap in vehicle.GetSupportingDocument<VehicleSetupConfig>("VehicleSetupConfig").MaterialMaps)
                {
                    foreach (KeyValuePair<string, string> kvp in materialMap.Substitutions)
                    {
                        SceneManager.Current.Content.Load<Material, MT2Importer>(kvp.Value, assetFolder, true);
                    }
                }
            }

            if (File.Exists(Path.Combine(assetFolder, "vehicle_setup.lol"))) { vehicle.SupportingDocuments["VehicleSetup"] = VehicleSetup.Load(Path.Combine(assetFolder, "vehicle_setup.lol")); }
            if (File.Exists(Path.Combine(assetFolder, "vfx_anchors.lol"))) { vehicle.SupportingDocuments["VFXAnchors"] = VFXAnchors.Load(Path.Combine(assetFolder, "vfx_anchors.lol")); }

            if (File.Exists(Path.Combine(assetFolder, "collision.cnt"))) { vehicle.SupportingDocuments["Collision"] = SceneManager.Current.Content.Load<Model, CNTImporter>("collision.cnt", assetFolder); }
            if (File.Exists(Path.Combine(assetFolder, "opponent_collision.cnt"))) { vehicle.SupportingDocuments["OpponentCollision"] = SceneManager.Current.Content.Load<Model, CNTImporter>("opponent_collision.cnt", assetFolder); }

            //if (File.Exists(assetFolder + "CrashSoundsConfig_Car.xml")) { vehicle.SupportingDocuments["SystemsDamage"] = SystemsDamage.Load(assetFolder + "SystemsDamage.xml"); }

            foreach (ModelBone bone in vehicle.Bones)
            {
                string boneName = bone.Name.ToLower();

                if (boneName.StartsWith("wheel_") || boneName.StartsWith("vfx_") || boneName.StartsWith("driver"))
                {
                    Entity entity = new Entity
                    {
                        Name = bone.Name,
                        EntityType = (boneName.StartsWith("driver") ? EntityType.Driver : (boneName.StartsWith("wheel_") ? EntityType.Wheel : EntityType.VFX)),
                        AssetType = AssetType.Sprite
                    };
                    entity.LinkWith(bone);

                    SceneManager.Current.Entities.Add(entity);
                }
            }

            SceneManager.Current.SetContext("Carmageddon Max Damage", ContextMode.Car);
        }

        public static void ImportCNT(string path)
        {
            SceneManager.Current.Content.Load<Model, CNTImporter>(Path.GetFileNameWithoutExtension(path), Path.GetDirectoryName(path), true);

            SceneManager.Current.UpdateProgress($"Imported {Path.GetFileName(path)}");
        }

        public static void ImportMDL(string path)
        {
            SceneManager.Current.Content.Load<Model, MDLImporter>(Path.GetFileNameWithoutExtension(path), Path.GetDirectoryName(path), true);

            SceneManager.Current.UpdateProgress($"Imported {Path.GetFileName(path)}");
        }

        public static void ImportLIGHT(string path)
        {
            SceneManager.Current.Content.Load<Model, LIGHTImporter>(Path.GetFileNameWithoutExtension(path), Path.GetDirectoryName(path), true);

            SceneManager.Current.UpdateProgress($"Imported {Path.GetFileName(path)}");
        }

        public static void SaveForCarmageddonMaxDamage(string path)
        {
            CNTExporter cx = new CNTExporter();
            cx.Export(SceneManager.Current.Models[0], path);

            MDLExporter mx = new MDLExporter();
            mx.Export(SceneManager.Current.Models[0], Path.GetDirectoryName(path));

            SceneManager.Current.UpdateProgress($"{Path.GetFileName(path)} saved successfully");
        }

        public static void SaveAsLevel()
        {
            new SaveAsLevel().ShowDialog();
        }

        public static void SaveAsVehicle()
        {
            new SaveAsVehicle().ShowDialog();
        }

        public static void ExportCNT(string path)
        {
            CNTExporter cx = new CNTExporter();
            cx.Export(SceneManager.Current.Models[0], path);

            SceneManager.Current.UpdateProgress($"Exported {Path.GetFileName(path)}");
        }

        public static void BulkUnZAD()
        {
            //FolderBrowserDialog fbdBrowse = new FolderBrowserDialog
            //{
            //    SelectedPath = Properties.Settings.Default.LastBrowsedFolder ?? Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
            //    ShowNewFolderButton = false
            //};

            //if (MessageBox.Show($"Are you entirely sure?  This will extra ALL ZAD files in and under\r\n{Properties.Settings.Default.PathCarmageddonMaxDamage}\r\nThis will require at least 30gb of free space", "Totes sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    if (fbdBrowse.ShowDialog() == DialogResult.OK && Directory.Exists(fbdBrowse.SelectedPath))
            //    {
            //        if (Directory.Exists(Properties.Settings.Default.PathCarmageddonMaxDamage))
            //        {
            //            int success = 0;
            //            int fail = 0;

            //            ToxicRagers.Helpers.IO.LoopDirectoriesIn(Properties.Settings.Default.PathCarmageddonMaxDamage, (d) =>
            //            {
            //                foreach (FileInfo fi in d.GetFiles("*.zad"))
            //                {
            //                    ToxicRagers.Stainless.Formats.ZAD zad = ToxicRagers.Stainless.Formats.ZAD.Load(fi.FullName);
            //                    int i = 0;

            //                    if (zad != null)
            //                    {
            //                        if (!zad.IsVT)
            //                        {
            //                            foreach (ToxicRagers.Stainless.Formats.ZADEntry entry in zad.Contents)
            //                            {
            //                                i++;

            //                                zad.Extract(entry, fbdBrowse.SelectedPath);

            //                                if (i % 25 == 0)
            //                                {
            //                                    SceneManager.Current.UpdateProgress($"[{success}/{fail}] {fi.Name} -> {entry.Name}");
            //                                }
            //                            }

            //                            success++;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        fail++;
            //                    }

            //                    SceneManager.Current.UpdateProgress($"[{success}/{fail}] {fi.FullName.Replace(Properties.Settings.Default.PathCarmageddonMaxDamage, "")}");
            //                }
            //            }
            //            );

            //            SceneManager.Current.UpdateProgress($"UnZADing complete. {success} success {fail} fail");
            //        }
            //    }
            //}
        }

        public static void WheelPreview()
        {
            WheelPreview preview = new WheelPreview();

            DialogResult result = preview.ShowDialog();

            switch (result)
            {
                case DialogResult.OK:
                case DialogResult.Abort:
                    foreach (Entity entity in SceneManager.Current.Entities)
                    {
                        if (entity.EntityType == EntityType.Wheel)
                        {
                            entity.Asset = result == DialogResult.OK ? preview.Wheel : null;
                            entity.AssetType = result == DialogResult.OK ? AssetType.Model : AssetType.Sprite;
                        }
                    }
                    break;
            }
        }
    }
}
