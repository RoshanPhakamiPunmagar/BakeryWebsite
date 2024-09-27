using BakeryWebsite.Models;
using System.Collections.Generic;

/**
 * 
 * @author Roshan Phakami PunMagar
 * 
 * File Name: IShoppingCartService.cs
 * Date: 27/09/2024
 * Purpose: This interface defines the contract for shopping cart services, 
 *          outlining the operations that can be performed on the shopping cart.
 *          It is designed for flexibility and easy unit testing in the application.
 * 
 * ******************************************************
 */
public interface IShoppingCartService
{
    
      //Retrieves a list of items currently in the shopping cart.
    List<CartItem> GetCartItems();

    
    // Adds a specified quantity of a product to the shopping cart.
    void AddToCart(Product product, int quantity);

    
     // Removes a product from the shopping cart based on its product ID.
    void RemoveFromCart(int productId);

    
      //Clears all items from the shopping cart.
    void ClearCart();

    
     //Calculates the total price of the items currently in the shopping cart.
    decimal GetTotalPrice();
}
