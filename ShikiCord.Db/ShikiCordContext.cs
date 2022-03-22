using Microsoft.EntityFrameworkCore;
using ShikiCord.Db.Entities;

namespace ShikiCord.Db;

public class ShikiCordContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ShikiCordContext(DbContextOptions<ShikiCordContext> options) 
        : base(options)
    {
        
    }
}