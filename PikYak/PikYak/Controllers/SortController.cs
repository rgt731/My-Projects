using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PikYak.Controllers
{
    public class SortController : Controller
    {

        private Models.ApplicationDbContext db = new Models.ApplicationDbContext();

        // GET: Sort
        public ActionResult Index(string sortOrder)
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

    }
}
