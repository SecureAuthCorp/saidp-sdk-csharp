using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SecureAuth.Sdk.UnitTests
{
    [TestClass]
    public class GroupServiceTest
    {
        static EnvironmentGroupServiceTest env;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            env = new EnvironmentGroupServiceTest();
        }

        [TestMethod]
        public void ValidateAddUserToGroupQueryStringTest()
        {
            BaseResponse res = env.secAuthSvc.GroupService.AddUserToGroupQueryString(env.groupName1, env.goodUserId, env.goodDomain);
            Assert.AreEqual(Constants.ResponseStatus.Success, res.Status);
        }

    }
}
