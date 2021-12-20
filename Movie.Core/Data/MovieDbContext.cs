using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie.Core.Model;

namespace Movie.Core.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options) { }

        private readonly string ConnectionString =
            "Server = localhost; " +
            "Database = Movies; " +
            "User Id =sa; " +
            "Password =admin!@#123;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Model.Movie>()
                .ToTable("Movie");

            modelBuilder
                .Entity<Actor>()
                .ToTable("Actor");

            modelBuilder
                .Entity<Image>()
                .ToTable("Image");

            modelBuilder
                .Entity<MovieActor>()
                .ToTable("MovieActor");
        }
    }
}
