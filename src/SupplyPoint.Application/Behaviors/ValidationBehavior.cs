namespace SupplyPoint.Application.Behaviors
{
    using FluentValidation;
    using FluentValidation.Results;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            // Run the validators
            foreach (IValidator<TRequest> validator in this.validators)
            {
                results.Add(validator.Validate(request));
            }

            // Check for errors.
            List<ValidationFailure> failures = results
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }

            TResponse response = await next();
            return response;
        }
    }
}