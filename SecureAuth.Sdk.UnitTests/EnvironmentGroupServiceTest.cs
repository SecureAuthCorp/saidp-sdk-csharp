using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureAuth.Sdk.UnitTests
{
    public class EnvironmentGroupServiceTest
    {
        // Globals
        public ISecureAuthService secAuthSvc;
        public string goodDomain;
        public string badDomain;
        public string goodUserId;
        public string badUserId;
        public string groupName1;
        public string groupName2;

        public EnvironmentGroupServiceTest()
        {
            // Grab values from app.config
            goodUserId = ConfigurationManager.AppSettings["GroupSvc.goodUserId"];
            badUserId = ConfigurationManager.AppSettings["GroupSvc.badUserId"];
            groupName1 = ConfigurationManager.AppSettings["GroupSvc.groupName1"];
            groupName2 = ConfigurationManager.AppSettings["GroupSvc.groupName2"];
            badDomain = ConfigurationManager.AppSettings["GroupSvc.badDomain"];
            goodDomain = ConfigurationManager.AppSettings["GroupSvc.goodDomain"];

            string secureAuthRealm = ConfigurationManager.AppSettings["SecureAuthRealmUrl"];
            string apiId = ConfigurationManager.AppSettings["ApiID"];
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];

            // Init the SecureAuthService
            Configuration config = new Configuration(secureAuthRealm, apiId, apiKey);
            secAuthSvc = new SecureAuthService(config);
        }
    }
}
