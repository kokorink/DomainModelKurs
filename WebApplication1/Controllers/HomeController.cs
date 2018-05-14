using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using DomainModel;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<QAModel> ListQA = new List<QAModel>();
            IGenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            IGenericRepository<Answers> RepA = new GenericRepository<Answers>();
            List<Questions> ListQ = RepQ.GetAll().ToList();
            List<Answers> ListA = RepA.GetAll().ToList();
            foreach (var item in ListQ)
            {
                int answerById = RepA.FindBy(x => x.IdQuestions == item.Id).Count();
                if (answerById == 0)
                {
                    ListQA.Add(new QAModel
                    {
                        Question = item.Question,
                        TimeQuestion = item.TimeQuestion,
                        Id = item.Id,
                        UserName = item.UserName,
                        UserMail = item.UserMail,
                        Answer = "",
                        TimeAnswer = null
                    });
                }
                else
                {
                    ListQA.Add(new QAModel
                    {
                        Question = item.Question,
                        TimeQuestion = item.TimeQuestion,
                        Id = item.Id,
                        UserName = item.UserName,
                        UserMail = item.UserMail,
                        Answer = RepA.FindBy(x => x.IdQuestions == item.Id).First().Answer,
                        TimeAnswer = RepA.FindBy(x => x.IdQuestions == item.Id).First().TimeAnswer
                    });
                }
            }

            return View(ListQA);

        }

    }
}