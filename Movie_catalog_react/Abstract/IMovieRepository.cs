using Movie_catalog_react.Entities;
using Movie_catalog_react.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_catalog_react.Abstract
{
    interface IMovieRepository
    {
        IEnumerable<Movie> Movies { get; }
        IQueryable<Movie> GetMoviesByFilter(List<int> genresId,List<int> companiesID);
        //converting Movie items into MovieModel for sending data to client
        void GetListMoviesModel(List<Movie> inputMovies, List<MovieModel> outputMovies);
        public void addingMovie(MovieModel movie);
        bool DeleteMovie(string id);
        
    }
}
