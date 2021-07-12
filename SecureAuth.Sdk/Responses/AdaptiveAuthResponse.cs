using System.Net;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class AdaptiveAuthResponse : BaseResponse
    {
        [DataMember(Name = "realm_workflow", EmitDefaultValue = false)]
        public string RealmWorkflow { get; set; }

        [DataMember(Name = "suggested_action", EmitDefaultValue = false)]
        public string SuggestedAction { get; set; }

        [DataMember(Name = "redirect_url", EmitDefaultValue = false)]
        public string RedirectUrl { get; set; }

        public override bool IsSuccess()
        {
            return (this.StatusCode == HttpStatusCode.OK);
        }
    }
}