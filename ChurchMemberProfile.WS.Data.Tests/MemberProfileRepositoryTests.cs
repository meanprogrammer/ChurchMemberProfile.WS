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

        [ClassInitialize]
        public void init()
        {
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

            repo.InsertOnSubmit(m1);
        }

        [ClassCleanup]
        public void cleanup()
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
        public void GetAllTest()
        {
            IEnumerable<MemberProfile> result = repo.GetAll();
            Assert.AreEqual(0, result.Count());
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

        [TestMethod()]
        public void SubmitChangesTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void InsertOnSubmitTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DeleteOnSubmitTest1()
        {
            throw new NotImplementedException();
        }
    }
}
