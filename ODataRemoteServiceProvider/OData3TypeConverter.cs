using Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataRemoteServiceProvider
{
    class OData3TypeConverter : ITypeConvertProvider
    {
        private Dictionary<string, string> _types;

        public OData3TypeConverter()
        {
            _types = new Dictionary<string, string>();

            _types.Add("Null", "any");
            _types.Add("Edm.Binary", "any");
            _types.Add("Edm.Boolean", "boolean");
            _types.Add("Edm.Byte", "any");
            _types.Add("Edm.DateTime", "date");
            _types.Add("Edm.Decimal", "number");
            _types.Add("Edm.Double", "number");
            _types.Add("Edm.Single", "number");
            _types.Add("Edm.Guid", "string");
            _types.Add("Edm.Int16", "number");
            _types.Add("Edm.Int32", "number");
            _types.Add("Edm.Int64", "number");
            _types.Add("Edm.SByte", "any");
            _types.Add("Edm.String", "string");
            _types.Add("Edm.Time", "date");
            _types.Add("Edm.DateTimeOffset", "date");
        }

        public string ConvertType(string type)
        {
            if (_types.Any(x => x.Key == type))
            {
                return _types.First(x => x.Key == type).Value;
            }
            else
            {
                return "any";
            }
            
        }
    }
}
