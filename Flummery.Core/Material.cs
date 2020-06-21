using System;
using System.Collections.Generic;

namespace Flummery.Core
{
    public class Material : Asset
    {
        private readonly Dictionary<string, Texture> textures = new Dictionary<string, Texture>();
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
    }
}
