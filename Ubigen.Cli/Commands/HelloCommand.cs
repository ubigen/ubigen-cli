using System;
using System.ComponentModel;
using Spectre.Console.Cli;

namespace Ubigen.Cli.Commands;

public class HelloSettings : CommandSettings
{
    [CommandOption("-n|--name")]
    [Description("Kullanıcının adı")]
    public string Name { get; set; } = "World";
}

public class HelloCommand : Command<HelloSettings>
{
    public override int Execute(CommandContext context, HelloSettings settings)
    {
        Console.WriteLine($"👋 Merhaba, {settings.Name}!");
        return 0;
    }
}