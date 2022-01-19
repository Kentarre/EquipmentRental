using EquipmentRental.Application.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .RegisterServices();

await CreateHostBuilder(args).Build().RunAsync();