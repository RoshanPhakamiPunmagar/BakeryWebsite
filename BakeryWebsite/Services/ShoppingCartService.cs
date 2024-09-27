using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using BakeryWebsite.Models;
using System.Collections.Generic;

namespace BakeryWebsite.Services
{
    /**
     * 
     * @author Roshan Phakami PunMagar
     * 
     * File Name: ShoppingCartService.cs
     * Date: 27/09/2024
     * Purpose: This class implements the IShoppingCartService interface and provides 
     *          functionality for managing a shopping cart using session storage.
     *          It includes methods for adding, removing, and retrieving items in the cart, 
     *          as well as calculating the total price of the items.
     * 
     * ******************************************************
     */
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        
         // Constructor that initializes the ShoppingCartService with an IHttpContextAccessor.
        public ShoppingCartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        
         // Retrieves the shopping cart from the session.
        private List<CartItem> GetCart()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cart = session.GetString("ShoppingCart");
            if (string.IsNullOrEmpty(cart))
            {
                return new List<CartItem>(); // Return an empty cart if no session exists
            }

            return JsonConvert.DeserializeObject<List<CartItem>>(cart); // Deserialize cart from session
        }

         // Saves the current state of the shopping cart to the session.
        private void SaveCart(List<CartItem> cart)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString("ShoppingCart", JsonConvert.SerializeObject(cart)); // Serialize cart to session
        }

        
         // Adds a specified quantity of a product to the shopping cart.
        public void AddToCart(Product product, int quantity)
        {
            var cart = GetCart();
            var cartItem = cart.Find(item => item.Product.Id == product.Id);

            if (cartItem == null)
            {
                cart.Add(new CartItem { Product = product, Quantity = quantity }); // Add new item
            }
            else
            {
                cartItem.Quantity += quantity; // Update quantity if product already in cart
            }

            SaveCart(cart); // Save the updated cart
        }

        
         // Removes a product from the shopping cart based on its product ID.
        public void RemoveFromCart(int productId)
        {
            var cart = GetCart();
            var cartItem = cart.Find(item => item.Product.Id == productId);

            if (cartItem != null)
            {
                cart.Remove(cartItem); // Remove the item from the cart
            }

            SaveCart(cart); // Save the updated cart
        }

        
         // Retrieves all items currently in the shopping cart.
         
        public List<CartItem> GetCartItems()
        {
            return GetCart(); // Return the current state of the cart
        }

        
         // Calculates the total price of the items currently in the shopping cart.
        
        public decimal GetTotalPrice()
        {
            var cart = GetCart();
            decimal total = 0;

            foreach (var item in cart)
            {
                total += item.Product.Price * item.Quantity; // Sum the price for each item
            }

            return total; // Return the total price
        }

         // Clears all items from the shopping cart by removing the session data.
        public void ClearCart()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.Remove("ShoppingCart"); // Remove the shopping cart from the session
        }
    }
}
