using Newtonsoft.Json;

namespace SecureAuth.Admin.Sdk.Models
{
    public class CyberArkVault
    {
        public string Username { get; set; }
        public string Address { get; set; }
        public string Safe { get; set; }
        public string Folder { get; set; }
        [JsonProperty(PropertyName = "Caobject")]
        public string Object { get; set; }
    }
}
