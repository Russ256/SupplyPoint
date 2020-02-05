namespace SupplyPoint.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using SupplyPoint.Domain.AggregateModel;
    using SupplyPoint.Infrastructure.EntityConfigurations;

    public class SupplyPointDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public SupplyPointDataContext(DbContextOptions<SupplyPointDataContext> options)
                  : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
        }
    }
}