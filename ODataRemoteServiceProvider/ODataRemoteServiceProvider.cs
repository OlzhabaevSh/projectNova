using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataRemoteServiceProvider
{
    using Core.Models;
    using Core.Providers;
    using Models;
    using Models.V3;
    using System.IO;
    using System.Net;
    using System.Xml;
    using System.Xml.Serialization;

    public class ODataRemoteServiceProvider : IRemoteServiceProvider
    {
        private string _fileName = "odataMetadata.xml";

        public RemoteServiceProviderEnum RemoteServiceProvider { get; private set; } = RemoteServiceProviderEnum.OData;
        
        public RemoteServiceInfo GetWebServerMetaInfo(string serviceUrl)
        {
            Edmx res = new Edmx();

            using (var webClient = new WebClient())
            {
                var url = serviceUrl;

                webClient.DownloadFile(url, _fileName);

                try
                {
                    var serializer = new XmlSerializer(typeof(Edmx));

                    using (var reader = XmlReader.Create(_fileName))
                    {
                        res = serializer.Deserialize(reader) as Edmx;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //throw new Exception("Error from get EDMX.xml", ex);
                }
                finally
                {
                    File.Delete(_fileName);
                }

            }

            var parser = new ODataParser();
            var prsOdata = parser.Parse(res);

            return prsOdata;
        }

        public RemoteServiceInfo ParseFile(string path)
        {
            Edmx res = new Edmx();

            try
            {
                var serializer = new XmlSerializer(typeof(Edmx));

                using (var reader = XmlReader.Create(path))
                {
                    res = serializer.Deserialize(reader) as Edmx;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw new Exception("Error from get EDMX.xml", ex);
            }
            finally
            {
                //File.Delete(_fileName);
            }

            var parser = new ODataParser();
            var prsOdata = parser.Parse(res);

            return prsOdata;
        }
    }
}
