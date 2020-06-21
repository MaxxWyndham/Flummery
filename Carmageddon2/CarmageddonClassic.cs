using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;

using ToxicRagers.Carmageddon2;
using ToxicRagers.Carmageddon2.Formats;
using ToxicRagers.Helpers;

using Flummery.Core;

namespace Flummery.Plugin
{
    [Plugin("CarmageddonClassic")]
    public class CarmageddonClassicPlugin : IPlugin
    {
        public string Name { get; } = "Carmageddon Classic";

        public ICommandDispatcher Commands { get; } = new PluginCommandDispatcher();

        public IPluginHandler PluginHandler { get; } = CarmageddonClassic.PluginHandler;
    }

    [Menu("CarmageddonClassic")]
    public class CarmageddonClassicMenu : IMenu
    {
        private ToolStripMenuItem ClientsConsultarMenu;
        private ToolStripMenuItem ClientsNovoMenu;

        private ToolStripMenuItem createMenu()
        {
            //return null; new ToolStripMenuItem
            //{
            //    Text = "Carmageddon 2",
            //    DropDownItems = 
            //    {

            //    }
            //};

            PluginMenu = new ToolStripMenuItem();
            ClientsConsultarMenu = new ToolStripMenuItem();
            ClientsNovoMenu = new ToolStripMenuItem();

            PluginMenu.DropDownItems.AddRange(
                new ToolStripItem[] {
                    ClientsConsultarMenu,
                    ClientsNovoMenu
                });
            PluginMenu.Name = "MenuClientsMain";
            PluginMenu.Text = "Clients";

            ClientsNovoMenu.Name = "MenuClientsNovo";
            ClientsNovoMenu.Text = "Novo";
            ClientsNovoMenu.Click += new EventHandler(CarmageddonClassic.ProcessLevelForCarmageddonMaxDamageClick);

            return PluginMenu;
        }

        [ImportingConstructor()]
        public CarmageddonClassicMenu([Import(typeof(IPluginHandler))] IPluginHandler pluginHandler)
        {
            createMenu();

            CarmageddonClassic.PluginHandler = pluginHandler;
        }

        public ToolStripMenuItem PluginMenu { get; private set; }
    }

    public static class CarmageddonClassic
    {
        public static IPluginHandler PluginHandler { get; set; }

        public static void ProcessLevelForCarmageddonMaxDamageClick(object sender, EventArgs e)
        {
            ProcessLevelForCarmageddonMaxDamage();
        }

        public static bool ProcessLevelForCarmageddonMaxDamage()
        {
            if (SceneManager.Current.Models.Count == 0) { return false; }

            ModelBoneCollection bones = SceneManager.Current.Models[0].Bones[0].AllChildren();

            //SceneManager.Current.UpdateProgress("Applying Carmageddon: Max Damage scale");

            ModelManipulator.Scale(bones, Matrix4D.CreateScale(6.9f, 6.9f, -6.9f), true);
            ModelManipulator.FlipFaces(bones, true);

            //SceneManager.Current.UpdateProgress("Fixing material names");

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

            //SceneManager.Current.UpdateProgress("Processing powerups and accessories");

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

            //SceneManager.Current.UpdateProgress("Processing complete!");

            //SceneManager.Current.SetCoordinateSystem(SceneManager.CoordinateSystem.LeftHanded);

            //SceneManager.Current.Change(ChangeType.Munge, ChangeContext.Model, -1);

            //SceneManager.Current.SetContext(ContextGame.CarmageddonReincarnation, ContextMode.Level);

            return true;
        }
    }
}
