using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_catalog_react.Entities
{
    public class Genre
    {

        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
