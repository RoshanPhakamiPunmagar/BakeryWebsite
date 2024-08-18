using System.ComponentModel.DataAnnotations.Schema;

namespace BakeryWebsite.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(7, 2)")]
        public decimal Price { get; set; } // The column type for Price should be decimal(7, 2)

        public string Description { get; set; }

        public string ImageUrl { get; set; } // No need for decimal(7, 2) here, since this is a string

        public string Category { get; set; }
    }
}
