using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This is where we can configure our database tables
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Samosa",
                Price = 15.00,
                Description = "This is Punjabi Samosa",
                CategoryName = "Appetizer",
                ImageUrl = "https://sukhis.com/wp-content/uploads/2019/07/Samosa-1.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Paneer Tikka Masala",
                Price = 13.99,
                Description = "This is Paneer Tikka Masala",
                CategoryName = "Entree",
                ImageUrl = "https://www.cookwithmanali.com/wp-content/uploads/2014/03/Paneer-Tikka-Masala-500x375.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Sweet Pie",
                Price = 10.99,
                Description = "This is Sweet Pie",
                CategoryName = "Dessert",
                ImageUrl = "https://www.196flavors.com/wp-content/uploads/2014/10/pithiviers-3-FP.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Pav Bhaji",
                Price = 15.00,
                Description = "This is Pav Bhaji",
                CategoryName = "Appetizer",
                ImageUrl = "https://www.cookwithmanali.com/wp-content/uploads/2014/03/Paneer-Tikka-Masala-500x375.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                Name = "Dosa",
                Price = 22.99,
                Description = "This is Dosa",
                CategoryName = "Entree",
                ImageUrl = "https://www.cookwithmanali.com/wp-content/uploads/2014/03/Paneer-Tikka-Masala-500x375.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                Name = "Gulab Jamun",
                Price = 10.99,
                Description = "This is Gulab Jamun",
                CategoryName = "Dessert",
                ImageUrl = "https://www.cookwithmanali.com/wp-content/uploads/2014/03/Paneer-Tikka-Masala-500x375.jpg"
            });
        }
    }
}
