using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_catalog_react.Models
{
    public class OutDataModel
    {
        public List<GenreModel> genres { get; set; }
        public List<CompanyModel> companies { get; set; }
        public List<MovieModel> movies { get; set; }
        public OutDataModel()
        {
            genres = new List<GenreModel>();
            companies = new List<CompanyModel>();
            movies = new List<MovieModel>();
        }
    }
}
