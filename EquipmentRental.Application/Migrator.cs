using EquipmentRental.Data.Migrations;
using EquipmentRental.Service.Configuration;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EquipmentRental.Service;

public class Migrator : BackgroundService
{
    private readonly IConfiguration _configuration;

    public Migrator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var migrator = CreateMigrator();

        using (var sc = migrator.CreateScope())
        {
            var runner = sc.ServiceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }

        return Task.CompletedTask;
    }

    private IServiceProvider CreateMigrator()
    {
        return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSQLite()
                .WithGlobalConnectionString($"Data Source={ServiceConfig.DbPath}")
                .ScanIn(AssemblyResolver.Migrator).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
    }
}