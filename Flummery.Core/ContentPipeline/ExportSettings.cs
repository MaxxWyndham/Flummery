using System.Collections.Generic;

namespace Flummery.Core.ContentPipeline
{
    public class ExportSettings
    {
        public Dictionary<string, object> Settings { get; } = new Dictionary<string, object>();

        public void AddSetting(string setting, object value)
        {
            Settings[setting] = value;
        }

        public bool HasSetting(string setting)
        {
            return Settings.ContainsKey(setting);
        }

        public T GetSetting<T>(string setting)
        {
            return (T)Settings[setting];
        }
    }
}