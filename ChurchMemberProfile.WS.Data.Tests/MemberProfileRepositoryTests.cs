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
            MemberProfile m1 = new MemberProfile() { 
                RecordID = 1,
                Lastname = "Dudan",
                Firstname = "Valiant",
                MI = "A",
                Nickname = "Dudz",
                Address = "Caloocan City",
                Birthdate = new DateTime(1986, 8, 14),
                LeaderId = 11
            };

            inner.InsertOnSubmit(m1);
        }

        [ClassCleanup]
        public static void cleanup()
        {
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE MemberProfile");
            }
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
                RecordID = 3,
                Lastname = "Dudan",
                Firstname = "PV",
                MI = "N",
                Nickname = "Duduy",
                Address = "Cabuyao City",
                Birthdate = new DateTime(2012, 10, 9),
                LeaderId = 11
            };

            repo.InsertOnSubmit(m1);

            MemberProfile mp = repo.GetById(3);
            Assert.IsNotNull(mp);

            repo.DeleteOnSubmit(3);

            MemberProfile mp2 = repo.GetById(3);
            Assert.IsNull(mp2);
        }
    }
}
