using SecureAuth.Sdk;
using System.Configuration;

namespace SACustomAPI.Models
{
    public static class ConfigurationModel
    {
        public static SecureAuth.Sdk.Configuration getConfig()
        {
            string appId = ConfigurationManager.AppSettings["AppId"];
            string appKey = ConfigurationManager.AppSettings["AppKey"];
            string SecureAuthUrl = ConfigurationManager.AppSettings["SecureAuthUrl"];
            string BypassCert = ConfigurationManager.AppSettings["BypassCert"];
            bool CertBypass = false;
            if (BypassCert.ToLower().Contains("true"))
            {
                CertBypass = true;
            }

            SecureAuth.Sdk.Configuration sdkConfig = new SecureAuth.Sdk.Configuration(SecureAuthUrl, appId, appKey, CertBypass);
            return sdkConfig;
        }
    }
}