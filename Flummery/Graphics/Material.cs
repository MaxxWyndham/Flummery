using System.Collections.Generic;
using System.Linq;

namespace Flummery
{
    public class Material : Asset
    {
        Dictionary<string, Texture> textures = new Dictionary<string, Texture>();
        protected string firstKey = null;

        public Texture Texture
        {
            get => textures.Count > 0 ? textures[firstKey] : null;
            set
            {
                if (textures.Count == 0) { firstKey = value.Name; }
                textures[value.Name] = value;
            }
        }

        public List<Texture> Textures => textures.Values.ToList();
    }

    public class MaterialList : AssetList 
    {
        public MaterialList() : base() { }

        public IEnumerator<Material> GetEnumerator()
        {
            return base.GetEnumerator<Material>();
        }
    }
}
