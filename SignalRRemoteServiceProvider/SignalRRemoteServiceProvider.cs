using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRRemoteServiceProvider
{
    using Core.Models;
    using Core.Providers;

    public class SignalRRemoteServiceProvider : IRemoteServiceProvider
    {
        public RemoteServiceProviderEnum RemoteServiceProvider { get; private set; } = RemoteServiceProviderEnum.SignalR;

        public string ServiceUrl { get; set; }

        public RemoteServiceInfo GetWebServerMetaInfo()
        {
            throw new NotImplementedException();
        }
    }
}
