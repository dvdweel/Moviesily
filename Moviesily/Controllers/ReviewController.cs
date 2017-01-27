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
    public class ReviewController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Review
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                var reviews = db.Reviews.Include(r => r.Movie).Include(r => r.Register);
                return View(reviews.ToList());
            }
            else
            {
                return RedirectToAction("Index", "HomeVMs");
            }
        }

        // GET: Review/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["UserID"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Review review = db.Reviews.Find(id);
                if (review == null)
                {
                    return HttpNotFound();
                }
                return View(review);
            }
            else
            {
                return RedirectToAction("Index", "HomeVMs");
            }
        }

        // GET: Review/Create
        public ActionResult Create()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title");
                ViewBag.UserID = new SelectList(db.Register, "UserID", "Username");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "HomeVMs");
            }
        }

        // POST: Review/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewID,UserID,MovieID,Content")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title", review.MovieID);
            ViewBag.UserID = new SelectList(db.Register, "UserID", "Username", review.UserID);
            return View(review);
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["UserID"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Review review = db.Reviews.Find(id);
                if (review == null)
                {
                    return HttpNotFound();
                }
                ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title", review.MovieID);
                ViewBag.UserID = new SelectList(db.Register, "UserID", "Username", review.UserID);
                return View(review);
            }
            else
            {
                return RedirectToAction("Index", "HomeVMs");
            }
        }

        // POST: Review/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,UserID,MovieID,Content")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title", review.MovieID);
            ViewBag.UserID = new SelectList(db.Register, "UserID", "Username", review.UserID);
            return View(review);
        }

        // GET: Review/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserID"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Review review = db.Reviews.Find(id);
                if (review == null)
                {
                    return HttpNotFound();
                }
                return View(review);
            }
            else
            {
                return RedirectToAction("Index", "HomeVMs");
            }
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
