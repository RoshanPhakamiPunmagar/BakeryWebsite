using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BakeryWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["LogoUrl"] = _configuration["LogoUrl"];
            return View();
        }
    }
}
