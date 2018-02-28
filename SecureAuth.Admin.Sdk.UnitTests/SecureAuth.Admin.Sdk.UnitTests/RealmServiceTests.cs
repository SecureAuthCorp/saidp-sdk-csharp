using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SecureAuth.Admin.Sdk.UnitTests
{
    [TestClass]
    public class RealmServiceTests
    {
        static ISecureAuthAdminService adminService;
        static string realmId;
        static string newRealmDescription;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            // Grab values from app.config 
            realmId = ConfigurationManager.AppSettings["RealmId"];
            newRealmDescription = ConfigurationManager.AppSettings["newRealmDescription"];


            string secureAuthUrl = ConfigurationManager.AppSettings["SecureAuthUrl"];
            string apiId = ConfigurationManager.AppSettings["ApiID"];
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];            

            // Init the SecureAuthService
            Configuration config = new Configuration(secureAuthUrl, apiId, apiKey);
            adminService = new SecureAuthAdminService(config);
        }

        [TestMethod]
        public void RetrieveRealm()
        {
            // Act
            RealmResponse resp = adminService.Realm.GetRealm(realmId);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, resp.Status);
            Assert.IsInstanceOfType(resp.Realm, typeof(Models.Realm));
        }

        [TestMethod]
        public void UpdateOverviewDescriptionTest()
        {
            // Arrange
            OverviewRequest req = new OverviewRequest();
            req.Overview.RealmDescription = newRealmDescription;
            req.RealmId = realmId;

            // Act
            BaseResponse res = adminService.Realm.UpdateOverview(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);
        }
    }
}
