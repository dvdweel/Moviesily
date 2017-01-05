using Moviesily.Models;
using Moviesily.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Moviesily.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var db = new MovieContext())
            {
                var HomeVM = new HomeVM();
                HomeVM.Genres = db.Genres.ToList();
                return View(HomeVM);
            }
        }
    }
}