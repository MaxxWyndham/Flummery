using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToxicRagers.Helpers;
using Flummery;
using System.Drawing;

namespace Flummery.Util
{
    class Logger
    {
        public static void Log(string format, params object[] args)
        {
            string formatted = string.Format(format, args);
            ToxicRagers.Helpers.Logger.LogToFile("[LOG] " + format, args);

            frmLog.getInstance().Log(formatted);
            Flummery.UI.SetProgressText(formatted);
        }

        public static void Error(string format, params object[] args)
        {
            string formatted = string.Format(format, args);
            ToxicRagers.Helpers.Logger.LogToFile("[ERROR] " + format, args);

            frmLog.getInstance().Log(formatted, Color.Red);
            Flummery.UI.SetProgressText(formatted, Color.Red);
        }

        public static void Warn(string format, params object[] args)
        {
            string formatted = string.Format(format, args);
            ToxicRagers.Helpers.Logger.LogToFile("[WARNING] " + format, args);

            frmLog.getInstance().Log(formatted, Color.OrangeRed);
            Flummery.UI.SetProgressText(formatted, Color.OrangeRed);
        }
    }
}
