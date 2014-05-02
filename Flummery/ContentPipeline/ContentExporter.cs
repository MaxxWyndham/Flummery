using System;

namespace Flummery.ContentPipeline
{
    public abstract class ContentExporter
    {
        protected dynamic settings;

        public void SetExportOptions(dynamic settings)
        {
            this.settings = settings;
        }

        public virtual void Export(Asset asset, string Path)
        {
        }
    }
}
