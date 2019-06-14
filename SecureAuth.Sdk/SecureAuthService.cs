
namespace SecureAuth.Sdk
{
<<<<<<< HEAD
    public class SecureAuthService
=======
    public class SecureAuthService : ISecureAuthService
>>>>>>> 767840d... updates for .net core and language helper function
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
<<<<<<< HEAD
        public UserService User
=======
        public IUserService User
>>>>>>> 767840d... updates for .net core and language helper function
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
<<<<<<< HEAD
        public AuthenticationService Authenticate
=======
        public IAuthenticationService Authenticate
>>>>>>> 767840d... updates for .net core and language helper function
        {
            get
            {
                return new AuthenticationService(new ApiClient(this.Configuration));
            }
        }
<<<<<<< HEAD
=======

        /// <summary>
        /// Gets the NumberProfile Service instance for the 
        /// current SecureAuth Service instance. Use for making calls to
        /// the /ap1/v1/numberprofile endpoint.
        /// </summary>
        public INumberProfileService NumberProfile
        {
            get
            {
                return new NumberProfileService(new ApiClient(this.Configuration));
            }
        }
>>>>>>> 767840d... updates for .net core and language helper function
        
        /// <summary>
        /// Gets the IP Evaluation Service instance for the current 
        /// SecureAuth Service instance. Use for making calls to the
        /// /api/v1/ipeval endpoint.
        /// </summary>
<<<<<<< HEAD
        public IpEvaluationService EvaluateIp
=======
        public IIpEvaluationService EvaluateIp
>>>>>>> 767840d... updates for .net core and language helper function
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
<<<<<<< HEAD
        public DeviceFingerprintService DeviceFingerprint
=======
        public IDeviceFingerprintService DeviceFingerprint
>>>>>>> 767840d... updates for .net core and language helper function
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
<<<<<<< HEAD
        public AccessHistoryService AccessHistory
=======
        public IAccessHistoryService AccessHistory
>>>>>>> 767840d... updates for .net core and language helper function
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
<<<<<<< HEAD
        public AdaptiveAuthService AdaptiveAuth
=======
        public IAdaptiveAuthService AdaptiveAuth
>>>>>>> 767840d... updates for .net core and language helper function
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
<<<<<<< HEAD
        public GroupService GroupService
=======
        public IGroupService GroupService
>>>>>>> 767840d... updates for .net core and language helper function
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