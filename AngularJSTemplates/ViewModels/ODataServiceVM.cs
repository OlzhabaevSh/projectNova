using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJSTemplates.ViewModels
{
    class ODataServiceVM
    {
        public string ModuleName { get; set; }

        public ICollection<ODataServiceControllerVM> Controllers { get; set; }
        
    }

    class ODataServiceControllerVM
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public ICollection<ODataServiceActionVM> Actions { get; set; }

    }

    class ODataServiceActionVM
    {
        public string Name { get; set; }

        public string Arguments { get; set; } = string.Empty;

        public string Method { get; set; }

        public string ResponseModel { get; set; }

        public bool IsPrimitive { get; set; } = false;

        public bool IsArray { get; set; } = false;
    }

}
