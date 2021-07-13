using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureAuth.Sdk.Models;
using System.Configuration;
using System.Net;
using System.Threading;

namespace SecureAuth.Sdk.UnitTests
{
    [TestClass]
    public class AuthenticationServiceTests
    {
        static EnvironmentAuthenticationServiceTest env;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            env = new EnvironmentAuthenticationServiceTest();
        }

        [TestMethod]
        public void ValidateGoodUserIdTest()
        {
            // Arrange
            ValidateUserIdRequest req = new ValidateUserIdRequest(env.goodUsername);

            // Act
            BaseResponse res = env.secAuthSvc.Authenticate.ValidateUserId(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Found, res.Status);
        }

        [TestMethod]
        public void ValidateGoodUserIdWithDomainTest()
        {
            // Arrange
            ValidateUserIdRequest req = new ValidateUserIdRequest(env.goodUsername, env.goodDomain);

            // Act
            BaseResponse res = env.secAuthSvc.Authenticate.ValidateUserId(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Found, res.Status);
        }

        [TestMethod]
        public void ValidateBadUserIdTest()
        {
            // Arrange
            ValidateUserIdRequest req = new ValidateUserIdRequest(env.badUsername);

            // Act
            BaseResponse res = env.secAuthSvc.Authenticate.ValidateUserId(req);

            // Assert
            Assert.AreNotEqual(Constants.ResponseStatus.Found, res.Status);
        }

        [TestMethod]
        public void ValidateBadDomainTest()
        {
            // Arrange
            ValidateUserIdRequest req = new ValidateUserIdRequest(env.goodUsername, env.badDomain);

            // Act
            BaseResponse res = env.secAuthSvc.Authenticate.ValidateUserId(req);

            // Assert
            Assert.AreNotEqual(Constants.ResponseStatus.Found, res.Status);
        }
        
        [TestMethod]
        public void ValidateGoodPasswordTest()
        {
            // Arrange
            ValidatePasswordRequest req = new ValidatePasswordRequest(env.goodUsername, env.goodPassword);

            // Act
            BaseResponse res = env.secAuthSvc.Authenticate.ValidatePassword(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, res.Status);
        }

        [TestMethod]
        public void ValidateBadPasswordTest()
        {
            // Arrange
            ValidatePasswordRequest req = new ValidatePasswordRequest(env.goodUsername, env.badPassword);

            // Act
            BaseResponse res = env.secAuthSvc.Authenticate.ValidatePassword(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Invalid, res.Status);
        }

        [TestMethod]
        public void ValidateGoodStaticPinTest()
        {
            // Arrange
            ValidatePinRequest req = new ValidatePinRequest(env.goodUsername, env.goodStaticPin);

            // Act
            BaseResponse res = env.secAuthSvc.Authenticate.ValidatePin(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, res.Status);
        }

        [TestMethod]
        public void ValidateBadStaticPinTest()
        {
            // Arrange
            ValidatePinRequest req = new ValidatePinRequest(env.goodUsername, env.badStaticPin);

            // Act
            BaseResponse res = env.secAuthSvc.Authenticate.ValidatePin(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Invalid, res.Status);
        }

