using Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiRemoteServiceProvider.Models
{
    class SwaggerJsonParser
    {
        public SwaggerApiInfo Parse(string jsonData)
        {
            var swaggetInfo = new SwaggerApiInfo();

            var deserJson = JsonConvert.DeserializeObject(jsonData) as JObject;

            // parse main info
            swaggetInfo.Swagger = deserJson.GetValue("swagger").Value<string>();
            swaggetInfo.Info = new Info()
            {
                Title = deserJson.GetValue("info").Value<JObject>().GetValue("title").Value<string>(),
                Version = deserJson.GetValue("info").Value<JObject>().GetValue("version").Value<string>()
            };
            swaggetInfo.Host = deserJson.GetValue("host").Value<string>();
            swaggetInfo.Schemes = deserJson.GetValue("schemes").Value<JArray>().Select(x => x.Value<string>()).ToList();

            // parse definistions
            swaggetInfo.Definitions = new List<Definition>();
            var definitions = deserJson.GetValue("definitions").Value<JObject>();
            foreach (var s in definitions)
            {
                var sd = new Definition()
                {
                    Title = s.Key,
                    Type = s.Value.Value<JObject>().GetValue("type").Value<string>(),
                    Properties = new List<Property>()
                };

                var props = s.Value.Value<JObject>().GetValue("properties").Value<JObject>();

                foreach (var pr in props)
                {
                    var nprs = new Property()
                    {
                        Title = pr.Key
                    };

                    var prFormat = pr.Value.Value<JObject>().GetValue("format");
                    var prObj = pr.Value.Value<JObject>().GetValue("type");
                    var hrefObj = pr.Value.Value<JObject>().GetValue("$ref");

                    if (hrefObj != null)
                    {
                        var href = pr.Value.Value<JObject>().GetValue("$ref").Value<string>();
                        var lastSlashIndex = href.LastIndexOf('/');
                        nprs.Type = href.Substring(lastSlashIndex + 1);
                        nprs.IsPrimitive = false;
                    }
                    else if (prObj != null && prFormat != null)
                    {
                        var tp = prObj.Value<string>();
                        var frmt = prFormat.Value<string>();

                        var type = TypeOrFormat(tp, frmt);

                        nprs.Type = type;
                    }
                    else if(prObj != null)
                    {
                        nprs.Type = prObj.Value<string>();
                        if (nprs.Type == "array")
                        {
                            var items = pr.Value.Value<JObject>().GetValue("items").Value<JObject>().GetValue("$ref").Value<string>();
                            var lastSlashIndex = items.LastIndexOf('/');
                            nprs.Generic = items.Substring(lastSlashIndex + 1);
                            nprs.IsPrimitive = false;
                        }
                    }
                    

                    sd.Properties.Add(nprs);
                }
                swaggetInfo.Definitions.Add(sd);
            }

            // parsing paths
            var paths = deserJson.GetValue("paths").Value<JObject>();
            swaggetInfo.Paths = new List<Path>();
            foreach (var pt in paths)
            {
                var urlStr = string.Empty;

                var withUrlParams = false;

                if (pt.Key.Contains("/{") == true)
                {
                    var index = pt.Key.IndexOf("/{");
                    urlStr = pt.Key.Substring(0, index);
                    withUrlParams = true;
                }
                else
                {
                    urlStr = pt.Key;
                }

                var methods = pt.Value.Value<JObject>();

                foreach (var mth in methods)
                {
                    var path = new Path()
                    {
                        Url = urlStr,
                        WithUrlParams = withUrlParams,
                        Method = mth.Key,
                        Parameters = new List<Parameter>()
                    };

                    var methodInfo = mth.Value.Value<JObject>();

                    path.Tags = methodInfo.GetValue("tags").Value<JArray>().Select(x => x.Value<string>()).ToList();

                    var reqParams = methodInfo.GetValue("parameters");

                    if (reqParams != null)
                    {
                        var rPrms = reqParams.Value<JArray>();

                        foreach (var prm in rPrms)
                        {
                            var prmetr = new Parameter()
                            {
                                Name = prm.Value<JObject>().GetValue("name").Value<string>(),
                                In = prm.Value<JObject>().GetValue("in").Value<string>(),
                                Required = prm.Value<JObject>().GetValue("required").Value<bool>(),
                                //Type = prm.Value<JObject>().GetValue("type").Value<string>(),
                            };
                            
                            if (prmetr.Name.ToLower() == "id")
                            {
                                prmetr.WithUrl = true;
                            }

                            var type = prm.Value<JObject>().GetValue("type");
                            if (type != null)
                            {
                                prmetr.Type = prm.Value<JObject>().GetValue("type").Value<string>();
                            }
                            else
                            {
                                var href = prm.Value<JObject>().GetValue("schema").Value<JObject>().GetValue("$ref").Value<string>();
                                var lastIndex = href.LastIndexOf('/');
                                prmetr.Type = href.Substring(lastIndex + 1);
                                prmetr.IsPrimitive = false;
                            }

                            path.Parameters.Add(prmetr);
                        }
                    }

                    var responses = methodInfo.GetValue("responses").Value<JObject>();

                    if (responses != null)
                    {
                        foreach (var codeRsp in responses)
                        {
                            var rsp = new Response()
                            {
                                Code = codeRsp.Key
                            };

                            var codeItem = codeRsp.Value.Value<JObject>();

                            var scha = codeItem.GetValue("schema");

                            if (scha != null)
                            {
                                var schema = scha.Value<JObject>();

                                var type = schema.GetValue("type");
                                if (type != null)
                                {
                                    rsp.Type = type.Value<string>();
                                    if (rsp.Type == "array")
                                    {
                                        var href = schema.GetValue("items").Value<JObject>().GetValue("$ref").Value<string>();
                                        var index = href.LastIndexOf('/');
                                        rsp.Generic = href.Substring(index + 1);
                                        rsp.IsPrimitive = false;
                                    }
                                }
                                else
                                {
                                    var href = schema.GetValue("$ref").Value<string>();
                                    var index = href.LastIndexOf('/');
                                    rsp.Type = href.Substring(index + 1);
                                    rsp.IsPrimitive = false;
                                }

                            }

                            path.Response = rsp;
                            break;
                        }
                    }

                    swaggetInfo.Paths.Add(path);
                }
            }

            return swaggetInfo;
        }

        private string TypeOrFormat(string type, string format)
        {
            if (type == "integer" || type == "number")
            {
                return type;
            }
            else if (type == "boolean")
            {
                return type;
            }
            else if (format == "byte" || format == "binary")
            {
                return format;
            }
            else if (format == "date" || format == "date-time")
            {
                return format;
            }
            else
            {
                return type;
            }
        }

    }
}
