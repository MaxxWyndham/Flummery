using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using ToxicRagers.Carmageddon2;
using ToxicRagers.Carmageddon2.Formats;
using ToxicRagers.Helpers;

using Flummery.Core;
using Flummery.Core.ContentPipeline;
using Flummery.Plugin.CarmageddonClassic.ContentPipeline;

namespace Flummery.Plugin.CarmageddonClassic
{
    [Plugin("CarmageddonClassic")]
    public class CarmageddonClassicPlugin : IPlugin
    {
        public string Name { get; } = "Carmageddon (Classic)";

        public List<string> Contexts { get; } = new List<string> { "Carmageddon", "Carmageddon 2" };

        public List<MenuItem> FileOpenItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Actor",
                Filter = "Carmageddon ACTOR (*.act)|*.act",
                FileOpenAction = CarmageddonClassic.OpenActor
            },
            new MenuItem
            {
                Name = "Car (C1)",
                Filter = "Carmageddon CAR (*.txt)|*.txt",
                FileOpenAction = CarmageddonClassic.OpenCarC1
            },
            new MenuItem
            {
                Name = "Race (C2)",
                Filter = "Carmageddon 2 Race (*.act)|*.act",
                FileOpenAction = CarmageddonClassic.OpenRaceC2
            }
        };

        public List<MenuItem> FileImportItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "BRender ACT File",
                Filter = "BRender ACT files (*.act)|*.act",
                FileOpenAction = CarmageddonClassic.ImportACT
            },
            new MenuItem
            {
                Name = "BRender DAT File",
                Filter = "BRender DAT files (*.dat)|*.dat",
                FileOpenAction = CarmageddonClassic.ImportDAT
            }
        };

        public List<MenuItem> FileSaveForItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Carmageddon 2",
                Filter = "BRender ACT files (*.act)|*.act",
                FileOpenAction = CarmageddonClassic.SaveForCarmageddon2
            }
        };

        public List<MenuItem> FileSaveAsItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Vehicle",
                ToolsAction = CarmageddonClassic.SaveAsVehicle
            }
        };

        public List<MenuItem> FileExportItems { get; } = null;

        public List<MenuItem> Tools { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "Process Car for Carmageddon: Max Damage",
                ToolsAction = CarmageddonClassic.ProcessCarForCarmageddonMaxDamage
            },
            new MenuItem
            {
                Name = "Process Race for Carmageddon: Max Damage",
                ToolsAction = CarmageddonClassic.ProcessLevelForCarmageddonMaxDamage
            }
        };

        public List<MenuItem> ProcessAllItems { get; } = new List<MenuItem>
        {
            new MenuItem
            {
                Name = "TXT files (C1 Car)",
                Mask = "*.txt",
                ProcessAction = ToxicRagers.Carmageddon.Formats.Car.Load
            }
        };

        public void RegisterEvents()
        {
            SceneManager.Current.OnSelectMaterial += current_OnSelectMaterial;
        }

        private void current_OnSelectMaterial(object sender, SelectMaterialEventArgs e)
        {
            if (Contexts.Contains(SceneManager.Current.Game))
            {
                Form editor = new MaterialEditor(SceneManager.Current.SelectedMaterial);

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    SceneManager.Current.Change(ChangeType.Munge, ChangeContext.Material, -1, SceneManager.Current.SelectedMaterial);
                }
            }
        }
    }

    public static class CarmageddonClassic
    {
        public static void OpenActor(string path)
        {
            SceneManager.Current.SetCoordinateSystem(CoordinateSystem.RightHanded);

            SceneManager.Current.Content.Load<Model, ACTImporter>(Path.GetFileNameWithoutExtension(path), Path.GetDirectoryName(path), true);

            SceneManager.Current.SetContext("Carmageddon", ContextMode.Generic);
        }

        public static void OpenCarC1(string path)
        {
            SceneManager.Current.SetCoordinateSystem(CoordinateSystem.RightHanded);

            SceneManager.Current.Content.Load<Model, C1CarImporter>(Path.GetFileNameWithoutExtension(path), Path.GetDirectoryName(path), true);

            SceneManager.Current.SetContext("Carmageddon", ContextMode.Car);
        }

        public static void ImportACT(string path)
        {
            SceneManager.Current.Content.Load<Model, ACTImporter>(Path.GetFileNameWithoutExtension(path), Path.GetDirectoryName(path), true);

            SceneManager.Current.UpdateProgress($"Imported {Path.GetFileName(path)}");
        }

        public static void ImportDAT(string path)
        {
            SceneManager.Current.Content.Load<Model, DATImporter>(Path.GetFileNameWithoutExtension(path), Path.GetDirectoryName(path), true);

            SceneManager.Current.UpdateProgress($"Imported {Path.GetFileName(path)}");
        }

        public static void OpenRaceC2(string path)
        {
            SceneManager.Current.SetCoordinateSystem(CoordinateSystem.RightHanded);

            string txtFile = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.txt");

            Model race = SceneManager.Current.Content.Load<Model, ACTImporter>(Path.GetFileNameWithoutExtension(path), Path.GetDirectoryName(path), true);
            if (File.Exists(txtFile)) { race.SupportingDocuments["TXT"] = Map.Load(txtFile); }

            SceneManager.Current.SetContext("Carmageddon 2", ContextMode.Level);
        }

        public static void SaveForCarmageddon2(string path)
        {
            string directory = Path.GetDirectoryName(path);
            HashSet<string> textures = new HashSet<string>();
            if (!Directory.Exists(Path.Combine(directory, "tiffrgb"))) { Directory.CreateDirectory(Path.Combine(directory, "tiffrgb")); }

            ACTExporter ax = new ACTExporter();
            ax.Export(SceneManager.Current.Models[0], path);

            DATExporter dx = new DATExporter();
            dx.Export(SceneManager.Current.Models[0], Path.Combine(directory, $"{Path.GetFileNameWithoutExtension(path)}.dat"));

            MATExporter mx = new MATExporter();
            mx.Export(SceneManager.Current.Materials, Path.Combine(directory, $"{Path.GetFileNameWithoutExtension(path)}.mat"));

            foreach (Material material in SceneManager.Current.Materials)
            {
                if (material == null) { continue; }

                if (material.Texture.Name != null && textures.Add(material.Texture.Name))
                {
                    TIFExporter tx = new TIFExporter();
                    tx.Export(material.Texture, Path.Combine(directory, "tiffrgb", $"{material.Texture.Name}.tif"));
                }
            }

            SceneManager.Current.UpdateProgress($"{Path.GetFileName(path)} saved successfully");
        }

        public static void ProcessCarForCarmageddonMaxDamage()
        {
            if (SceneManager.Current.Models.Count == 0) { return; }

            Model model = SceneManager.Current.Models[0];
            ModelBoneCollection bones = SceneManager.Current.Models[0].Bones[0].AllChildren();

            SceneManager.Current.UpdateProgress("Applying Carmageddon Reincarnation scale");

            ModelManipulator.Scale(bones, Matrix4D.CreateScale(6.9f, 6.9f, -6.9f), true);
            ModelManipulator.FlipFaces(bones, true);

            SceneManager.Current.UpdateProgress("Fixing material names");

            foreach (Material material in SceneManager.Current.Materials)
            {
                if (material.Name.Contains(".")) { material.Name = material.Name.Substring(0, material.Name.IndexOf(".")); }
                material.Name = material.Name.Replace("\\", "");
            }

            SceneManager.Current.UpdateProgress("Munging parts and fixing wheels");

            float scale;

            for (int i = 0; i < bones.Count; i++)
            {
                ModelBone bone = bones[i];

                if (i == 0)
                {
                    bone.Name = "c_Body";
                    bone.Mesh.Name = "c_Body";
                }
                else
                {
                    bone.Name = Path.GetFileNameWithoutExtension(bone.Name);
                }

                switch (bone.Name.ToUpper())
                {
                    case "C_BODY":
                        break;

                    case "FLPIVOT":
                    case "FRPIVOT":
                        bone.Name = "Hub_" + bone.Name.ToUpper().Substring(0, 2);

                        if (bone.Transform.ExtractTranslation() == Vector3.Zero)
                        {
                            ModelManipulator.MungeMeshWithBone(bone.Children[0].Mesh, false);

                            Matrix4D m = bone.Transform;
                            m.M31 = bone.Children[0].Transform.M31;
                            m.M32 = bone.Children[0].Transform.M32;
                            m.M33 = bone.Children[0].Transform.M33;
                            bone.Transform = m;

                            model.SetTransform(Matrix4D.Identity, bone.Children[0].Index);
                        }
                        break;

                    case "FLWHEEL":
                        scale = bone.CombinedTransform.ExtractTranslation().Y / 0.35f;

                        bone.Name = "Wheel_FL";
                        model.ClearMesh(bone.Index);
                        model.SetTransform(Matrix4D.CreateScale(scale) * Matrix4D.CreateRotationY(Maths.DegreesToRadians(180)), bone.Index);
                        break;

                    case "FRWHEEL":
                        scale = bone.CombinedTransform.ExtractTranslation().Y / 0.35f;

                        bone.Name = "Wheel_FR";
                        model.ClearMesh(bone.Index);
                        model.SetTransform(Matrix4D.CreateScale(scale), bone.Index);
                        break;

                    case "RLWHEEL":
                    case "RRWHEEL":
                        string suffix = bone.Name.ToUpper().Substring(0, 2);

                        bone.Name = "Hub_" + suffix;

                        if (bone.Transform.ExtractTranslation() == Vector3.Zero) { ModelManipulator.MungeMeshWithBone(bone.Mesh, false); }
                        model.ClearMesh(bone.Index);

                        scale = bone.CombinedTransform.ExtractTranslation().Y / 0.35f;

                        int newBone = model.AddMesh(null, bone.Index);
                        model.SetName("Wheel_" + suffix, newBone);
                        model.SetTransform(Matrix4D.CreateScale(scale) * (suffix == "RL" ? Matrix4D.CreateRotationY(Maths.DegreesToRadians(180)) : Matrix4D.Identity), newBone);
                        break;

                    case "DRIVER":
                        bone.Name = "Dryver";
                        goto default;

                    default:
                        if (bone.Type == BoneType.Mesh) { ModelManipulator.MungeMeshWithBone(bone.Mesh, false); }
                        break;
                }
            }

            SceneManager.Current.UpdateProgress("Processing complete!");

            SceneManager.Current.SetCoordinateSystem(CoordinateSystem.LeftHanded);

            SceneManager.Current.Change(ChangeType.Munge, ChangeContext.Model, -1);

            SceneManager.Current.SetContext("Carmageddon Max Damage", ContextMode.Car);
        }

        public static void ProcessLevelForCarmageddonMaxDamage()
        {
            if (SceneManager.Current.Models.Count == 0) { return; }

            ModelBoneCollection bones = SceneManager.Current.Models[0].Bones[0].AllChildren();

            SceneManager.Current.UpdateProgress("Applying Carmageddon: Max Damage scale");

            ModelManipulator.Scale(bones, Matrix4D.CreateScale(6.9f, 6.9f, -6.9f), true);
            ModelManipulator.FlipFaces(bones, true);

            SceneManager.Current.UpdateProgress("Fixing material names");

            foreach (Material material in SceneManager.Current.Materials)
            {
                if (material.Name.Contains(".")) { material.Name = material.Name.Substring(0, material.Name.IndexOf(".")); }
                material.Name = material.Name.Replace("\\", "");

                MATMaterial m = (material.SupportingDocuments["Source"] as MATMaterial);
                if (!m.HasTexture)
                {
                    using (Bitmap bmp = new Bitmap(16, 16))
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(m.DiffuseColour[3], m.DiffuseColour[0], m.DiffuseColour[1], m.DiffuseColour[2])), 0, 0, 16, 16);

                        Texture t = new Texture();
                        t.CreateFromBitmap(bmp, string.Format("{4}_R{0:x2}G{1:x2}B{2:x2}A{3:x2}", m.DiffuseColour[0], m.DiffuseColour[1], m.DiffuseColour[2], m.DiffuseColour[3], material.Name));
                        material.Texture = t;
                    }
                }
            }

            SceneManager.Current.UpdateProgress("Processing powerups and accessories");

            for (int i = bones.Count - 1; i >= 0; i--)
            {
                ModelBone bone = bones[i];

                if (bone.Name.StartsWith("&"))
                {
                    Entity entity = new Entity();

                    if (bone.Name.StartsWith("&£"))
                    {
                        string key = bone.Name.Substring(2, 2);

                        entity.UniqueIdentifier = $"errol_B00BIE{key}_{i:000}";
                        entity.EntityType = EntityType.Powerup;

                        C2Powerup pup = Powerups.LookupID(int.Parse(key));

                        if (pup.InMD)
                        {
                            entity.Name = $"pup_{pup.Name}";
                            entity.Tag = pup.Model;
                        }
                        else
                        {
                            entity.Name = "pup_Credits";
                            entity.Tag = pup.Model;
                        }
                    }
                    else
                    {
                        // accessory
                        entity.UniqueIdentifier = $"errol_HEAD00{bone.Name.Substring(1, 2)}_{i:000}";
                        entity.EntityType = EntityType.Accessory;
                        entity.Name = $"C2_{bone.Mesh.Name.Substring(3)}";
                    }

                    entity.Transform = bone.CombinedTransform;
                    entity.AssetType = AssetType.Sprite;
                    SceneManager.Current.Entities.Add(entity);

                    SceneManager.Current.Models[0].RemoveBone(bone.Index);
                }
            }

            if (SceneManager.Current.Models[0].SupportingDocuments.ContainsKey("TXT"))
            {
                Map map = SceneManager.Current.Models[0].GetSupportingDocument<Map>("TXT");

                Entity entity = new Entity
                {
                    EntityType = EntityType.Grid,
                    AssetType = AssetType.Sprite,
                    Transform = Matrix4D.CreateTranslation(map.GridPosition.X * 6.9f, map.GridPosition.Y * 6.9f, map.GridPosition.Z * -6.9f)
                };

                SceneManager.Current.Entities.Add(entity);
            }

            SceneManager.Current.UpdateProgress("Processing complete!");

            SceneManager.Current.SetCoordinateSystem(CoordinateSystem.LeftHanded);

            SceneManager.Current.Change(ChangeType.Munge, ChangeContext.Model, -1);

            SceneManager.Current.SetContext("Carmageddon Max Damage", ContextMode.Level);
        }

        public static void SaveAsVehicle()
        {
            new SaveAsVehicle().ShowDialog();
        }
    }
}
