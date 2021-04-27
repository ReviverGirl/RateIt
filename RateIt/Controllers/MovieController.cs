using Microsoft.AspNet.Identity;
using RateIt.Data;
using RateIt.Models;
using RateItData;
using RateItModels;
using RateItModels.Movie;
using RateItModels.Review;
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
    public class MovieController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Movie
        public ActionResult Index()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MovieService(userId);
            var model = service.GetMovies();
            return View(model);

        }
        public ActionResult AllMovies(string sortOrder,string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var movies = from s in db.Movies
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.MovieName.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    movies = movies.OrderByDescending(s => s.MovieName);
                    break;
                case "Date":
                    movies = movies.OrderBy(s => s.DateRelease);
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(s => s.DateRelease);
                    break;  
                default:
                    movies = movies.OrderBy(s => s.MovieName);
                    break;
            }
            return View(movies.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateMovieService();
            if (service.CreateMovie(model))
            {
                TempData["SaveResult"] = "Your Moive was created";
                return RedirectToAction("Index");

            };
            ModelState.AddModelError("", "Movie could not be created");
            return View(model);

        }
        public ActionResult Details(int id)
        {

            var svc = CreateMovieService();
            MovieReviewView movieReviewView = new MovieReviewView();

            movieReviewView.Movie = svc.GetMovieById(id);
            movieReviewView.Reviews = svc.GetReveiwsByMovieId(id);
            ViewBag.AverageRating = svc.GetRatingAvgByMovieId(id);
            return View(movieReviewView);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMovieService();
            var detail = service.GetMovieById(id);
            var model = new MovieEdit
            {
                MovieId = detail.MovieId,
                MovieName = detail.MovieName,
                DirectorName = detail.DirectorName,
                Duration = detail.Duration,
                GenreOfMovie = detail.GenreOfMovie,
                DateRelease = detail.DateRelease
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.MovieId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
            }
            var service = CreateMovieService();
            if (service.UpdateMovie(model))
            {
                TempData["SaveResult"] = "Your Movie was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Movie could not be updated");
            return View();
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateMovieService();
            var model = svc.GetMovieById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMovieService();
            service.DeleteMovie(id);
            TempData["SaveResult"] = "Your movie was deleted";

            return RedirectToAction("Index");
        }


        public JsonResult IsMovieNameExist(string movieName, int? Id)
        {
            var validateName = db.Movies.FirstOrDefault
                                (x => x.MovieName == movieName && x.MovieId != Id);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        private MovieService CreateMovieService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MovieService(userId);
            return service;
        }
    }
}