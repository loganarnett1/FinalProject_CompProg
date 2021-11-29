using Microsoft.EntityFrameworkCore;
using FinalProject_CompProg.Models;

namespace FinalProject_CompProg.Data
{
    public class RestaurantsContext : DbContext

    {
        public RestaurantsContext(DbContextOptions<RestaurantsContext> options) : base(options) {}
        
        public DbSet<Restaurant> Restaurants { get; set; }
        protected override void OnModelCreating(ModelBuilder Restaurant)
        {
            builder.Entity<Restaurants>().HasData(
                new Restaurant {id = 0, name = "McDonalds", foodType = "Burgers", founder = "Richard McDonald and Maurice McDonald", foundingYear = 1955},
                new Restaurant {id = 1, name = "Wendys", foodType = "Burgers", founder = "Dave Thomas", foundingYear = 1969},
                new Restaurant {id = 2, name = "Olive Garden", foodType = "Spaghetti", founder = "Bill Darden", foundingYear = 1982});
        }
    }
}
