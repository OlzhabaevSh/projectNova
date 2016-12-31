using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapRemoteServiceProvider
{
    using Core.Models;
    using Core.Providers;

    public class SoapRemoteServiceProvider : IRemoteServiceProvider
    {
        public RemoteServiceProviderEnum RemoteServiceProvider { get; private set; } = RemoteServiceProviderEnum.Soap;

        public string ServiceUrl { get; set; }

        public RemoteServiceInfo GetWebServerMetaInfo()
        {
            throw new NotImplementedException();
        }
    }
}
