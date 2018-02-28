using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace SecureAuth.Admin.Sdk.Models
{
    public class PhoneBlocking
    {
        [JsonProperty (ItemConverterType = typeof(StringEnumConverter))]
        public List<Enums.MultiFactorPhoneNumberSource> BlockedSources { get; set; }
        public bool? BlockRecentlyChangedCarrier { get; set; }
        public bool? AllowApproveDeleteRecentlyChangedCarrier { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorCarrierStorageField? CarrierStorageField { get; set; }
        public bool? EnableBlockAllowList { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorListAction? ListAction { get; set; }
        public List<PhoneCarrier> PhoneCarriers { get; set; }
    }
}
