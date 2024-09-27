namespace BakeryWebsite.Models
{
    /**
     *
     * @author Roshan Phakami PunMagar
     * 
     * File Name: CartItem.cs
     * Date: 27/09/2024
     * Purpose: Represents an item in the shopping cart, containing a product and its quantity.
     *
     * ******************************************************
     */
    public class CartItem
    {
        // Gets or sets the product associated with this cart item.
        public Product Product { get; set; }

        // Gets or sets the quantity of the product in the cart.
        public int Quantity { get; set; }
    }
}
