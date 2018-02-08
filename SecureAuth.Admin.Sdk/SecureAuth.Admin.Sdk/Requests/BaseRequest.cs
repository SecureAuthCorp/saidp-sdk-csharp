using System.Runtime.Serialization;

namespace SecureAuth.Admin.Sdk
{
    public class BaseRequest
    {
        
        public string RealmId { get; set; }
        
        public BaseRequest()
        {
        }

        public BaseRequest(string realmId)
        {
            this.RealmId = realmId;
        }
    }
}