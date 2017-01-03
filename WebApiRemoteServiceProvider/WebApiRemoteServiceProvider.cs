using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiRemoteServiceProvider
{
    using Core.Models;
    using Core.Providers;
    using Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Net;

    public class WebApiRemoteServiceProvider : IRemoteServiceProvider
    {
        public RemoteServiceProviderEnum RemoteServiceProvider { get; private set; } = RemoteServiceProviderEnum.WebApi;
        
        public RemoteServiceInfo GetWebServerMetaInfo(string serviceUrl)
        {
            var swaggetInfo = new SwaggerApiInfo();

            using (var _client = new WebClient())
            {
                var res = _client.DownloadString(serviceUrl);

                var jsonParser = new SwaggerJsonParser();
                // delete

                swaggetInfo = jsonParser.Parse(res);
            }

            var parser = new SwaggerInfoParser();
            var prsInfo = parser.Parse(swaggetInfo);

            return prsInfo;
        }

        public RemoteServiceInfo ParseFile(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                throw new Exception("Не правильный путь к файлу. Path: '" + path + "'");
            }

            var swaggerJsonStr = System.IO.File.ReadAllText(path);

            var jsonParser = new SwaggerJsonParser();

            var swaggetInfo = jsonParser.Parse(swaggerJsonStr);

            var parser = new SwaggerInfoParser();
            var prsInfo = parser.Parse(swaggetInfo);

            return prsInfo;
        }
        
    }
}
