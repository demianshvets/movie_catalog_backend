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
            if(!context.Resources.Any())
            {
                context.Resources.Add(new Resource
                {
                    DataPath="Photos/defalt.jpg"
                });
            }
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
                        Name = "Historical"
                    }, new Genre
                    {
                        Name = "Crime"
                    }, new Genre
                    {
                        Name = "Action"
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
                         Name = "Paramount Pictures"
                     },
                     new Company
                     {
                         Name = "Universal Pictures"
                     },
                     new Company
                     {
                         Name = "The Weinstein Company"
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
                        Name = "The God Father",
                        Company = context.Companies.FirstOrDefault(x => x.Name == "Paramount Pictures"),
                        Duration = new TimeSpan(2, 57, 00),
                        ReleaseTime = new DateTime(1972, 3, 14),
                        Photo = new Resource { Format = ResourceFormat.JPEG, DataPath = "Photos/god_father.jpg" },
                        Genre = new List<Genre>() { context.Genres.FirstOrDefault(x => x.Name == "Crime") },
                        Description = "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son."
                    },
                    new Movie
                    {
                        Name = "The Truman show",
                        Company = context.Companies.FirstOrDefault(x => x.Name == "Paramount Pictures"),
                        Duration = new TimeSpan(1, 43, 25),
                        ReleaseTime = new DateTime(1998, 6, 1),
                        Genre = new List<Genre>() { context.Genres.FirstOrDefault(x => x.Name == "Comedy") },
                        Photo = new Resource { Format = ResourceFormat.JPEG, DataPath = "Photos/Show_truman.jpg" },
                        Description = "An insurance salesman discovers his whole life is actually a reality TV show."
                    },
                    new Movie
                    {
                        Name = "Wolf of Wall-Street",
                        Company = context.Companies.FirstOrDefault(x => x.Name == "Universal Pictures"),
                        Duration = new TimeSpan(3, 0, 24),
                        ReleaseTime = new DateTime(2013, 12, 25),
                        Genre = new List<Genre>() { context.Genres.FirstOrDefault(x => x.Name == "Comedy") },
                        Photo = new Resource { Format = ResourceFormat.JPEG, DataPath = "Photos/wolf_wall_street.jpg" },
                        Description = "American comedy based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government."
                    }
                    ,
                    new Movie
                    {
                        Name = "The imitation game",
                        Company = context.Companies.FirstOrDefault(x => x.Name == "The Weinstein Company"),
                        Duration = new TimeSpan(1, 54, 15),
                        ReleaseTime = new DateTime(2014, 8, 29),
                        Genre = new List<Genre>() { context.Genres.FirstOrDefault(x => x.Name == "Drama") },
                        Photo = new Resource { Format = ResourceFormat.JPEG, DataPath = "Photos/the_immitation_game.jpg" },
                        Description = "During World War II, the English mathematical genius Alan Turing tries to crack the German Enigma code with help from fellow mathematicians while attempting to come to terms with his troubled private life."
                    },
                    new Movie
                    {
                        Name = "The Island",
                        Company = context.Companies.FirstOrDefault(x => x.Name == "Universal Pictures"),
                        Duration = new TimeSpan(2, 16, 03),
                        ReleaseTime = new DateTime(2005, 8, 22),
                        Genre = new List<Genre>() { context.Genres.FirstOrDefault(x => x.Name == "Action") },
                        Photo = new Resource { Format = ResourceFormat.JPEG, DataPath = "Photos/the island.jpg" },
                        Description = "A man living in a futuristic sterile colony begins to question his circumscribed existence when his friend is chosen to go to the Island, the last uncontaminated place on earth."
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

