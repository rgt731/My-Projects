﻿using System;
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

        public ActionResult Search(string sortOrder)
        {
            
            /*ViewBag.CurrentSort = sortOrder;
            ViewBag.LikeSortParm = String.IsNullOrEmpty(sortOrder) ? "yak desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";*/

            /* if (Request.HttpMethod == "GET")
             {
                 searchString = currentFilter;
             }

             ViewBag.CurrentFilter = searchString;*/

            var yaks = from s in db.Yaks.ToList()
                       select s;

            switch (sortOrder)
            {
                /*case "yak desc":
                    yak = yak.OrderByDescending(s => s.likes);
                    break;*/
                case "Date":
                    yaks = yaks.OrderBy(s => s.Timestamp);
                    break;
                case "DateDesc":
                    yaks = yaks.OrderByDescending(s => s.Timestamp);
                    break;
            }

            return View(yaks);
        }

        public ActionResult YakPost()
        {
            return View();
        }

        public ActionResult Like(string YakId)
        {
           /* int likeCount = 0; 

            foreach(Like in Yak){
                likeCount++; 
            }*/


            if (YakId != null)
            {


            //changes from a string to a number
            //This isnt safe***
            int num = Int32.Parse(YakId);

            //create new like     //Instaniate a new Like object- object that will get saved into the database
            var newLike = new Like(num);

           // newLike.UserId = Int32.Parse(YakId);

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

                //changes from a string to a number
                //This isnt safe***
                int num =  1;

                //create new like     //Instaniate a new Like object
                var newLike = new Like(num);

                //fill in the properties
                //assign the date and time at this moment to the newLike item

                newLike.Timestamp = DateTime.Now;

                //save to db
                db.Likes.Add(newLike);
                db.SaveChanges();


                //redirect to action
                return RedirectToAction("Index");
           }
        }
    }
}