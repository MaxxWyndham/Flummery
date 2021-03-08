using System;

namespace Flummery.Core
{
    public static class ExtensionMethods
    {
        public static long NextLong(this Random random)
        {
            return random.NextLong(0, long.MaxValue);
        }
        public static long NextLong(this Random random, long min, long max)
        {
            ulong range = (ulong)(max - min);

            ulong r;

            do
            {
                byte[] b = new byte[8];
                random.NextBytes(b);
                r = (ulong)BitConverter.ToInt64(b, 0);
            } while (r > ulong.MaxValue - ((ulong.MaxValue % range) + 1) % range);

            return (long)(r % range) + min;
        }
    }
}
