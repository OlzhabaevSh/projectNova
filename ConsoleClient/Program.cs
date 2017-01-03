using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    using WebApiRemoteServiceProvider;
    using WebApiRemoteServiceProvider.Models;

    using ODataRemoteServiceProvider;

    class Program
    {
        static void Main(string[] args)
        {
            var provider = new WebApiRemoteServiceProvider();
            //serviceUrl = "http://localhost:50591/swagger/docs/v1";

            //var provider = new ODataRemoteServiceProvider();
            //serviceUrl = "http://localhost:50591/odata/$metadata";

            Console.WriteLine("Write file path, please");
            var path = Console.ReadLine();

            //TODO: for test
            path = "D:/NovaProjData/swaggerdata.json";
            //path = "D:/NovaProjData/odataV3metadata.xml";
            
            var res = provider.ParseFile(path);
        }
    }
}
