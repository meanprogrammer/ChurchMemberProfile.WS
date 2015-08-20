using ChurchMemberProfile.WS.Data.Core;
using ChurchMemberProfile.WS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchMemberProfile.WS.Data
{
    public class MemberProfileRepository : IRepository<MemberProfile>
    {

        public MemberProfile GetById(int id)
        {
            MemberProfile member = null;
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                member = context.MemberProfiles.Where(c => c.RecordID == id).FirstOrDefault();
            }
            return member;
        }

        public IEnumerable<MemberProfile> GetAll()
        {
            List<MemberProfile> members = new List<MemberProfile>();
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                members = context.MemberProfiles.ToList();
            }
            return members;
        }

        public void InsertOnSubmit(int id)
        {
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                MemberProfile entity = context.MemberProfiles.Where(c => c.RecordID == id).FirstOrDefault();
                context.MemberProfiles.Add(entity);
                context.SaveChanges();
            }
        }

        public void DeleteOnSubmit(int id)
        {
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                MemberProfile entity = context.MemberProfiles.Where(c => c.RecordID == id).FirstOrDefault();
                context.MemberProfiles.Remove(entity);
                context.SaveChanges();
            }
        }

        public void SubmitChanges()
        {
            throw new NotImplementedException();
        }


        public void InsertOnSubmit(MemberProfile entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteOnSubmit(MemberProfile entity)
        {
            throw new NotImplementedException();
        }
    }
}
