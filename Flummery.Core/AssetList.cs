using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flummery.Core
{
    public abstract class AssetList
    {
        public List<Asset> Entries { get; } = new List<Asset>();

        public virtual IEnumerator<T> GetEnumerator<T>() where T : Asset
        {
            foreach (T asset in Entries)
            {
                yield return asset;
            }
        }
    }
}
