using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Moviesily.Models
{
    public class Register
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage ="Vul je Voornaam in.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Vul je Achternaam in.")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Vul je Emailadres in.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Vul een geldig Emailadres in.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Vul een gebruikersnaam in.")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Vul een wachtwoord in.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Vul nogmaals hetzelfde wachtwoord in.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}