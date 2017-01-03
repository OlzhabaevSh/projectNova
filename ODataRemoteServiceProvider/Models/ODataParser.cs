using Core.Models;
using Core.Providers;
using ODataRemoteServiceProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataRemoteServiceProvider.Models
{
    class ODataParser
    {
        public RemoteServiceInfo Parse(V3.Edmx edmx)
        {
            var res = new RemoteServiceInfo()
            {
                Controllers = new List<ControllerInfo>(),
                Models = new List<ModelInfo>(),
                BaseUrl = ""
            };

            var dataService = edmx.DataServices.Schema.First(x => x.Namespace != "Default");

            // get moduleName
            if (dataService.Namespace.Contains('.'))
            {
                res.ModulName = dataService.Namespace.Remove(dataService.Namespace.IndexOf('.'));
            }
            else
            {
                res.ModulName = dataService.Namespace;
            }

            ITypeConvertProvider cnvrt = new OData3TypeConverter();

            // get models
            dataService.EntityType.ToList().ForEach(type => 
            {
                var mdl = new ModelInfo()
                {
                    Title = type.Name, 
                    Properties = new List<PropertyInfo>()
                };

                type.Property.ToList().ForEach(prp => 
                {
                    var prpInro = new PropertyInfo()
                    {
                        Title = prp.Name,
                        Type = cnvrt.ConvertType(prp.Type),
                        Nullable =prp.Nullable,     
                        IsPrimitive = true 
                        // TODO: about array    
                    };

                    if (type.Key.PropertyRef.Name == prp.Name)
                    {
                        prpInro.WithUrl = true;
                    }

                    mdl.Properties.Add(prpInro);
                });

                type.NavigationProperty.ToList().ForEach(nvgProp =>
                {
                    var prpInro = new PropertyInfo()
                    {
                        Title = nvgProp.Name,
                        Type = nvgProp.Name,
                        IsPrimitive = false
                    };

                    var relation = nvgProp.Relationship.Substring(nvgProp.Relationship.LastIndexOf('.') + 1);

                    // "*", "0..1"
                    var mptcity = dataService.Association.FirstOrDefault(x => x.Name == relation).End.FirstOrDefault(x => x.Role == nvgProp.ToRole).Multiplicity;

                    if (mptcity == "*")
                    {
                        prpInro.Array = true;
                        prpInro.Nullable = true;
                    }
                    else if (mptcity == "0..1")
                    {
                        prpInro.Array = false;
                        prpInro.Nullable = true;
                    }
                    else
                    {
                        prpInro.Array = false;
                        prpInro.Nullable = false;
                    }

                    mdl.Properties.Add(prpInro);
                });

                res.Models.Add(mdl);
            });

            // get controllers
            res.Models.ToList().ForEach(mdl => 
            {
                var ctrl = new ControllerInfo()
                {
                    Url = "/odata/" + mdl.Title,
                    Name = mdl.Title,
                    Actions = new List<ActionInfo>()
                };

                var methods = new List<string>() { "get", "get", "post", "put", "delete" };

                methods.ForEach(mth => 
                {
                    var index = methods.IndexOf(mth);

                    var name = mth;

                    if (index == 0)
                    {
                        name += "Collection";
                    }
                    else
                    {
                        name += "Item";
                    }

                    var act = new ActionInfo()
                    {
                        IsArrayResponse = index == 0 ? true : false,
                        IsPrimitive = false,
                        Method = mth,
                        Name = name,
                        ReponseModel = mdl.Title,
                        Url = "/odata/" + mdl.Title,
                        Parameters = new List<PropertyInfo>()
                    };

                    if (mth == "get")
                    {
                        if (index == 1)
                        {
                            var prop = dataService.EntityType.First(x => x.Name == mdl.Title).Key.PropertyRef.Name;
                            act.Parameters.Add(new PropertyInfo()
                            {
                                Array = false,
                                IsPrimitive = true,
                                Nullable = false,
                                Title = prop,
                                Type = res.Models.First(x => x.Title == prop).Title,
                                WithUrl = true
                            });
                        }
                    }
                    else if (mth == "post")
                    {
                        act.Parameters.Add(new PropertyInfo()
                        {
                            Array = false,
                            IsPrimitive = false,
                            Nullable = false,
                            Title = mdl.Title,
                            Type = res.Models.First(x => x.Title == mdl.Title).Title,
                            WithUrl = false
                        });
                    }
                    else if (mth == "put")
                    {
                        var prop = dataService.EntityType.First(x => x.Name == mdl.Title).Key.PropertyRef.Name;
                        act.Parameters.Add(new PropertyInfo()
                        {
                            Array = false,
                            IsPrimitive = true,
                            Nullable = false,
                            Title = prop,
                            Type = mdl.Properties.First(x => x.Title == prop).Type,
                            WithUrl = true
                        });
                        act.Parameters.Add(new PropertyInfo()
                        {
                            Array = false,
                            IsPrimitive = false,
                            Nullable = false,
                            Title = mdl.Title,
                            Type = res.Models.First(x => x.Title == mdl.Title).Title,
                            WithUrl = false
                        });
                        act.ReponseModel = "";
                    }
                    else if (mth == "delete")
                    {
                        var prop = dataService.EntityType.First(x => x.Name == mdl.Title).Key.PropertyRef.Name;
                        act.Parameters.Add(new PropertyInfo()
                        {
                            Array = false,
                            IsPrimitive = true,
                            Nullable = false,
                            Title = prop,
                            Type = mdl.Properties.First(x => x.Title == prop).Type,
                            WithUrl = true
                        });
                    }

                    ctrl.Actions.Add(act);
                });

                res.Controllers.Add(ctrl);
            });

            return res;
        }
    }
}
