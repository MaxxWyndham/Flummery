using System;

namespace Flummery.ContentPipeline
{
    public abstract class ContentExporter
    {
        public virtual void Export(Asset asset, string Path)
        {
        }
    }
}
