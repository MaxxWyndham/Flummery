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

        public LinkType LinkType { get; private set; }

        public object Link { get; private set; }

        public bool Linked => Link != null;

        public virtual Asset Clone()
        {
            return this;
        }

        public void LinkWith(object item, LinkType linkType = LinkType.All)
        {
            Link = item;
            LinkType = linkType;
        }

        public T GetSupportingDocument<T>(string documentName)
        {
            return (T)SupportingDocuments[documentName];
        }
    }
}
