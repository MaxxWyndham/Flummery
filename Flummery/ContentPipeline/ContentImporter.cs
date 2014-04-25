using System;
using System.IO;

namespace Flummery.ContentPipeline
{
    public abstract class ContentImporter    
    {
        public virtual string GetExtension()
        {
            return "";
        }

        public string Find(string assetName)
        {
            if (File.Exists(assetName)) { return assetName; }

            if (assetName.IndexOf("\\") > -1) 
            {
                var hint = assetName.Substring(0, assetName.LastIndexOf("\\") + 1);
                assetName = assetName.Replace(hint, "");
                ContentManager.AddHint(hint);
            }
            if (assetName.IndexOf(".") > -1) { assetName = assetName.Substring(0, assetName.LastIndexOf(".") - 1); }

            string path;

            if (ContentManager.LoadOrDefaultFile(assetName, GetExtension(), out path))
            {
                return path;
            }
            else
            {
                return null;
            }
        }

        public virtual Asset Import(string Path)
        {
            return default(Asset);
        }
    }
}
