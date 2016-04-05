using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PikYak.Controllers
{
    public class YakController : Controller
    {
        // GET: Yak
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Faq()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult YakPost()
        {
            return View();
        }

        public ActionResult Like(string YakId)
        {
            Console.WriteLine("You liked a Yak" + YakId); 

            return RedirectToAction("Index"); 
        }
    }
}