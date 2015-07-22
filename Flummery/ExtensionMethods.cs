using System;

using Flummery;

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

        public static Vector3 ToEuler(this Quaternion q, RotationOrder order)
        {
            Vector3 r = Vector3.Zero;
            //Single test = q.X * q.Y + q.Z * q.W;

            //if (test > 0.499f)
            //{
            //    r.X = 0;
            //    r.Y = (Single)MathHelper.RadiansToDegrees(Math.Atan2(q.X, q.W));
            //    r.Z = 90;
            //}
            //else if (test < -0.499f)
            //{
            //    r.X = 0;
            //    r.Y = -(Single)MathHelper.RadiansToDegrees(Math.Atan2(q.X, q.W));
            //    r.Z = -90;
            //}
            //else
            //{
            //    r.X = (Single)MathHelper.RadiansToDegrees(Math.Atan2(2 * q.X * q.W - 2 * q.Y * q.Z, 1 - 2 * (q.X * q.X) - 2 * (q.Z * q.Z)));
            //    r.Y = (Single)MathHelper.RadiansToDegrees(Math.Atan2(2 * q.Y * q.W - 2 * q.X * q.Z, 1 - 2 * (q.Y * q.Y) - 2 * (q.Z * q.Z)));
            //    r.Z = (Single)MathHelper.RadiansToDegrees(Math.Asin(2 * q.X * q.Y + 2 * q.Z * q.W));
            //}

            float r11, r12, r21, r31, r32;
            r11 = r12 = r21 = r31 = r32 = 0;

            switch (order)
            {
                case RotationOrder.OrderXYZ:
                    r11 = -2.0f * (q.X * q.Y - q.W * q.Z); // was r31
                    r21 =  2.0f * (q.X * q.Z + q.W * q.Y);
                    r31 = -2.0f * (q.Y * q.Z - q.W * q.X); // was r11
                    r12 = q.W * q.W + q.X * q.X - q.Y * q.Y - q.Z * q.Z; // was r32
                    r32 = q.W * q.W - q.X * q.X - q.Y * q.Y + q.Z * q.Z; // was r12
                    break;

                case RotationOrder.OrderYZX:
                    r11 = -2.0f * (q.X * q.Z - q.W * q.Y);
                    r12 = q.W * q.W + q.X * q.X - q.Y * q.Y - q.Z * q.Z;
                    r21 = 2.0f * (q.X * q.Y + q.W * q.Z);
                    r31 = -2.0f * (q.Y * q.Z - q.W * q.X);
                    r32 = q.W * q.W - q.X * q.X + q.Y * q.Y - q.Z * q.Z;
                    break;
            }

            r.X = (Single)MathHelper.RadiansToDegrees(Math.Atan2(r31, r32));
            r.Y = (Single)MathHelper.RadiansToDegrees(Math.Asin(r21));
            r.Z = (Single)MathHelper.RadiansToDegrees(Math.Atan2(r11, r12));

            //if (r.X < -90) { r.X += 360; }
            //if (r.Y < -90) { r.Y += 360; }
            //if (r.Z < -90) { r.Z += 360; }

            return r;
        }
    }
}

namespace Flummery
{
    public enum RotationOrder
    {
        OrderXYZ,
        OrderXZY,
        OrderYZX,
        OrderYXZ,
        OrderZXY,
        OrderZYX,
        OrderSphericXYZ
    }

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
