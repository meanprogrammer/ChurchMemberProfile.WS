using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChurchMemberProfile.WS.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChurchMemberProfile.WS.Model;
namespace ChurchMemberProfile.WS.Data.Tests
{
    [TestClass()]
    public class MemberProfileRepositoryTests
    {
        MemberProfileRepository repo = new MemberProfileRepository();
        [TestMethod()]
        public void GetByIdTest()
        {
            MemberProfile result = repo.GetById(1);
            Assert.IsNull(result);
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
