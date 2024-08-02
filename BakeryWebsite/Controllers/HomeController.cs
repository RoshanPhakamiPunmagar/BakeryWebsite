
using Microsoft.AspNetCore.Mvc;
namespace BakeryWebsite.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

    }
}
