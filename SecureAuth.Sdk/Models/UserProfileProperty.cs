using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class UserProfileProperty
    {
        [DataMember(Name = "value")]
        public string Value { get; set; }

        [DataMember(Name = "isWritable")]
        public bool IsWritable { get; set; }

        [DataMember(Name = "displayName", EmitDefaultValue = false)]
        public string DisplayName { get; set; }
    }
}
