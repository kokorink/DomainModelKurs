using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AnswersController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            IGenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            ViewBag.IdQuestions = new SelectList(RepQ.GetAll(), "Id", "Question");
            IGenericRepository<Answers> RepA = new GenericRepository<Answers>();
            List<Answers> ListA = RepA.GetAll().ToList();
            return View(ListA);
        }

        [HttpGet]
        public ActionResult Create()
        {
            IGenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            ViewBag.IdQuestions = new SelectList(RepQ.GetAll(), "Id", "Question");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Answers antswer)
        {
            if (antswer.Answer == null)
            {
                return View(antswer);
            }
            else
            {
                IGenericRepository<Answers> RepA = new GenericRepository<Answers>();

                antswer.TimeAnswer = DateTime.Now;
                RepA.Add(antswer);
                RepA.Save();
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult Read(int id)
        {
            IGenericRepository<Answers> RepA = new GenericRepository<Answers>();
            Answers answer = RepA.FindBy(item => item.IdQuestions == id).First();
            return View(answer);

        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            IGenericRepository<Answers> RepA = new GenericRepository<Answers>();
            Answers antswer = RepA.FindBy(item => item.IdQuestions == id).First();
            return View(antswer);

        }

        [HttpPost]
        public ActionResult Update(Answers antswer)
        {

            IGenericRepository<Answers> RepA = new GenericRepository<Answers>();
            RepA.Edit(antswer);
            RepA.Save();
            return RedirectToAction("Index");

        }



        [HttpGet]
        public ActionResult Delete(int id)
        {
            IGenericRepository<Answers> RepA = new GenericRepository<Answers>();
            Answers answer = RepA.FindBy(item => item.IdQuestions == id).First();
            RepA.Delete(answer);
            RepA.Save();
            return RedirectToAction("Index");

        }



    }
}