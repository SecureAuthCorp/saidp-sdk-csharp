using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class RestServiceProfileDataStore : DataStoreBase
    {
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.RestServiceProfileAuthenticationMethod? AuthenticationMethod { get; set; }
        public string GetProfileUrl { get; set; }
        public string UpdateProfileUrl { get; set; }
        public string CookieUrl { get; set; }
        public bool? ClearProfile { get; set; }
        public bool? DeleteProvider { get; set; }

        public bool ShouldSerializeDeleteProvider()
        {
            return false;
        }
    }
}
