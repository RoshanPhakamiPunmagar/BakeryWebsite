using System.Collections.Generic;

namespace BakeryWebsite.Models
{
    public class CheckoutViewModel
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }

        public List<CartItem> CartItems { get; set; } // Items in the cart
        public decimal TotalPrice { get; set; } // Total price of the cart
    }
}
