﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace SecureAuth.Sdk.UnitTests
{
    [TestClass]
    public class AuthenticationServiceTests
    {
        // Globals
        static ISecureAuthService secAuthSvc;
        static string goodUsername;
        static string goodPassword;
        static string badUsername;
        static string badPassword;
        static string goodStaticPin;
        static string badStaticPin;
        static string goodPhoneNumber;
        static string goodEmailAddress;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            // Grab values from app.config
            goodUsername = ConfigurationManager.AppSettings["AuthSvc.goodUsername"];
            goodPassword = ConfigurationManager.AppSettings["AuthSvc.goodPassword"];
            badUsername = ConfigurationManager.AppSettings["AuthSvc.badUsername"];
            badPassword = ConfigurationManager.AppSettings["AuthSvc.badPassword"];
            goodStaticPin = ConfigurationManager.AppSettings["AuthSvc.goodStaticPin"];
            badStaticPin = ConfigurationManager.AppSettings["AuthSvc.badStaticPin"];
            goodPhoneNumber = ConfigurationManager.AppSettings["AuthSvc.goodPhoneNumber"];
            goodEmailAddress = ConfigurationManager.AppSettings["AuthSvc.goodEmailAddress"];

            string secureAuthRealm = ConfigurationManager.AppSettings["SecureAuthRealmUrl"];
            string apiId = ConfigurationManager.AppSettings["ApiID"];
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];

            // Init the SecureAuthService
            Configuration config = new Configuration(secureAuthRealm, apiId, apiKey);
            secAuthSvc = new SecureAuthService(config);
        }

        [TestMethod]
        public void ValidateGoodUserIdTest()
        {
            // Arrange
            ValidateUserIdRequest req = new ValidateUserIdRequest(goodUsername);

            // Act
            BaseResponse res = secAuthSvc.Authenticate.ValidateUserId(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Found, res.Status);
        }

        [TestMethod]
        public void ValidateBadUserIdTest()
        {
            // Arrange
            ValidateUserIdRequest req = new ValidateUserIdRequest(badUsername);

            // Act
            BaseResponse res = secAuthSvc.Authenticate.ValidateUserId(req);

            // Assert
            Assert.AreNotEqual(Constants.ResponseStatus.Found, res.Status);
        }

        [TestMethod]
        public void ValidateGoodPasswordTest()
        {
            // Arrange
            ValidatePasswordRequest req = new ValidatePasswordRequest(goodUsername, goodPassword);

            // Act
            BaseResponse res = secAuthSvc.Authenticate.ValidatePassword(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, res.Status);
        }

        [TestMethod]
        public void ValidateBadPasswordTest()
        {
            // Arrange
            ValidatePasswordRequest req = new ValidatePasswordRequest(goodUsername, badPassword);

            // Act
            BaseResponse res = secAuthSvc.Authenticate.ValidatePassword(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Invalid, res.Status);
        }

        [TestMethod]
        public void ValidateGoodStaticPinTest()
        {
            // Arrange
            ValidatePinRequest req = new ValidatePinRequest(goodUsername, goodStaticPin);

            // Act
            BaseResponse res = secAuthSvc.Authenticate.ValidatePin(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, res.Status);
        }

        [TestMethod]
        public void ValidateBadStaticPinTest()
        {
            // Arrange
            ValidatePinRequest req = new ValidatePinRequest(goodUsername, badStaticPin);

            // Act
            BaseResponse res = secAuthSvc.Authenticate.ValidatePin(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Invalid, res.Status);
        }

        [TestMethod]
        public void ValidateSendAdHocSmsOtpTest()
        {
            AdHocSmsOtpRequest request = new AdHocSmsOtpRequest
            {
                Token = goodPhoneNumber,
                UserId = goodUsername,
                EvaluateNumber = false
            };

            SendOtpResponse response = secAuthSvc.Authenticate.SendAdHocSmsOtp(request);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, response.Status);
        }

        [TestMethod]
        public void ValidateSendAdHocPhonecallOtpTest()
        {
            AdHocPhonecallOtpRequest request = new AdHocPhonecallOtpRequest
            {
                Token = goodPhoneNumber,
                UserId = goodUsername,
                EvaluateNumber = false
            };

            SendOtpResponse response = secAuthSvc.Authenticate.SendAdHocPhonecallOtp(request);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, response.Status);
        }


        [TestMethod]
        public void ValidateSendAdHocEmailOtpTest()
        {
            AdHocEmailOtpRequest request = new AdHocEmailOtpRequest
            {
                Token = goodEmailAddress,
                UserId = goodUsername,
            };

            SendOtpResponse response = secAuthSvc.Authenticate.SendAdHocEmailOtp(request);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, response.Status);
        }
    }
}
