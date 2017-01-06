using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJSTemplates
{
    public partial class AngularViewModels
    {
        public RemoteServiceInfo Model { get; set; }
    }

    public partial class AngularODataHttpService
    {
        public RemoteServiceInfo Model { get; set; }
    }

    public partial class AngularWebApiHttpService
    {
        public RemoteServiceInfo Model { get; set; }
    }

}
