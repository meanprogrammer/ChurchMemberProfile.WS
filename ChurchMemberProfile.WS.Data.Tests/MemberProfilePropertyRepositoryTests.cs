using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChurchMemberProfile.WS.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ChurchMemberProfile.WS.Data.Tests
{
    [TestClass()]
    public class MemberProfilePropertyRepositoryTests
    {
        private static TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [ClassInitialize]
        public static void init(TestContext a)
        {
            cleanup();
            UnitTestHelper.InsertOneMember();
            int memberId = 1;
            UnitTestHelper.InsertDefaultTemplate(memberId);

        }

        [ClassCleanup]
        public static void cleanup()
        {
            UnitTestHelper.TruncateTable("MemberProfile");
        }

        [TestMethod()]
        public void MemberProfilePropertyRepositoryContructorTest()
        {
            MemberProfilePropertyRepository repo = new MemberProfilePropertyRepository();
            Assert.IsNotNull(repo);
            MemberProfilePropertyRepository repo2 = new MemberProfilePropertyRepository(2);
            Assert.IsNotNull(repo2);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void InsertOnSubmitTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DeleteOnSubmitTest()
        {
            throw new NotImplementedException();
        }
    }
}
