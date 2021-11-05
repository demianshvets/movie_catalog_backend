using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_catalog_react.Entities
{
    public class Company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [InverseProperty("Company")]
        public virtual List<Movie> Movies { get; set; }
    }
}
