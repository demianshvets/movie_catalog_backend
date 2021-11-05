using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_catalog_react.Entities
{
    public class Movie
    {
        public Movie()
        {
            ReleaseTime = new DateTime(2000, 1, 1);
            this.Genre = new HashSet<Genre>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        // fkeys
        [Required]
        public virtual Company Company { get; set; }

        // fkeys
        [Required]
        public virtual ICollection<Genre> Genre { get; set; }

        // fkeys
        public virtual Resource Photo { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseTime { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }


        public string Description { get; set; }
    }
}

