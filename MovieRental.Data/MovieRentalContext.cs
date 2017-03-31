using Microsoft.EntityFrameworkCore;
using MovieRental.Models;

namespace MovieRental.Data
{
    public class MovieRentalContext : DbContext
    {
        public MovieRentalContext(DbContextOptions<MovieRentalContext> options) 
            : base(options)  
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>()
                .HasKey(m => new { m.MovieId, m.GenreId });

            modelBuilder.Entity<MovieGenre>()
                .HasOne(m => m.Movie)
                .WithMany(p => p.Genres)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(m => m.Genre)
                .WithMany(t => t.Movies)
                .HasForeignKey(m => m.GenreId);
        }
    }

}
