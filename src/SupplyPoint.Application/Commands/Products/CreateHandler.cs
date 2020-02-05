namespace SupplyPoint.Application.Commands.Products
{
    using MediatR;
    using SupplyPoint.Domain.AggregateModel;

    public class CreateHandler : RequestHandler<CreateRequest, CreateResponse>
    {
        private IProductRepository productRepository;

        public CreateHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        protected override CreateResponse Handle(CreateRequest request)
        {
            Product product = new Product(request.Name, request.Text);
            this.productRepository.Add(product);

            return new CreateResponse(product.Id, product.Name, product.Text);
        }
    }
}