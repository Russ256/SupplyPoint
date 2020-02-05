namespace SupplyPoint.Application.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductQueries
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
    }
}