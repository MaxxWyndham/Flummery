using System;
using System.Collections.Generic;
using System.IO;

using Flummery.ContentPipeline;

namespace Flummery
{
    public partial class ContentManager
    {
        Dictionary<string, Asset> assets = new Dictionary<string, Asset>(StringComparer.InvariantCultureIgnoreCase);
        public static string Hints = "";

        public static bool LoadOrDefaultFile(string Filename, string FileExtension, out string FilePath)
        {
            string[] hints = Hints.Split(';');
            string[] fileNames = Filename.Split(';');
            string[] extensions = FileExtension.Split(';');

            foreach (string file in fileNames)
            {
                foreach (string extension in extensions)
                {
                    foreach (string hint in hints)
                    {
                        FilePath = hint + (hint.EndsWith("\\") ? "" : "\\") + file + "." + extension;

                        if (File.Exists(FilePath)) { return true; }
                    }
                }
            }

            FilePath = null;
            return false;
        }

        public static void AddHint(string hint)
        {
            List<string> list = new List<string>(Hints.Split(';'));
            int index = list.IndexOf(hint);

            if (index > -1) { list.RemoveAt(index); }
            list.Insert(0, hint);

            Hints = string.Join(";", list.ToArray());
        }

        public void Reset()
        {
            assets.Clear();
        }

        public T Load<T, T2>(string assetName, string assetPath = null, bool bAddToScene = false) where T : Asset, new()
                                                                                                  where T2 : ContentImporter, new()
        {
            string key = typeof(T).ToString() + assetName;

            if (assets.ContainsKey(key)) { return (T)assets[key].Clone(); }

            T2 importer = new T2();
            string path = importer.Find(assetName, assetPath);
            Asset content = null;

            if (path != null)
            {
                content = importer.Import(path);
            }
            else
            {
                content = new T
                {
                    Name = assetName
                };
            }

            if (content != null)
            {
                Console.WriteLine("Loaded {0}", assetName);

                assets[key] = content;
                if (bAddToScene) { SceneManager.Current.Add(content); }

                return (T)content;
            }

            return default(T);
        }

        public void LoadMany<T, T2>(string assetName, string assetPath = null, bool bAddToScene = false) where T: AssetList, new()
                                                                                                         where T2: ContentImporter, new()
        {
            T2 importer = new T2();
            string path = importer.Find(assetName, assetPath);

            if (path != null)
            {
                AssetList content = importer.ImportMany(path);

                if (content != null)
                {
                    foreach (Asset asset in content.Entries)
                    {
                        string key = asset.GetType().ToString() + asset.Name;

                        if (!assets.ContainsKey(key))
                        { 
                            assets[key] = asset;
                            if (bAddToScene) { SceneManager.Current.Add(asset); }
                        }
                    }
                }
            }
        }
    }
}
