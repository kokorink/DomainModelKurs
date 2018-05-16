using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ApiMainController : Controller
    {
        // GET: ApiMain
        public ActionResult Index()
        {
            return View();
        }
    }
}