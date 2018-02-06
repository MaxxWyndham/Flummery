using System.Collections.Generic;

namespace Flummery.ContentPipeline
{
    public class ExportSettings
    {
        Dictionary<string, object> settings;

        public ExportSettings()
        {
            settings = new Dictionary<string, object>();
        }

        public void AddSetting(string setting, object value)
        {
            settings[setting] = value;
        }

        public bool HasSetting(string setting)
        {
            return settings.ContainsKey(setting);
        }

        public T GetSetting<T>(string setting)
        {
            return (T)settings[setting];
        }
    }
}