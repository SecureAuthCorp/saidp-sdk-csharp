using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;

namespace SecureAuth.Admin.Sdk.Models
{
    [JsonConverter(typeof(CustomPostAuthJsonConverter))]
    public class PostAuthentication
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PostAuthRedirectType? RedirectType { get; set; }
        public RedirectBase Redirect { get; set; }
        public PostAuthFormsAuthentication FormsAuthentication { get; set; }
        public PostAuthMachineKey MachineKey { get; set; }
        public PostAuthCookie AuthenticationCookie { get; set; }

        /// <summary>
        /// Used to cast the Redirect property to the appropriate subclass based on the RedirectType
        /// </summary>
        private class CustomPostAuthJsonConverter : JsonCreationConverter<PostAuthentication>
        {
            protected override PostAuthentication Create(Type objectType, JObject jObject)
            {
                PostAuthentication postAuth = new PostAuthentication();

                var redirectType = jObject.Value<string>("RedirectType");
                if(redirectType == null)
                {
                    redirectType = jObject.Value<string>("redirectType");
                }
                if (!string.IsNullOrEmpty(redirectType) && (jObject.Value<object>("Redirect") != null || jObject.Value<object>("redirect") != null))
                {
                    switch ((Enums.PostAuthRedirectType)Enum.Parse(typeof(Enums.PostAuthRedirectType), redirectType))
                    {
                        case Enums.PostAuthRedirectType.Saml2IdpInitiated:
                        case Enums.PostAuthRedirectType.Saml2SpInitiated:
                        case Enums.PostAuthRedirectType.Saml2SpInitiatedByPost:
                            postAuth.Redirect = new SamlSetting();
                            break;
                        case Enums.PostAuthRedirectType.WsFederation:
                            postAuth.Redirect = new WsFedSetting();
                            break;
                        default:
                            break;
                    }
                }

                return postAuth;
            }
        }
    }
}
