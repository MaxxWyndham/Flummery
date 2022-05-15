using System.Collections.Generic;

using ToxicRagers.Helpers;

namespace Flummery.Core
{
    public class Vertex
    {
        public Vector3 Position { get; set; }

        public Vector3 Normal { get; set; }

        public Vector4 UV { get; set; }

        public Colour Colour { get; set; } = Colour.White;

        public List<int> OriginalIDs { get; set; } = new List<int>();

        public int OriginalID => OriginalIDs.Count > 0 ? OriginalIDs[0] : -1;

        public Vertex Clone()
        {
            return new Vertex
            {
                Position = Position,
                Normal = Normal,
                UV = UV,
                Colour = Colour
            };
        }
    }
}
