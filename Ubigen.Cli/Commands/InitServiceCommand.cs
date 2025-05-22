using System;
using System.Collections.Generic;
using System.ComponentModel;
using Spectre.Console.Cli;
using Ubigen.Core.Models;
using Ubigen.Core.Parsers;

namespace Ubigen.Cli.Commands;

/// <summary>
///  Proje kökünde (veya verilen konumda) service.yaml dosyasını oluşturur.
///  Yalnızca üst seviye bilgileri (serviceName, description, version) yazar.
///  Adapters ve boundedContexts boş liste olarak kalır.
/// </summary>
public class InitServiceSettings : CommandSettings
{
    [CommandArgument(0, "<ServiceName>")]
    [Description("Servisin adı (ör: NotificationService)")]
    public string ServiceName { get; set; } = string.Empty;

    [CommandOption("--description|-d")] public string Description { get; set; } = string.Empty;
    [CommandOption("--version|-v")]     public string Version     { get; set; } = "1.0.0";
    [CommandOption("--file|-f")]        public string ServiceFile { get; set; } = "service.yaml";
}

public class InitServiceCommand : Command<InitServiceSettings>
{
    public override int Execute(CommandContext context, InitServiceSettings s)
    {
        var model = new ServiceModel
        {
            ServiceName      = s.ServiceName,
            Description      = s.Description,
            Version          = s.Version,
            Adapters         = new(),    // boş sözlük
            BoundedContexts  = new List<string>()
        };

        ServiceYaml.Save(model, s.ServiceFile);
        Console.WriteLine($"✅ {s.ServiceFile} oluşturuldu: {s.ServiceName}");
        return 0;
    }
}
