using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fumasi.Models
{
    public class Loginviewmodel
    {
        [Required(ErrorMessage = "Email address required!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid email address")]
        [Display(Name = "Email Address")]
        public string Emailaddress { get; set; }
        [Required(ErrorMessage = "Password required!")]
        [DataType(DataType.Password, ErrorMessage = "Enter a valid password")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool Rememberme { get; set; }
    }
}
