using EquipmentRental.Data;
using EquipmentRental.Data.Repositories;
using EquipmentRental.Data.Repositories.Interfaces;
using EquipmentRental.Service;
using EquipmentRental.Service.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EquipmentRental.Application.Helpers;

public static class HostBuilderExtension
{
    public static IHostBuilder RegisterServices(this IHostBuilder builder)
    {
        builder.ConfigureServices((context, services) =>
        {
            services.AddDbContext<RentalDbContext>(c =>
                c.UseSqlite($"Data Source={ServiceConfig.DbPath}"));
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            
            services.AddHostedService<Migrator>();
        });
        
        return builder;
    }
}