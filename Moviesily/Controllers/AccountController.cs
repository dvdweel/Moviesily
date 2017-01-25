using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moviesily.Models;
using System.Web.Security;
using System.Net;
using System.Data.Entity;

namespace Moviesily.Controllers
{
    public class AccountController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Account
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    return View(db.Register.ToList());
                }
            }
            else
            {
                return RedirectToAction("Index", "HomeVMs");
            }
        }

        // GET: Account2/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Register register = db.Register.Find(id);
                if (register == null)
                {
                    return HttpNotFound();
                }
                return View(register);
            } else
            {
                return RedirectToAction("Index", "HomeVMs");
            }
        }

        // GET: Account2/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                return View();
            } else
            {
                return RedirectToAction("Index", "HomeVMs");
            }
        }

        // POST: Account2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FirstName,LastName,Email,Username,Password,ConfirmPassword,Role")] Register register)
        {
            if (ModelState.IsValid)
            {
                db.Register.Add(register);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(register);
        }

        // GET: Account2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["UserID"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Register register = db.Register.Find(id);
                if (register == null)
                {
                    return HttpNotFound();
                }
                return View(register);
            } else
            {
                return RedirectToAction("Index", "HomeVMs");
            }
        
        }

        // POST: Account2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,LastName,Email,Username,Password,ConfirmPassword,Role")] Register register)
        {
            if (ModelState.IsValid)
            {
                db.Entry(register).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(register);
        }

        // GET: Account2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Register register = db.Register.Find(id);
                if (register == null)
                {
                    return HttpNotFound();
                }
                return View(register);
            } else
            {
                return RedirectToAction("Index", "HomeVMs");
            }
        }

        // POST: Account2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Register register = db.Register.Find(id);
            db.Register.Remove(register);
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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    db.Register.Add(register);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = register.FirstName + " " + register.LastName + " De registratie is gelukt.";
            }
            return RedirectToAction("Login", "Account");
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Register register)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var usr = db.Register.Where(x => x.Username.Equals(register.Username) && x.Password.Equals(register.Password)).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();

                    if (usr.Role == 1)
                    {
                        Session["Admin"] = true;
                        return RedirectToAction("Index", "Account");
                    }
                    else
                    {
                        return RedirectToAction("Index", "HomeVMs");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Gebruikersnaam of wachtwoord is onjuist.");
                    return View();
                }
            }
        }

        public ActionResult AfterLogin()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "HomeVMs");

        }
    }
}