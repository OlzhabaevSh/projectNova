using Core.CodeGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using System.IO;

namespace AngularJSTemplates
{
    public class AngularCodeGenerator : ICodeGenerator
    {
        public Framework Framework { get; private set; } = Framework.AngularJS;

        public string GenerateFile(RemoteServiceInfo info, ComponentType componentType, string path, string fileName)
        {
            var res = MatchCodeGenerator(info, componentType);

            var fullPath = path != string.Empty ? path + "/" + fileName : fileName;

            fullPath.Replace(@"\\", "/");
            fullPath.Replace(@"//", "/");
            fullPath.Replace(@"\/", "/");

            if (componentType == ComponentType.ViewModelDts)
            {
                if (!fileName.Contains(".d.ts"))
                {
                    fileName.Replace(".ts", "");
                    fullPath += ".d.ts";
                }
            }

            if (componentType == ComponentType.ProxyService)
            {
                if (!fileName.Contains(".service.ts"))
                {
                    fileName.Replace(".ts", "");
                    fullPath += ".service.ts";
                }
            }
            
            using (StreamWriter sw = File.CreateText(fullPath))
            {
                sw.Write(res);
            }

            return fullPath;
        }

        private string MatchCodeGenerator(RemoteServiceInfo info, ComponentType componentType)
        {
            var str = string.Empty;

            // here matching
            if (componentType == ComponentType.ViewModelDts)
            {
                str = GenerateViewModels(info);
            }
            else if (componentType == ComponentType.ProxyService)
            {
                str = GenerateService(info);
            }
            else if (componentType == ComponentType.ProxyServiceWithLinq)
            {
                throw new NotImplementedException("ComponentType.ProxyService not created");
            }
            else if (componentType == ComponentType.CrudComponent)
            {
                throw new NotImplementedException("ComponentType.ProxyService not created");
            }

            return str;
        }

        private string GenerateViewModels(RemoteServiceInfo info)
        {
            var angOdataVM = new AngularViewModels();
            angOdataVM.Model = info;

            var res = angOdataVM.TransformText();

            return res;
        }

        private string GenerateService(RemoteServiceInfo info)
        {
            var srv = new AngularODataHttpService();
            srv.Model = info;

            var res = srv.TransformText();

            return res;
        }


    }
}
