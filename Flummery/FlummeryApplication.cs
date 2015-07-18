using System;
using System.Drawing;
using System.Globalization;

namespace Flummery
{
    public static class FlummeryApplication
    {
        private static KnownColor[] knownColourNames = (KnownColor[])Enum.GetValues(typeof(KnownColor));

        public static frmMain UI;
        public static bool Active;
        public static CultureInfo Culture = new CultureInfo("en-gb");
        public static string Version = "0.3.7.2";
        public static Random Random = new Random();

        public static Color PickRandomColour()
        {
            return Color.FromKnownColor(knownColourNames[Random.Next(knownColourNames.Length)]);
        }
    }
}
