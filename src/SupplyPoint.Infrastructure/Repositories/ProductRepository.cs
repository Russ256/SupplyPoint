namespace SupplyPoint.Infrastructure.Repositories
{
    using SupplyPoint.Domain.AggregateModel;
    using System;

    public class ProductRepository : IProductRepository
    {
        private readonly SupplyPointDataContext context;

        public ProductRepository(SupplyPointDataContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Product Add(Product product)
        {
            return this.context.Add(product).Entity;
        }
    }
}