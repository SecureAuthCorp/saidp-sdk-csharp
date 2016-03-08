using System;

namespace SecureAuth.Sdk
{
    public class Configuration
    {
        private string _secureAuthRealmUrl;
        public string SecureAuthRealmUrl
        {
            get { return this._secureAuthRealmUrl; }
            set { this._secureAuthRealmUrl = value.TrimEnd(new char[] {'/'}); }
        }

        public string AppId { get; set; }
        public string AppKey { get; set; }
        public bool BypassCertValidation { get; set; }
        
        public Configuration()
        {
        }

        public Configuration(string secureAuthRealmUrl, string appId, string appKey, bool isDevelopment = false)
        {
            if (secureAuthRealmUrl == null)
            {
                throw new ArgumentNullException("secureAuthRealmUrl", "A SecureAuth realm URL is required.");
            }
            if (string.IsNullOrEmpty(appId))
            {
                throw new ArgumentNullException("appId", "An application ID is required.");
            }
            if (string.IsNullOrEmpty(appKey))
            {
                throw new ArgumentNullException("appKey", "An application key is required.");
            }

            this._secureAuthRealmUrl = secureAuthRealmUrl.TrimEnd(new char[] { '/' });
            this.AppId = appId;
            this.AppKey = appKey;
            this.BypassCertValidation = isDevelopment;
        }
    }
}