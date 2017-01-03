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

        public string ModulName { get; set; } = "Core";

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

        public bool WithUrl { get; set; } = false;

        public bool IsPrimitive { get; set; } = true;
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

        public string ReponseModel { get; set; } = string.Empty;

        public bool IsPrimitive { get; set; } = true;

        public string Method { get; set; }

        public ICollection<PropertyInfo> Parameters { get; set; }
    }
}
