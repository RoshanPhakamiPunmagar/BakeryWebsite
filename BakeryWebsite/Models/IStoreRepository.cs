using System.Linq;

namespace BakeryWebsite.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}
