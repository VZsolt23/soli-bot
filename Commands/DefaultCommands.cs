using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using SoliBot.Games.CardGame;

namespace SoliBot.Commands;

public class DefaultCommands : BaseCommandModule
{
    [Command("ping")]
    public async Task PingCommand(CommandContext ctx)
    {
        await ctx.Channel.SendMessageAsync("Pong");
    }

    [Command("hello")]
    public async Task WelcomeCommand(CommandContext ctx)
    {
        await ctx.Channel.SendMessageAsync($"Szia {ctx.User.Mention}");
    }

    [Command("embed")]
    public async Task EmbedMessageCommand(CommandContext ctx)
    {
        var message = new DiscordMessageBuilder()
            .AddEmbed(new DiscordEmbedBuilder()
                .WithTitle("First embed test")
                .WithDescription($"This command was executed by {ctx.User.Mention}")
                // .WithColor(new DiscordColor("#03fcb1"))
                .WithColor(DiscordColor.Aquamarine)
                .WithFooter("This is a footer"));

        await ctx.Channel.SendMessageAsync(message);
    }

    [Command("embedv2")]
    public async Task EmbedMessageV2Command(CommandContext ctx)
    {
        var message = new DiscordEmbedBuilder
        {
            Title = "First embed test",
            Description = $"This command was executed by {ctx.User.Mention}",
            Color = DiscordColor.Aquamarine,
            Footer = new DiscordEmbedBuilder.EmbedFooter()
        };

        await ctx.Channel.SendMessageAsync(embed: message);
    }

    [Command("cardgame")]
    public async Task CardGameCommand(CommandContext ctx)
    {
        var userCard = new CardSystem();

        var userCardEmbed = new DiscordEmbedBuilder
        {
            Title = $"Your card is {userCard.SelectedCard}",
            Color = DiscordColor.Lilac
        };

        await ctx.Channel.SendMessageAsync(embed: userCardEmbed);

        var botCard = new CardSystem();

        var botCardEmbed = new DiscordEmbedBuilder
        {
            Title = $"Bot card is {botCard.SelectedCard}",
            Color = DiscordColor.Yellow
        };

        await ctx.Channel.SendMessageAsync(embed: botCardEmbed);

        if (userCard.SelectedNumber > botCard.SelectedNumber)
        {
            var winMessage = new DiscordEmbedBuilder
            {
                Title = "Congrats, you won!",
                Color = DiscordColor.Green
            };

            await ctx.Channel.SendMessageAsync(embed: winMessage);
        }
        else
        {
            var loseMessage = new DiscordEmbedBuilder
            {
                Title = "You lost the game!",
                Color = DiscordColor.Red
            };

            await ctx.Channel.SendMessageAsync(embed: loseMessage);
        }
    }
}