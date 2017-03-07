using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace SecureAuth.Sdk.UnitTests
{
    /// <summary>
    /// Summary description for UserServiceTests
    /// </summary>
    [TestClass]
    public class UserServiceTests
    {
        // Globals
        static ISecureAuthService secAuthSvc;
        static string goodUsername;
        static string badUsername;
        static string currentPassword;
        static string newPassword1;
        static string newPassword2;
        static string newFirstName;
        static string newLastName;
        static string newUserId;
        static string groupName1;
        static string groupName2;

        [ClassInitialize]
        public static void Init(TestContext testContext)
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

            string secureAuthRealm = ConfigurationManager.AppSettings["SecureAuthRealmUrl"];
            string apiId = ConfigurationManager.AppSettings["ApiID"];
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];

            // Init the SecureAuthService
            Configuration config = new Configuration(secureAuthRealm, apiId, apiKey);
            secAuthSvc = new SecureAuthService(config);
        }

        [TestMethod]
        public void RetrieveFactorsGoodUserTest()
        {
            // Act
            GetFactorsResponse res = secAuthSvc.User.GetFactors(goodUsername);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Found, res.Status);
        }

        [TestMethod]
        public void RetrieveProfileGoodUserTest()
        {
            // Act
            GetUserProfileResponse res = secAuthSvc.User.GetUserProfile(goodUsername);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Found, res.Status);
        }

        [TestMethod]
        public void UpdateProfileFirstNameTest()
        {
            // Arrange
            UpdateUserProfileRequest req = new UpdateUserProfileRequest();
            req.Properties.Add("firstName", newFirstName);

            // Act
            BaseResponse res = secAuthSvc.User.UpdateUserProfile(goodUsername, req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);
        }

        [TestMethod]
        public void UpdateProfileKBTest()
        {
            // Arrange
            UpdateUserProfileRequest req = new UpdateUserProfileRequest();
            req.KnowledgeBase.Add("kbq1", new KbProperty("Which Voltron lion is your favorite?", "The black one"));

            // Act
            BaseResponse res = secAuthSvc.User.UpdateUserProfile(goodUsername, req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);
        }

        [TestMethod]
        public void CreateUserTest()
        {
            // Arrange
            CreateUserRequest req = new CreateUserRequest();
            req.UserId = newUserId;
            req.Password = newPassword2;
            req.Properties.Add("firstName", newFirstName);
            req.Properties.Add("lastName", newLastName);
            req.KnowledgeBase.Add("kbq1", new KbProperty("Which day were you born?", "Tuesday"));

            // Act
            BaseResponse res = secAuthSvc.User.CreateUser(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);

            // Validate password for new user
            // Arrange
            ValidatePasswordRequest req2 = new ValidatePasswordRequest(req.UserId, req.Password);

            // Act
            BaseResponse res2 = secAuthSvc.Authenticate.ValidatePassword(req2);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, res2.Status);
        }

        [TestMethod]
        public void ChangePasswordTest()
        {
            // Arrange
            ChangePasswordRequest req = new ChangePasswordRequest
            {
                CurrentPassword = currentPassword,
                NewPassword = newPassword1
            };

            // Act
            BaseResponse res = secAuthSvc.User.ChangePassword(goodUsername, req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);

            // Validate new password
            // Arrange
            ValidatePasswordRequest vReq = new ValidatePasswordRequest(goodUsername, newPassword1);

            // Act
            BaseResponse vRes = secAuthSvc.Authenticate.ValidatePassword(vReq);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, vRes.Status);
        }

        [TestMethod]
        public void ResetPasswordTest()
        {
            // Arrange
            ResetPasswordRequest req = new ResetPasswordRequest
            {
                NewPassword = newPassword2
            };

            // Act
            BaseResponse res = secAuthSvc.User.ResetPassword(goodUsername, req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);

            // Validate new password
            // Arrange
            ValidatePasswordRequest vReq = new ValidatePasswordRequest(goodUsername, newPassword2);

            // Act
            BaseResponse vRes = secAuthSvc.Authenticate.ValidatePassword(vReq);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, vRes.Status);
        }

        [TestMethod]
        public void AddGroupToUserTest()
        {
            // Act
            BaseResponse res = secAuthSvc.User.AddGroupToUser(goodUsername, groupName1);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);
        }

        [TestMethod]
        public void AddMultipleGroupsToUserTest()
        {
            // Arrange
            GroupAssociateRequest req = new GroupAssociateRequest();
            req.GroupNames.Add(groupName1);
            req.GroupNames.Add(groupName2);

            // Act
            BaseResponse res = secAuthSvc.User.AddGroupsToUser(goodUsername, req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);
        }
    }
}
