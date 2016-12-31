using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionRemoteServiceProvider
{
    using Core.Models;
    using Core.Providers;

    public class ReflectionRemoteServiceProvider : IRemoteServiceProvider
    {
        public RemoteServiceProviderEnum RemoteServiceProvider { get; private set; }

        public string ServiceUrl { get; set; }

        public RemoteServiceInfo GetWebServerMetaInfo()
        {
            throw new NotImplementedException();
        }
    }
}
