using Microsoft.AspNetCore.Mvc;
using BakeryWebsite.Models;
using System.Linq;

namespace BakeryWebsite.Controllers
{
    public class CatalogueController : Controller
    {
        private readonly IStoreRepository _repository;

        public CatalogueController(IStoreRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(string category)
        {
            var products = _repository.Products;

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category);
            }

            return View("Catalogue",products);
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
          // Have to add some idea about what to do after this button is clicked

            }
           

            return RedirectToAction("Index", "Catalogue");
        }

    }
}