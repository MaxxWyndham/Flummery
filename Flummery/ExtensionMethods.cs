using System;
using OpenTK;

namespace OpenTK
{
    public static class ExtensionMethods
    {
        public static Vector3 Right(this Matrix4 m)
        {
            return new Vector3(m.M11, m.M12, m.M13);
        }

        public static Vector3 Up(this Matrix4 m)
        {
            return new Vector3(m.M21, m.M22, m.M23);
        }

        public static Vector3 Forward(this Matrix4 m)
        {
            return -(new Vector3(m.M31, m.M32, m.M33));
        }

        public static void NormaliseRight(this Matrix4 m)
        {
            var v = m.Right();
            v.Normalize();
            m.M11 = v.X;
            m.M12 = v.Y;
            m.M13 = v.Z;
        }

        public static void NormaliseUp(this Matrix4 m)
        {
            var v = m.Up();
            v.Normalize();
            m.M21 = v.X;
            m.M22 = v.Y;
            m.M23 = v.Z;
        }

        public static void NormaliseForward(this Matrix4 m)
        {
            var v = m.Forward();
            v.Normalize();
            m.M31 = v.X;
            m.M32 = v.Y;
            m.M33 = v.Z;
        }

        public static Vector3 Position(this Matrix4 m)
        {
            return new Vector3(m.M41, m.M42, m.M43);
        }
    }
}

namespace Flummery
{
    public static class ExtensionMethods
    {
        public static string Replace(this string originalString, string oldValue, string newValue, StringComparison comparisonType)
        {
            int startIndex = 0;
            while (true)
            {
                startIndex = originalString.IndexOf(oldValue, startIndex, comparisonType);
                if (startIndex == -1)
                    break;

                originalString = originalString.Substring(0, startIndex) + newValue + originalString.Substring(startIndex + oldValue.Length);

                startIndex += newValue.Length;
            }

            return originalString;
        }

        public static bool HasProperty(this dynamic o, string property)
        {
            return o.GetType().GetProperty(property) != null;
        }
    }
}
