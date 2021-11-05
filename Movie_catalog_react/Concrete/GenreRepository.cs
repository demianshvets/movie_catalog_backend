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
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;
        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Genre> Genres
        {
            get
            {
                return _context.Genres.Include(g=>g.Movies);
            }
        }

        public void addGenre(string name)
        {
            if(name!=null)
            {
                _context.Add(new Genre { Name = name });
                _context.SaveChanges();
            }
          
        }

        public void FillingGenresId(List<int> genresId)
        {
            if (genresId.Count == 0)
            {
                foreach (Genre g in _context.Genres)
                    genresId.Add(g.GenreId);
            }
        }


        public void FilteredGenres(List<int> genresID, string inputGenreId)
        {
            if(inputGenreId!=null)
            {
                genresID.Clear();
                if (inputGenreId == "all")
                {
                    this.FillingGenresId(genresID);
                }
                else
                {
                    genresID.Add(int.Parse(inputGenreId));
                }
            }
           
        }

        public void GetGenersModel(List<Genre> inputGenres, List<GenreModel> outputGenres)
        {
            outputGenres.Clear();
            foreach (Genre g in inputGenres)
                outputGenres.Add(new GenreModel() { genreId = g.GenreId.ToString(), genreName = g.Name.ToString() });
            
        }
    }
}
