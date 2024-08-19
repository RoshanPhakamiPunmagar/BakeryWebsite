using System.ComponentModel.DataAnnotations.Schema;

namespace BakeryWebsite.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(7, 2)")]
        public decimal Price { get; set; } 

        public string Description { get; set; }

        public string ImageUrl { get; set; } 

        public string Category { get; set; }
    }
}
