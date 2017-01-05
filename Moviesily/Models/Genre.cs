using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Moviesily.Models
{
    public class Genre
    {
        [ScaffoldColumn(false)]
        public int GenreID { get; set; }

        [Required, StringLength(100)]
        public string GenreName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}