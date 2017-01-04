using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moviesily.Models;

namespace Moviesily.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return View(db.Register.ToList());
            }
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
            return View();
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
                var usr = db.Register.Single(u => u.Username == register.Username && u.Password == register.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("AfterLogin");
                }
                else
                {
                    ModelState.AddModelError("", "Gebruikersnaam of wachtwoord is onjuist.");
                }
            }
            return View();
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
    }
}