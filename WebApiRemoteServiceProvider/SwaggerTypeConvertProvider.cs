using Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiRemoteServiceProvider
{
    class SwaggerTypeConvertProvider : ITypeConvertProvider
    {
        private Dictionary<string, string> _typeDictionary;

        public SwaggerTypeConvertProvider()
        {
            _typeDictionary = new Dictionary<string, string>();

            _typeDictionary.Add("integer","number");
            _typeDictionary.Add("number", "number");

            _typeDictionary.Add("string", "string");

            _typeDictionary.Add("byte", "any");
            _typeDictionary.Add("binary", "any");

            _typeDictionary.Add("boolean", "boolean");

            _typeDictionary.Add("date", "string");
            _typeDictionary.Add("date-time", "string");
        }

        public string ConvertType(string type)
        {
            if (!_typeDictionary.Any(x => x.Key == type))
            {
                return type;
            }

            var typeRes = _typeDictionary.FirstOrDefault(x => x.Key == type);

            return typeRes.Value;
        }
    }
}
