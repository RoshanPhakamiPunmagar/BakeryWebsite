/**
 *
 * @author Roshan Phakami PunMagar
 * 
 * File Name: AboutController.cs
 * Date: 27/09/2024
 * Purpose: Handles requests related to the About Us page of the application.
 *          This controller defines actions for displaying information about the application or organization.
 * 
 * ******************************************************
 */
using Microsoft.AspNetCore.Mvc;

public class AboutController : Controller
{
    public IActionResult AboutUs()
    {
        return View();
    }
}
