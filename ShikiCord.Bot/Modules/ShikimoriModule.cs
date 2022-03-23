using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace ShikiCord.Bot.Modules;

public class ShikimoriModule : ApplicationCommandModule
{
    [SlashCommand("shiki-link", "Links your Shikimori account with Discord")]
    public async Task ShikiLinkAsync(InteractionContext ctx)
    {
        var interaction = new DiscordInteractionResponseBuilder()
            .AsEphemeral();
        
        await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource, interaction);

        var webHook = new DiscordWebhookBuilder()
            .WithContent("TODO: GENERATED URL TO THE API");
        
        await ctx.EditResponseAsync(webHook);
    }
}