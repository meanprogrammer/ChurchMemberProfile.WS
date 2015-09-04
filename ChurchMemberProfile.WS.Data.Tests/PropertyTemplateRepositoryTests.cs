using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChurchMemberProfile.WS.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChurchMemberProfile.WS.Data.Core;
using ChurchMemberProfile.WS.Model;
namespace ChurchMemberProfile.WS.Data.Tests
{
    [TestClass()]
    public class PropertyTemplateRepositoryTests
    {
        PropertyTemplateRepository repo = new PropertyTemplateRepository();
        static PropertyTemplateRepository inner = new PropertyTemplateRepository();

        private static TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [ClassInitialize]
        public static void init(TestContext a)
        {
            cleanup();
            PropertyTemplate t1 = new PropertyTemplate()
            {
                RecordID = 1,
                TemplateName = "Default Template",
                TemplateDescription = "Default template Description"
            };

            List<MemberProfilePropertyDefinition> list = new List<MemberProfilePropertyDefinition>();
            MemberProfilePropertyDefinition d1 = new MemberProfilePropertyDefinition() { 
                RecordID = 1,
                Name = "Chapter 1",
                Type = "Bool",
                Enabled = 1,
                Description = "Has the member finished with the chapter 1",
                TemplateID = 1
            };

            MemberProfilePropertyDefinition d2 = new MemberProfilePropertyDefinition()
            {
                RecordID = 2,
                Name = "Chapter 2",
                Type = "Bool",
                Enabled = 1,
                Description = "Has the member finished with the chapter 2",
                TemplateID = 1
            };

            MemberProfilePropertyDefinition d3 = new MemberProfilePropertyDefinition()
            {
                RecordID = 3,
                Name = "Chapter 3",
                Type = "Bool",
                Enabled = 1,
                Description = "Has the member finished with the chapter 3",
                TemplateID = 1
            };

            list.Add(d1); list.Add(d2); list.Add(d3);
            t1.MemberProfilePropertyDefinitions = list;
            inner.InsertOnSubmit(t1);
        }

        [ClassCleanup]
        public static void cleanup()
        {
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE MemberProfilePropertyDefinition");
                context.Database.ExecuteSqlCommand("ALTER TABLE MemberProfilePropertyDefinition DROP CONSTRAINT FK_MemberProfilePropertyDefinition_PropertyTemplate");
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE PropertyTemplate;");
                context.Database.ExecuteSqlCommand("ALTER TABLE MemberProfilePropertyDefinition  WITH CHECK ADD  CONSTRAINT [FK_MemberProfilePropertyDefinition_PropertyTemplate] FOREIGN KEY([TemplateID]) REFERENCES [dbo].[PropertyTemplate] ([RecordID])");
            }
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            PropertyTemplate t = repo.GetById(1);
            Assert.IsNotNull(t);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void InsertOnSubmitTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DeleteOnSubmitTest()
        {
            throw new NotImplementedException();
        }
    }
}
