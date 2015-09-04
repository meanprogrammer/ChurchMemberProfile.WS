﻿using ChurchMemberProfile.WS.Data.Core;
using ChurchMemberProfile.WS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchMemberProfile.WS.Data
{
    public class PropertyTemplateRepository : IRepository<PropertyTemplate>
    {
        public PropertyTemplate GetById(int id)
        {
            PropertyTemplate template = null;
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                template = context.PropertyTemplates.Where(c => c.RecordID == id).FirstOrDefault();
                if (template != null) 
                {
                    template.MemberProfilePropertyDefinitions = context.MemberProfilePropertyDefinitions.Where(x => x.TemplateID == template.RecordID).ToList();
                }
            }
            return template;
        }

        private List<MemberProfilePropertyDefinition> GetProperties(int templateId) {
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                return context.MemberProfilePropertyDefinitions.Where(c => c.TemplateID == templateId).ToList();
            }
        }

        public IEnumerable<PropertyTemplate> GetAll()
        {
            IEnumerable<PropertyTemplate> all = null;
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                all = context.PropertyTemplates.ToList();
                foreach (PropertyTemplate a in all)
                {
                    a.MemberProfilePropertyDefinitions = GetProperties(a.RecordID);
                }
            }
            return all;
        }

        public void InsertOnSubmit(PropertyTemplate entity)
        {
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                context.PropertyTemplates.Add(entity);
                context.SaveChanges();
            }
        }

        public void DeleteOnSubmit(int id)
        {
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                PropertyTemplate template = context.PropertyTemplates.Where(c => c.RecordID == id).FirstOrDefault();
                if (template != null)
                {
                    context.PropertyTemplates.Remove(template);
                    context.SaveChanges();
                }
            }
        }
    }
}