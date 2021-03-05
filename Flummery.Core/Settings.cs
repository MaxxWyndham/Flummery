using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;

namespace Flummery.Core
{
    public class Settings
    {
        [IgnoreDataMember]
        public string FileName { get; set; }

        private object this[string propertyName]
        {
            set
            {
                Type type = GetType();
                PropertyInfo property = type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);

                if (property != null)
                {
                    property.SetValue(this, Convert.ChangeType(value, property.PropertyType), null);
                }
                else
                {
                    Console.WriteLine($"  Invalid setting: {propertyName}");
                }
            }
        }

        public void Load(string file)
        {
            string path = Path.Combine(Environment.CurrentDirectory, file);

            FileName = path;

            if (File.Exists(path))
            {
                foreach (string line in File.ReadAllLines(path))
                {
                    if (line.Trim().StartsWith("#") || line.Trim().Length == 0) { continue; }

                    string[] parts = line.Split(' ');

                    this[parts[0].Replace(".", "")] = parts[2];
                }
            }
        }

        public void Save()
        {
            Type type = GetType();

            using (StreamWriter settings = File.CreateText(FileName))
            {
                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (!Attribute.IsDefined(property, typeof(IgnoreDataMemberAttribute)))
                    {
                        settings.WriteLine($"{property.Name} = {property.GetValue(this)}".ToLower());
                    }
                }
            }
        }
    }
}
