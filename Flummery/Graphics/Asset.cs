using System;

namespace Flummery
{
    public abstract class Asset 
    {
        protected string name;
        protected object tag;

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

        public virtual Asset Clone()
        {
            return this;
        }
    }
}
