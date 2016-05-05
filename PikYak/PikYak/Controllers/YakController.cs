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

        public ActionResult YakPost()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(YakClass Yak)
        {

            return View();
        }
        // This should work for the search function.
        /*public ActionResult Index(string id)

        {

            string searchString = id;
            var yaks = from m in db.Yaks
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                yaks = yaks.Where(s => s.Title.Contains(searchString));
            }

            return View(yaks);
        }*/


        /*public ActionResult Search(string yakId)
        {
            string searchString = yakId;
        }*/


        public ActionResult Search(string searchString)
        {            

            var yaks = from y in db.Yaks
                       select y;

            if (!String.IsNullOrEmpty(searchString))
            {
                yaks = yaks.Where(s => s.Text.Contains(searchString));
            }

            return View(yaks);
        }


        public ActionResult Like(string yakId)
        {
            if (yakId != null)

            {
                //Do checking here with try parse
                //to make sure yakId is a number
                int number;

                //changes from a string to a number
                //This isnt safe***
                // int yakNumber = Int32.Parse(yakId);
                bool result = Int32.TryParse(yakId, out number);

                if (result)
                {

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
                }
                else
                {
                    ViewBag.ErrorMessage = "Sorry you entered the wrong data type in the Like address bar, Quit being Fancy!";
                }


                //redirect to action
                return RedirectToAction("Index");
            }

            else
            {

                //redirect to action
                //If YakId was null
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
                //LikeCounts
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

        /*public List<YakViewModel> getLikeCount()
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
        }*/

        //get like view models function
        public List<YakViewModel> getYakViewModel()
        {

            var yaks = db.Yaks.ToList();
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

