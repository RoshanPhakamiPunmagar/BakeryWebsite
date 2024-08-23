using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BakeryWebsite.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options) { }
         
        public DbSet<Product> Products { get; set; }
    }
}
