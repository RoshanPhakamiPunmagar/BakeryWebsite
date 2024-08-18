using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using BakeryWebsite.Models;

namespace BakeryWebsite
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();



            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Cheese Cake",
                        Description = "Delicious creamy cheesecake with strawberry topping.",
                        Category = "Cake",
                        Price = 6.99M,
                        ImageUrl = "/Images/CheeseCakes.jpg"
                    },
                    new Product
                    {
                        Name = "Croissant",
                        Description = "Flaky and buttery croissant, perfect for breakfast.",
                        Category = "Pastry",
                        Price = 2.99M,
                        ImageUrl = "/Images/Croissant.jpg"
                    },
                    new Product
                    {
                        Name = "Puff Pastry",
                        Description = "Light and crispy puff pastry filled with custard.",
                        Category = "Pastry",
                        Price = 3.50M,
                        ImageUrl = "/Images/PuffPastry.jpg"
                    },
                    new Product
                    {
                        Name = "Banana Bread",
                        Description = "Moist banana bread with walnuts.",
                        Category = "Bread",
                        Price = 4.50M,
                        ImageUrl = "/Images/BananaBread.jpg"
                    },
                    new Product
                    {
                        Name = "Donuts",
                        Description = "Soft and sweet donuts with chocolate and sprinkles.",
                        Category = "Pastry",
                        Price = 1.99M,
                        ImageUrl = "/Images/Donuts.jpg"
                    },
                    new Product
                    {
                        Name = "Almond Biscuits",
                        Description = "Crunchy almond biscuits with a hint of vanilla.",
                        Category = "Biscuit",
                        Price = 5.99M,
                        ImageUrl = "/Images/AlmondBiscuits.jpg"
                    },
                    new Product
                    {
                        Name = "Heart Biscuits",
                        Description = "Heart-shaped biscuits, perfect for Valentine's Day.",
                        Category = "Biscuit",
                        Price = 4.99M,
                        ImageUrl = "/Images/HeartBiscuits.jpg"
                    },
                    new Product
                    {
                        Name = "Cannoli Cake",
                        Description = "Traditional Italian cannoli cake filled with ricotta cream.",
                        Category = "Cake",
                        Price = 8.50M,
                        ImageUrl = "/Images/CannoliCake.jpg"
                    },
                    new Product
                    {
                        Name = "Muffin",
                        Description = "Soft muffins with blueberry and chocolate chips.",
                        Category = "Pastry",
                        Price = 3.00M,
                        ImageUrl = "/Images/Muffin.jpg"
                    },
                    new Product
                    {
                        Name = "Baked Ricotta Cake",
                        Description = "Traditional baked ricotta cake, perfect for any occasion.",
                        Category = "Cake",
                        Price = 7.99M,
                        ImageUrl = "/Images/BakedRicottaCake.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
