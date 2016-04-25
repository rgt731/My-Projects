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
            var yakViewModels = new List<YakViewModel>();

            foreach(var y in yaks)
            {

                var yvm = new YakViewModel() { Yak = y };
                yakViewModels.Add(yvm);

            }
             

            return View(yakViewModels);
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

        public ActionResult Like(string yakId)
        {
          
            if (yakId != null)
            {
            
            //Do checking here with try parse
            //to make sure yakId is a number

            //changes from a string to a number
            //This isnt safe***
            int yakNumber = Int32.Parse(yakId);

            //create new like     //Instaniate a new Like object- object that will get saved into the database
            var newLike = new Like();

            //fill in the properties
            //assign the date and time at this moment to the newLike item

            newLike.Timestamp = DateTime.Now;
            newLike.YakId = yakNumber; 

            //save to db
            db.Likes.Add(newLike);
            db.SaveChanges();


            //redirect to action
            return RedirectToAction("Index");
            }

            else{

                //redirect to action
                return RedirectToAction("Index");
           }
        }

        private List<YakViewModel> GenerateLikeViewModels()
        {
            //create a new list of likes
            var likeViewModels = new List<YakViewModel>();

            var likeCounts = from l in db.Likes

                                 // where l.

                             group l by l.YakId into grouping
                             select new
                             {
                                 YakId = grouping.Key,
                                 Count = grouping.Count()
                             };

            //refer to this connection to the database
            var yaks = db.Yaks.ToList();

            foreach (var y in yaks)
            {
                var lvm = new YakViewModel() { Yak = y };
                //tier 1
                if (likeCounts.Where(lc => lc.YakId == y.Id).Count() > 0)
                {
                    lvm.LikeCount = likeCounts.Where(tc => tc.YakId == y.Id).First().Count;
                }
                else
                {
                    lvm.LikeCount = 0;
                }
            }
            
                return likeViewModels;
        }
    }
}