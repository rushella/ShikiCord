using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var environment = Environment.GetEnvironmentVariable("SHIKICORD_ENVIRONMENT")!;

var configuration = new ConfigurationBuilder()
    .AddJsonFile($"botsettings.json", false, true)
    .AddJsonFile($"botsettings.{environment}.json", true, true)
    .AddEnvironmentVariables()
    .Build();

var serviceProvider = new ServiceCollection()
    .AddSingleton(configuration)

    .BuildServiceProvider();