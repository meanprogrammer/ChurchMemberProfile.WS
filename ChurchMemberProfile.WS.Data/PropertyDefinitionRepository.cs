using ChurchMemberProfile.WS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchMemberProfile.WS.Data
{
    public class PropertyDefinitionRepository : IRepository<MemberProfilePropertyDefinition>
    {
        public MemberProfilePropertyDefinition GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MemberProfilePropertyDefinition> GetAll()
        {
            throw new NotImplementedException();
        }

        public void InsertOnSubmit(MemberProfilePropertyDefinition entity)
        {
            
        }

        public void DeleteOnSubmit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
