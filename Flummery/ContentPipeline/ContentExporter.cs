using System;

namespace Flummery.ContentPipeline
{
    public abstract class ContentExporter
    {
        protected ExportSettings settings = new ExportSettings();

        public ExportSettings ExportSettings { get { return settings; } }

        public virtual void Export(Asset asset, string Path)
        {
        }
    }
}
