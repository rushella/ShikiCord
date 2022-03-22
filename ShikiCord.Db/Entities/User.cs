using System.ComponentModel.DataAnnotations;

namespace ShikiCord.Db.Entities;

public class User
{
    [Key]
    public ulong DiscordId { get; set; }

    public int? ShikimoriId { get; set; }
}