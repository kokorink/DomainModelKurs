using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomainModel;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();
        public ActionResult Index()
        {
            var ListQA = new List<QuestionsAnswersModel>();
            var questionsList = db.Questions.ToList();
            GenericRepository<Answers> answers = new GenericRepository<Answers>();
            foreach (var item in questionsList)
            {
                var answerById = answers.FindBy(x => x.IdQuestions == item.Id).FirstOrDefault();
                if (answerById is null)
                {
                    ListQA.Add(new QuestionsAnswersModel
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
                    ListQA.Add(new QuestionsAnswersModel
                    {
                        Question = item.Question,
                        TimeQuestion = item.TimeQuestion,
                        Id = item.Id,
                        UserName = item.UserName,
                        UserMail = item.UserMail,
                        Answer = answerById.Answer,
                        TimeAnswer = answerById.TimeAnswer
                    });
                }
            }
            //var answers = db.Answers.Include(a => a.Questions);
            return View(ListQA);
        }
    }
}