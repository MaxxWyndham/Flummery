using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace Flummery
{
    public static class FlummeryApplication
    {
        private static readonly List<FlummeryContributor> contributors = new List<FlummeryContributor> {
            new FlummeryContributor { Name = "toshiba-3", Website = "rr2000.cwaboard.co.uk" },
            new FlummeryContributor { Name = "razor", Website = "razor.cwaboard.co.uk" },
            new FlummeryContributor { Name = "trent", Website = "trent.incarnated.co.uk" },
            new FlummeryContributor { Name = "n0bby", Website = "www.shockrods.com" },
            new FlummeryContributor { Name = "shane", Website = "" },
            new FlummeryContributor { Name = "fatcat", Website = "" },
            new FlummeryContributor { Name = "alextsk", Website = "alextsekot.com" },
            new FlummeryContributor { Name = "cwaboard", Website = "www.cwaboard.co.uk" },
            new FlummeryContributor { Name = "art0rz", Website = "github.com/art0rz" }
        };

        private static readonly KnownColor[] knownColourNames = (KnownColor[])Enum.GetValues(typeof(KnownColor));

        public static frmMain UI;
        public static bool Active;
        public static CultureInfo Culture = new CultureInfo("en-gb");
        public static string Version = "0.3.8.9";
        public static Random Random = new Random();

        public static Color PickRandomColour()
        {
            return Color.FromKnownColor(knownColourNames[Random.Next(knownColourNames.Length)]);
        }

        public static FlummeryContributor PickRandomContributor()
        {
            return contributors.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }
    }

    public class FlummeryContributor
    {
        public string Name { get; set; }

        public string Website { get; set; }
    }
}
