using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Web;

namespace SecureAuth.Admin.Sdk.Models
{
    public class PostAuthFormsAuthentication
    {
        public string Name { get; set; }
        public string LoginUrl { get; set; }
        public string Domain { get; set; }
        public bool? RequireSsl { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public HttpCookieMode? CookieMode { get; set; }
        public bool? IsSlidingExpiration { get; set; }
        public int? Timeout { get; set; }
    }
}
