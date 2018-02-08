using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class DeviceRecognitionMethod
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.DeviceRecognitionIntegrationMethod? IntegrationMethod { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.DeviceRecognitionClientSideControl? ClientSideControl { get; set; }
    }
}