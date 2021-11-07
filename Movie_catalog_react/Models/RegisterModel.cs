using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_catalog_react.Models
{
    public class RegisterModel
    {
      //  [Required(ErrorMessage = "Input Email")]
        public string Email { get; set; }

      //  [Required(ErrorMessage = "Input password")]
      //  [DataType(DataType.Password)]
        public string Password { get; set; }

        /*[DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passeord is incorrect")]
        public string ConfirmPassword { get; set; }*/
    }
}
