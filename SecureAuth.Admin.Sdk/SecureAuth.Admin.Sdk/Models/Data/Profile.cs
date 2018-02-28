using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;


namespace SecureAuth.Admin.Sdk.Models
{
    public class Profile
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ProfileProviderName? DefaultProvider { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ProfileIndex? DataStoreType { get; set; }
        public LdapProfileDataStore LdapDataStore { get; set; }
        public SqlProfileDataStore SqlDataStore { get; set; }
        public OracleProfileDataStore OracleDataStore { get; set; }
        public AzureProfileDataStore AzureDataStore { get; set; }
        public WebServiceProfileDataStore WebServiceDataStore { get; set; }
        public List<RestServiceProfileDataStore> RestServiceDataStores { get; set; }
        public List<ProfileField> ProfileFields { get; set; }
    }
}
