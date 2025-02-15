using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Mission6_Hamilton.Models
{
    public class MovieContextFactory : IDesignTimeDbContextFactory<MovieDbContext>
    {
        public MovieDbContext CreateDbContext(string[] args)
        {
            // 1. Build configuration (so we can read appsettings.json)
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();

            // 2. Set up DbContextOptions
            var builder = new DbContextOptionsBuilder<MovieDbContext>();
            builder.UseSqlite(config.GetConnectionString("MovieConnection"));

            // 3. Construct and return your context
            return new MovieDbContext(builder.Options);
        }
    }
}