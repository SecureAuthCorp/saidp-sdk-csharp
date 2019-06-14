using System.Runtime.Serialization;

namespace SecureAuth.Sdk.Models
{
    [DataContract(Name = "push_accept_details")]
    public class PushAcceptDetails
    {
        [DataMember(Name = "company_name", EmitDefaultValue = false)]
        public string CompanyName { get; set; }

        [DataMember(Name = "application_description", EmitDefaultValue = false)]
        public string ApplicationDescription { get; set; }

        [DataMember(Name = "enduser_ip", EmitDefaultValue = false)]
        public string EndUserIp { get; set; }
    }
}
