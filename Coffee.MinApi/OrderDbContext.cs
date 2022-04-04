using Microsoft.EntityFrameworkCore;

namespace Coffee.MinApi
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options): base(options) { 
        }

        public DbSet<Order> Orders { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Order>().HasData(
        //        new Order
        //        {
        //            Id = 1,
        //            OrderNumber = 100,
        //            Created = DateTime.Now,
        //            Description = "Flat White",
        //            PromoCode = "Openning",                    
        //            Total = 5
        //        },
        //        new Order
        //        {
        //            Id = 2,
        //            OrderNumber = 101,
        //            Created = DateTime.Now,
        //            Description = "Long Black",
        //            PromoCode = "Openning",                    
        //            Total = 3
        //        }
        //    );
        //}
    }
}
