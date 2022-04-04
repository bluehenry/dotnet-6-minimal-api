using Microsoft.EntityFrameworkCore;
using CoffeeApp.Domain;

namespace CoffeeApp.Data
{
    public class CoffeeContext: DbContext
    {
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=CoffeeAppDb");
        }
    }
}