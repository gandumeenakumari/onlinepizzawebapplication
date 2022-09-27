using Microsoft.EntityFrameworkCore;
using onlinepizzawebapplication.Models;
namespace onlinepizzawebapplication.Data
{
    public class FullStackDbContext : DbContext
    {
        public FullStackDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Reviews> Reviews { get; set; }

    }
}