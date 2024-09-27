using System.Collections.Generic;

namespace BakeryWebsite.Models
{
    /**
     *
     * @author Roshan Phakami PunMagar
     * 
     * File Name: CheckoutViewModel.cs
     * Date: 27/09/2024
     * Purpose: Represents the model used for the checkout process, 
     *          containing user information, selected payment method, 
     *          items in the cart, and the total price.
     *
     * ******************************************************
     */
    public class CheckoutViewModel
    {
        // Gets or sets the full name of the customer for the checkout process.
        public string FullName { get; set; }

        // Gets or sets the shipping address provided by the customer.
        public string Address { get; set; }

        // Gets or sets the payment method selected by the customer (e.g., credit card, PayPal).
        public string PaymentMethod { get; set; }

        // Gets or sets the list of items in the shopping cart associated with this checkout.
        public List<CartItem> CartItems { get; set; } // Items in the cart

        // Gets or sets the total price of all items in the cart.
        public decimal TotalPrice { get; set; } // Total price of the cart
    }
}
