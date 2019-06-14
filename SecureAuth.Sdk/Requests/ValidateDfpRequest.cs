using System.Runtime.Serialization;
using SecureAuth.Sdk.Models;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class ValidateDfpRequest : BaseRequest
    {
        [DataMember(Name = "fingerprint_id", EmitDefaultValue = false)]
        public string FingerprintId { get; set; }

        [DataMember(Name = "host_address", EmitDefaultValue = false)]
        public string HostAddress { get; set; }

        [DataMember(Name = "fingerprint", EmitDefaultValue = false)]
<<<<<<< HEAD
        public Fingerprint Fingerprint { get; set; }

        public ValidateDfpRequest()
        {
            
=======
        public FingerprintWrapper Fingerprint { get; set; }

        public ValidateDfpRequest()
        {
>>>>>>> 767840d... updates for .net core and language helper function
        }

        public ValidateDfpRequest(string fpJson)
        {
<<<<<<< HEAD
            this.Fingerprint = JsonSerializer.Deserialize<ValidateDfpRequest>(fpJson).Fingerprint;
=======
            this.Fingerprint = JsonSerializer.Deserialize<FingerprintWrapper>(fpJson);
            //this.Fingerprint = JsonSerializer.Deserialize<ValidateDfpRequest>(fpJson).Fingerprint;
>>>>>>> 767840d... updates for .net core and language helper function
        }
    }
}