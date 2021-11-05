using Microsoft.EntityFrameworkCore;
using Movie_catalog_react.Abstract;
using Movie_catalog_react.Entities;
using Movie_catalog_react.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_catalog_react.Concrete
{
    public class MovieRepository : IMovieRepository
    {

        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Movie> Movies
        {
            get
            {
                return _context.Movies.Include(m=>m.Genre).Include(m => m.Photo).Include(m=>m.Company);
            }
        }


        public IQueryable<Movie> GetMoviesByFilter(List<int> genresId, List<int> companiesID)
        {
            if(genresId.Count==1&&companiesID.Count==1)
            {
                Genre g = _context.Genres.FirstOrDefault(g => g.GenreId == genresId.FirstOrDefault());
                Company c = _context.Companies.FirstOrDefault(c => c.CompId == companiesID.FirstOrDefault());
                return _context.Movies.Include(m => m.Company).Include(m => m.Photo).Include(m => m.Genre).Where(m => m.Genre.Contains(g)).Where(m => m.Company == c);
            }
            else
            {
                if (genresId.Count == 1)
                {
                    Genre g = _context.Genres.FirstOrDefault(g => g.GenreId == genresId.FirstOrDefault());
                    return _context.Movies.Include(m => m.Company).Include(m => m.Photo).Include(m => m.Genre).Where(m => m.Genre.Contains(g));
                }
                if (companiesID.Count == 1)
                {
                    Company c = _context.Companies.FirstOrDefault(c => c.CompId == companiesID.FirstOrDefault());
                    return _context.Movies.Include(m => m.Company).Include(m => m.Photo).Include(m => m.Genre).Where(m => m.Company==c);
                }

                return _context.Movies.Include(m => m.Genre).Include(m => m.Company).Include(m=>m.Photo); ;
            }
            
        }

        public void GetListMoviesModel(List<Movie> inputMovies, List<MovieModel> outputMovies)
        {
            //List<MovieModel> result = new List<MovieModel>();
            String genres;
            outputMovies.Clear();
            foreach (Movie m in inputMovies)
            {
                genres = "";
                string photoPath = "Photos/chill1.jpg";
                foreach (Genre genre in m.Genre)
                {
                    genres += genre.Name + ", ";
                }
                if (genres.Length >= 2)
                    genres = genres.Substring(0, genres.Length - 2);
                if(m.Photo!=null)
                {
                    photoPath = "Photos/"+m.Photo.DataPath;
                }
                outputMovies.Add(new MovieModel { Id = m.MovieId.ToString(), Name = m.Name, Company = m.Company.Name, Genres = genres, ReleaseDate = m.ReleaseTime.Date.ToString("yyyy/MM/dd"), Duration = m.Duration.ToString(), Description = m.Description, PhotoPath= photoPath });
            }

            //return result;
        }

        public void addingMovie(MovieModel movie)
        {
            if(movie.Name!=null)
            {
               // Resource ph = _context.Resources.FirstOrDefault(x => x.ResourceId == movie.PhotoId);
                Movie m = new Movie
                {
                    Name = movie.Name,
                    Company = _context.Companies.FirstOrDefault(x => x.CompId == int.Parse(movie.Company)),
                    Genre = new List<Genre>() { _context.Genres.FirstOrDefault(x => x.GenreId == int.Parse(movie.Genres)) },
                    ReleaseTime = DateTime.Parse(movie.ReleaseDate),
                    Description = movie.Description,
                    Duration = TimeSpan.Parse(movie.Duration),
                    Photo = _context.Resources.FirstOrDefault(x => x.ResourceId == movie.PhotoId)

                };
                _context.Movies.Add(m);
                _context.SaveChanges();
            }
           
        }

        public bool DeleteMovie(string id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == int.Parse(id));
            if(movie!=null)
            {
                _context.Remove(movie);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
