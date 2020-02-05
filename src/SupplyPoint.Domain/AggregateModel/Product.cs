namespace SupplyPoint.Domain.AggregateModel
{
    using SupplyPoint.Domain.Common;
    using System;

    public class Product : AggregateRoot, IAggregateRoot
    {
        protected Product()
        {
        }

        public Product(string name, string text)
            : this()
        {
            this.Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            this.Text = !string.IsNullOrWhiteSpace(text) ? text : throw new ArgumentNullException(nameof(text));

            this.Id = Guid.NewGuid();
        }

        public string Name { get; private set; }
        public string Text { get; private set; }
    }
}