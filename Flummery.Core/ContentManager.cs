using System;
using System.Collections.Generic;
using System.IO;

using Flummery.Core.ContentPipeline;

namespace Flummery.Core
{
    public partial class ContentManager
    {
        Dictionary<string, Asset> Assets { get; } = new Dictionary<string, Asset>(StringComparer.InvariantCultureIgnoreCase);
        public static string Hints { get; private set; } = "";

        public static bool LoadOrDefaultFile(string fileName, string fileExtension, out string filePath)
        {
            string[] hints = Hints.Split(';');
            string[] fileNames = fileName.Split(';');
            string[] extensions = fileExtension.Split(';');

            foreach (string file in fileNames)
            {
                foreach (string extension in extensions)
                {
                    foreach (string hint in hints)
                    {
                        filePath = hint + (hint.EndsWith("\\") ? "" : "\\") + file + "." + extension;

                        if (File.Exists(filePath)) { return true; }
                    }
                }
            }

            filePath = null;
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
            Assets.Clear();
        }

        public T Load<T, T2>(string assetName, string assetPath = null, bool addToScene = false) where T : Asset, new()
                                                                                                 where T2 : ContentImporter, new()
        {
            string key = typeof(T).ToString() + assetName;

            if (Assets.ContainsKey(key)) { return (T)Assets[key].Clone(); }

            T2 importer = new T2();
            string path = importer.Find(assetName, assetPath);
            Asset content;
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

                Assets[key] = content;
                if (addToScene) { SceneManager.Current.Add(content); }

                return (T)content;
            }

            return default;
        }

        public void LoadMany<T, T2>(string assetName, string assetPath = null, bool addToScene = false) where T : AssetList, new()
                                                                                                        where T2 : ContentImporter, new()
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

                        if (!Assets.ContainsKey(key))
                        {
                            Assets[key] = asset;
                            if (addToScene) { SceneManager.Current.Add(asset); }
                        }
                    }
                }
            }
        }
    }
}
