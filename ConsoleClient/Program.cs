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
            //var provider = new WebApiRemoteServiceProvider();
            //provider.ServiceUrl = "http://localhost:50591/swagger/docs/v1";
            
            var provider = new ODataRemoteServiceProvider();
            provider.ServiceUrl = "http://localhost:50591/odata/$metadata";

            var res = provider.GetWebServerMetaInfo();

        }
    }
}
