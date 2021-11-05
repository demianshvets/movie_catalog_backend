using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_catalog_react.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Input Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Input Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
