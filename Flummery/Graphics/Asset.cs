using System;

namespace Flummery
{
    public abstract class Asset 
    {
        protected string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
