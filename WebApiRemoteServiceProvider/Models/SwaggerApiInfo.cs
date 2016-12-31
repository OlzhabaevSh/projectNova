using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiRemoteServiceProvider.Models
{
    public class SwaggerApiInfo
    {
        public string Swagger { get; set; }
        public Info Info { get; set; }
        public string Host { get; set; }
        public ICollection<string> Schemes { get; set; }
        public ICollection<Path> Paths { get; set; }
        public ICollection<Definition> Definitions { get; set; }
    }

    public class Info
    {
        public string Version { get; set; }
        public string Title { get; set; }
    }

    public class Path
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public ICollection<string> Tags { get; set; }
        public ICollection<Parameter> Parameters { get; set; }
        public Response Response { get; set; }
    }

    public class Parameter
    {
        public string Name { get; set; }
        public string In { get; set; }
        public bool Required { get; set; }
        public string Type { get; set; }
        //public Definition Schema { get; set; }
    }

    public class Response
    {
        public string Code { get; set; }
        public string Type { get; set; }
        public string Generic { get; set; }
    }

    public class Definition
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public ICollection<Property> Properties { get; set; }
    }

    public class Property
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Generic { get; set; }
    }

}
