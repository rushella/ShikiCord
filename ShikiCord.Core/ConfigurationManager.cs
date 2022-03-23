using DSharpPlus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShikimoriSharp.Bases;

namespace ShikiCord.Core;

public static class ShikiCordConfigurationManager
{
    public static IConfigurationRoot LoadRootConfiguration()
    {
        var environment = Environment.GetEnvironmentVariable("SHIKICORD_ENVIRONMENT")!;
        
        return new ConfigurationBuilder()
            .AddJsonFile($"shikicordsettings.json", false, true)
            .AddJsonFile($"shikicordsettings.{environment}.json", true, true)
            .Build();
    }

    public static DiscordConfiguration CreateDiscordClientConfiguration(IConfigurationRoot configurationRoot)
    {
        return new DiscordConfiguration
        {
            TokenType = TokenType.Bot,
            Token = "NzM2MTAzMDM1MDUwMjYyNTc5.Xxp7Xw.A719uc5-FjwvmWARCHuxNEVUnIY",
            AutoReconnect = true,
            MinimumLogLevel = LogLevel.Debug,
        };
    }
    
    public static ClientSettings CreateShikiClientConfiguration(IConfigurationRoot configurationRoot)
    {
        return new ClientSettings(
            configurationRoot["Shikimori:ClientName"]!, 
            configurationRoot["Shikimori:ClientId"]!, 
            configurationRoot["Shikimori:ClientSecret"]!
        );
    }
}