using System.Collections.Generic;
using System.IO;

namespace Flummery.Core
{
    public class FlumpFile
    {
        public Dictionary<string, string> Settings { get; } = new Dictionary<string, string>();

        public static FlumpFile Load(string path)
        {
            FlumpFile flump = new FlumpFile();

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        int i = line.IndexOf(":=");

                        if (i > -1)
                        {
                            flump.Settings[line.Substring(0, i)] = line.Substring(i + 2);
                        }
                    }
                }
            }

            return flump;
        }

        public void Save(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (KeyValuePair<string, string> kvp in Settings)
                {
                    sw.WriteLine($"{kvp.Key}:={kvp.Value}");
                }
            }
        }
    }
}