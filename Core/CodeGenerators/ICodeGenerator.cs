using Core.Models;
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

        string GenerateFile(RemoteServiceInfo info, ComponentType componentType, string path, string fileName);
    }
}
