using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flummery.Core
{
    public class Asset
    {
        public string Name { get; set; }

        public object Tag { get; set; }

        public Dictionary<string, object> SupportingDocuments { get; } = new Dictionary<string, object>();

        public T GetSupportingDocument<T>(string documentName)
        {
            return (T)SupportingDocuments[documentName];
        }
    }
}
