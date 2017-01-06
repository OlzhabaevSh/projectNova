using Core.Models;
using Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CodeGenerators
{
    public enum Framework
    {
        AngularJS,
        JQuery,
        ReactJS
    }

    public enum ComponentType
    {
        ViewModelDts,
        ProxyService,
        ProxyServiceWithLinq,
        CrudComponent
    }

    public interface ICodeGenerator
    {
        Framework Framework { get; }

        string GenerateFile(RemoteServiceInfo info, ComponentType componentType, RemoteServiceProviderEnum remoteService,string path, string fileName);
    }
}
