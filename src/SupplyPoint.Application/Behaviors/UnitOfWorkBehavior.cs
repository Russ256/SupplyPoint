namespace SupplyPoint.Application.Behaviors
{
    using MediatR;
    using SupplyPoint.Domain.Common;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Manages the unit of work the command runs under in the Mediator pipeline.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class UnitOfWorkBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private IUnitOfWork unitOfWork;

        public UnitOfWorkBehaviour(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                await this.unitOfWork.BeginAsync();
                TResponse response = await next();
                await this.unitOfWork.CommitAsync();

                return response;
            }
            catch (Exception)
            {
                this.unitOfWork.Rollback();
                throw;
            }
        }
    }
}