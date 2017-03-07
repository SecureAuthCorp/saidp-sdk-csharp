
namespace SecureAuth.Sdk
{
    public class SecureAuthService : ISecureAuthService
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
        /// Get or set the Configuration SecureAuth Realm URL.
        /// </summary>
        public string SecureAuthRealmUrl
        {
            get { return this.Configuration.SecureAuthRealmUrl; }
            set { this.Configuration.SecureAuthRealmUrl = value; }
        }

        /// <summary>
        /// Gets the User Service instance for the current 
        /// SecureAuth Service instance. Use for making calls
        /// to the /api/v1/user endpoint.
        /// </summary>
        public IUserService User
        {
            get
            {
                return new UserService(new ApiClient(this.Configuration));
            }
        }

        /// <summary>
        /// Gets the Authentication Service instance for the current 
        /// SecureAuth Service instance. Use for making calls to the
        /// /api/v1/auth endpoint.
        /// </summary>
        public IAuthenticationService Authenticate
        {
            get
            {
                return new AuthenticationService(new ApiClient(this.Configuration));
            }
        }
        
        /// <summary>
        /// Gets the IP Evaluation Service instance for the current 
        /// SecureAuth Service instance. Use for making calls to the
        /// /api/v1/ipeval endpoint.
        /// </summary>
        public IIpEvaluationService EvaluateIp
        {
            get
            {
                return new IpEvaluationService(new ApiClient(this.Configuration));
            }
        }

        /// <summary>
        /// Gets the Device Fingerprint Service instance for the current
        /// SecureAuth Service instance. Use for making calls to the 
        /// /api/v1/dfp endpoint.
        /// </summary>
        public IDeviceFingerprintService DeviceFingerprint
        {
            get
            {
                return new DeviceFingerprintService(new ApiClient(this.Configuration));
            }
        }

        /// <summary>
        /// Gets the Access History Service instance for the current
        /// SecureAuth Service instance. Use for making calls to the 
        /// /api/v1/accesshistory endpoint.
        /// </summary>
        public IAccessHistoryService AccessHistory
        {
            get
            {
                return new AccessHistoryService(new ApiClient(this.Configuration));
            }
        }

        /// <summary>
        /// Gets the Adaptive Auth Service instance for the current
        /// SecureAuth Service instance. Use for making calls to the 
        /// /api/v1/adaptauth endpoint.
        /// </summary>
        public IAdaptiveAuthService AdaptiveAuth
        {
            get
            {
                return new AdaptiveAuthService(new ApiClient(this.Configuration));
            }
        }

        /// <summary>
        /// Gets the Group Service instance for the current
        /// SecureAuth Service instance. Use for making calls
        /// to the /api/v1/groupservice endpoint.
        /// </summary>
        public IGroupService GroupService
        {
            get
            {
                return new GroupService(new ApiClient(this.Configuration));
            }
        }
        #endregion

        #region Constructors
        public SecureAuthService()
        {
            this.Configuration = new Configuration();
        }

        public SecureAuthService(Configuration configuration)
        {
            this.Configuration = configuration;
        }

        public SecureAuthService(string secureAuthRealmUrl, string appId, string appKey)
        {
            this.Configuration = new Configuration(secureAuthRealmUrl, appId, appKey);
        }
        #endregion
    }
}