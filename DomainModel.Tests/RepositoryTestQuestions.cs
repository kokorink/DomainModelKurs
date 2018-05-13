using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainModel.Tests
{
    [TestClass]
    public class RepositoryTestQuestions
    {

        [TestMethod]
        public void QFindBy()
        {
            Questions TestQuestion = new Questions { Question = "FindByQuestion?", TimeQuestion = DateTime.Now, UserName = "FindByTest", UserMail = "FindBy@domainmodel.test" };
            GenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            RepQ.Add(TestQuestion);
            RepQ.Save();
            Questions findByQuestion = RepQ.FindBy(question => question.Question == "FindByQuestion?").First();
            Assert.AreEqual(findByQuestion.UserName, "FindByTest");
            RepQ.Delete(TestQuestion);
            RepQ.Save();
        }

        [TestMethod]
        public void QAddTest()
        {
            Questions TestQuestion = new Questions { Question = "AddTestQuestion?", TimeQuestion = DateTime.Now, UserName = "AddTest", UserMail = "AddTest@domainmodel.test" };
            GenericRepository<Questions> RepQ = new GenericRepository<Questions>();

            int x = RepQ.GetAll().Count();
            RepQ.Add(TestQuestion);
            RepQ.Save();

            Assert.IsTrue(RepQ.GetAll().Count() > x);
            Assert.AreEqual("AddTest@domainmodel.test", RepQ.GetAll().Where(item => item.Question == "AddTestQuestion?").First().UserMail);
            RepQ.Delete(TestQuestion);
            RepQ.Save();
        }

        [TestMethod]
        public void QDeleteTest()
        {
            Questions TestQuestion = new Questions { Question = "DeleteTestQuestion?", TimeQuestion = DateTime.Now, UserName = "DeleteTest", UserMail = "DeleteTest@domainmodel.test" };
            GenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            RepQ.Add(TestQuestion);
            RepQ.Save();

            int x = RepQ.GetAll().Where(item => item.Question == "DeleteTestQuestion?").Count();
            Assert.IsTrue(x == 1);
            RepQ.Delete(TestQuestion);
            RepQ.Save();

            x = RepQ.GetAll().Where(item => item.Question == "DeleteTestQuestion?").Count();
            Assert.IsTrue(x == 0);

        }

        [TestMethod]
        public void QSaveTest()
        {
            Questions TestQuestion = new Questions { Question = "SaveTestQuestion?", TimeQuestion = DateTime.Now, UserName = "SaveTest", UserMail = "SaveTest@domainmodel.test" };
            GenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            RepQ.Add(TestQuestion);

            int x = RepQ.GetAll().Where(item => item.Question == "SaveTestQuestion?").Count();
            Assert.IsTrue(x == 0);
            RepQ.Save();

            x = RepQ.GetAll().Where(item => item.Question == "SaveTestQuestion?").Count();
            Assert.IsTrue(x == 1);
            RepQ.Delete(TestQuestion);

            x = RepQ.GetAll().Where(item => item.Question == "SaveTestQuestion?").Count();
            Assert.IsTrue(x == 1);
            RepQ.Save();

            x = RepQ.GetAll().Where(item => item.Question == "SaveTestQuestion?").Count();
            Assert.IsTrue(x == 0);
        }

        [TestMethod]
        public void QEditTest()
        {
            Questions TestQuestion = new Questions { Question = "EditTestQuestion?", TimeQuestion = DateTime.Now, UserName = "EditTest", UserMail = "EditTest@domainmodel.test" };
            GenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            RepQ.Add(TestQuestion);
            RepQ.Save();
            int x = RepQ.GetAll().Where(item => item.Question == "EditTestQuestion?").Count();
            Assert.IsTrue(x == 1);
            TestQuestion.Question = "NewEditTestQuestion?";
            RepQ.Edit(TestQuestion);
            RepQ.Save();
            x = RepQ.GetAll().Where(item => item.Question == "EditTestQuestion?").Count();
            Assert.IsTrue(x == 0);
            x = RepQ.GetAll().Where(item => item.Question == "NewEditTestQuestion?").Count();
            Assert.IsTrue(x == 1);
            RepQ.Delete(TestQuestion);
            RepQ.Save();
        }


        [TestMethod]
        public void QGetAllTest()
        {
            Questions TestQuestion = new Questions {Question = "GetAllTestQuestion?", TimeQuestion = DateTime.Now, UserName = "GetAll", UserMail = "GetAll@domainmodel.test" };
            GenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            int x = RepQ.GetAll().Count();
            RepQ.Add(TestQuestion);
            RepQ.Save();
            Assert.IsTrue(RepQ.GetAll().Count() > x);
            RepQ.Delete(TestQuestion);
            RepQ.Save();
        }
    }
}


