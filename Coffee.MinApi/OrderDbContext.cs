using Microsoft.EntityFrameworkCore;

namespace Coffee.MinApi
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options): base(options) { }

        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    OrderNumber = 100,
                    Created = DateTime.Now,
                    Description = "Flat white",
                    PromoCode = "Openning",                    
                    Total = 25
                },
                new Order
                {
                    Id = 2,
                    OrderNumber = 101,
                    Created = DateTime.Now,
                    Description = "Long Black",
                    PromoCode = "Openning",                    
                    Total = 25
                }
            );
        }
    }
}
