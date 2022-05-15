using System;
using System.Drawing;
using System.Drawing.Drawing2D;

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

        public static Bitmap Resize(this Bitmap bitmap, int maxWidth, int maxHeight)
        {
            int resizeWidth = Math.Min(maxWidth, bitmap.Width);
            int resizeHeight = Math.Min(maxHeight, bitmap.Height);

            if (bitmap.Width == resizeWidth && bitmap.Height == resizeHeight) { return bitmap; }

            Bitmap resized = new Bitmap(resizeWidth, resizeHeight);
            RectangleF srcRect = new RectangleF(0, 0, bitmap.Width, bitmap.Height);
            RectangleF destRect = new RectangleF(0, 0, resizeWidth, resizeHeight);
            Graphics grfx = Graphics.FromImage(resized);

            grfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grfx.DrawImage(bitmap, destRect, srcRect, GraphicsUnit.Pixel);

            return resized;
        }
    }
}
