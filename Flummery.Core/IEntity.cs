using ToxicRagers.Helpers;

namespace Flummery.Core
{
    public interface IEntity
    {
        string Name { get; set; }

        object Tag { get; set; }

        Matrix4D Transform { get; set; }

        void Draw();
    }
}
