
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_catalog_react.Concrete;
using Movie_catalog_react.Entities;
using Movie_catalog_react.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_catalog_react.Controllers
{

    // [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
        {

        static readonly OutDataModel data = new OutDataModel();
        readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        static readonly List<GenreModel> genres = new List<GenreModel>();
        static readonly List<int> chosenGenresId = new List<int>();

        static readonly List<CompanyModel> companies = new List<CompanyModel>();
        static readonly List<int> chosenCompaniesId = new List<int>();

        static readonly List<MovieModel> movies = new List<MovieModel>();

        readonly MovieRepository movieRepository;
        readonly GenreRepository genreRepository;
        readonly CompanyRepository companyRepository;
       
        public MoviesController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            movieRepository = new MovieRepository(context);
            genreRepository = new GenreRepository(context);
            companyRepository = new CompanyRepository(context);


            List<Movie> listMovie = new List<Movie>();
            List<Genre> ListOfGenres = genreRepository.Genres.ToList();
            List<Company> ListOfCompanies = companyRepository.Companies.ToList();


            listMovie = movieRepository.GetMoviesByFilter(chosenGenresId, chosenCompaniesId).ToList();

            genreRepository.GetGenersModel(ListOfGenres,genres);
            companyRepository.GetListCompaniesModel(ListOfCompanies,companies);
            movieRepository.GetListMoviesModel(listMovie, movies);

            ListOfGenres.Clear();
            ListOfCompanies.Clear();
            listMovie.Clear();
            //genreRepository.FillingGenresId(chosenGenresId);
          //  companyRepository.FillingCompaniesId(chosenCompaniesId);


            data.movies = movies;
            data.genres = genres;
            data.companies = companies;


        }


       
        [HttpGet]
            public OutDataModel Get()
            {
                return data;
            }

            [HttpPost]
            public IActionResult Post( MovieModel movie, string genreId, string newGenre, string companyId, string newCompany)
            {

            this.movieRepository.addingMovie(movie);
            this.genreRepository.FilteredGenres(chosenGenresId, genreId);
            this.genreRepository.addGenre(newGenre);
            this.companyRepository.FilteredCompany(chosenCompaniesId, companyId);
            this.companyRepository.addCompany(newCompany);

            return Ok();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(string id)
            {
                     
                if (!this.movieRepository.DeleteMovie(id))
                {
                    return NotFound();
                }
            MovieModel mov = data.movies.FirstOrDefault(x => x.Id == id);
            return Ok(mov);
            }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;
                var splitFileName = filename.Split('.');
               
                if(Enum.IsDefined(typeof(ResourceFormat),splitFileName[1]))
                {
                    using (FileStream stream = new FileStream(physicalPath, FileMode.OpenOrCreate))
                    {
                        postedFile.CopyTo(stream);
                    }

                    Resource r = new Resource { DataPath = "Photos/" + filename, Format=Enum.Parse<ResourceFormat>( splitFileName[1]) };
                    _context.Resources.Add(r);
                    _context.SaveChanges();
                    int PhotoId = r.ResourceId;
                    return new JsonResult(PhotoId);
                }

                return new JsonResult(_context.Resources.FirstOrDefault(x => x.DataPath == "Photos/defalt.jpg").ResourceId);
            }
            catch (Exception)
            {
                return new JsonResult(_context.Resources.FirstOrDefault(x => x.DataPath == "Photos/defalt.jpg").ResourceId);
            }
        }
    }
    }

