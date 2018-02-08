using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureAuth.Admin.Sdk
{
    public class SecureAuthAdminService : ISecureAuthAdminService
    {

        #region Public Properties
        public Configuration Configuration { get; set; }

        /// <summary>
        /// Get or set the Configuration Application ID.
        /// </summary>
        public string AppId
        {
            get { return this.Configuration.AppId; }
            set { this.Configuration.AppId = value; }
        }

        /// <summary>
        /// Get or set the Configuration Application ID.
        /// </summary>
        public string AppKey
        {
            get { return this.Configuration.AppKey; }
            set { this.Configuration.AppKey = value; }
        }

        /// <summary>
        /// Get or set the Configuration SecureAuth URL.
        /// </summary>
        public string SecureAuthUrl
        {
            get { return this.Configuration.SecureAuthUrl; }
            set { this.Configuration.SecureAuthUrl = value; }
        }

        /// <summary>
        /// Gets the User Service instance for the current 
        /// SecureAuth Service instance. Use for making calls
        /// to the /api/v1/user endpoint.
        /// </summary>
        public IRealmService Realm
        {
            get
            {
                return new RealmService(new ApiClient(this.Configuration));
            }
        }        







        #endregion

        #region Constructors
        public SecureAuthAdminService()
        {
            this.Configuration = new Configuration();
        }

        public SecureAuthAdminService(Configuration configuration)
        {
            this.Configuration = configuration;
        }

        public SecureAuthAdminService(string secureAuthRealmUrl, string appId, string appKey)
        {
            this.Configuration = new Configuration(secureAuthRealmUrl, appId, appKey);
        }
        #endregion

    }
}
