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
                        ImageUrl = "/Images/cheesecake.jpg"

                    },

                    new Product
                    {
                        Name = "Brioche",
                        Description = "Traditional Italian sweet brioche - the perfect accompaniment to your morning coffee or served with gelato.",
                        Category = "Cake",
                        Price = 6.99M,
                        ImageUrl = "/Images/brioche.jpg"

                    },

                    new Product
                    {
                        Name = "Danish",
                        Description = "Danish pastries with assorted fruit toppings.",
                        Category = "Cake",
                        Price = 6.99M,
                        ImageUrl = "/Images/danish.jpg"

                    },

                    new Product
                    {
                        Name = "Croissant Scrolls",
                        Description = "Buttery. Flakey. Delicious. Our new Croissant Scrolls are available as Nutella and Pistachio flavour.",
                        Category = "Cake",
                        Price = 6.99M,
                        ImageUrl = "/Images/croissantscrolls.jpg"

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
                        ImageUrl = "/Images/puff.jpg"
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
                        ImageUrl = "/Images/Donut.jpg"
                    },
                    new Product
                    {
                        Name = "Almond Biscuits",
                        Description = "Crunchy almond biscuits with a hint of vanilla.",
                        Category = "Biscuit",
                        Price = 5.99M,
                        ImageUrl = "/Images/almond.jpg"
                    },
                    new Product
                    {
                        Name = "Heart Biscuits",
                        Description = "Heart-shaped biscuits, perfect for Valentine's Day.",
                        Category = "Biscuit",
                        Price = 4.99M,
                        ImageUrl = "/Images/heartbiscuits.jpg"
                    },
                    new Product
                    {
                        Name = "Cannoli Cake",
                        Description = "Traditional Italian cannoli cake filled with ricotta cream.",
                        Category = "Cake",
                        Price = 8.50M,
                        ImageUrl = "/Images/cannolicakes.jpg"
                    },
                    new Product
                    {
                        Name = "Muffin",
                        Description = "Soft muffins with blueberry and chocolate chips.",
                        Category = "Pastry",
                        Price = 3.00M,
                        ImageUrl = "/Images/muffin.jpg"
                    },
                    new Product
                    {
                        Name = "Baked Ricotta Cake",
                        Description = "Traditional baked ricotta cake, perfect for any occasion.",
                        Category = "Cake",
                        Price = 7.99M,
                        ImageUrl = "/Images/ricotta.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
