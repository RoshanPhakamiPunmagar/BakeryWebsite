using Microsoft.AspNetCore.Mvc;
using BakeryWebsite.Models;
using System.Collections.Generic;

namespace BakeryWebsite.Controllers
{
    public class CatalogueController : Controller
    {
        public IActionResult Index()
        {
            var bakeryItems = new List<BakeryItem>
            {
                new BakeryItem { Id = 1, Name = "Strawberry Cheese Cake", Price = 5.99M, Description = "Delicious creamy cheesecake.", ImageUrl = "/Images/CheeseCakes.jpg" },
                new BakeryItem { Id = 2, Name = "Croissant", Price = 2.99M, Description = "Flaky and buttery croissant.", ImageUrl = "/Images/Croissant.jpg" },
                new BakeryItem { Id = 3, Name = "Puff Pastry", Price = 3.50M, Description = "Light and crispy puff pastry with Strawberry topping.", ImageUrl = "/Images/Puff.jpg" },
                new BakeryItem { Id = 4, Name = "Banana Bread", Price = 4.50M, Description = "Moist and sweet banana bread.", ImageUrl = "/Images/bananabread.jpg" },
                new BakeryItem { Id = 5, Name = "Donuts", Price = 1.99M, Description = "Soft and sweet donuts with various toppings.", ImageUrl = "/Images/donut.jpg" },
                new BakeryItem { Id = 6, Name = "Almonds Biscuits", Price = 3.99M, Description = "Crunchy and delicious almonds biscuits.", ImageUrl = "/Images/almondsbiscuits.jpg" },
                new BakeryItem { Id = 7, Name = "Heart Biscuits", Price = 4.50M, Description = "Sweet and buttery heart-shaped biscuits.", ImageUrl = "/Images/heartbiscuits.jpg" },
                new BakeryItem { Id = 8, Name = "Cannoli Cakes", Price = 6.99M, Description = "Traditional Italian cannoli cakes filled with creamy ricotta.", ImageUrl = "/Images/cannolicakes.jpg" },
                new BakeryItem { Id = 9, Name = "Muffin", Price = 2.50M, Description = "Soft and fluffy muffins with various flavors.", ImageUrl = "/Images/muffin.jpg" },
                new BakeryItem { Id = 10, Name = "Baked Ricotta Cakes", Price = 5.50M, Description = "Rich and creamy baked ricotta cakes.", ImageUrl = "/Images/bakedricottacakes.jpg" }
            };

            return View(bakeryItems);
        }
    }
}
