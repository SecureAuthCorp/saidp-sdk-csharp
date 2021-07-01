using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureAuth.Sdk.UnitTests
{
    public class EnvironmentDeviceFingerprintServiceTest
    {
        // Globals
        public ISecureAuthService secAuthSvc;
        public string goodUsername1;
        public string goodUsername2;

        public EnvironmentDeviceFingerprintServiceTest()
        {
            // Grab values from app.config
            goodUsername1 = ConfigurationManager.AppSettings["DeviceFingerprintSvc.goodUsername1"];
            goodUsername2 = ConfigurationManager.AppSettings["DeviceFingerprintSvc.goodUsername2"];
          
            string secureAuthRealm = ConfigurationManager.AppSettings["SecureAuthRealmUrl"];
            string apiId = ConfigurationManager.AppSettings["ApiID"];
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];

            // Init the SecureAuthService
            Configuration config = new Configuration(secureAuthRealm, apiId, apiKey);
            secAuthSvc = new SecureAuthService(config);
        }
    }
}
