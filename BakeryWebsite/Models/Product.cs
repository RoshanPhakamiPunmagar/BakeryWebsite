using System.ComponentModel.DataAnnotations.Schema;

namespace BakeryWebsite.Models
{
    /**
     *
     * @author Roshan Phakami PunMagar
     * 
     * File Name: Product.cs
     * Date: 27/09/2024
     * Purpose: Represents a product in the bakery website, including 
     *          its attributes such as name, price, description, 
     *          image URL, and category.
     *
     * ******************************************************
     */
    public class Product
    {
        // Unique identifier for the product
        public int Id { get; set; }

        // Name of the product
        public string Name { get; set; }

        // Price of the product, formatted to two decimal places
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Price { get; set; }

        // Description providing details about the product
        public string Description { get; set; }

        // URL for the product's image
        public string ImageUrl { get; set; }

        // Category under which the product is classified
        public string Category { get; set; }
    }
}
