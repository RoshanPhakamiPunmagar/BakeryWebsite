/**
 *
 * @author Roshan Phakami PunMagar
 * 
 * File Name: CatalogueController.cs
 * Date: 27/09/2024
 * Purpose: Handles the requests related to product catalog in the bakery website.
 *          This controller manages product listings, details, and adding items to the shopping cart.
 * 
 * ******************************************************
 */

using Microsoft.AspNetCore.Mvc;
using BakeryWebsite.Models;
using System.Linq;

namespace BakeryWebsite.Controllers
{
    public class CatalogueController : Controller
    {
        private readonly IStoreRepository _repository;  // Repository for accessing product data
        private readonly IShoppingCartService _shoppingCartService;  // Service for managing shopping cart operations

        // Inject both repository and shopping cart service through the constructor
        public CatalogueController(IStoreRepository repository, IShoppingCartService shoppingCartService)
        {
            _repository = repository;  // Assign the injected repository to the field
            _shoppingCartService = shoppingCartService;  // Assign the injected service to the field
        }

        // Action to display the product catalog with optional filtering by category
        public IActionResult Index(string category)
        {
            var products = _repository.Products;  // Retrieve all products from the repository

            // Filter products by category if specified
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category);
            }

            return View("Catalogue", products);  // Return the view with the filtered products
        }

        // Action to display details of a specific product by its ID
        public IActionResult Details(int id)
        {
            var product = _repository.Products.FirstOrDefault(p => p.Id == id);  // Retrieve product by ID
            if (product == null)
            {
                return NotFound();  // Return 404 if product is not found
            }

            return View(product);  // Return the product details view
        }

        // Action to add a product to the shopping cart
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _repository.Products.FirstOrDefault(p => p.Id == productId);  // Retrieve product by ID
            if (product != null)
            {
                _shoppingCartService.AddToCart(product, quantity);  // Call the shopping cart service to add the product
            }

            return RedirectToAction("Index", "Catalogue");  // Redirect to the Catalogue page after adding to cart
        }
    }
}
