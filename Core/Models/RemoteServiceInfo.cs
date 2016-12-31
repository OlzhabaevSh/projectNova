using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class RemoteServiceInfo
    {
        public string BaseUrl { get; set; }

        public ICollection<ModelInfo> Models { get; set; }

        public ICollection<ControllerInfo> Controllers { get; set; }
    }

    public class ModelInfo
    {
        public string Title { get; set; }

        public ICollection<PropertyInfo> Properties { get; set; }
    }

    public class PropertyInfo
    {
        public string Title { get; set; }

        public string Type { get; set; }

        public bool Nullable { get; set; } = true;

        public bool Array { get; set; } = false;
    }

    public class ControllerInfo
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public ICollection<ActionInfo> Actions { get; set; }
    }

    public class ActionInfo
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public bool IsArrayResponse { get; set; } = false;

        public string ReponseModel { get; set; }
        
        public string Method { get; set; }

        public ICollection<PropertyInfo> Parameters { get; set; }
    }
}
