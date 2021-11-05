using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie_catalog_react.Entities;

namespace Movie_catalog_react.Concrete
{
    public class AppDbContext : DbContext
    {
       // public virtual DbSet<User> Userss { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
               : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
