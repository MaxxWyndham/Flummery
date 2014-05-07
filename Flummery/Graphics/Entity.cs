using System;
using OpenTK;

namespace Flummery
{
    public enum AssetType
    {
        Sprite,
        Model
    }

    public enum EntityType
    {
        Accessory,
        Powerup
    }

    public class Entity
    {
        string uniqueIdentifier;
        string name;
        string tag;
        EntityType entityType = EntityType.Powerup;
        Matrix4 transform;
        Asset asset;
        AssetType assetType = AssetType.Model;

        public string UniqueIdentifier
        {
            get { return uniqueIdentifier; }
            set { uniqueIdentifier = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public EntityType EntityType
        {
            get { return entityType; }
            set { entityType = value; }
        }

        public Matrix4 Transform
        {
            get { return transform; }
            set { transform = value; }
        }
    }
}
