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
        protected Dictionary<string, object> supportingDocuments;
        protected object tag;
        protected long key = DateTime.Now.Ticks;

        protected LinkType linkType;
        protected object link;

        public string FileName
        {
            get => filename;
            set => filename = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public Dictionary<string, object> SupportingDocuments => supportingDocuments;

        public object Tag
        {
            get => tag;
            set => tag = value;
        }

        public Asset()
        {
            supportingDocuments = new Dictionary<string, object>();
        }

        public long Key => key;
        public bool Linked => link != null;

        public virtual Asset Clone()
        {
            return this;
        }

        public void LinkWith(object item, LinkType linkType = LinkType.All)
        {
            link = item;
            this.linkType = linkType;
        }

        public T GetSupportingDocument<T>(string documentName)
        {
            return (T)supportingDocuments[documentName];
        }
    }

    public abstract class AssetList
    {
        protected List<Asset> assets;

        public List<Asset> Entries => assets;

        public AssetList()
        {
            assets = new List<Asset>();
        }

        public virtual IEnumerator<T> GetEnumerator<T>() where T : Asset
        {
            foreach (T asset in assets)
            {
                yield return asset;
            }
        }
    }
}
