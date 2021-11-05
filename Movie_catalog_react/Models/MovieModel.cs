using Movie_catalog_react.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_catalog_react.Models
{
    public class MovieModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }
        public int PhotoId { get; set; }
        public string Genres { get; set; }
        public string Company { get; set; }
        public string ReleaseDate { get; set; }
        public string Duration { get; set; }

        public string Description { get; set; }
    
    }
}

