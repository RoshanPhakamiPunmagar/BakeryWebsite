using BakeryWebsite.Models;
using Microsoft.AspNetCore.Mvc;
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

        // Action to list all products
        public IActionResult Index()
        {
            // Get all products as IQueryable
            var products = _repository.Products;

            // Pass the products to the view
            return View(products);
        }
    }
}
