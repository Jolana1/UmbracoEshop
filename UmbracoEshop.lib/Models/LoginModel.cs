using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UmbracoEshop.lib.Models
{
    public class LoginModel
    {
        [Display(Name = "Prihlasovacie meno")]
        [Required(ErrorMessage = "Prihlasovacie meno musí byť zadané")]
        public string Username { get; set; }

        [Display(Name = "Heslo")]
        [Required(ErrorMessage = "Heslo musí byť zadané")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
