using System;
using System.Collections.Generic;

namespace APTOS.EOM.ATPService.ATPEFModels
{
    public partial class ServiceConfiguration
    {
        public string ServiceConfigKey { get; set; }
        public string ServiceConfigValue { get; set; }
        public string Serviceconfigcomments { get; set; }
        public bool IsActiveFlag { get; set; }
    }
}
