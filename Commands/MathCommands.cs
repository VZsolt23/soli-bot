using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace SoliBot.Commands;

public class MathCommands : BaseCommandModule
{
    [Command("add")]
    public async Task AddCommand(CommandContext ctx, params int[] numbers)
    {
        var sum = numbers.Sum();

        var formattedNumbers = numbers.Select(n => n < 0 ? $"({n})" : n.ToString());
        var quotient = string.Join(" - ", formattedNumbers);

        await ctx.Channel.SendMessageAsync($"``{quotient} = {sum}``");
    }

    [Command("subtract")]
    public async Task SubtractCommand(CommandContext ctx, params int[] numbers)
    {
        var res = numbers.First();
        foreach (var number in numbers.Skip(1))
        {
            res -= number;
        }

        var formattedNumbers = numbers.Select(n => n < 0 ? $"({n})" : n.ToString());
        var subtraction = string.Join(" - ", formattedNumbers);

        await ctx.Channel.SendMessageAsync($"``{subtraction} = {res}``");
    }

    [Command("multiply")]
    public async Task MultiplyCommand(CommandContext ctx, params int[] numbers)
    {
        var res = numbers.First();
        foreach (var number in numbers.Skip(1))
        {
            res *= number;
        }

        var formattedNumbers = numbers.Select(n => n < 0 ? $"({n})" : n.ToString());
        var product = string.Join(" * ", formattedNumbers);

        await ctx.Channel.SendMessageAsync($"``{product} = {res}``");
    }

    [Command("division")]
    public async Task DivisionCommand(CommandContext ctx, params int[] numbers)
    {
        var res = numbers.First();
        foreach (var number in numbers.Skip(1))
        {
            res /= number;
        }

        var formattedNumbers = numbers.Select(n => n < 0 ? $"({n})" : n.ToString());
        var product = string.Join(" / ", formattedNumbers);

        await ctx.Channel.SendMessageAsync($"``{product} = {res}``");
    }
}