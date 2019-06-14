//using System.Net;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class OathTokenResponse : BaseResponse
    {
        [DataMember(Name = "server_time", EmitDefaultValue = false)]
        public string ServerTime { get; set; }

        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string OathSeed { get; set; }

        [DataMember(Name = "interval", EmitDefaultValue = false)]
        public string Interval { get; set; }

        [DataMember(Name = "length", EmitDefaultValue = false)]
        public string Length { get; set; }

        [DataMember(Name = "offset", EmitDefaultValue = false)]
        public string Offset { get; set; }

        [DataMember(Name = "pin_control", EmitDefaultValue = false)]
        public string PinControl { get; set; }

        [DataMember(Name = "failed_wipe", EmitDefaultValue = false)]
        public string FailedWipe { get; set; }

        [DataMember(Name = "screen_timeout", EmitDefaultValue = false)]
        public string ScreenTimeout { get; set; }

        [DataMember(Name = "tokentype", EmitDefaultValue = false)]
        public string TokenType { get; set; }

        [DataMember(Name = "counter", EmitDefaultValue = false)]
        public int? Counter { get; set; }
    }
}