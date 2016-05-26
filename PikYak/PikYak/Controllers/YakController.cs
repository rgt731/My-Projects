using System;
//doesnt know what a Yak is -- this gets added(below)
using PikYak.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net;

namespace PikYak.Controllers
{
    public class YakController : Controller
    {
        //we can access/view list all likes, yaks, etc
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Yak

 
        public ActionResult Index(string sortOrder)
        {

            var yakViewModels = getYakViewModel();
            if (sortOrder != null)
            {

                switch (sortOrder.ToLower())
                {

                    case "date":
                        yakViewModels = yakViewModels.OrderByDescending(yvm => yvm.Yak.Timestamp).ToList();
                        break;
                    case "likes":
                        yakViewModels = yakViewModels.OrderByDescending(yvm => yvm.LikeCount).ToList();
                        //yaks = yaks.OrderByDescending(s => s.likes);
                        break;
                    /*case "location":
                        yaks = yaks.OrderBy();
                        break;*/
                    case "reports":
                        yakViewModels = yakViewModels.OrderByDescending(yvm => yvm.ReportCount).ToList();
                        break;
                    case "location":
                        yakViewModels = yakViewModels.OrderByDescending(yvm => yvm.DistanceAway).ToList();
                        break;

                }
            }


            return View(yakViewModels);
        }

    

        public ActionResult Faq()
        {
            return View();
        }




        //log out function
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }



        //Make sure a user is logged into the system!!
        [Authorize]
        public ActionResult Admin(string sortOrder)
        {
            var yakViewModels = getYakViewModel();
            if (sortOrder != null)
            {

                //Something needs to happen here to only show reports yaks greater than 10

                switch (sortOrder.ToLower())
                {
                    case "likes":
                        yakViewModels = yakViewModels.OrderByDescending(yvm => yvm.LikeCount).ToList();
                        break;
                    case "reports":
                        yakViewModels = yakViewModels.OrderByDescending(yvm => yvm.ReportCount).ToList();
                        break;

                }
            }


            return View(yakViewModels);

        }

        /*
        public ActionResult Search(string sortOrder)


        public ActionResult YakCreate()

        {

            var yakViewModels = getYakViewModel();
            if (sortOrder != null)
            {

                switch (sortOrder.ToLower())
                {

                    case "date":
                        yakViewModels = yakViewModels.OrderByDescending(yvm => yvm.Yak.Timestamp).ToList();
                        break;
                    case "likes":
                        yakViewModels = yakViewModels.OrderByDescending(yvm => yvm.LikeCount).ToList();
                        //yaks = yaks.OrderByDescending(s => s.likes);
                        break;*/
        /*case "location":
            yaks = yaks.OrderBy();
            break;*/
        /*
}
}

return View(yakViewModels);
}*/

        public ActionResult CreateReply(string replyId)
        {
            int ReplyId;

            Int32.TryParse(replyId, out ReplyId);

            return View();
        }

        public ActionResult Create(int? replyId)
        {
            YakViewModel yvm = null;

            if (replyId.HasValue)
            {
               yvm = getYakViewModel(replyId.Value);
            }

            return View(yvm);
        }

        [HttpPost]
        public ActionResult Create(string yakMessage, double latitude, double longitude, double confidence, string sentiment, int? replyId)

        {

            Yak yak;

            /*Checking for message length of 140 chracters or less*/
            if (yakMessage.Length < 141)
            {





                if (replyId != null)
                {
                    yak = new Yak()
                    {
                        Text = yakMessage,
                        Latitude = latitude,
                        Longitude = longitude,
                        Confidence = confidence,
                        Sentiment = sentiment,
                        ReplyToYakId = replyId.Value,
                        Timestamp = DateTime.Now
                    };
                }
                else
                {
                    yak = new Yak()
                    {
                        Text = yakMessage,
                        Latitude = latitude,
                        Longitude = longitude,
                        Confidence = confidence,
                        Sentiment = sentiment,
                        Timestamp = DateTime.Now
                    };
                }

                db.Yaks.Add(yak);
                db.SaveChanges();
                return RedirectToAction("Index");

            }//end of function - yakmessage was 140 chracters or less

            else
            {
                ViewBag.ErrorMessage = "Sorry a 'Yak' can't have more than 140 characters! Try and shorten the length a bit! ";
                return View();

            }


        }//End create function

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


        /*public ActionResult Search(string searchString)
        {

            var yaks = from y in db.Yaks
                       select y;
        }*/

