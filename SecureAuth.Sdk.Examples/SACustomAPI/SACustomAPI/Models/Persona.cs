using SACustomAPI.Utilities;
using SecureAuth.Sdk;

namespace SACustomAPI.Models
{
    public class Persona
    {
        public string UserReturnUrl { get; set; }

        public string FingerprintJson { get; set; }

        public AuthorizeEnum.State AuthState { get; set; }

        public string UserIpAddress { get; set; }

        public string FingerprintId { get; set; }

        public bool AllowDeviceRecog { get; set; }

        public GetFactorsResponse factors { get; set; }

        public MultiFactorOption selectedFactor { get; set; }
    }
}