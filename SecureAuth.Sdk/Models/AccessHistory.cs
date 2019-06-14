using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class AccessHistory
    {
        [DataMember(Name = "userAgent")]
        public string UserAgent { get; set; }

        [DataMember(Name = "ipAddress")]
        public string IpAddress { get; set; }

        [DataMember(Name = "timeStamp")]
        public string TimeStamp { get; set; }

        [DataMember(Name = "authState")]
        public string AuthState { get; set; }
    }
}
