using System;
using System.Collections.Generic;

namespace Flummery
{
    public abstract class Asset 
    {
        protected string filename;
        protected string name;
        protected object tag;

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

        public bool Linked { get { return link != null; } }

        public virtual Asset Clone()
        {
            return this;
        }

        public void LinkWith(object item)
        {
            link = item;
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
