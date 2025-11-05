using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyStore.Domain.IRepository;
using MyStore.Domain.IRepository.ICustomer;
using MyStore.Domain.IRepository.Order;
using MyStore.Domain.IRepository.OrderItens;
using MyStore.Domain.IRepository.Product;
using MyStore.Infrasctructure.DataAccess;
using MyStore.Infrasctructure.DataAccess.MongoDb.Repositories.Customer;
using MyStore.Infrasctructure.DataAccess.MongoDb.Repositories.Order;
using MyStore.Infrasctructure.DataAccess.MongoDb.Repositories.OrderItem;
using MyStore.Infrasctructure.DataAccess.MongoDb.Repositories.Product;
using MyStore.Infrasctructure.DataAccess.Repositories.Customer;
using MyStore.Infrasctructure.DataAccess.Repositories.Order;
using MyStore.Infrasctructure.DataAccess.Repositories.OrderItem;
using MyStore.Infrasctructure.DataAccess.Repositories.Product;
using MyStore.Infrasctructure.Extensions;
using MyStore.Infrasctructure.Seed;
using System.Reflection;

namespace MyStore.Infrasctructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            AddRepository(services);
            AddDbContext_SqlServer(services,configuration);
            AddFluentMigrator(services, configuration);
            AddMongoDb(services, configuration);
        }
        private static void AddDbContext_SqlServer(IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.ConnectionString());
            });
        }

        private static void AddRepository(IServiceCollection services)
        {
            services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            services.AddScoped<ICustomerUpdateOnlyRepository,CustomerRepository>();
            services.AddScoped<ICustomerWriteOnlyRepository,CustomerRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductUpdateOnlyRepository,ProductRepository>();
            services.AddScoped<IProductWriteOnlyRepository,ProductRepository>();
            services.AddScoped<IOrderReadRepository,OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository,OrderRepository>();
            services.AddScoped<IOrderUpdateOnlyRepository,OrderRepository>();
            services.AddScoped<IOrderItemReadRepository,OrderItemReadRepository>();
            services.AddScoped<IOrderItemUpdateOnlyRepository, OrderItemRepository>();
            services.AddScoped<IOrderItemWriteOnlyRepository, OrderItemRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MongoDbContext>();
        }

        private static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentMigratorCore().ConfigureRunner(options =>
            {
                options.AddSqlServer().WithGlobalConnectionString(configuration.ConnectionString())
                .ScanIn(Assembly.Load("MyStore.Infrasctructure")).For.All();
            });
        }
    }
}
