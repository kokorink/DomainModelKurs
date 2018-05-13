using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Tests
{
    [TestClass]
    public class RepositoryTestAnswers
    {
        [TestMethod]
        public void AFindBy()
        {
            Questions TestQuestion = new Questions { Question = "FindByQuestion?", TimeQuestion = DateTime.Now, UserName = "FindByTest", UserMail = "FindBy@domainmodel.test" };
            GenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            RepQ.Add(TestQuestion);
            RepQ.Save();
            Answers TestAnswer = new Answers { Answer = "FindByAnswer", TimeAnswer = DateTime.Now,  IdQuestions = TestQuestion.Id};
            GenericRepository<Answers> RepA = new GenericRepository<Answers>();
            RepA.Add(TestAnswer);
            RepA.Save();
            Answers findByAnser = RepA.FindBy(answer => answer.Answer == "FindByAnswer").First();
            Assert.AreEqual(findByAnser.IdQuestions, TestQuestion.Id);
            RepA.Delete(TestAnswer);
            RepA.Save();
            RepQ.Delete(TestQuestion);
            RepQ.Save();
        }

        [TestMethod]
        public void AAddTest()
        {
            Questions TestQuestion = new Questions { Question = "AddTestQuestion?", TimeQuestion = DateTime.Now, UserName = "AddTest", UserMail = "AddTest@domainmodel.test" };
            GenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            RepQ.Add(TestQuestion);
            RepQ.Save();
            Answers TestAnswer = new Answers { Answer = "AddTestAnswer", TimeAnswer = DateTime.Now, IdQuestions = TestQuestion.Id };
            GenericRepository<Answers> RepA = new GenericRepository<Answers>();

            int x = RepA.GetAll().Where(item => item.Answer == "AddTestAnswer").Count();
            RepA.Add(TestAnswer);
            RepA.Save();

            Assert.IsTrue(RepA.GetAll().Where(item => item.Answer == "AddTestAnswer").Count() > x);
            Assert.AreEqual(TestQuestion.Id, RepA.GetAll().Where(item => item.Answer == "AddTestAnswer").First().IdQuestions);


            RepA.Delete(TestAnswer);
            RepA.Save();
            RepQ.Delete(TestQuestion);
            RepQ.Save();

        }

        [TestMethod]
        public void ADeleteTest()
        {
            Questions TestQuestion = new Questions { Question = "DeleteTestQuestion?", TimeQuestion = DateTime.Now, UserName = "DeleteTest", UserMail = "DeleteTest@domainmodel.test" };
            GenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            RepQ.Add(TestQuestion);
            RepQ.Save();
            Answers TestAnswer = new Answers { Answer = "DeleteTestAnswer", TimeAnswer = DateTime.Now, IdQuestions = TestQuestion.Id };
            GenericRepository<Answers> RepA = new GenericRepository<Answers>();
            RepA.Add(TestAnswer);
            RepA.Save();
            int x = RepA.GetAll().Where(item => item.Answer == "DeleteTestAnswer").Count();
            Assert.IsTrue(x == 1);
            RepA.Delete(TestAnswer);
            RepA.Save();
            RepQ.Delete(TestQuestion);
            RepQ.Save();
            x = RepA.GetAll().Where(item => item.Answer == "DeleteTestAnswer").Count();
            Assert.IsTrue(x == 0);
        }

        [TestMethod]
        public void ASaveTest()
        {
            Questions TestQuestion = new Questions { Question = "SaveTestQuestion?", TimeQuestion = DateTime.Now, UserName = "SaveTest", UserMail = "SaveTest@domainmodel.test" };
            GenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            RepQ.Add(TestQuestion);
            RepQ.Save();
            Answers TestAnswer = new Answers { Answer = "SaveTestAnswer", TimeAnswer = DateTime.Now, IdQuestions = TestQuestion.Id };
            GenericRepository<Answers> RepA = new GenericRepository<Answers>();
            RepA.Add(TestAnswer);
            int x = RepA.GetAll().Where(item => item.Answer == "SaveTestAnswer").Count();
            Assert.AreEqual(x, 0);
            RepA.Save();
            x = RepA.GetAll().Where(item => item.Answer == "SaveTestAnswer").Count();
            Assert.AreEqual(x, 1);
            RepA.Delete(TestAnswer);
            x = RepA.GetAll().Where(item => item.Answer == "SaveTestAnswer").Count();
            Assert.AreEqual(x, 1);
            RepA.Save();
            x = RepA.GetAll().Where(item => item.Answer == "SaveTestAnswer").Count();
            Assert.AreEqual(x, 0);
            RepQ.Delete(TestQuestion);
            RepQ.Save();
        }

        [TestMethod]
        public void AEditTest()
        {
            Questions TestQuestion = new Questions { Question = "EditTestQuestion?", TimeQuestion = DateTime.Now, UserName = "EditTest", UserMail = "EditTest@domainmodel.test" };
            GenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            RepQ.Add(TestQuestion);
            RepQ.Save();
            Answers TestAnswer = new Answers { Answer = "EditTestAnswer", TimeAnswer = DateTime.Now, IdQuestions = TestQuestion.Id };
            GenericRepository<Answers> RepA = new GenericRepository<Answers>();
            RepA.Add(TestAnswer);
            RepA.Save();
            int x = RepA.GetAll().Where(item => item.Answer == "EditTestAnswer").Count();
            Assert.IsTrue(x == 1);
            TestAnswer.Answer = "NewEditTestAnswer";
            RepA.Edit(TestAnswer);
            RepA.Save();
            x = RepA.GetAll().Where(item => item.Answer == "EditTestAnswer").Count();
            Assert.IsTrue(x == 0);
            x = RepA.GetAll().Where(item => item.Answer == "NewEditTestAnswer").Count();
            Assert.IsTrue(x == 1);
            RepA.Delete(TestAnswer);
            RepA.Save();
            RepQ.Delete(TestQuestion);
            RepQ.Save();
        }


        [TestMethod]
        public void AGetAllTest()
        {
            Questions TestQuestion = new Questions { Question = "GetAllTestQuestion?", TimeQuestion = DateTime.Now, UserName = "GetAllTest", UserMail = "GetAllTest@domainmodel.test" };
            GenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            RepQ.Add(TestQuestion);
            RepQ.Save();
            Answers TestAnswer = new Answers { Answer = "GetAllTestAnswer", TimeAnswer = DateTime.Now, IdQuestions = TestQuestion.Id};
            GenericRepository<Answers> RepA = new GenericRepository<Answers>();

            int x = RepA.GetAll().Count();

            RepA.Add(TestAnswer);
            RepA.Save();


            Assert.IsTrue(RepA.GetAll().Count() > x);

            RepA.Delete(TestAnswer);
            RepA.Save();
            RepQ.Delete(TestQuestion);
            RepQ.Save();
         }


    }
}
