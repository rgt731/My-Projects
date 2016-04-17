using System;
//doesnt know what a Yak is -- this gets added(below)
using PikYak.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PikYak.Controllers
{
    public class YakController : Controller
    {
        //we can access/view list all likes, yaks, etc

        private Models.ApplicationDbContext db = new Models.ApplicationDbContext();

        // GET: Yak
        public ActionResult Index()
        {
            var yaks = db.Yaks.ToList();    
            return View(yaks);
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
            if (YakId != null)
            {


            //changes from a string to a number
            //This isnt safe***
            int num = Int32.Parse(YakId);

            //create new like     //Instaniate a new Like object
            var newLike = new Like(num);

            //fill in the properties
            //assign the date and time at this moment to the newLike item

            newLike.Timestamp = DateTime.Now;

            //save to db
            db.Likes.Add(newLike);
            db.SaveChanges();

           // Console.WriteLine("You liked a Yak" + YakId);

            //redirect to action
            return RedirectToAction("Index");
            }

            else{
             
             //Do something here if no likes have been added to table

            //redirect to action
            return RedirectToAction("Index");
           }
        }
    }
}