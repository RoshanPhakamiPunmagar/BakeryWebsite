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

        public IActionResult References()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(string name, string email, string message)
        {         
            ViewBag.Message = "Thank you for contacting us! We will get back to you shortly.";

            return View();
        }
    }
}
