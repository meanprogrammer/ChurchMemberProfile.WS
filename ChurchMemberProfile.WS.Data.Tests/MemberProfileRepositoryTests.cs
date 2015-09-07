using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChurchMemberProfile.WS.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChurchMemberProfile.WS.Model;
using ChurchMemberProfile.WS.Data.Core;
namespace ChurchMemberProfile.WS.Data.Tests
{
    [TestClass()]
    public class MemberProfileRepositoryTests
    {
        MemberProfileRepository repo = new MemberProfileRepository();
        static MemberProfileRepository inner = new MemberProfileRepository();

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
        }

        [ClassCleanup]
        public static void cleanup()
        {
            UnitTestHelper.TruncateTable("MemberProfile");
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            MemberProfile result = repo.GetById(1);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetByIdTestNotExist()
        {
            MemberProfile result = repo.GetById(99);
            Assert.IsNull(result);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            IEnumerable<MemberProfile> result = repo.GetAll();
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod()]
        public void InsertOnSubmitTest()
        {
            MemberProfile m1 = new MemberProfile()
            {
                RecordID = 2,
                Lastname = "Nicdao",
                Firstname = "Apple",
                MI = "B",
                Nickname = "Apz",
                Address = "Cabuyao City",
                Birthdate = new DateTime(1984, 10, 30),
                LeaderId = 11
            };

            repo.InsertOnSubmit(m1);

            MemberProfile mp = repo.GetById(2);
            Assert.IsNotNull(mp);
        }

        [TestMethod()]
        public void DeleteOnSubmitTest()
        {
            MemberProfile m1 = new MemberProfile()
            {
                Lastname = "Dudan",
                Firstname = "PV",
                MI = "N",
                Nickname = "Duduy",
                Address = "Cabuyao City",
                Birthdate = new DateTime(2012, 10, 9),
                LeaderId = 11
            };

            repo.InsertOnSubmit(m1);

            MemberProfile mp = repo.GetById(m1.RecordID);
            Assert.IsNotNull(mp);

            int deletedId = m1.RecordID;

            repo.DeleteOnSubmit(m1.RecordID);

            MemberProfile mp2 = repo.GetById(deletedId);
            Assert.IsNull(mp2);
        }
    }
}
