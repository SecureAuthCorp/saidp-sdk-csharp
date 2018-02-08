using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SecureAuth.Admin.Sdk.Models
{
    [JsonConverter(typeof(CustomAdaptiveAuthJsonConverter))]
    public class AdaptiveAuthBase
    {
        private class CustomAdaptiveAuthJsonConverter : JsonCreationConverter<AdaptiveAuthentication>
        {
            
            protected override AdaptiveAuthentication Create(Type objectType, JObject jObject)
            {
                

                AdaptiveAuthentication adaptiveAuth = new AdaptiveAuthentication();

                // Test for the version
                try
                {
                    var version = jObject.Value<string>("version");
                    if (version != null && !string.IsNullOrWhiteSpace(version))
                    {
                        if (version.ToLower() == "v2")
                        {
                            adaptiveAuth = new Models.v2.AdaptiveAuthentication();
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                }

                return adaptiveAuth;
            }
        }
    }
}
