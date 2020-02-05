namespace SupplyPoint.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SupplyPoint.Infrastructure;
    using SupplyPoint.Web.Data;
    using System;

    /// <summary>
    /// Class to ensure the migrations are run before the site starts so the 
    /// apply migrations page is not displayed.
    /// </summary>
    public class MigrationStartupFilter : IStartupFilter
    {
        private readonly IServiceProvider services;

        public MigrationStartupFilter(IServiceProvider services)
        {
            this.services = services;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            // Create a new scope to retrieve scoped services
            using (IServiceScope scope = this.services.CreateScope())
            {
                // Get the DbContext instance
                ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.EnsureCreated();

                // Get the DbContext instance
                SupplyPointDataContext spContext = scope.ServiceProvider.GetRequiredService<SupplyPointDataContext>();
                spContext.Database.Migrate();
            }

            return next;
        }
    }
}