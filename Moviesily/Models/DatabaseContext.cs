using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Moviesily.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Register> Register { get; set; }

    }
}