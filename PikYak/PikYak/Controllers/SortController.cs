using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PikYak.Controllers
{
    public class SortController : Controller
    {
        // GET: Sort
        public ActionResult Index(string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.LikeSortParm = String.IsNullOrEmpty(sortOrder) ? "yak desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";

            if (Request.HttpMethod == "GET")
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = searchString;

            var yak = from s in db.PikYak
                           select s;

            switch (sortOrder)
            {
                case "yak desc":
                    yak = yak.OrderByDescending(s => s.likes);
                    break;
                case "Date":
                    yak = yak.OrderBy(s => s.PostDate);
                    break;
                case "Date desc":
                    yak = yak.OrderByDescending(s => s.PostDate);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(yak.ToPagedList(pageNumber, pageSize));
        }
    }

        // GET: Sort/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sort/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sort/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sort/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sort/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sort/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sort/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
