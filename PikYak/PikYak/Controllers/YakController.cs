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

        private ApplicationDbContext db = new ApplicationDbContext();

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

        public ActionResult _YakPost(string text)
        {
            
            return View();
        }

        public ActionResult Like(string yakId)
        {


            /*foreach(Like in YakId){
                likeCount++; 
            }*/


            if (yakId != null)
            {
            
            //Do checking here with try parse
            //to make sure yakId is a number

            //changes from a string to a number
            //This isnt safe***
            int yakNumber = Int32.Parse(yakId);

            //create new like     //Instaniate a new Like object- object that will get saved into the database
            var newLike = new Like();

           // newLike.UserId = Int32.Parse(YakId);

            //fill in the properties
            //assign the date and time at this moment to the newLike item

            newLike.Timestamp = DateTime.Now;
            newLike.YakId = yakNumber; 

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