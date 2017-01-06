using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Moviesily.Models
{
    public class DatabaseContext : DbContext
    { 

        public DatabaseContext() : base("name=DatabaseContext")
        {
            Database.SetInitializer<DatabaseContext>(
                new DropCreateDatabaseAlways<DatabaseContext>());
        }

        public DbSet<Register> Register { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<Moviesily.ViewModels.HomeVM> HomeVMs { get; set; }
    }
}