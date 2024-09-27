using System.Linq;

namespace BakeryWebsite.Models
{
    /**
     *
     * @author Roshan Phakami PunMagar
     * 
     * File Name: IStoreRepository.cs
     * Date: 27/09/2024
     * Purpose: Interface for the store repository, defining 
     *          the contract for accessing product data from 
     *          the underlying data source.
     *
     * ******************************************************
     */
    public interface IStoreRepository
    {
        // Property that returns an IQueryable collection of Product objects,
        // allowing for LINQ queries against the product data.
        IQueryable<Product> Products { get; }
    }
}
