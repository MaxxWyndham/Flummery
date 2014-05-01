using System;
using OpenTK;

namespace OpenTK
{
    public static class ExtensionMethods
    {
        public static Vector3 Forward(this Matrix4 m)
        {
            return -(new Vector3(m.M31, m.M32, m.M33));
        }

        public static Vector3 Position(this Matrix4 m)
        {
            return new Vector3(m.M41, m.M42, m.M43);
        }

        public static void NormaliseForward(this Matrix4 m)
        {
            var v = m.Forward();
            v.Normalize();
            m.M31 = v.X;
            m.M32 = v.Y;
            m.M33 = v.Z;
        }
    }
}
