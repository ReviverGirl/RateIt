using Microsoft.AspNet.Identity;
using RateIt.Data;
using RateIt.Models;
using RateItModels;
using RateItModels.Movie;
using RateItModels.Music;
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
    public class MusicController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MusicService(userId);
            var model = service.GetMusics();
            return View(model);
        }
        public ActionResult AllMusic(string sortOrder,string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var musics = from s in db.Musics
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                musics = musics.Where(s => s.ArtistName.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    musics = musics.OrderByDescending(s => s.ArtistName);
                    break;
                case "Date":
                    musics = musics.OrderBy(s => s.DateRelease);
                    break;
                case "date_desc":
                    musics = musics.OrderByDescending(s => s.DateRelease);
                    break;
                default:
                    musics = musics.OrderBy(s => s.ArtistName);
                    break;
            }
            return View(musics.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MusicCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateMusicService();
            if (service.CreateMusic(model))
            {
                TempData["SaveResult"] = "Your Music was created";
                return RedirectToAction("Index");

            };
            ModelState.AddModelError("", "Music could not be created");
            return View(model);

        }
        public ActionResult Details(int id)
        {
            var svc = CreateMusicService();
            MusicReviewView movieReviewView = new MusicReviewView();

            movieReviewView.Music = svc.GetMusicById(id);
            movieReviewView.Reviews = svc.GetReveiwsByMusicId(id);
            ViewBag.AverageRating = svc.GetRatingAvgByMusicId(id);
            return View(movieReviewView);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMusicService();
            var detail = service.GetMusicById(id);
            var model = new MusicEdit
            {
                MusicId=detail.MusicId,
                ArtistName = detail.ArtistName,
                Duration = detail.Duration,
                DateRelease = detail.DateRelease,
                GenreOfMusic = detail.GenreOfMusic,
                TypeOfMusic = detail.TypeOfMusic
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MusicEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.MusicId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
            }
            var service = CreateMusicService();
            if (service.UpdateMusic(model))
            {
                TempData["SaveResult"] = "Your Music was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Music could not be updated");
            return View();
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateMusicService();
            var model = svc.GetMusicById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMusicService();
            service.DeleteMusic(id);
            TempData["SaveResult"] = "Your music was deleted";

            return RedirectToAction("Index");
        }

        private MusicService CreateMusicService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MusicService(userId);
            return service;
        }
    }
}