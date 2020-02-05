namespace SupplyPoint.Application
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SupplyPoint.Application.Queries;
    using SupplyPoint.Infrastructure;
    using System.Reflection;
    using MediatR;
    using SupplyPoint.Domain.Common;
    using SupplyPoint.Domain.AggregateModel;
    using SupplyPoint.Infrastructure.Repositories;
    using SupplyPoint.Application.Behaviors;
    using FluentValidation;
    using SupplyPoint.Application.Commands.Products;

    /// <summary>
    /// Entensions to add the application to the di container.
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddSupplyPointApplication(this IServiceCollection services, string connectionString)
        {
            return services.AddCommon(connectionString).AddCommands(connectionString).AddQueries(connectionString);
        }

        private static IServiceCollection AddCommands(this IServiceCollection services, string connectionString)
        {
            // MedaitR - by default adds all command handers
            services.AddMediatR(typeof(DependencyInjectionExtensions).GetTypeInfo().Assembly);

            // MedaitR request pipeline
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehaviour<,>));

            // Validators
            services.AddTransient<IValidator<CreateRequest>, CreateValidator>();

            // Command Infrastructure
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static IServiceCollection AddCommon(this IServiceCollection services, string connectionString)
        {
            // Infrastructure setup.
            services.AddEntityFrameworkSqlite()
                    .AddDbContext<SupplyPointDataContext>(options =>
                    {
                        options.UseSqlite(connectionString);
                    },
                    ServiceLifetime.Scoped
                    );

            return services;
        }

        private static IServiceCollection AddQueries(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IProductQueries, ProductQueries>(s =>
            {
                return new ProductQueries(connectionString);
            });

            return services;
        }
    }
}