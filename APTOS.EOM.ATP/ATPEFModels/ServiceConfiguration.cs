using System;
using System.Collections.Generic;

namespace APTOS.EOM.ATPService.ATPEFModels
{
    public partial class ServiceConfiguration
    {
        public string SettingKey { get; set; }
        public string SettingValue { get; set; }
        public string SettingComments { get; set; }
        public bool IsActive { get; set; }
    }
}
