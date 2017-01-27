using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Moviesily.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [ForeignKey("Register")]
        public int UserID { get; set; }

        public Register Register { get; set; }

        [ForeignKey("Movie")]
        public int MovieID { get; set; }

        public Movie Movie { get; set; }

        public string Content { get; set; }
    }
}