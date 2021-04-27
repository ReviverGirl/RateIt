using Microsoft.AspNet.Identity;
using RateIt.Data;
using RateIt.Models;
using RateItData;
using RateItModels.Movie;
using RateItModels.Review;
using RateItServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace RateIt.Controllers
{
    public class ReviewController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            var model = service.GetReviews();
            return View(model);
        }

        public ActionResult AllReviews()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            var model = service.GeAllReviews();
            return View(model);
        }

        

        public ActionResult Create(int ID)
        {
            ViewBag.ID = ID;
            return View(new ReviewCreate());
        }
        public ActionResult CreateReview()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateReviewService();
            if (service.CreateReview(model))
            {
                TempData["SaveResult"] = "Your Review was created";
                return RedirectToAction("Index");

            };
            ModelState.AddModelError("","Review could not be created");
            return View(model);

        }

        public ActionResult CreateMusicReview(int ID)
        {
            ViewBag.ID = ID;
            return View(new ReviewCreate());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMusicReview(ReviewCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateReviewService();
            if (service.CreateReview(model))
            {
                TempData["SaveResult"] = "Your Review was created";
                return RedirectToAction("Index");

            };
            ModelState.AddModelError("", "Review could not be created");
            return View(model);

        }


        public ActionResult CreateShowReview(int ID)
        {
            ViewBag.ID = ID;
            return View(new ReviewCreate());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateShowReview(ReviewCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateReviewService();
            if (service.CreateReview(model))
            {
                TempData["SaveResult"] = "Your Review was created";
                return RedirectToAction("Index");

            };
            ModelState.AddModelError("", "Review could not be created");
            return View(model);

        }


        public ActionResult Details(int id)
        {
            var svc = CreateReviewService();
            var model = svc.GetReviewById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateReviewService();
            var detail = service.GetReviewById(id);
            var model =
                new ReviewEdit
                {
                    ReviewId = detail.ReviewId,
                    Content = detail.Content,
                    Rating = detail.Rating,
                    MovieId=detail.MovieId,
                    MusicId=detail.MusicId,
                    ShowId=detail.ShowId

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ReviewId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
            }
            var service = CreateReviewService();
            if (service.UpdateReview(model))
            {
                TempData["SaveResult"] = "Your Review was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Review could not be updated");
            return View();
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateReviewService();
            var model = svc.GetReviewById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateReviewService();
            service.DeleteReview(id);
            TempData["SaveResult"] = "Your review was deleted";

            return RedirectToAction("Index");
        }

        private ReviewService CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            return service;
        }
    }
}