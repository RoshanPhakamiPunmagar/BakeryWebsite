using Microsoft.AspNetCore.Mvc;
using BakeryWebsite.Models;
using BakeryWebsite.Services;  // Make sure to include the namespace where your IShoppingCartService is located
using System.Linq;

namespace BakeryWebsite.Controllers
{
    public class CatalogueController : Controller
    {
        private readonly IStoreRepository _repository;
        private readonly IShoppingCartService _shoppingCartService;

        // Inject both repository and shopping cart service through the constructor
        public CatalogueController(IStoreRepository repository, IShoppingCartService shoppingCartService)
        {
            _repository = repository;
            _shoppingCartService = shoppingCartService;  // Assign the injected service to the field
        }

        public IActionResult Index(string category)
        {
            var products = _repository.Products;

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category);
            }

            return View("Catalogue", products);
        }

        public IActionResult Details(int id)
        {
            var product = _repository.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _repository.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _shoppingCartService.AddToCart(product, quantity);  // Call the shopping cart service to add the product
            }

            return RedirectToAction("Index", "Catalogue");  // Redirect to the Catalogue page
        }
    }
}
