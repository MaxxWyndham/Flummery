using System;
using System.Collections.Generic;

namespace Flummery.Core
{
    public class MaterialList : AssetList
    {
        public MaterialList() : base() { }

        public IEnumerator<Material> GetEnumerator()
        {
            return base.GetEnumerator<Material>();
        }
    }
}
