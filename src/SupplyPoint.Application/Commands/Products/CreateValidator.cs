namespace SupplyPoint.Application.Commands.Products
{
    using FluentValidation;

    public class CreateValidator : AbstractValidator<CreateRequest>
    {
        public CreateValidator()
        {
            this.RuleFor(r => r.Name).NotEmpty().MaximumLength(32);
        }
    }
}