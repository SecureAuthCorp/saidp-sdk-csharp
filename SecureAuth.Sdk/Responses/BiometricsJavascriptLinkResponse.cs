using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk.Responses
{
    [DataContract]
    public class BiometricsJavascriptLinkResponse : BaseResponse
    {
        [DataMember(Name = "src")]
        public string Source { get; set; }

        public override bool IsSuccess()
        {
            return ((this.StatusCode == HttpStatusCode.OK) && (!string.IsNullOrEmpty(this.Source)));
        }
    }
}
