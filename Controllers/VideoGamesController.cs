using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _200223057A1.Models;

namespace _200223057A1.Controllers
{
    public class VideoGamesController : Controller
    {
        private VideoGameContext db = new VideoGameContext();

        // GET: VideoGames
        public ActionResult Index()
        {
            var videoGames = db.VideoGames.Include(v => v.Developer).Include(v => v.Publisher).Include(v => v.Review);
            return View(videoGames.ToList());
        }

        // GET: VideoGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // GET: VideoGames/Create
        public ActionResult Create()
        {
            ViewBag.DeveloperId = new SelectList(db.Developers, "DeveloperId", "Name");
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name");
            ViewBag.ReviewId = new SelectList(db.Reviews, "ReviewId", "Name");
            ViewBag.Genres = new MultiSelectList(db.Genres, "GenreId", "Name");
            return View();
        }

        // POST: VideoGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoGameId,PublisherId,DeveloperId,ReviewId,Price,Name,Description,MinimumRequirements")] VideoGame videoGame)
            
        {
            if (ModelState.IsValid)
            {
                //Attempts to split the genres coming from the POST request in the form
                try
                {
                    var genresToAdd = Request.Form["Genres"].Split(',');
                    foreach (var genreToAdd in genresToAdd)

                    {
                        //Converts GenreId to an int so we can query the DB using Id
                        var genreId = Convert.ToInt32(genreToAdd);
                        var genre = db.Genres.First(g => g.GenreId.Equals(genreId));
                        videoGame.Genres.Add(genre);
                    }
                }
                catch { }
                db.VideoGames.Add(videoGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeveloperId = new SelectList(db.Developers, "DeveloperId", "Name", videoGame.DeveloperId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name", videoGame.PublisherId);
            ViewBag.ReviewId = new SelectList(db.Reviews, "ReviewId", "Name", videoGame.ReviewId);
            ViewBag.Genres = new MultiSelectList(db.Genres, "GenreId", "Name");
            return View(videoGame);
        }

        // GET: VideoGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeveloperId = new SelectList(db.Developers, "DeveloperId", "Name", videoGame.DeveloperId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name", videoGame.PublisherId);
            ViewBag.ReviewId = new SelectList(db.Reviews, "ReviewId", "Name", videoGame.ReviewId);
            return View(videoGame);
        }

        // POST: VideoGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoGameId,PublisherId,DeveloperId,ReviewId,Price,Name,Description,MinimumRequirements")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeveloperId = new SelectList(db.Developers, "DeveloperId", "Name", videoGame.DeveloperId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name", videoGame.PublisherId);
            ViewBag.ReviewId = new SelectList(db.Reviews, "ReviewId", "Name", videoGame.ReviewId);
            return View(videoGame);
        }

        // GET: VideoGames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // POST: VideoGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoGame videoGame = db.VideoGames.Find(id);
            db.VideoGames.Remove(videoGame);
            db.SaveChanges();
            return RedirectToAction("Index");
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
