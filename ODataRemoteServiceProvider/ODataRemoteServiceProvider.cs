using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataRemoteServiceProvider
{
    using Core.Models;
    using Core.Providers;

    class ODataRemoteServiceProvider : IRemoteServiceProvider
    {
        public RemoteServiceProviderEnum RemoteServiceProvider { get; private set; } = RemoteServiceProviderEnum.OData;

        public string ServiceUrl { get; set; }

        public RemoteServiceInfo GetWebServerMetaInfo()
        {
            throw new NotImplementedException();
        }
    }
}
