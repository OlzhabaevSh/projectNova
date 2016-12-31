using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Providers
{
    using Models;

    public enum RemoteServiceProviderEnum
    {
        OData,
        Soap,
        WebApi,
        SignalR,
        Reflection
    }
    
    public interface IRemoteServiceProvider
    {
        RemoteServiceProviderEnum RemoteServiceProvider { get; }

        string ServiceUrl { get; set; }

        RemoteServiceInfo GetWebServerMetaInfo();
        
    }
}
