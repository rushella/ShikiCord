using DSharpPlus;
using DSharpPlus.SlashCommands;
using ShikiCord.Db;
using ShikiCord.Core;
using ShikimoriSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShikiCord.Bot.Modules;

var rootConfiguration = ShikiCordConfigurationManager.LoadRootConfiguration();
var discordConfiguration = ShikiCordConfigurationManager.CreateDiscordClientConfiguration(rootConfiguration);
var shikimoriConfiguration = ShikiCordConfigurationManager.CreateShikiClientConfiguration(rootConfiguration);

var serviceProvider = new ServiceCollection()
    .AddSingleton(rootConfiguration)
    .AddSingleton(discordConfiguration)
    .AddSingleton(shikimoriConfiguration)
    .AddSingleton<DiscordClient>()
    .AddScoped<ShikimoriClient>()
    .AddDbContext<ShikiCordContext>((o) => o.UseNpgsql(rootConfiguration.GetConnectionString("ShikiCordDb")!))
    .BuildServiceProvider();

var discordClient = serviceProvider.GetRequiredService<DiscordClient>();

var slash = discordClient.UseSlashCommands();

slash.RegisterCommands<ShikimoriModule>(914152578391105606);

await discordClient.ConnectAsync();

await Task.Delay(Timeout.Infinite);