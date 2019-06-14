using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class BaseRequest
    {
<<<<<<< HEAD
=======
        [DataMember(Name = "domain")]
        public string Domain { get; set; }

>>>>>>> 767840d... updates for .net core and language helper function
        [DataMember(Name = "user_id", EmitDefaultValue = false)]
        public string UserId { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        public BaseRequest()
        {
        }

<<<<<<< HEAD
        public BaseRequest(string userId, string type)
        {
            this.UserId = userId;
            this.Type = type;
=======
        public BaseRequest(string userId, string type, string domain = "")
        {
            this.UserId = userId;
            this.Type = type;
            this.Domain = string.IsNullOrEmpty(Domain) ? string.Empty : Domain;
>>>>>>> 767840d... updates for .net core and language helper function
        }
    }
}