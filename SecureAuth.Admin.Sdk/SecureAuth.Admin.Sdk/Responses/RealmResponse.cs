using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;


namespace SecureAuth.Admin.Sdk
{
    [DataContract]
    public class RealmResponse : BaseResponse
    {
        [DataMember(Name = "realm")]
        public Models.Realm Realm { get; set; }

        public override bool IsSucess()
        {
            return ((this.StatusCode == HttpStatusCode.OK));
        }
    }
}
