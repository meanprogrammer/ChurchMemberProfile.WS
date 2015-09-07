using ChurchMemberProfile.WS.Data.Core;
using ChurchMemberProfile.WS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchMemberProfile.WS.Data.Tests
{
    public class UnitTestHelper
    {
        static MemberProfileRepository memberRepo = new MemberProfileRepository();
        static PropertyTemplateRepository templateRepo = new PropertyTemplateRepository();
        public static void InsertOneMember()
        {
            MemberProfile m1 = new MemberProfile()
            {
                RecordID = 1,
                Lastname = "Dudan",
                Firstname = "Valiant",
                MI = "A",
                Nickname = "Dudz",
                Address = "Caloocan City",
                Birthdate = new DateTime(1986, 8, 14),
                LeaderId = 11
            };

            memberRepo.InsertOnSubmit(m1);
        }

        public static void InsertDefaultTemplate(int memberId)
        {
            PropertyTemplate t1 = new PropertyTemplate()
            {
                RecordID = 1,
                TemplateName = "Default Template",
                TemplateDescription = "Default template Description"
            };

            List<PropertyTemplateItem> list = new List<PropertyTemplateItem>();
            PropertyTemplateItem d1 = new PropertyTemplateItem()
            {
                RecordID = 1,
                Name = "Chapter 1",
                Type = "Bool",
                Enabled = 1,
                Description = "Has the member finished with the chapter 1",
                TemplateID = 1
            };

            PropertyTemplateItem d2 = new PropertyTemplateItem()
            {
                RecordID = 2,
                Name = "Chapter 2",
                Type = "Bool",
                Enabled = 1,
                Description = "Has the member finished with the chapter 2",
                TemplateID = 1
            };

            PropertyTemplateItem d3 = new PropertyTemplateItem()
            {
                RecordID = 3,
                Name = "Chapter 3",
                Type = "Bool",
                Enabled = 1,
                Description = "Has the member finished with the chapter 3",
                TemplateID = 1
            };

            list.Add(d1); list.Add(d2); list.Add(d3);
            t1.PropertyTemplateItems = list;
            templateRepo.InsertOnSubmit(t1);
        }

        public static void TruncateTable(string tableName)
        {
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                context.Database.ExecuteSqlCommand(string.Format("TRUNCATE TABLE {0}", tableName));
            }
        }
    }
}