        [TestMethod]
        public void ValidateSendAdHocSmsOtpTest()
        {
            AdHocSmsOtpRequest request = new AdHocSmsOtpRequest
            {
                Token = env.goodPhoneNumber,
                UserId = env.goodUsername,
                EvaluateNumber = false
            };

            SendOtpResponse response = env.secAuthSvc.Authenticate.SendAdHocSmsOtp(request);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, response.Status);
        }

        [TestMethod]
        public void ValidateSendAdHocPhonecallOtpTest()
        {
            AdHocPhonecallOtpRequest request = new AdHocPhonecallOtpRequest
            {
                Token = env.goodPhoneNumber,
                UserId = env.goodUsername,
                EvaluateNumber = false
            };

            SendOtpResponse response = env.secAuthSvc.Authenticate.SendAdHocPhonecallOtp(request);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, response.Status);
        }


        [TestMethod]
        public void ValidateSendAdHocEmailOtpTest()
        {
            AdHocEmailOtpRequest request = new AdHocEmailOtpRequest
            {
                Token = env.goodEmailAddress,
                UserId = env.goodUsername,
            };

            SendOtpResponse response = env.secAuthSvc.Authenticate.SendAdHocEmailOtp(request);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, response.Status);
        }

        [TestMethod]
        public void ValidateSendSmsLinkTest()
        {
            // Arrange
            SmsLinkOtpRequest req = new SmsLinkOtpRequest(env.goodUsername, "Phone1");

            // Act
            BaseResponse res = env.secAuthSvc.Authenticate.SendSmsLink(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, res.Status);
        }

        [TestMethod]
        public void ValidateSendEmailLinkOtpTest()
        {
            // Arrange
            EmailLinkOtpRequest req = new EmailLinkOtpRequest(env.goodUsername, "Email1");

            // Act
            BaseResponse res = env.secAuthSvc.Authenticate.SendEmailLinkOtp(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, res.Status);
        }
        
        [TestMethod]
        public void ValidateSendPushAcceptSymbolTest()
        {
            // Arrange
            PushAcceptSymbolRequest req = new PushAcceptSymbolRequest(env.goodUsername, "1f12159f-244a-420f-9713-0f50d7eb10e0");

            // Act
            PushAcceptSymbolResponse res = env.secAuthSvc.Authenticate.SendPushAcceptSymbol(req);

            BaseResponse resStatus = env.secAuthSvc.Authenticate.GetPushAcceptStatus(res.ReferenceId);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, res.Status);
        }

        [TestMethod]
        public void ValidateSendPushBiometricTest()
        {
            BiometricType biometricType = new BiometricType();

            // Arrange
            PushBiometricRequest req = new PushBiometricRequest(env.goodUsername, "ac809acab7f64f82a53922498a701f7b", biometricType);

            // Act
            PushBiometricResponse res = env.secAuthSvc.Authenticate.SendPushBiometric(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, res.Status);
        }

        [TestMethod]
        public void ValidateGetPushAcceptStatusTest()
        {
            
            // Act
            BaseResponse res = env.secAuthSvc.Authenticate.GetPushAcceptStatus("3fbea605-b027-4c2f-b345-ce0d497111c3");

            // Assert
            Assert.AreEqual("ACCEPTED", res.Status);
        }

        [TestMethod]
        public void ValidateGetLinkStatusTest()
        {

            // Act
            BaseResponse res = env.secAuthSvc.Authenticate.GetLinkStatus("f3b0e479-90e8-4d09-a53c-f0ee2a95eecb");

            // Assert
            Assert.AreEqual("ACCEPTED", res.Status);
        }

        [TestMethod]
        public void ValidateGetPushAcceptStatusStateFulTest()
        {
            string ingressCookie = "1625673799.852.257.384037";
            // Act
            BaseResponse res = env.secAuthSvc.Authenticate.GetPushAcceptStatusStateful("9320be4e-c631-40c6-82db-05ddfa8b27c0", ingressCookie);

            // Assert
            Assert.AreEqual("ACCEPTED", res.Message);
        }


        //SmsLinkResponse SendAdHocSmsLinkOtp(AdHocSmsLinkOtpRequest request, bool errorOnAccountStatus = false)
        [TestMethod]
        public void ValidateSendAdHocSmsLinkOtpTest()
        {
            AdHocSmsLinkOtpRequest req = new AdHocSmsLinkOtpRequest();
            req.Token = env.goodPhoneNumber;
            req.UserId = "Test";
            // Act
            SmsLinkResponse res = env.secAuthSvc.Authenticate.SendAdHocSmsLinkOtp(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, res.Status);
        }

        [TestMethod]
        public void ValidateSendAdHocEmailLinkOtpTest()
        {
            AdHocEmailLinkOtpRequest req = new AdHocEmailLinkOtpRequest();
            req.Token = env.goodEmailAddress;
            req.UserId = "Test";
            // Act
            EmailLinkResponse res = env.secAuthSvc.Authenticate.SendAdHocEmailLinkOtp(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, res.Status);
        }
    }
}
