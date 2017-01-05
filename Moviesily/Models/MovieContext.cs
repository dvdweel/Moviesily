using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Moviesily.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("Moviesily")
        { }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }
    }
}