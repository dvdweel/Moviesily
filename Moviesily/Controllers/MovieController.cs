using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Moviesily.Models;

namespace Moviesily.Controllers
{
    public class MovieController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Movie
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                var movies = db.Movies.Include(m => m.Genre);
                return View(movies.ToList());
            } else
            {
                return RedirectToAction("Index", "HomeVMs");
            }
        }

        // functies om blogposts te acitiveren & deactiveren
        [HttpPost]
        public ActionResult Activate(int id)
        {
            Movie movies = db.Movies.Find(id);
            movies.Active = 1;
            db.SaveChanges();

            return RedirectToAction("Index","Movie");
        }

        [HttpPost]
        public ActionResult Deactivate(int id)
        {
            Movie movies = db.Movies.Find(id);
            movies.Active = 0;
            db.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }


        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Movie movie = db.Movies.Find(id);
                if (movie == null)
                {
                    return HttpNotFound();
                }
                return View(movie);
            } else
            {
                return RedirectToAction("Index", "HomeVMs");
            }
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName");
                return View();
            } else
            {
                return RedirectToAction("Index", "HomeVMs");
            }
        }

        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieID,Title,Director,ReleaseYear,Language,Description,Image,GenreID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", movie.GenreID);
            return View(movie);
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Movie movie = db.Movies.Find(id);
                if (movie == null)
                {
                    return HttpNotFound();
                }
                ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", movie.GenreID);
                return View(movie);
            }
            else
            {
                return RedirectToAction("Index", "HomeVMs");
            }
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,Title,Director,ReleaseYear,Language,Description,Image,GenreID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", movie.GenreID);
            return View(movie);
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Movie movie = db.Movies.Find(id);
                if (movie == null)
                {
                    return HttpNotFound();
                }
                return View(movie);
            } else
            {
                return RedirectToAction("Index", "HomeVMs");
            }
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
