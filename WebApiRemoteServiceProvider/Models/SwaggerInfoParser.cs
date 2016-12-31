using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiRemoteServiceProvider.Models
{
    class SwaggerInfoParser
    {
        public RemoteServiceInfo Parse(SwaggerApiInfo info)
        {
            var res = new RemoteServiceInfo()
            {
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

                    prpInfo.Title = prp.Title;

                    if (prp.Type == "array")
                    {
                        prpInfo.Array = true;
                        prpInfo.Type = prp.Generic;
                    }
                    else
                    {
                        prpInfo.Type = prp.Type;
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
            var actInfo = new ActionInfo()
            {
                Url = actionName,
                Name = string.Format("{0}Data", pth.Method),
                Method = pth.Method,
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
                    Type = prp.Type
                };

                actInfo.Parameters.Add(propInfo);
            }

            return actInfo;
        }

    }
}
