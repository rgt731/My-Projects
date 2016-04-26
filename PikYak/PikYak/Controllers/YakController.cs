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
            return View(getYakViewModel());
        }

        public ActionResult Faq()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Post(string text)
        {
            
            return View();
        }

        public ActionResult Like(string yakId)
        {
           /*foreach(Like in YakId){
                likeCount++;*/
            

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
            var yakViewModels = new List<YakViewModel>();

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
                var yvm = new YakViewModel() { Yak = y };
                //tier 1
                if (likeCounts.Where(lc => lc.YakId == y.Id).Count() > 0)
                {
                    yvm.LikeCount = likeCounts.Where(lc => lc.YakId == y.Id).First().Count;
                }
                else
                {
                    yvm.LikeCount = 0;
                }
                yakViewModels.Add(yvm);
            }
            
                return yakViewModels;
        }

        public List<YakViewModel> getLikeCount()
        {
            var yakViewModels = new List<YakViewModel>();

            var likeCounts =  from c in db.Likes
                            group c by c.YakId into grouping
                            select new
                            {
                                LikeId = grouping.Key,
                                Count = grouping.Count()
                            };
                            



          return likeCounts;
        }

        //get like view models function
       public List<YakViewModel> getYakViewModel()
        {

            
            var yakViewModels = new List<YakViewModel>();

            //Get Like Count
            var likeCounts = from c in db.Likes
                             group c by c.YakId into grouping
                             select new
                             {
                                 LikeId = grouping.Key,
                                 Count = grouping.Count()
                             };//Finish Like Count



            foreach (var y in yaks)
            {

                var yvm = new YakViewModel() { Yak = y };
                //for each y.Id how likes are in this table
                // getLikeCount(); 
                if (likeCounts.Where(lc => lc.LikeId == y.Id).Count() > 0)
                {
                    yvm.LikeCount = likeCounts.Where(yc => yc.LikeId == y.Id).First().Count;
                }
                else
                {
                    yvm.LikeCount = 0;
                }
                yakViewModels.Add(yvm);

            }

            return yakViewModels;

        }
    }
}

