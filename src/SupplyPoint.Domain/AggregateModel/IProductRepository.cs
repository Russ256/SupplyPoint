namespace SupplyPoint.Domain.AggregateModel
{
    using SupplyPoint.Domain.Common;

    public interface IProductRepository : IRepository<Product>
    {
        Product Add(Product product);
    }
}