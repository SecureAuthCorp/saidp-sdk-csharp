using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureAuth.Sdk.UnitTests
{
    public class EnvironmentUserServiceTest
    {
        // Globals
        public ISecureAuthService secAuthSvc;
        public string goodDomain;
        public string badDomain;
        public string goodUsername;
        public string badUsername;
        public string currentPassword;
        public string newPassword1;
        public string newPassword2;
        public string newFirstName;
        public string newLastName;
        public string newUserId;
        public string groupName1;
        public string groupName2;

        public EnvironmentUserServiceTest()
        {
            // Grab values from app.config
            goodUsername = ConfigurationManager.AppSettings["UserSvc.goodUsername"];
            badUsername = ConfigurationManager.AppSettings["UserSvc.badUsername"];
            currentPassword = ConfigurationManager.AppSettings["UserSvc.currentPassword"];
            newPassword1 = ConfigurationManager.AppSettings["UserSvc.newPassword1"];
            newPassword2 = ConfigurationManager.AppSettings["UserSvc.newPassword2"];
            newFirstName = ConfigurationManager.AppSettings["UserSvc.newFirstName"];
            newLastName = ConfigurationManager.AppSettings["UserSvc.newLastName"];
            newUserId = ConfigurationManager.AppSettings["UserSvc.newUserId"];
            groupName1 = ConfigurationManager.AppSettings["UserSvc.groupName1"];
            groupName2 = ConfigurationManager.AppSettings["UserSvc.groupName2"];
            goodDomain = ConfigurationManager.AppSettings["UserSvc.goodDomain"];
            badDomain = ConfigurationManager.AppSettings["UserSvc.badDomain"];
            goodDomain = ConfigurationManager.AppSettings["UserSvc.goodDomain"];

            string secureAuthRealm = ConfigurationManager.AppSettings["SecureAuthRealmUrl"];
            string apiId = ConfigurationManager.AppSettings["ApiID"];
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];

            // Init the SecureAuthService
            Configuration config = new Configuration(secureAuthRealm, apiId, apiKey);
            secAuthSvc = new SecureAuthService(config);
        }
    }
}
