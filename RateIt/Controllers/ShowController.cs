using Microsoft.AspNet.Identity;
using RateIt.Data;
using RateIt.Models;
using RateItModels;
using RateItModels.Movie;
using RateItModels.Review;
using RateItModels.Show;
using RateItServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace RateIt.Controllers
{
    public class ShowController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movie
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShowService(userId);
            var model = service.GetShows();
            return View(model);
        }
        public ActionResult AllShows(string sortOrder,string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var shows = from s in db.Shows
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                shows = shows.Where(s => s.ShowName.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    shows = shows.OrderByDescending(s => s.ShowName);
                    break;
                case "Date":
                    shows = shows.OrderBy(s => s.DateRelease);
                    break;
                case "date_desc":
                    shows = shows.OrderByDescending(s => s.DateRelease);
                    break;
                default:
                    shows = shows.OrderBy(s => s.ShowName);
                    break;
            }
            return View(shows.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShowCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateShowService();
            if (service.CreateShow(model))
            {
                TempData["SaveResult"] = "Your show was created";
                return RedirectToAction("Index");

            };
            ModelState.AddModelError("", "Show could not be created");
            return View(model);

        }
        public ActionResult Details(int id)
        {
            var svc = CreateShowService();
            ShowReviewView showReviewView = new ShowReviewView();

            showReviewView.Show = svc.GetShowById(id);
            showReviewView.Reviews = svc.GetReveiwsByShowId(id);
            ViewBag.AverageRating = svc.GetRatingAvgByShowId(id);
            return View(showReviewView);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateShowService();
            var detail = service.GetShowById(id);
            var model = new ShowEdit
            {
                ShowId=detail.ShowId,
                ShowName = detail.ShowName,
                DirectorName = detail.DirectorName,
                Duration = detail.Duration,
                GenreOfShow = detail.GenreOfShow,
                DateRelease = detail.DateRelease
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShowEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ShowId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
            }
            var service = CreateShowService();
            if (service.UpdateShow(model))
            {
                TempData["SaveResult"] = "Your Show was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Show could not be updated");
            return View();
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateShowService();
            var model = svc.GetShowById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateShowService();
            service.DeleteShow(id);
            TempData["SaveResult"] = "Your show was deleted";

            return RedirectToAction("Index");
        }
        public JsonResult IsShowNameExist(string showName, int? Id)
        {
            var validateName =db.Shows.FirstOrDefault
                                (x => x.ShowName == showName && x.ShowId != Id);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        private ShowService CreateShowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShowService(userId);
            return service;
        }

    }
}