        public ActionResult SearchYak(string searchString)
        {            
            if (!String.IsNullOrEmpty(searchString))
            {
                var yakViewModels = getYakViewModel();
                var searchResults = yakViewModels.Where(yvm => yvm.Yak.Text.Contains(searchString));
                
                return View(searchResults);
            }
            else
            {
                return View();
            }        
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

                    //save to database
                    db.Likes.Add(newLike);
                    db.SaveChanges();
                }
                else
                {
                   // ViewBag.ErrorMessage = "Sorry you entered the wrong data type in the Like address bar, Quit being Fancy!";
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

        /***************Changes for Report Yak*************/

        public ActionResult Report(string yakId)
        {
            if (yakId != null)

            {
                //Do checking here with try parse
                //to make sure yakId is a number
                int number;

                //changes from a string to a number
                bool result = Int32.TryParse(yakId, out number);


                if (result)
                {
                    /********************************************************/
                    /*changes need to be made here if reportCount is over 10*/
                    /********************************************************/


                    int yakNumber = Int32.Parse(yakId);



                    //create new report     //Instaniate a new Like object- object that will get saved into the database
                    var newReport = new Report();

                    //fill in the properties
                    //assign the date and time at this moment to the newLike item

                    newReport.Timestamp = DateTime.Now;
                    newReport.YakId = yakNumber;

                    //save to db
                    db.Reports.Add(newReport);
                    db.SaveChanges();
                }
                else
                {
                    // ViewBag.ErrorMessage = "Sorry you entered the wrong data type in the Like address bar, Quit being Fancy!";
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

        

        /**************** Reports ViewModel*******************/
        /*
        private List<YakViewModel> GenerateReportViewModels()
        {
            //create a new list of reports
            var yakViewModels = new List<YakViewModel>();

            var reportCounts = from r in db.Reports
                               
                             group r by r.YakId into grouping
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
                //ReportCounts
                if (reportCounts.Where(rc => rc.YakId == y.Id).Count() > 0)
                {
                    yvm.ReportCount = reportCounts.Where(rc => rc.YakId == y.Id).First().Count;
                }
                else
                {
                    yvm.ReportCount = 0;
                }
                yakViewModels.Add(yvm);
            }

            return yakViewModels;
        }
        */
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

            /*** This is what runs when INDEX is called ****/

        public List<YakViewModel> getYakViewModel(/*double userLat, double userLong*/)

        {

            
            var yakViewModels = new List<YakViewModel>();

            var yaks = db.Yaks.ToList();

            //Get Like Count
            var likeCounts = from c in db.Likes
                             group c by c.YakId into grouping
                             select new
                             {
                                 LikeId = grouping.Key,
                                 Count = grouping.Count()
                             };

            //Get Report Count
            var reportCounts = from r in db.Reports

                               group r by r.YakId into grouping
                               select new
                               {
                                   YakId = grouping.Key,
                                   Count = grouping.Count()
                               };

            //Get Yak Count
           /* var yakCounts = from yc in db.Yaks

                               group yc by yc.Id into grouping
                               select new
                               {
                                   YakId = grouping.Key,
                                   Count = grouping.Count()
                               };*/


            foreach (var y in yaks)
            {

                var yvm = new YakViewModel() { Yak = y };

                /**************************/
                /***** Like Counts ********/
                /**************************/

                if (likeCounts.Where(lc => lc.LikeId == y.Id).Count() > 0)
                {
                    yvm.LikeCount = likeCounts.Where(yc => yc.LikeId == y.Id).First().Count;
                }

                //if the like count was less than 0 set it to 0 then add one
                else
                {
                    yvm.LikeCount = 0;
                }

                /****************************/
                /***** Report Counts ********/
                /****************************/

                if (reportCounts.Where(rc => rc.YakId == y.Id).Count() > 0)
                {
                    yvm.ReportCount = reportCounts.Where(rc => rc.YakId == y.Id).First().Count;
                }

                //if the like count was less than 0 set it to 0 then add one
                else
                {
                    yvm.ReportCount = 0;
                }

                /*************************/
                /***** Yak Counts ********/
                /*************************/

                /*
                if (yakCounts.Where(yc => yc.YakId == y.Id).Count() > 0)
                {
                    yvm.ReportCount = reportCounts.Where(yc => yc.YakId == y.Id).First().Count;
                }

                //if the like count was less than 0 set it to 0 then add one
                else
                {
                    yvm.ReportCount = 0;
                }

                //Compute Distance
                // yvm.DistanceAway = DistanceBetweenPoints(userLat, userLong, y.Latitude, y.Longitude);*/

                /**************************************/
                /*This actually helps display the yaks*/
                /**************************************/

                yakViewModels.Add(yvm);

            }

            return yakViewModels;

        }

        /*
        private static double ToRad(double num)
        {

            return
            num * Math.PI / 180;
        }

        public double DistanceBetweenPoints(double lat1, double long1, double lat2, double long2)
        {
            const int r = 6371;
            // radius of earth in km


            // Convert to Radians

            lat1 = ToRad(lat1);

            long1 = ToRad(lat2);

            lat2 = ToRad(long1);

            long2 = ToRad(long2);


            // Spherical Law of Cosines

            return
            Math.Acos(

            Math.Sin(lat1) * Math.Sin(lat2) +

            Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(long2 - long1)

            ) * r;
        }*/
        

        public YakViewModel getYakViewModel(int ID)
        {

            var yak = db.Yaks.Where(y => y.Id == ID).First();

            int likeCount = db.Likes.Count(l => l.YakId == ID);

            YakViewModel yvm = new YakViewModel() { Yak = yak, LikeCount = likeCount };

            return yvm;
        }

        /**********************************************************/
        /***Going to need to delete posts once they are reported***/
        /**********************************************************/

        
       /* This section of code is for a confirmation page 
        To make sure you do want to delete a yak */    
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yak currentYak = db.Yaks.Find(id); 
            if (currentYak == null)
            {
                return HttpNotFound();
            }
            return View(currentYak);
        }

        /* This section of code is for actually 
        deleting a yak */

        // POST: SecretWordModelsController2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yak currentYak = db.Yaks.Find(id);
            db.Yaks.Remove(currentYak);
            db.SaveChanges();
            return RedirectToAction("Admin");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}

