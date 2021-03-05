using System;

namespace OpenTK
{
    public static class ExtensionMethods
    {
        public static Vector3 Position(this Matrix4 m)
        {
            return new Vector3(m.M41, m.M42, m.M43);
        }

        public static bool Decompose(this Matrix4 m, out Vector3 scale, out Quaternion rotation, out Vector3 translation)
        {
            translation.X = m.M41;
            translation.Y = m.M42;
            translation.Z = m.M43;
            float xs, ys, zs;

            if (Math.Sign(m.M11 * m.M12 * m.M13 * m.M14) < 0)
                xs = -1f;
            else
                xs = 1f;

            if (Math.Sign(m.M21 * m.M22 * m.M23 * m.M24) < 0)
                ys = -1f;
            else
                ys = 1f;

            if (Math.Sign(m.M31 * m.M32 * m.M33 * m.M34) < 0)
                zs = -1f;
            else
                zs = 1f;

            scale.X = xs * (float)Math.Sqrt(m.M11 * m.M11 + m.M12 * m.M12 + m.M13 * m.M13);
            scale.Y = ys * (float)Math.Sqrt(m.M21 * m.M21 + m.M22 * m.M22 + m.M23 * m.M23);
            scale.Z = zs * (float)Math.Sqrt(m.M31 * m.M31 + m.M32 * m.M32 + m.M33 * m.M33);

            if (scale.X == 0.0 || scale.Y == 0.0 || scale.Z == 0.0)
            {
                rotation = Quaternion.Identity;
                return false;
            }

            Matrix3 m1 = new Matrix3(
                m.M11 / scale.X, m.M12 / scale.X, m.M13 / scale.X,
                m.M21 / scale.Y, m.M22 / scale.Y, m.M23 / scale.Y,
                m.M31 / scale.Z, m.M32 / scale.Z, m.M33 / scale.Z
            );

            rotation = Quaternion.FromMatrix(m1);

            return true;
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
    }
}