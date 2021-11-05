using Movie_catalog_react.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_catalog_react.Concrete
{
    public class SampleData
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Email = "email@mail.com",
                        Password=BCrypt.Net.BCrypt.HashPassword("password")
                    }
                   
                );
                context.SaveChanges();
            }
            if (!context.Genres.Any())
            {
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Horror",
                    },
                    new Genre
                    {
                        Name = "Drama",
                    }, new Genre
                    {
                        Name = "Comedy",
                    }, new Genre
                    {
                        Name = "Historical",
                    }
                );
                context.SaveChanges();
            }
            if (!context.Companies.Any())
            {
                context.Companies.AddRange(
                    new Company
                    {
                        Name = "HBO"
                    },
                    new Company
                    {
                        Name = "Colambia Pictures"
                    }
                );
                context.SaveChanges();
            }
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(
                    new Movie
                    {
                        Name = "Chernobyl",
                        Company = context.Companies.FirstOrDefault(x => x.Name == "HBO"),
                        // Company = context.Companies.Where(x => x.Name == "HBO").FirstOrDefault();
                        Duration = new TimeSpan(1, 8, 25),
                        ReleaseTime = new DateTime(2019, 5, 6),
                        Genre = new List<Genre>() { context.Genres.FirstOrDefault(x => x.Name == "Drama"), context.Genres.FirstOrDefault(x => x.Name == "Historical") },
                        Description = "In April 1986, a huge explosion erupted at the Chernobyl nuclear power station in northern Ukraine. This series follows the stories of the men and women, who tried to contain the disaster, as well as those who gave their lives preventing a subsequent and worse one."
                    },
                    new Movie
                    {
                        Name = "Titanic",
                        Company = context.Companies.FirstOrDefault(x => x.Name == "Colambia Pictures"),
                        // Company = context.Companies.Where(x => x.Name == "HBO").FirstOrDefault();
                        Duration = new TimeSpan(1, 50, 25),
                        ReleaseTime = new DateTime(1997, 5, 6),
                        Genre = new List<Genre>() { context.Genres.FirstOrDefault(x => x.Name == "Drama"), context.Genres.FirstOrDefault(x => x.Name == "Historical") },
                        Description = "In April 1986, a huge explosion erupted at the Chernobyl nuclear power station in northern Ukraine. This series follows the stories of the men and women, who tried to contain the disaster, as well as those who gave their lives preventing a subsequent and worse one."
                    },
                    new Movie
                    {
                        Name = "Getto",
                        Company = context.Companies.FirstOrDefault(x => x.Name == "Colambia Pictures"),
                        // Company = context.Companies.Where(x => x.Name == "HBO").FirstOrDefault();
                        Duration = new TimeSpan(2, 0, 25),
                        ReleaseTime = new DateTime(2005, 5, 6),
                        Genre = new List<Genre>() { context.Genres.FirstOrDefault(x => x.Name == "Drama") },
                        Description = "In April 1986, a huge explosion erupted at the Chernobyl nuclear power station in northern Ukraine. This series follows the stories of the men and women, who tried to contain the disaster, as well as those who gave their lives preventing a subsequent and worse one."
                    }
                /* new Movie
                 {
                     Name = "Colambia Pictures",
                 }*/
                );
                
                context.SaveChanges();
            }
        }
    }
}

