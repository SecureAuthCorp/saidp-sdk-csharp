using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureAuth.Admin.Sdk.Models.v2
{
    public class AdaptiveAuthentication : Models.AdaptiveAuthentication
    {
        public new v2.UserRiskSetting UserRisk { get; set; }
    }
}
