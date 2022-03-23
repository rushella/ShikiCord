using ShikiCord.Db;

namespace ShikiCord.Core.Services;

public class ShikiLinkService
{
    private readonly ShikiCordContext _context;

    public ShikiLinkService(ShikiCordContext context)
    {
        _context = context;
    }
}