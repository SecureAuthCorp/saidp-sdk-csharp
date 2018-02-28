using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;


namespace SecureAuth.Admin.Sdk.Models
{
    [JsonConverter(typeof(CustomMembershipJsonConverter))]
    public class Membership
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MembershipIndex? DataStoreType { get; set; }
        public DataStoreBase DataStore { get; set; }

        /// <summary>
        /// Used to cast the DataStore to the appropriate subclass based on the DataStoreType
        /// </summary>
        private class CustomMembershipJsonConverter : JsonCreationConverter<Membership>
        {
            protected override Membership Create(Type objectType, JObject jObject)
            {
                Membership membership = new Membership();

                var dataStoreType = jObject.Value<string>("DataStoreType");
                if(dataStoreType == null)
                {
                    dataStoreType = jObject.Value<string>("dataStoreType");
                }
                if (!string.IsNullOrEmpty(dataStoreType) && (jObject.Value<object>("DataStore") != null || jObject.Value<object>("dataStore") != null))
                {
                    switch ((Enums.MembershipIndex)Enum.Parse(typeof(Enums.MembershipIndex), dataStoreType))
                    {
                        case Enums.MembershipIndex.ADSamAccountName:
                        case Enums.MembershipIndex.ADUPN:
                        case Enums.MembershipIndex.ADAM:
                        case Enums.MembershipIndex.Domino:
                        case Enums.MembershipIndex.eDirectory:
                        case Enums.MembershipIndex.SunOne:
                        case Enums.MembershipIndex.Tivoli:
                        case Enums.MembershipIndex.OpenLDAP:
                        case Enums.MembershipIndex.OtherLDAP:
                            membership.DataStore = new LdapMembershipDataStore();
                            break;
                        case Enums.MembershipIndex.SQLServer:
                            membership.DataStore = new SqlMembershipDataStore();
                            break;
                        case Enums.MembershipIndex.Oracle:
                            membership.DataStore = new OracleMembershipDataStore();
                            break;
                        case Enums.MembershipIndex.Azure:
                            membership.DataStore = new AzureMembershipDataStore();
                            break;
                        case Enums.MembershipIndex.WebService:
                            membership.DataStore = new WebServiceMembershipDataStore();
                            break;
                        default:
                            break;
                    }
                }

                return membership;
            }
        }
    }
}
