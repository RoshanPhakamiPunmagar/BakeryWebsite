using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BakeryWebsite.Models
{
    /**
     *
     * @author Roshan Phakami PunMagar
     * 
     * File Name: StoreDbContext.cs
     * Date: 27/09/2024
     * Purpose: Represents the database context for the Bakery website, 
     *          allowing interaction with the database using Entity Framework Core.
     *
     * ******************************************************
     */
    public class StoreDbContext : DbContext
    {
        /**
         * Constructor that initializes the StoreDbContext with the specified options.
         *
         * @param options Configuration options for the DbContext.
         */
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options) { }

        // DbSet representing the collection of Product entities in the database.
        public DbSet<Product> Products { get; set; }
    }
}
