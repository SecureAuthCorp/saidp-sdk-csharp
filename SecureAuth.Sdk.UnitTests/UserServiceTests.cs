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
        static EnvironmentUserServiceTest env;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            env = new EnvironmentUserServiceTest();
        }

        [TestMethod]
        public void RetrieveFactorsGoodUserTest()
        {
            // Act
            GetFactorsResponse res = env.secAuthSvc.User.GetFactors(env.goodUsername);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Found, res.Status);
        }

        [TestMethod]
        public void RetrieveProfileGoodUserTest()
        {
            // Act
            GetUserProfileResponse res = env.secAuthSvc.User.GetUserProfile(env.goodUsername);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Found, res.Status);
        }

        [TestMethod]
        public void UpdateProfileFirstNameTest()
        {
            // Arrange
            UpdateUserProfileRequest req = new UpdateUserProfileRequest();
            req.Properties.Add("firstName", env.newFirstName);

            // Act
            BaseResponse res = env.secAuthSvc.User.UpdateUserProfile(env.goodUsername, req);

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
            BaseResponse res = env.secAuthSvc.User.UpdateUserProfile(env.goodUsername, req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);
        }

        [TestMethod]
        public void CreateUserTest()
        {
            // Arrange
            CreateUserRequest req = new CreateUserRequest();
            req.Domain = env.goodDomain;
            req.UserId = env.newUserId;
            req.Password = env.newPassword2;
            req.Properties.Add("firstName", env.newFirstName);
            req.Properties.Add("lastName", env.newLastName);
            req.KnowledgeBase.Add("kbq1", new KbProperty("Which day were you born?", "Tuesday"));

            // Act
            BaseResponse res = env.secAuthSvc.User.CreateUser(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);

            // Validate password for new user
            // Arrange
            ValidatePasswordRequest req2 = new ValidatePasswordRequest(req.UserId, req.Password, req.Domain);

            // Act
            BaseResponse res2 = env.secAuthSvc.Authenticate.ValidatePassword(req2);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, res2.Status);
        }

        [TestMethod]
        public void ChangePasswordTest()
        {
            // Arrange
            ChangePasswordRequest req = new ChangePasswordRequest
            {
                CurrentPassword = env.currentPassword,
                NewPassword = env.newPassword1
            };

            // Act
            BaseResponse res = env.secAuthSvc.User.ChangePassword(env.goodUsername, req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);

            // Validate new password
            // Arrange
            ValidatePasswordRequest vReq = new ValidatePasswordRequest(env.goodUsername, env.newPassword1, env.goodDomain);

            // Act
            BaseResponse vRes = env.secAuthSvc.Authenticate.ValidatePassword(vReq);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, vRes.Status);
        }

        [TestMethod]
        public void ChangePasswordWithDomainTest()
        {
            // Arrange
            ChangePasswordRequest req = new ChangePasswordRequest
            {
                CurrentPassword = env.currentPassword,
                NewPassword = env.newPassword1
            };

            // Act
            BaseResponse res = env.secAuthSvc.User.ChangePassword(env.goodUsername, req, env.goodDomain);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);

            // Validate new password
            // Arrange
            ValidatePasswordRequest vReq = new ValidatePasswordRequest(env.goodUsername, env.newPassword1, env.goodDomain);

            // Act
            BaseResponse vRes = env.secAuthSvc.Authenticate.ValidatePassword(vReq);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, vRes.Status);
        }

        [TestMethod]
        public void ResetPasswordTest()
        {
            // Arrange
            ResetPasswordRequest req = new ResetPasswordRequest
            {
                NewPassword = env.newPassword2
            };

            // Act
            BaseResponse res = env.secAuthSvc.User.ResetPassword(env.goodUsername, req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);

            // Validate new password
            // Arrange
            ValidatePasswordRequest vReq = new ValidatePasswordRequest(env.goodUsername, env.newPassword2, env.goodDomain);

            // Act
            BaseResponse vRes = env.secAuthSvc.Authenticate.ValidatePassword(vReq);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, vRes.Status);
        }

        [TestMethod]
        public void ResetPasswordWithDomainTest()
        {
            // Arrange
            ResetPasswordRequest req = new ResetPasswordRequest
            {
                NewPassword = env.newPassword2
            };

            // Act
            BaseResponse res = env.secAuthSvc.User.ResetPassword(env.goodUsername, req, env.goodDomain);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);

            // Validate new password
            // Arrange
            ValidatePasswordRequest vReq = new ValidatePasswordRequest(env.goodUsername, env.newPassword2, env.goodDomain);

            // Act
            BaseResponse vRes = env.secAuthSvc.Authenticate.ValidatePassword(vReq);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, vRes.Status);
        }

        [TestMethod]
        public void AddGroupToUserTest()
        {
            // Act
            BaseResponse res = env.secAuthSvc.User.AddUserToGroup(env.goodUsername, env.groupName1);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);
        }

        [TestMethod]
        public void AddGroupToUserWithDomainTest()
        {
            // Act
            BaseResponse res = env.secAuthSvc.User.AddUserToGroup(env.goodUsername, env.groupName1, env.goodDomain);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);
        }

        [TestMethod]
        public void AddMultipleGroupsToUserTest()
        {
            // Arrange
            GroupAssociateRequest req = new GroupAssociateRequest();
            req.GroupNames.Add(env.groupName1);
            req.GroupNames.Add(env.groupName2);

            // Act
            BaseResponse res = env.secAuthSvc.User.AddGroupsToUser(env.goodUsername, req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);
        }

        [TestMethod]
        public void AddMultipleGroupsToUserWithDomainTest()
        {
            // Arrange
            GroupAssociateRequest req = new GroupAssociateRequest();
            req.GroupNames.Add(env.groupName1);
            req.GroupNames.Add(env.groupName2);

            // Act
            BaseResponse res = env.secAuthSvc.User.AddGroupsToUser(env.goodUsername, req, env.goodDomain);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);
        }

        [TestMethod]
        public void ValidateGetUserFactorsQueryStringTest()
        {
            // Arrange

            // Act
            GetFactorsResponse res = env.secAuthSvc.User.GetUserFactorsQueryString(env.goodUsername, env.goodDomain);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Found, res.Status);
        }

        [TestMethod]
        public void ValidateAddGroupsToUserQueryStringTest()
        {
            // Arrange
            GroupAssociateRequest request = new GroupAssociateRequest();
            request.GroupNames.Add(env.groupName1);
            request.GroupNames.Add(env.groupName2);

            // Act
            GroupAssociateResponse res = env.secAuthSvc.User.AddGroupsToUserQueryString(env.goodUsername, request, env.goodDomain);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);
        }

        [TestMethod]
        public void ValidateAddUserToGroupQueryStringTest()
        {
            // Arrange

            // Act
            BaseResponse res = env.secAuthSvc.User.AddUserToGroupQueryString(env.groupName1,env.goodUsername, env.goodDomain);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);
        }

        [TestMethod]
        public void ValidateGetUserStatusTest()
        {
            // Arrange

            // Act
            UserStatusResponse res = env.secAuthSvc.User.GetUserStatus(env.goodUsername, env.goodDomain);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, res.Status);
        }

        [TestMethod]
        public void ValidateSetUserStatusTest()
        {
            // Arrange
            SetUserStatusRequest request = new SetUserStatusRequest(Constants.ResponseStatus.LockOut);

            // Act
            BaseResponse res = env.secAuthSvc.User.SetUserStatus(env.goodUsername, request, env.goodDomain);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);
        }
    }
}
