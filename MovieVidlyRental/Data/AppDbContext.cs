using Microsoft.EntityFrameworkCore;
using MovieVidlyRental.Models;

namespace MovieVidlyRental.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        public DbSet<Movie> Movie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
            .HasKey(m => m.MovieId);

            modelBuilder.Entity<Movie>()
            .Property(m => m.MovieTitle)
            .IsRequired()
            .HasMaxLength(50);

            modelBuilder.Entity<Movie>()
            .Property(m => m.Description)
            .IsRequired()
            .HasMaxLength(300);

            modelBuilder.Entity<Movie>()
            .Property(m => m.Genre)
            .IsRequired()
            .HasMaxLength(50);
        }
    }

}
