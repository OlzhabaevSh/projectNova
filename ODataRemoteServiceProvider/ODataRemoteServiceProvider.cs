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
    using System.IO;
    using System.Net;
    using System.Xml;
    using System.Xml.Serialization;

    public class ODataRemoteServiceProvider : IRemoteServiceProvider
    {
        private string _fileName = "odataMetadata.xml";

        public RemoteServiceProviderEnum RemoteServiceProvider { get; private set; } = RemoteServiceProviderEnum.OData;

        public string ServiceUrl { get; set; } // "http://tas.ddnsfree.com:40001/odata/$metadata"

        public RemoteServiceInfo GetWebServerMetaInfo()
        {
            Edmx res = new Edmx();

            using (var webClient = new WebClient())
            {
                var url = ServiceUrl;

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
    }
}
