using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShikiCord.Db;

var environment = Environment.GetEnvironmentVariable("SHIKICORD_ENVIRONMENT")!;

var configuration = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.json", false, true)
    .AddJsonFile($"appsettings.{environment}.json", true, true)
    .AddEnvironmentVariables()
    .Build();

var serviceProvider = new ServiceCollection()
    .AddSingleton(configuration)
    .AddSingleton<ShikiCordContext>()
    .AddSingleton<DbContextOptions<ShikiCordContext>>()
    .AddDbContext<ShikiCordContext>(
        (optionsBuilder) => optionsBuilder.UseNpgsql(configuration.GetConnectionString("ShikiCordDb")!))
    .BuildServiceProvider();
    
    