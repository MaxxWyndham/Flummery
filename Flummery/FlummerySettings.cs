using System;

using Flummery.Core;

namespace Flummery
{
    public class FlummerySettings : Settings
    {
        public bool CheckForUpdates { get; set; } = true;

        public bool UseFlummeryWorkingDirectory { get; set; } = true;

        public string PersonalAuthor { get; set; }

        public string PersonalWebsite { get; set; }
    }
}
