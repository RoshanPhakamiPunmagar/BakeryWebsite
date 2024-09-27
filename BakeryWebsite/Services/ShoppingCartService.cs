using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using BakeryWebsite.Models;
using System.Collections.Generic;

namespace BakeryWebsite.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingCartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private List<CartItem> GetCart()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cart = session.GetString("ShoppingCart");
            if (string.IsNullOrEmpty(cart))
            {
                return new List<CartItem>();
            }

            return JsonConvert.DeserializeObject<List<CartItem>>(cart);
        }

        private void SaveCart(List<CartItem> cart)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString("ShoppingCart", JsonConvert.SerializeObject(cart));
        }

        public void AddToCart(Product product, int quantity)
        {
            var cart = GetCart();
            var cartItem = cart.Find(item => item.Product.Id == product.Id);

            if (cartItem == null)
            {
                cart.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                cartItem.Quantity += quantity; // Update quantity if product already in cart
            }

            SaveCart(cart);
        }

        public void RemoveFromCart(int productId)
        {
            var cart = GetCart();
            var cartItem = cart.Find(item => item.Product.Id == productId);

            if (cartItem != null)
            {
                cart.Remove(cartItem);
            }

            SaveCart(cart);
        }

        public List<CartItem> GetCartItems()
        {
            return GetCart();
        }

        public decimal GetTotalPrice()
        {
            var cart = GetCart();
            decimal total = 0;

            foreach (var item in cart)
            {
                total += item.Product.Price * item.Quantity;
            }

            return total;
        }

        public void ClearCart()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.Remove("ShoppingCart");
        }
    }
}