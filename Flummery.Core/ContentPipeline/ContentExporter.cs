using System;

namespace Flummery.Core.ContentPipeline
{
    public abstract class ContentExporter
    {
        protected ExportSettings settings = new ExportSettings();

        public ExportSettings ExportSettings => settings;

        public virtual void Export(Asset asset, string path)
        {
        }

        public virtual void Export(AssetList asset, string path)
        {
        }
    }
}
