namespace SupplyPoint.Application.Commands.Products
{
    using System;

    public class CreateResponse
    {
        public CreateResponse(Guid id, string name, string text)
        {
            this.Id = id;
            this.Name = name;
            this.Text = text;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Text { get; private set; }
    }
}