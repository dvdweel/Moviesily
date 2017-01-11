using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Moviesily.Models;
using Moviesily.ViewModels;

namespace Moviesily.Controllers
{
    public class HomeVMsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: HomeVMs
        public ActionResult Index()
        {
            using (var db = new DatabaseContext())
            {
                var HomeVM = new HomeVM();
                HomeVM.Genres = db.Genres.ToList();
                HomeVM.Movies = db.Movies.ToList();

                return View(HomeVM);
            }
        }
 
        public ActionResult Browse(string genre)
        {       
            var genreModel = db.Genres.Include("Movies")         
                .Single(g => g.GenreName == genre);  
            return View(genreModel);
        }

        // GET: /Store/Details/5  
        public string Details(int id)
        {
            string message = "HomeVMs.Details, ID = " + id;
            return message;
        }


        // GET: HomeVMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeVMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] HomeVM homeVM)
        {
            if (ModelState.IsValid)
            {
                db.HomeVMs.Add(homeVM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(homeVM);
        }

        // GET: HomeVMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeVM homeVM = db.HomeVMs.Find(id);
            if (homeVM == null)
            {
                return HttpNotFound();
            }
            return View(homeVM);
        }

        // POST: HomeVMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] HomeVM homeVM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homeVM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homeVM);
        }

        // GET: HomeVMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeVM homeVM = db.HomeVMs.Find(id);
            if (homeVM == null)
            {
                return HttpNotFound();
            }
            return View(homeVM);
        }

        // POST: HomeVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HomeVM homeVM = db.HomeVMs.Find(id);
            db.HomeVMs.Remove(homeVM);
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
