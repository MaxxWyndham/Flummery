using System;
using System.Collections.Generic;

namespace Flummery.Core
{
    [Flags]
    public enum LinkType
    {
        Position = 1,
        Rotation = 2,
        Scale = 4,
        All = Position | Rotation | Scale
    }

    public abstract class Asset
    {
        public string FileName { get; set; }

        public string Name { get; set; }

        public Dictionary<string, object> SupportingDocuments { get; } = new Dictionary<string, object>();

        public object Tag { get; set; }

        public long Key { get; } = SceneManager.Current.Random.NextLong();

        public virtual Asset Clone()
        {
            return this;
        }

        public T GetSupportingDocument<T>(string documentName)
        {
            return (T)SupportingDocuments[documentName];
        }
    }
}
