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
            throw new NotImplementedException();
        }

        public IEnumerable<MemberProfile> GetAll()
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

        public void SubmitChanges()
        {
            throw new NotImplementedException();
        }
    }
}
