using System;
using System.Collections.Generic;

namespace Flummery
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
        protected string filename;
        protected string name;
        protected object tag;
        protected long key = DateTime.Now.Ticks;

        protected LinkType linkType;
        protected object link;

        public string FileName
        {
            get { return filename; }
            set { filename = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public long Key { get { return key; } }
        public bool Linked { get { return link != null; } }

        public virtual Asset Clone()
        {
            return this;
        }

        public void LinkWith(object item, LinkType linkType = LinkType.All)
        {
            link = item;
            this.linkType = linkType;
        }
    }

    public abstract class AssetList
    {
        List<Asset> assets;

        public List<Asset> Entries
        {
            get { return assets; }
        }

        public AssetList()
        {
            assets = new List<Asset>();
        }
    }
}
