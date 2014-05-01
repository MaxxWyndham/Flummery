using System;
using System.Collections.Generic;
using System.IO;
using Flummery.ContentPipeline;

namespace Flummery
{
    public class ContentManager
    {
        Dictionary<string, Asset> assets = new Dictionary<string, Asset>();
        public static string Hints = "";//(Properties.Settings.Default.FolderHints != null ? Properties.Settings.Default.FolderHints : "");

        public static bool LoadOrDefaultFile(string Filename, string FileExtension, out string FilePath)
        {
            string[] hints = Hints.Split(';');
            var fileNames = Filename.Split(';');
            var extensions = FileExtension.Split(';');

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
            var list = new List<string>(Hints.Split(';'));
            int index = list.IndexOf(hint);

            if (index > -1) { list.RemoveAt(index); }
            list.Insert(0, hint);

            Hints = string.Join(";", list.ToArray());
        }

        public T Load<T, T2>(string assetName, string assetPath = null, bool bAddToScene = false) where T : Asset 
                                                                                                  where T2 : ContentImporter, new()
        {
            string key = typeof(T).ToString() + assetName;

            if (assets.ContainsKey(key)) { return (T)assets[key]; }

            var importer = new T2();
            var path = importer.Find(assetName, assetPath);

            if (path != null)
            {
                var content = importer.Import(path);

                Properties.Settings.Default.FolderHints = Hints;
                Properties.Settings.Default.Save();

                if (content != null)
                {
                    assets[key] = content;
                    if (bAddToScene) { SceneManager.Scene.Add(content); }

                    return (T)content;
                }
            }

            return default(T);
        }
    }
}
