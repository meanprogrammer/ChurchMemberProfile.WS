using ChurchMemberProfile.WS.Data.Core;
using ChurchMemberProfile.WS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchMemberProfile.WS.Data
{
    public class PropertyDefinitionRepository : IRepository<PropertyTemplateItem>
    {

        public PropertyTemplateItem GetById(int id)
        {
            PropertyTemplateItem def = null;
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                def = context.PropertyTemplateItems.Where(c => c.RecordID == id).FirstOrDefault();
            }
            return def;
        }

        public IEnumerable<PropertyTemplateItem> GetAll()
        {
            IEnumerable<PropertyTemplateItem> defs = null;
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                defs = context.PropertyTemplateItems.ToList();
            }
            return defs;
        }

        public void InsertOnSubmit(PropertyTemplateItem entity)
        {
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                context.PropertyTemplateItems.Add(entity);
                context.SaveChanges();
            }
        }

        public void DeleteOnSubmit(int id)
        {
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                PropertyTemplateItem def = context.PropertyTemplateItems.Where(c => c.RecordID == id).FirstOrDefault();
                if (def != null)
                {
                    context.PropertyTemplateItems.Remove(def);
                    context.SaveChanges();
                }
            }
        }
    }
}
