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
            inner.InsertOnSubmit(t1);
        }

        [ClassCleanup]
        public static void cleanup()
        {
            using (ChurchMemberProfileEntities context = new ChurchMemberProfileEntities())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE PropertyTemplateItem");
                context.Database.ExecuteSqlCommand("ALTER TABLE PropertyTemplateItem DROP CONSTRAINT FK_PropertyTemplateItem_PropertyTemplate");
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE PropertyTemplate;");
                context.Database.ExecuteSqlCommand("ALTER TABLE PropertyTemplateItem  WITH CHECK ADD  CONSTRAINT [FK_PropertyTemplateItem_PropertyTemplate] FOREIGN KEY([TemplateID]) REFERENCES [dbo].[PropertyTemplate] ([RecordID])");
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
            var all = repo.GetAll();
            Assert.IsNotNull(all);
            Assert.AreEqual(1, all.Count());
        }

        [TestMethod()]
        public void InsertOnSubmitTest()
        {
            PropertyTemplate t1 = new PropertyTemplate()
            {
                RecordID = 1,
                TemplateName = "leaders template Template",
                TemplateDescription = "leaders template Description"
            };

            List<PropertyTemplateItem> list = new List<PropertyTemplateItem>();
            PropertyTemplateItem d1 = new PropertyTemplateItem()
            {
                RecordID = 1,
                Name = "Chapter 21",
                Type = "Bool",
                Enabled = 1,
                Description = "Has the member finished with the chapter 21",
                TemplateID = 1
            };

            PropertyTemplateItem d2 = new PropertyTemplateItem()
            {
                RecordID = 2,
                Name = "Chapter 22",
                Type = "Bool",
                Enabled = 1,
                Description = "Has the member finished with the chapter 22",
                TemplateID = 1
            };

            PropertyTemplateItem d3 = new PropertyTemplateItem()
            {
                RecordID = 3,
                Name = "Chapter 23",
                Type = "Bool",
                Enabled = 1,
                Description = "Has the member finished with the chapter 23",
                TemplateID = 1
            };

            list.Add(d1); list.Add(d2); list.Add(d3);
            t1.PropertyTemplateItems = list;
            inner.InsertOnSubmit(t1);

            var template = repo.GetById(t1.RecordID);
            Assert.IsNotNull(template);
        }

        [TestMethod()]
        public void DeleteOnSubmitTest()
        {
            PropertyTemplate t1 = new PropertyTemplate()
            {
                RecordID = 1,
                TemplateName = "advanced template Template",
                TemplateDescription = "advanced template Description"
            };

            List<PropertyTemplateItem> list = new List<PropertyTemplateItem>();
            PropertyTemplateItem d1 = new PropertyTemplateItem()
            {
                RecordID = 1,
                Name = "Chapter 11",
                Type = "Bool",
                Enabled = 1,
                Description = "Has the member finished with the chapter 11",
                TemplateID = 1
            };

            PropertyTemplateItem d2 = new PropertyTemplateItem()
            {
                RecordID = 2,
                Name = "Chapter 12",
                Type = "Bool",
                Enabled = 1,
                Description = "Has the member finished with the chapter 12",
                TemplateID = 1
            };

            PropertyTemplateItem d3 = new PropertyTemplateItem()
            {
                RecordID = 3,
                Name = "Chapter 13",
                Type = "Bool",
                Enabled = 1,
                Description = "Has the member finished with the chapter 13",
                TemplateID = 1
            };

            list.Add(d1); list.Add(d2); list.Add(d3);
            t1.PropertyTemplateItems = list;
            inner.InsertOnSubmit(t1);

            repo.DeleteOnSubmit(2);

            var template = repo.GetById(2);
            Assert.IsNull(template);

        }
    }
}
