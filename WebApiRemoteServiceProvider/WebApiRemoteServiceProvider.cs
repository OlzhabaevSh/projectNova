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

            RemoteServiceInfo res = new RemoteServiceInfo();

            using (var _client = new WebClient())
            {
                var swaggerJsonStr = _client.DownloadString(serviceUrl);

                try
                {
                    var jsonParser = new SwaggerJsonParser();

                    swaggetInfo = jsonParser.Parse(swaggerJsonStr);
                }
                catch (Exception ex)
                {
                    throw new Exception("Parse json failed", ex);
                }

                try
                {
                    var parser = new SwaggerInfoParser();
                    res = parser.Parse(swaggetInfo);
                }
                catch (Exception ex)
                {
                    throw new Exception("Parse to GeneralInfo failed", ex);
                }

                return res;
            }
        }

        public RemoteServiceInfo ParseFile(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                throw new Exception("Не правильный путь к файлу. Path: '" + path + "'");
            }

            RemoteServiceInfo res = new RemoteServiceInfo();

            var swaggerJsonStr = System.IO.File.ReadAllText(path);

            SwaggerApiInfo swaggetInfo = new SwaggerApiInfo();

            try
            {
                var jsonParser = new SwaggerJsonParser();

                swaggetInfo = jsonParser.Parse(swaggerJsonStr);
            }
            catch (Exception ex)
            {
                throw new Exception("Parse json failed", ex);
            }

            try
            {
                var parser = new SwaggerInfoParser();
                res = parser.Parse(swaggetInfo);
            }
            catch (Exception ex)
            {
                throw new Exception("Parse to GeneralInfo failed", ex);
            }
            
            return res;
        }
        
    }
}
