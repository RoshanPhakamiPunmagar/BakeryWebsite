using BakeryWebsite.Models;
using System.Collections.Generic;

public interface IShoppingCartService
{
    List<CartItem> GetCartItems();
    void AddToCart(Product product, int quantity);
    void RemoveFromCart(int productId);
    void ClearCart();
    decimal GetTotalPrice();
}
