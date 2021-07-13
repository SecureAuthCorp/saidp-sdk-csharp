using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureAuth.Sdk.UnitTests
{
    public class EnvironmentAuthenticationServiceTest
    {
        // Globals
        public ISecureAuthService secAuthSvc;
        public string goodDomain;
        public string badDomain;
        public string goodUsername;
        public string goodPassword;
        public string badPassword;
        public string badUsername;
        public string goodStaticPin;
        public string badStaticPin;
        public string goodPhoneNumber;
        public string goodEmailAddress;

        public EnvironmentAuthenticationServiceTest() 
        {
            // Grab values from app.config
            goodUsername = ConfigurationManager.AppSettings["UserSvc.goodUsername"];
            badUsername = ConfigurationManager.AppSettings["UserSvc.badUsername"];
            goodDomain = ConfigurationManager.AppSettings["AuthSvc.goodDomain"];
            badDomain = ConfigurationManager.AppSettings["AuthSvc.badDomain"];
            goodEmailAddress = ConfigurationManager.AppSettings["AuthSvc.goodEmailAddress"];
            goodDomain = ConfigurationManager.AppSettings["AuthSvc.goodDomain"];
            badStaticPin = ConfigurationManager.AppSettings["AuthSvc.badStaticPin"];
            goodStaticPin = ConfigurationManager.AppSettings["AuthSvc.goodStaticPin"];
            goodPassword = ConfigurationManager.AppSettings["AuthSvc.goodPassword"];
            badPassword = ConfigurationManager.AppSettings["AuthSvc.badPassword"];
            goodPhoneNumber = ConfigurationManager.AppSettings["AuthSvc.goodPhoneNumber"];
            
            string secureAuthRealm = ConfigurationManager.AppSettings["SecureAuthRealmUrl"];
            string apiId = ConfigurationManager.AppSettings["ApiID"];
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];

            // Init the SecureAuthService
            Configuration config = new Configuration(secureAuthRealm, apiId, apiKey);
            secAuthSvc = new SecureAuthService(config);
        }
    }
}
