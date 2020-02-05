namespace SupplyPoint.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using SupplyPoint.Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly SupplyPointDataContext dataContext;

        public UnitOfWork(SupplyPointDataContext dataContexts)
        {
            this.dataContext = dataContexts;
        }

        public Task BeginAsync()
        {
            // Nothing to do here.

            return Task.CompletedTask;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            int result = 0;

            IExecutionStrategy strategy = this.dataContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                IDbContextTransaction transaction = await this.dataContext.Database.BeginTransactionAsync();

                result = await this.dataContext.SaveChangesAsync(cancellationToken);

                // Note: we could also save changes in other db contexts here to participate in the transaction.

                transaction.Commit();
            });

            return result;
        }

        public void Rollback()
        {
            // Nothing to do here.
        }
    }
}