﻿namespace Flummery.Core
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

        public List<Texture> Textures => textures.Values.ToList();

        public void SetTexture(string name, Texture texture)
        {
            textures[name] = texture;
        }
    }
}
