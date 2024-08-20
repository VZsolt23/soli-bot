using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Configuration;
using SoliBot.Commands;

namespace SoliBot;

public class Program
{
    private static DiscordClient _client { get; set; }
    private static CommandsNextExtension _commands { get; set; }

    static async Task Main(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

        IConfiguration config = builder.Build();

        var discordConfig = new DiscordConfiguration
        {
            Intents = DiscordIntents.All,
            TokenType = TokenType.Bot,
            Token = config["BotToken"],
            AutoReconnect = true
        };

        _client = new DiscordClient(discordConfig);

        _client.Ready += ClientReady;

        var commandConfig = new CommandsNextConfiguration
        {
            StringPrefixes = new[] { config["Prefix"] ?? "+" },
            EnableMentionPrefix = true,
            EnableDms = true,
            EnableDefaultHelp = true // TODO: false
        };

        _commands = _client.UseCommandsNext(commandConfig);
        
        _commands.RegisterCommands<DefaultCommands>();
        _commands.RegisterCommands<MathCommands>();

        await _client.ConnectAsync();
        await Task.Delay(-1);
    }

    private static Task ClientReady(DiscordClient sender, ReadyEventArgs args)
    {
        return Task.CompletedTask;
    }
}