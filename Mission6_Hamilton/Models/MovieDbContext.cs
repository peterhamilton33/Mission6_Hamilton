using Microsoft.EntityFrameworkCore;

namespace Mission6_Hamilton.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        // If you have a Category table, include:
        // public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: explicitly map tables
            modelBuilder.Entity<Movie>().ToTable("Movies");
            // modelBuilder.Entity<Category>().ToTable("Categories");
        }
        public DbSet<Category> Categories { get; set; }

    }
}