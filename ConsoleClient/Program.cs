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
    using AngularJSTemplates;
    using Core.CodeGenerators;
    using Core.Providers;

    class Program
    {
        static void Main(string[] args)
        {
            //var provider = new WebApiRemoteServiceProvider();
            //serviceUrl = "http://localhost:50591/swagger/docs/v1";

            //var provider = new ODataRemoteServiceProvider();
            //serviceUrl = "http://localhost:50591/odata/$metadata";

            //TODO: for test
            //path = "D:/NovaProjData/swaggerdata.json";
            //path = "D:/NovaProjData/odataV3metadata.xml";
            Console.WriteLine("[0 - AngularJS, 1 - JQuery (for future), 2 - ReactJS (for future)]");
            Console.Write("Select framework: ");
            var frameWork = (Framework)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("- - - - - - - - - - - - ");

            FrameworkAndSourseMapper(frameWork);
            
        }

        static void FrameworkAndSourseMapper(Framework framework)
        {
            if (framework == Framework.AngularJS)
            {
                Console.WriteLine("[0 - OData, 1 - SOAP (for future), 2 - WebApi (for future), 3 - SignalR (for future), 4 - Reflection (for future)]");
                Console.Write("Select sourse type: ");
                var sourseService = (RemoteServiceProviderEnum)Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("- - - - - - - - - - - - ");

                SourseAndComponentToAnugularMapper(sourseService);
            }
            else if (framework == Framework.JQuery)
            {
                throw new NotImplementedException("JQuery is not created");
            }
            else if (framework == Framework.ReactJS)
            {
                throw new NotImplementedException("React is not created");
            }
            else
            {
                throw new NotImplementedException("Error selected: " + framework);
            }
        }

        static void SourseAndComponentToAnugularMapper(RemoteServiceProviderEnum remoteService)
        {
            IRemoteServiceProvider provider;

            if (remoteService == RemoteServiceProviderEnum.OData)
            {
                provider = new ODataRemoteServiceProvider();
            }
            else if (remoteService == RemoteServiceProviderEnum.WebApi)
            {
                provider = new WebApiRemoteServiceProvider();
            }
            else
            {
                throw new NotImplementedException("Selected sourse not ready");
            }

            Console.WriteLine("[0 - only ViewModels, 1 - Services with viewModels]");
            Console.Write("Select component type: ");
            var componentType = (ComponentType)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("- - - - - - - - - - - - ");

            Console.Write("Write file path, please: ");
            var path = Console.ReadLine();
            Console.WriteLine("- - - - - - - - - - - - ");

            var res = provider.ParseFile(path);

            Console.Write("Write file name: [example: core]: ");
            var name = Console.ReadLine();

            ICodeGenerator generator = new AngularCodeGenerator();

            if (componentType == ComponentType.ViewModelDts)
            {
                generator.GenerateFile(res, ComponentType.ViewModelDts, "", name);
            }
            else if (componentType == ComponentType.ProxyService)
            {
                generator.GenerateFile(res, ComponentType.ViewModelDts, "", name);
                generator.GenerateFile(res, ComponentType.ProxyService, "", name);
            }

        }

    }
}
