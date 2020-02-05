namespace SupplyPoint.Test.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SupplyPoint.Domain.AggregateModel;
    using SupplyPoint.Infrastructure;
    using System.Threading.Tasks;

    [TestClass]
    public class SupplyPointDataContextTests
    {
        /// <summary>
        /// Check for any errors in the ef data model.
        /// </summary>
        [TestMethod]
        public async Task ContextIsValid()
        {
            DbContextOptions<SupplyPointDataContext> options = new DbContextOptionsBuilder<SupplyPointDataContext>()
                .UseSqlite("Data Source=SupplyPoint.db")
                .Options;

            SupplyPointDataContext context = new SupplyPointDataContext(options);
            context.Database.Migrate();

            Product product = await context.Products.FirstOrDefaultAsync();
        }
    }
}