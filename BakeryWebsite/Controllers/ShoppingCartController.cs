using Microsoft.AspNetCore.Mvc;
using BakeryWebsite.Models;
using System.Linq;

public class ShoppingCartController : Controller
{
    private readonly IShoppingCartService _shoppingCartService;

    public ShoppingCartController(IShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService;
    }

    // Change the name of the action to return Cart view
    public IActionResult Cart()
    {
        var cartItems = _shoppingCartService.GetCartItems();
        ViewBag.TotalPrice = _shoppingCartService.GetTotalPrice();
        return View("Cart", cartItems);
    }

    public IActionResult RemoveFromCart(int productId)
    {
        _shoppingCartService.RemoveFromCart(productId);
        return RedirectToAction("Cart"); // Redirect to Cart after removing an item
    }

    public IActionResult ClearCart()
    {
        _shoppingCartService.ClearCart();
        return RedirectToAction("Cart"); // Redirect to Cart after clearing
    }

    // GET: ShoppingCart/Checkout
    public IActionResult Checkout()
    {
        var cartItems = _shoppingCartService.GetCartItems();

        if (cartItems == null || cartItems.Count == 0)
        {
            return RedirectToAction("Index", "Catalogue"); // Redirect if cart is empty
        }

        // Create an instance of CheckoutViewModel
        var checkoutViewModel = new CheckoutViewModel
        {
            CartItems = cartItems,
            TotalPrice = cartItems.Sum(item => item.Product.Price * item.Quantity), // Calculate total price
        };

        return View(checkoutViewModel); // Pass the CheckoutViewModel to the view
    }

    // POST: ShoppingCart/Checkout
    [HttpPost]
    public IActionResult Checkout(CheckoutViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Process the order (this is where payment logic would go)

            _shoppingCartService.ClearCart(); // Clear the cart after checkout

            // Redirect to Order Confirmation after successfully placing the order
            return RedirectToAction("OrderConfirmation");
        }

        // If there's an issue, redisplay the checkout page
        model.CartItems = _shoppingCartService.GetCartItems(); // Re-fetch cart items
        model.TotalPrice = model.CartItems.Sum(item => item.Product.Price * item.Quantity); // Recalculate total
        return View(model); // Pass the model back to the view
    }

    public IActionResult OrderConfirmation()
    {
        return View(); // Return the OrderConfirmation view
    }
}
