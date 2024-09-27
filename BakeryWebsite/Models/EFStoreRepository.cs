using System.Linq;

namespace BakeryWebsite.Models
{
    /**
     *
     * @author Roshan Phakami PunMagar
     * 
     * File Name: EFStoreRepository.cs
     * Date: 27/09/2024
     * Purpose: Implements the IStoreRepository interface for accessing 
     *          product data from the database using Entity Framework.
     *
     * ******************************************************
     */
    public class EFStoreRepository : IStoreRepository
    {
        // Holds the instance of the database context for data operations.
        private StoreDbContext context;

        // Constructor that accepts a StoreDbContext instance for data access.
        public EFStoreRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        // Property that retrieves all products from the database as an IQueryable.
        public IQueryable<Product> Products => context.Products;
    }
}
