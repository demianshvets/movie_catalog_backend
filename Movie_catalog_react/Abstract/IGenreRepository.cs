using Movie_catalog_react.Entities;
using Movie_catalog_react.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_catalog_react.Abstract
{
    interface IGenreRepository
    {
        IEnumerable<Genre> Genres { get; }
        void FillingGenresId(List<int> genresId);
        void FilteredGenres(List<int> genresID, string inputGenreId);
        void GetGenersModel(List<Genre> inputGenres, List<GenreModel> outputGenres);
        public void addGenre(string name);
    }
}
