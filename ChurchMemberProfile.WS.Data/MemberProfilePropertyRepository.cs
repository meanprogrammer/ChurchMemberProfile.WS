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

        public MemberProfilePropertyRepository() { }

        public MemberProfilePropertyValue GetById(int id)
        {
            MemberProfilePropertyValue prop = null;
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                prop = context.MemberProfilePropertyValues.Where(c => c.RecordID == id).FirstOrDefault();
            }
            return prop;
        }


        protected void SetMemberId(int memberId)
        {
            this.memberId = memberId;
        }

        public IEnumerable<MemberProfilePropertyValue> GetAll()
        {
            if (this.memberId == 0) { throw new InvalidOperationException("A member id must be set."); }

            IEnumerable<MemberProfilePropertyValue> props = null;
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                props = context.MemberProfilePropertyValues.Where(c => c.MemberId == this.memberId).ToList();
            }
            return props;
        }

        public void InsertOnSubmit(MemberProfilePropertyValue entity)
        {
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                context.MemberProfilePropertyValues.Add(entity);
                context.SaveChanges();
            }
            
        }

        public void DeleteOnSubmit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
