using System.Runtime.Serialization;
using SecureAuth.Sdk.Models;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class ResetBehavioralBioRequest : BaseRequest
    {
        [DataMember(Name = "userId", EmitDefaultValue = false)]
        public string UserId { get; set; }

        [DataMember(Name = "fieldName", EmitDefaultValue = false)]
        public string FieldName { get; set; }

        [DataMember(Name = "fieldType", EmitDefaultValue = false)]
        public string FieldType { get; set; }

        [DataMember(Name = "deviceType", EmitDefaultValue = false)]
        public string DeviceType { get; set; }

        public ResetBehavioralBioRequest() { }

    }
}
