﻿using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class QuestionsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            IGenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            List<Questions> ListQ = RepQ.GetAll().ToList();
            return View(ListQ);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Questions quetstion)
        {
            if (quetstion.Question == null || quetstion.UserMail == null || quetstion.UserName == null)
            {
                return View(quetstion);
            }
            else
            {
                IGenericRepository<Questions> RepQ = new GenericRepository<Questions>();
                quetstion.TimeQuestion = DateTime.Now;
                RepQ.Add(quetstion);
                RepQ.Save();
                return RedirectToAction("Index","Home");
            }
        }

        [HttpGet]
        public ActionResult Read(int id)

        {
            IGenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            Questions question = RepQ.FindBy(item => item.Id == id).FirstOrDefault();
            return View(question);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            IGenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            Questions quetstion = RepQ.FindBy(item => item.Id == id).FirstOrDefault();
            return View(quetstion);
        }

        [HttpPost]
        public ActionResult Update(Questions quetstion)
        {
            if (quetstion.Question == null || quetstion.UserMail == null || quetstion.UserName == null)
            {
                return View(quetstion);
            }
            else
            {
                IGenericRepository<Questions> RepQ = new GenericRepository<Questions>();
                RepQ.Edit(quetstion);
                RepQ.Save();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            IGenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            Questions quetstion = RepQ.FindBy(item => item.Id == id).FirstOrDefault();
            RepQ.Delete(quetstion);
            RepQ.Save();
            return RedirectToAction("Index");
        }
    }
}