using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToxicRagers.Helpers;

namespace Flummery.Core
{
    public enum AssetType
    {
        Sprite,
        Model
    }

    public enum EntityType
    {
        Accessory,
        Bone,
        Checkpoint,
        CopSpawn,
        Driver,
        Grid,
        Light,
        Powerup,
        RaceNode,
        Wheel,
        VFX,
        Crush
    }

    public class Entity : Asset
    {
        public string UniqueIdentifier { get; set; }

        public EntityType EntityType { get; set; } = EntityType.Powerup;

        public AssetType AssetType { get; set; } = AssetType.Model;

        public Matrix4D Transform { get; set; }
    }
}
