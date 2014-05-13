using System;

namespace Flummery
{
    public class Material : Asset
    {
        Texture texture;

        public Texture Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public Material()
        {
            texture = new Texture();
        }
    }

    public class MaterialList : AssetList { }
}
