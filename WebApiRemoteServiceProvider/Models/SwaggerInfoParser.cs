using Core.Models;
using Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiRemoteServiceProvider.Models
{
    class SwaggerInfoParser
    {
        private ITypeConvertProvider _cvt = new SwaggerTypeConvertProvider();

        public RemoteServiceInfo Parse(SwaggerApiInfo info)
        {
            var res = new RemoteServiceInfo()
            {
                ModulName = info.Info.Title,
                BaseUrl = info.Host,
                Controllers = new List<ControllerInfo>(),
                Models = new List<ModelInfo>()
            };

            foreach (var dfn in info.Definitions)
            {
                var mdl = new ModelInfo()
                {
                    Title = dfn.Title,
                    Properties = new List<PropertyInfo>()
                };

                foreach (var prp in dfn.Properties)
                {
                    var prpInfo = new PropertyInfo();

                    prpInfo.IsPrimitive = prp.IsPrimitive;

                    prpInfo.Title = _cvt.ConvertType(prp.Title);

                    if (prp.Type == "array")
                    {
                        prpInfo.Array = true;
                        prpInfo.Type = _cvt.ConvertType(prp.Generic);
                    }
                    else
                    {
                        prpInfo.Type = _cvt.ConvertType(prp.Type);
                    }
                    mdl.Properties.Add(prpInfo);
                }

                res.Models.Add(mdl);
            }

            var controllers = new List<ControllerInfo>();

            foreach (var pth in info.Paths)
            {
                var url = pth.Url; 
                // '/api/controllerName'
                if (pth.Url.Contains("/api/"))
                {
                    var indexStart = pth.Url.IndexOf("/api/");
                    url = pth.Url.Remove(indexStart, 5);
                }

                var ctrl = controllers.FirstOrDefault(x => x.Name == url);

                if (ctrl == null)
                {
                    ctrl = new ControllerInfo()
                    {
                        Url = url,
                        Name = url,
                        Actions = new List<ActionInfo>()
                    };
                    controllers.Add(ctrl);
                }

                if (!url.Contains('/'))
                {
                    var actionName = url;

                    var actInfo = ParseActions(pth, actionName);

                    ctrl.Actions.Add(actInfo);
                }
                else
                {
                    var startIndex = url.IndexOf('/');
                    var actionName = url.Substring(startIndex + 1);

                    var actInfo = ParseActions(pth, actionName);

                    ctrl.Actions.Add(actInfo);
                }
            }

            res.Controllers = controllers;

            return res;
        }

        private ActionInfo ParseActions(Path pth, string actionName)
        {
            if (pth.Response.Type == null)
            {
                pth.Response.Type = string.Empty;
            }

            if (pth.Response.Generic == null)
            {
                pth.Response.Generic = string.Empty;
            }
            
            StringBuilder name = new StringBuilder(pth.Method);

            if (pth.Response.Type == "array")
            {
                name.Append("Collection");
            }
            else
            {
                name.Append("Item");
            }

            var actInfo = new ActionInfo()
            {
                Url = actionName,
                Name = name.ToString(),
                Method = pth.Method,
                IsPrimitive = pth.Response.IsPrimitive,
                ReponseModel = pth.Response.Type != "array" ? pth.Response.Type : pth.Response.Generic,
                IsArrayResponse = pth.Response.Type == "array",
                Parameters = new List<PropertyInfo>()
            };

            foreach (var prp in pth.Parameters)
            {
                var propInfo = new PropertyInfo()
                {
                    Nullable = prp.Required,
                    Title = prp.Name,
                    Type = prp.Type,
                    IsPrimitive = prp.IsPrimitive,
                    WithUrl = prp.WithUrl
                };

                actInfo.Parameters.Add(propInfo);
            }

            return actInfo;
        }
        
    }
}
