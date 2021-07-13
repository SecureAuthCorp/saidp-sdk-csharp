using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureAuth.Sdk.UnitTests
{
    public class EnvironmentBehavioralBiometricsServiceTest
    {
        // Globals
        public ISecureAuthService secAuthSvc;
        public string goodUsername;
        public string fieldName;
        public string fieldType;
        public string deviceType;
        public string behaviorProfile;
        public string hostAddress;
        public string userAgent;

        public EnvironmentBehavioralBiometricsServiceTest()
        {
            goodUsername = ConfigurationManager.AppSettings["BehBioSvc.goodUsername"];
            fieldName = ConfigurationManager.AppSettings["BehBioSvc.fieldName"];
            fieldType = ConfigurationManager.AppSettings["BehBioSvc.fieldType"];
            deviceType = ConfigurationManager.AppSettings["BehBioSvc.deviceType"];
            behaviorProfile = ConfigurationManager.AppSettings["BehBioSvc.behaviorProfile"];
            hostAddress = ConfigurationManager.AppSettings["BehBioSvc.hostAddress"];
            userAgent = ConfigurationManager.AppSettings["BehBioSvc.userAgent"];

            string secureAuthRealm = ConfigurationManager.AppSettings["SecureAuthRealmUrl"];
            string apiId = ConfigurationManager.AppSettings["ApiID"];
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];

            // Init the SecureAuthService
            Configuration config = new Configuration(secureAuthRealm, apiId, apiKey);
            secAuthSvc = new SecureAuthService(config);
        }
    }
}
