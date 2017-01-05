using Moviesily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moviesily.ViewModels
{
    public class HomeVM
    {
        public List<Genre> Genres { get; set; }

        public List<Movie> Movies { get; set; }
    }
}