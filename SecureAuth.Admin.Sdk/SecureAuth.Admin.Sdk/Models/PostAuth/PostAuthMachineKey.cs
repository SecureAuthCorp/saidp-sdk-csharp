using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Web.Configuration;

namespace SecureAuth.Admin.Sdk.Models
{
    public class PostAuthMachineKey
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public MachineKeyValidation? Validation { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PostAuthMachineKeyDecryption? Decryption { get; set; }
        public string ValidationKey { get; set; }
        public string DecryptionKey { get; set; }
    }
}
