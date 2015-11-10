using System;
using System.Collections.Generic;
using System.IO;

using Flummery.ContentPipeline.Core;
using ToxicRagers.Carmageddon2.Formats;
using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.Helpers;
using ToxicRagers.Stainless.Formats;
using OpenTK;

namespace Flummery.ContentPipeline.Stainless
{
    class MaterialImporter : ContentImporter
    {
        public override string GetExtension() { return "mt2;mtl;mat"; }

        public override string GetHints(string currentPath)
        {
            string hints = (currentPath != null ? currentPath + ";" : "");

            if (Properties.Settings.Default.PathCarmageddon1 != null && currentPath.Contains(Properties.Settings.Default.PathCarmageddon1))
            {
                if (Directory.Exists(Properties.Settings.Default.PathCarmageddon1 + "DATA\\MATERIAL\\")) { hints += Properties.Settings.Default.PathCarmageddon1 + "DATA\\MATERIAL\\;"; }
            }

            if (Properties.Settings.Default.PathCarmageddonReincarnation != null && currentPath.Contains(Properties.Settings.Default.PathCarmageddonReincarnation))
            {
                if (Directory.Exists(Properties.Settings.Default.PathCarmageddonReincarnation + "Data_Core\\Content\\Textures\\")) { hints += Properties.Settings.Default.PathCarmageddonReincarnation + "Data_Core\\Content\\Textures\\;"; }
            }

            return hints;
        }

        public override Asset Import(string path)
        {
            Material material;

            string name = Path.GetFileNameWithoutExtension(path);
            ToxicRagers.Generics.Material m = null;

            switch (Path.GetExtension(path).ToLower())
            {
                case ".mt2":
                    m = MT2.Load(path);
                    break;

                case ".mtl":
                    m = MTL.Load(path);
                    break;
            }

            if (m != null)
            {
                var mat = (m as MT2);
                string fileName = (mat != null ? mat.Texture : (m as MTL).Textures[0]);

                if (fileName == null || fileName == "")
                {
                    material = new Material { Name = name, Texture = new Texture() { Name = fileName } };
                }
                else
                {
                    material = new Material { Name = name, Texture = SceneManager.Current.Content.Load<Texture, TDXImporter>(fileName, Path.GetDirectoryName(path)) };
                }

                material.SupportingDocuments["Source"] = m;
            }
            else
            {
                material = new Material();
            }

            return material;
        }

        public override AssetList ImportMany(string path)
        {
            MaterialList materials = new MaterialList();
            MAT mat = MAT.Load(path);

            foreach (var material in mat.Materials)
            {
                if (material.Texture == Path.GetFileNameWithoutExtension(material.Texture))
                {
                    materials.Entries.Add(
                        new Material
                        {
                            Name = material.Name,
                            Texture = SceneManager.Current.Content.Load<Texture, TIFImporter>(material.Texture, Path.GetDirectoryName(path))
                        }
                    );

                    materials.Entries[materials.Entries.Count - 1].SupportingDocuments["Source"] = material;
                }
                else
                {
                    materials.Entries.Add(
                        new Material
                        {
                            Name = material.Name,
                            Texture = SceneManager.Current.Content.Load<Texture, PIXImporter>(material.Texture, Path.GetDirectoryName(path))
                        }
                    );
                }
            }

            return materials;
        }
    }
}
