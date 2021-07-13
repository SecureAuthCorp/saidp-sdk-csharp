using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureAuth.Sdk.Requests;
using SecureAuth.Sdk.Responses;

namespace SecureAuth.Sdk.UnitTests
{
    [TestClass]
    public class BehavioralBiometricsServiceTest
    {
        static EnvironmentBehavioralBiometricsServiceTest env;
        static readonly string _secureAuthRealm = ConfigurationManager.AppSettings["SecureAuthRealmUrl"];

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            env = new EnvironmentBehavioralBiometricsServiceTest();
        }

        [TestMethod]
        public void ValidateGetBehavioralBioJavascriptLinkTest()
        {
             BiometricsJavascriptLinkResponse res = env.secAuthSvc.BehavioralBiometricsService.GetBehavioralBioJavascriptLink();

            // Assert
            Assert.AreEqual($"{_secureAuthRealm}/assets/scripts/api/behaveBio.obf.js?ver=20.06.00.0", res.Source, true);
        }

        [TestMethod]
        public void ValidateResetBehavioralBioTest()
        {
            ResetBehavioralBioRequest req = new ResetBehavioralBioRequest();
            req.UserId = env.goodUsername;
            req.FieldName = env.fieldName;
            req.DeviceType = env.deviceType;
            req.FieldType = env.fieldType;

            BaseResponse res = env.secAuthSvc.BehavioralBiometricsService.ResetBehavioralBio(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, res.Status);
        }

        [TestMethod]
        public void ValidateSendBehavioralBioTest()
        {
            SendBehavioralBioRequest req = new SendBehavioralBioRequest();
            req.UserId = env.goodUsername;
            req.BehaviorProfile = env.behaviorProfile;
            req.HostAddress = env.hostAddress;
            req.UserAgent = env.userAgent;

            BaseResponse res = env.secAuthSvc.BehavioralBiometricsService.SendBehavioralBio(req);

            // Assert
            Assert.AreEqual(Constants.ResponseStatus.Valid, res.Status);
        }
    }
}
