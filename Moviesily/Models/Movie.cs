using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Moviesily.Models
{
    public class Movie
    {
        [Key]
        [ScaffoldColumn(false)]
        public int MovieID { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required, StringLength(100)]
        public string Director { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required, StringLength(100)]
        public string Language { get; set; }

        [Required, StringLength(1000), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string Image { get; set; }

        public int? GenreID { get; set; }

        public virtual Genre Genre { get; set; }

        [Required]
        public int Active { get; set; }

    }
}