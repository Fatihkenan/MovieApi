using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Entities;

namespace Persistence.Context
{
    public class MovieContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;initial Catalog = ApiMovieDb; Integrated Security=True;TrustServerCertificate=True");
        }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }



    }
}
