using System;

namespace SecureAuth.Admin.Sdk
{
    public class Configuration
    {
        private string _secureAuthUrl;
        public string SecureAuthUrl
        {
            get { return this._secureAuthUrl; }
            set { this._secureAuthUrl = value.TrimEnd(new char[] {'/'}); }
        }

        public string AppId { get; set; }
        public string AppKey { get; set; }
        public bool BypassCertValidation { get; set; }
        
        public Configuration()
        {
        }

        public Configuration(string secureAuthUrl, string appId, string appKey, bool isDevelopment = false)
        {
            if (secureAuthUrl == null)
            {
                throw new ArgumentNullException("secureAuthUrl", "A SecureAuth URL is required.");
            }
            if (string.IsNullOrEmpty(appId))
            {
                throw new ArgumentNullException("appId", "An application ID is required.");
            }
            if (string.IsNullOrEmpty(appKey))
            {
                throw new ArgumentNullException("appKey", "An application key is required.");
            }

            this._secureAuthUrl = secureAuthUrl.TrimEnd(new char[] { '/' });
            this.AppId = appId;
            this.AppKey = appKey;
            this.BypassCertValidation = isDevelopment;
        }
    }
}