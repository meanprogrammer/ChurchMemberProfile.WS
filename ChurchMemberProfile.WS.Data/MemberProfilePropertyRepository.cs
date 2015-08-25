using ChurchMemberProfile.WS.Data.Core;
using ChurchMemberProfile.WS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchMemberProfile.WS.Data
{
    public class MemberProfilePropertyRepository : IRepository<MemberProfilePropertyValue>
    {
        private int memberId;
        public MemberProfilePropertyRepository(int memberId)
        {
            this.memberId = memberId;
        }

        private MemberProfilePropertyRepository() { }

        public MemberProfilePropertyValue GetById(int id)
        {
            MemberProfilePropertyValue prop = null;
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                //prop = context.MemberProfilePropertyValues.Where(c=>c.)
            }
            return null;
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
