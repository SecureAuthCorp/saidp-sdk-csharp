using System.Net;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class DfpResponse : BaseResponse
    {
        [DataMember(Name = "user_id", EmitDefaultValue = false)]
        public string UserId { get; set; }

        [DataMember(Name = "fingerprint_id", EmitDefaultValue = false)]
        public string FingerprintId { get; set; }

        [DataMember(Name = "fingerprint_name", EmitDefaultValue = false)]
        public string FingerprintName { get; set; }

        [DataMember(Name = "score", EmitDefaultValue = false)]
        public string Score { get; set; }

        [DataMember(Name = "match_score", EmitDefaultValue = false)]
        public string MatchScore { get; set; }

        [DataMember(Name = "update_score", EmitDefaultValue = false)]
        public string UpdateScore { get; set; }

        public override bool IsSucess()
        {
            return (this.StatusCode == HttpStatusCode.OK);
        }
    }
}