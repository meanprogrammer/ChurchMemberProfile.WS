using ChurchMemberProfile.WS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchMemberProfile.WS.Data
{
    public class MemberProfilePropertyRepository : IRepository<MemberProfilePropertyValue>
    {
        public MemberProfilePropertyValue GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MemberProfilePropertyValue> GetAll()
        {
            throw new NotImplementedException();
        }

        public void InsertOnSubmit(MemberProfilePropertyValue entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteOnSubmit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
