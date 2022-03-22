using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ShikiCord.Db;

public class ShikiCordContextFactory : IDesignTimeDbContextFactory<ShikiCordContext>
{
    public ShikiCordContext CreateDbContext(string[] args)
    {
        if (args.Length == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(args), "Please provide environment name [dev/prod]");
        }

        var environment = args[0];

        Console.WriteLine($"Creating ShikiCordContext for \"{environment}\" environment.");
        
        var configuration = new ConfigurationBuilder()
            .AddJsonFile($"dbsettings.json", false, true)
            .AddJsonFile($"dbsettings.{environment}.json", true, true)
            .Build();
        
        var optionsBuilder = new DbContextOptionsBuilder<ShikiCordContext>();
        
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("ShikiCordDb")!);

        return new ShikiCordContext(optionsBuilder.Options);
    }
}