namespace SupplyPoint.Application.Commands.Products
{
    using MediatR;

    public class CreateRequest : IRequest<CreateResponse>
    {
        public CreateRequest(string name, string text)
        {
            this.Name = name;
            this.Text = text;
        }

        public string Name { get; private set; }
        public string Text { get; private set; }
    }
}