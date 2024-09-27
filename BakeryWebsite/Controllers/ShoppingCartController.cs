/**
 *
 * @author Roshan Phakami PunMagar
 * 
 * File Name: ShoppingCartController.cs
 * Date: 27/09/2024
 * Purpose: Manages the shopping cart functionality for the bakery website.
 *          This controller handles viewing the cart, adding/removing items,
 *          checking out, and confirming orders.
 * 
 * ******************************************************
 */

using Microsoft.AspNetCore.Mvc;
using BakeryWebsite.Models;
using System.Linq;

public class ShoppingCartController : Controller
{
    private readonly IShoppingCartService _shoppingCartService;  // Service to handle shopping cart operations

    // Constructor that injects the IShoppingCartService
    public ShoppingCartController(IShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService;  // Assign the injected service to the field
    }

    // Action to display the shopping cart
    public IActionResult Cart()
    {
        var cartItems = _shoppingCartService.GetCartItems();  // Get the current items in the cart
        ViewBag.TotalPrice = _shoppingCartService.GetTotalPrice();  // Calculate the total price of items in the cart
        return View("Cart", cartItems);  // Return the Cart view with the cart items
    }

    // Action to remove an item from the cart
    public IActionResult RemoveFromCart(int productId)
    {
        _shoppingCartService.RemoveFromCart(productId);  // Remove the item from the cart using its product ID
        return RedirectToAction("Cart"); // Redirect to the Cart view after removing the item
    }

    // Action to clear all items from the cart
    public IActionResult ClearCart()
    {
        _shoppingCartService.ClearCart();  // Clear all items from the shopping cart
        return RedirectToAction("Cart"); // Redirect to the Cart view after clearing the cart
    }

    // GET: ShoppingCart/Checkout
    public IActionResult Checkout()
    {
        var cartItems = _shoppingCartService.GetCartItems();  // Get the current items in the cart

        if (cartItems == null || cartItems.Count == 0)
        {
            return RedirectToAction("Index", "Catalogue"); // Redirect to Catalogue if the cart is empty
        }

        // Create an instance of CheckoutViewModel to hold cart items and total price
        var checkoutViewModel = new CheckoutViewModel
        {
            CartItems = cartItems,
            TotalPrice = cartItems.Sum(item => item.Product.Price * item.Quantity), // Calculate total price of items in the cart
        };

        return View(checkoutViewModel); // Pass the CheckoutViewModel to the view for checkout
    }

    // POST: ShoppingCart/Checkout
    [HttpPost]
    public IActionResult Checkout(CheckoutViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Process the order (this is where payment logic would go)

            _shoppingCartService.ClearCart(); // Clear the cart after successfully placing the order

            // Redirect to Order Confirmation after successfully placing the order
            return RedirectToAction("OrderConfirmation");
        }

        // If there's an issue, redisplay the checkout page with the current model
        model.CartItems = _shoppingCartService.GetCartItems(); // Re-fetch cart items for display
        model.TotalPrice = model.CartItems.Sum(item => item.Product.Price * item.Quantity); // Recalculate total price
        return View(model); // Return the checkout view with the model for corrections
    }

    // Action to display the order confirmation page
    public IActionResult OrderConfirmation()
    {
        return View(); // Return the OrderConfirmation view to the user
    }
}
