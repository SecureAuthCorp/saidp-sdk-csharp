using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureAuth.Sdk.Models
{
    public class ApiVersion
    {
        private ApiVersion(string value) { Value = value; }

        public string Value { get; private set; }

        public static ApiVersion V1 { get { return new ApiVersion("v1"); } }
        public static ApiVersion V2 { get { return new ApiVersion("v2"); } }
    }
}
