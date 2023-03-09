using Microsoft.EntityFrameworkCore;
using Data_Access.Entities;

namespace Data_Access
{
    public static class DbContextExtensions
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().HasData(new[]
            //{
            //    new Category() { Id = 1, Name = "Laptop" },
            //    new Category() { Id = 2, Name = "Phone" },
            //    new Category() { Id = 3, Name = "PC" },
            //    new Category() { Id = 4, Name = "Headphones" },
            //    new Category() { Id = 5, Name = "Accessories" },
            //    new Category() { Id = 6, Name = "Accoustic System" }
            //});
        }

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().HasData(new[]
            //{
            //    new Product()
            //    {
            //        Id = 1,
            //        Name = "Google Pixel 7 Pro",
            //        Price = 1200,
            //        CategoryId = 2
            //    },
            //    new Product()
            //    {
            //        Id = 2,
            //        Name = "iPhone 14 Pro",
            //        Price = 999,
            //        CategoryId = 2
            //    },
            //    new Product()
            //    {
            //        Id = 3,
            //        Name = "Acer Predator Helios",
            //        Price = 1000,
            //        CategoryId = 1
            //    },
            //    new Product()
            //    {
            //        Id = 4,
            //        Name = "Xiaomi Powerbank",
            //        Price = 120,
            //        CategoryId = 5
            //    },
            //    new Product()
            //    {
            //        Id = 5,
            //        Name = "Apple HomePod Mini",
            //        Price = 450,
            //        CategoryId = 6
            //    }
            //});
        }
    }
}