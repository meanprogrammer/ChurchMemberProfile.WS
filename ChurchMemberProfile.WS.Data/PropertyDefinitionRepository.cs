using ChurchMemberProfile.WS.Data.Core;
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
            MemberProfilePropertyDefinition def = null;
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                def = context.MemberProfilePropertyDefinitions.Where(c => c.RecordID == id).FirstOrDefault();
            }
            return def;
        }

        public IEnumerable<MemberProfilePropertyDefinition> GetAll()
        {
            IEnumerable<MemberProfilePropertyDefinition> defs = null;
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                defs = context.MemberProfilePropertyDefinitions.ToList();
            }
            return defs;
        }

        public void InsertOnSubmit(MemberProfilePropertyDefinition entity)
        {
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                context.MemberProfilePropertyDefinitions.Add(entity);
                context.SaveChanges();
            }
        }

        public void DeleteOnSubmit(int id)
        {
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                MemberProfilePropertyDefinition def = context.MemberProfilePropertyDefinitions.Where(c => c.RecordID == id).FirstOrDefault();
                if (def != null)
                {
                    context.MemberProfilePropertyDefinitions.Remove(def);
                    context.SaveChanges();
                }
            }
        }
    }
}
