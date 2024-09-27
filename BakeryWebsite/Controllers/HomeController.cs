/**
 *
 * @author Roshan Phakami PunMagar
 * 
 * File Name: HomeController.cs
 * Date: 27/09/2024
 * Purpose: Manages the home page and related actions for the bakery website.
 *          This controller handles displaying the home page, contact form submission,
 *          and references page.
 * 
 * ******************************************************
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BakeryWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;  // Configuration object to access app settings

        // Constructor that injects the IConfiguration service
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;  // Assign injected configuration to the field
        }

        // Action to display the home page
        public IActionResult Index()
        {
            ViewData["LogoUrl"] = _configuration["LogoUrl"];  // Get logo URL from configuration and store it in ViewData
            return View();  // Return the home page view
        }

        // Action to display the references page
        public IActionResult References()
        {
            return View();  // Return the references view
        }

        // Action to display the contact page
        public IActionResult Contact()
        {
            return View();  // Return the contact page view
        }

        // Action to handle the submission of the contact form
        [HttpPost]
        public IActionResult Contact(string name, string email, string message)
        {
            ViewBag.Message = "Thank you for contacting us! We will get back to you shortly.";  // Set a thank-you message for the user

            return View();  // Return the contact page view
        }
    }
}