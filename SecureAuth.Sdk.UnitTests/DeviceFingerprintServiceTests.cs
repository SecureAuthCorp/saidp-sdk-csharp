using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureAuth.Sdk.Models;
using SecureAuth.Sdk.Responses;
using System;
using System.Configuration;

namespace SecureAuth.Sdk.UnitTests
{
    [TestClass]
    public class DeviceFingerprintServiceTests
    {
        // Globals
        static ISecureAuthService secAuthSvc;
        ValidateDfpRequest _validateDfpRequest;
        ScoreDfpRequest _scoreDfpRequest;
        SaveDfpRequest _saveDfpRequest;
        static string goodUsername1;
        static string goodUsername2;

        static readonly string _secureAuthRealm = ConfigurationManager.AppSettings["SecureAuthRealmUrl"];

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            // Grab values from app.config
            goodUsername1 = ConfigurationManager.AppSettings["DeviceFingerprintSvc.goodUsername1"];
            goodUsername2 = ConfigurationManager.AppSettings["DeviceFingerprintSvc.goodUsername2"];

            string apiId = ConfigurationManager.AppSettings["ApiID"];
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];

            // Init the SecureAuthService
            Configuration config = new Configuration(_secureAuthRealm, apiId, apiKey);
            secAuthSvc = new SecureAuthService(config);
        }

        [TestInitialize]
        public void TestInit()
        {
            Fingerprint fingerprint = new Fingerprint
            {
                Fonts = "Agency FB,Aharoni,Algerian,Andalus,Angsana New,AngsanaUPC",
                Plugins = "ActiveTouch General Plugin Container:ActiveTouch General Plugin Container Version 105",
                TimeZone = "America/Los_Angeles",
                Video = "1920x1080x24",
                LocalStorage = false,
                SessionStorage = false,
                IeUserDate = false,
                CookieEnabled = true,
                UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:41.0) Gecko/20100101 Firefox/41.0",
                Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
                AcceptCharSet = "utf-8",
                AcceptEncoding = "gzip, deflate",
                AcceptLanguage = "en-US,en;q=0.5",
            };

            _validateDfpRequest = new ValidateDfpRequest
            {
                UserId = goodUsername1,
                HostAddress = "172.217.3.110",
                Fingerprint = fingerprint,
            };

            _scoreDfpRequest = new ScoreDfpRequest
            {
                UserId = goodUsername1,
                HostAddress = "172.217.3.110",
                Fingerprint = fingerprint,
            };

            _saveDfpRequest = new SaveDfpRequest
            {
                UserId = goodUsername1,
                HostAddress = "172.217.3.110",
                Fingerprint = fingerprint,
            };
        }

        [TestMethod]
        public void GetDfpJavascriptLinkTest()
        {
            // Arrange
            // Act
            DfpJavascriptLinkResponse res = secAuthSvc.DeviceFingerprint.GetDfpJavascriptLink();

            // Assert
            Assert.AreEqual($"{_secureAuthRealm}/assets/scripts/api/digitalFingerprint.min.js?ver=9.1.0.102", res.Source, true);
        }

        [TestMethod]
        public void ValidateDfpWithoutUserIdTest()
        {
            // Arrange
            _validateDfpRequest.UserId = null;

            // Act
            try
            {
                DfpResponse res = secAuthSvc.DeviceFingerprint.ValidateDfp(_validateDfpRequest);

                Assert.Fail("No exception was thrown.");
            }
            // Assert
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(@"User ID cannot be empty.
Parameter name: ValidateDfpRequest.UserId", ex.Message);
            }
        }

        [TestMethod]
        public void ValidateDfpWithoutHostAddressTest()
        {
            // Arrange
            _validateDfpRequest.HostAddress = null;

            // Act
            try
            {
                DfpResponse res = secAuthSvc.DeviceFingerprint.ValidateDfp(_validateDfpRequest);

                Assert.Fail("No exception was thrown.");
            }
            // Assert
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(@"Host Address cannot be empty.
Parameter name: ValidateDfpRequest.HostAddress", ex.Message);
            }
        }

        [TestMethod]
        public void ValidateDfpWithoutFingerprintTest()
        {
            // Arrange
            _validateDfpRequest.Fingerprint = null;

            // Act
            try
            {
                DfpResponse res = secAuthSvc.DeviceFingerprint.ValidateDfp(_validateDfpRequest);

                Assert.Fail("No exception was thrown.");
            }
            // Assert
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(@"Fingerprint cannot be empty.
Parameter name: ValidateDfpRequest.Fingerprint", ex.Message);
            }
        }

        [TestMethod]
        public void ValidateDfpTest()
        {
            // Arrange
            // Act
            DfpResponse res = secAuthSvc.DeviceFingerprint.ValidateDfp(_validateDfpRequest);

            // Assert
            Assert.IsTrue(res.IsSucess());
            Assert.IsNotNull(res.FingerprintId);
            Assert.IsNotNull(res.FingerprintName);
        }

        [TestMethod]
        public void ConfirmDfpWithoutUserIdTest()
        {
            // Arrange
            ConfirmDfpRequest req = new ConfirmDfpRequest
            {
                FingerprintId = "bae0d00c3f484459ae5a2dc823dc8d2f",
            };

            // Act
            try
            {
                DfpResponse res = secAuthSvc.DeviceFingerprint.ConfirmDfp(req);

                Assert.Fail("No exception was thrown.");
            }
            // Assert
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(@"User ID cannot be empty.
Parameter name: ValidateDfpRequest.UserId", ex.Message);
            }
        }

        [TestMethod]
        public void ConfirmDfpWithoutFingerprintIdTest()
        {
            // Arrange
            ConfirmDfpRequest req = new ConfirmDfpRequest
            {
                UserId = goodUsername1,
            };

            // Act
            try
            {
                DfpResponse res = secAuthSvc.DeviceFingerprint.ConfirmDfp(req);

                Assert.Fail("No exception was thrown.");
            }
            // Assert
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(@"Fingerprint ID cannot be empty.
Parameter name: ValidateDfpRequest.FingerprintId", ex.Message);
            }
        }

        [TestMethod]
        public void ConfirmDfpTest()
        {
            // Arrange
            _validateDfpRequest.UserId = goodUsername2;

            DfpResponse res = secAuthSvc.DeviceFingerprint.ValidateDfp(_validateDfpRequest);

            ConfirmDfpRequest req = new ConfirmDfpRequest
            {
                UserId = _validateDfpRequest.UserId,
                FingerprintId = res.FingerprintId,
            };

            // Act
            res = secAuthSvc.DeviceFingerprint.ConfirmDfp(req);

            // Assert
            Assert.IsTrue(res.IsSucess());
            Assert.IsNotNull(res.FingerprintId);
            Assert.IsNotNull(res.FingerprintName);
        }

        [TestMethod]
        public void ScoreDfpWithoutUserIdTest()
        {
            // Arrange
            _scoreDfpRequest.UserId = null;

            // Act
            try
            {
                DfpResponse res = secAuthSvc.DeviceFingerprint.ScoreDfp(_scoreDfpRequest);

                Assert.Fail("No exception was thrown.");
            }
            // Assert
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(@"User ID cannot be empty.
Parameter name: ValidateDfpRequest.UserId", ex.Message);
            }
        }

        [TestMethod]
        public void ScoreDfpWithoutHostAddressTest()
        {
            // Arrange
            _scoreDfpRequest.HostAddress = null;

            // Act
            try
            {
                DfpResponse res = secAuthSvc.DeviceFingerprint.ScoreDfp(_scoreDfpRequest);

                Assert.Fail("No exception was thrown.");
            }
            // Assert
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(@"Host Address cannot be empty.
Parameter name: ValidateDfpRequest.HostAddress", ex.Message);
            }
        }

        [TestMethod]
        public void ScoreDfpWithoutFingerprintTest()
        {
            // Arrange
            _scoreDfpRequest.Fingerprint = null;

            // Act
            try
            {
                DfpResponse res = secAuthSvc.DeviceFingerprint.ScoreDfp(_scoreDfpRequest);

                Assert.Fail("No exception was thrown.");
            }
            // Assert
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(@"Fingerprint cannot be empty.
Parameter name: ValidateDfpRequest.Fingerprint", ex.Message);
            }
        }

        [TestMethod]
        public void ScoreDfpTest()
        {
            // Arrange
            // Act
            DfpResponse res = secAuthSvc.DeviceFingerprint.ScoreDfp(_scoreDfpRequest);

            // Assert
            Assert.IsTrue(res.IsSucess());
            Assert.IsNotNull(res.FingerprintId);
            Assert.IsNotNull(res.FingerprintName);
        }

        [TestMethod]
        public void SaveDfpWithoutUserIdTest()
        {
            // Arrange
            _saveDfpRequest.UserId = null;

            // Act
            try
            {
                DfpResponse res = secAuthSvc.DeviceFingerprint.SaveDfp(_saveDfpRequest);

                Assert.Fail("No exception was thrown.");
            }
            // Assert
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(@"User ID cannot be empty.
Parameter name: ValidateDfpRequest.UserId", ex.Message);
            }
        }

        [TestMethod]
        public void SaveDfpWithoutHostAddressTest()
        {
            // Arrange
            _saveDfpRequest.HostAddress = null;

            // Act
            try
            {
                DfpResponse res = secAuthSvc.DeviceFingerprint.SaveDfp(_saveDfpRequest);

                Assert.Fail("No exception was thrown.");
            }
            // Assert
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(@"Host Address cannot be empty.
Parameter name: ValidateDfpRequest.HostAddress", ex.Message);
            }
        }

        [TestMethod]
        public void SaveDfpWithoutFingerprintTest()
        {
            // Arrange
            _saveDfpRequest.Fingerprint = null;

            // Act
            try
            {
                DfpResponse res = secAuthSvc.DeviceFingerprint.SaveDfp(_saveDfpRequest);

                Assert.Fail("No exception was thrown.");
            }
            // Assert
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(@"Fingerprint cannot be empty.
Parameter name: ValidateDfpRequest.Fingerprint", ex.Message);
            }
        }

        [TestMethod]
        public void SaveDfpTest()
        {
            // Arrange
            _validateDfpRequest.UserId = goodUsername2;

            DfpResponse res = secAuthSvc.DeviceFingerprint.ValidateDfp(_validateDfpRequest);

            _saveDfpRequest.UserId = _validateDfpRequest.UserId;

            // Act
            res = secAuthSvc.DeviceFingerprint.SaveDfp(_saveDfpRequest);

            // Assert
            Assert.IsTrue(res.IsSucess());
            Assert.IsNotNull(res.FingerprintId);
            Assert.IsNotNull(res.FingerprintName);
        }
    }
}
