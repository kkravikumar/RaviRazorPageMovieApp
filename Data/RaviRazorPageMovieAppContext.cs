using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RaviRazorPageMovieApp.Models;

namespace RaviRazorPageMovieApp.Data
{
    public class RaviRazorPageMovieAppContext : DbContext
    {
        public RaviRazorPageMovieAppContext (DbContextOptions<RaviRazorPageMovieAppContext> options)
            : base(options)
        {
        }

        public DbSet<RaviRazorPageMovieApp.Models.Movie> Movies { get; set; } = default!;

        public DbSet<RaviRazorPageMovieApp.Models.Actor>? Actors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany(a => a.Movies);

            modelBuilder.Entity<Movie>()
            .HasOne(m => m.Hero);

            base.OnModelCreating(modelBuilder);
        }
    }
}
