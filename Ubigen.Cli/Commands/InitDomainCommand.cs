using System;
using System.ComponentModel;
using System.IO;
using Spectre.Console.Cli;
using Ubigen.Core.Models;
using Ubigen.Core.Parsers;

namespace Ubigen.Cli.Commands;

/// <summary>
///  Proje kökünde (veya verilen yol altında) domain.yaml dosyasını oluşturur
///  ya da mevcutsa günceller.  İlk adımda sadece ServiceName ve Version alanları
///  set edilir.  BoundedContexts ve Integrations boş bırakılır – bunlar sonraki
///  add-* komutları ile doldurulacaktır.
/// </summary>
public class InitDomainSettings : CommandSettings
{
    [CommandArgument(0, "<ServiceName>")]
    [Description("Servisin adı (örnek: NotificationService)")]
    public string ServiceName { get; set; } = string.Empty;

    [CommandOption("--file|-f")]
    [Description("domain.yaml'ı farklı bir klasöre yazmak için mutlak veya görece yol")]
    public string FilePath { get; set; } = "domain.yaml";
}

public class InitDomainCommand : Command<InitDomainSettings>
{
    public override int Execute(CommandContext context, InitDomainSettings settings)
    {
        var path = Path.GetFullPath(settings.FilePath);

        var model = File.Exists(path) ? DomainYaml.Load(path) : new DomainModel();

        model = model with
        {
            ServiceName = settings.ServiceName,
            Version = string.IsNullOrEmpty(model.Version) ? "1.0.0" : model.Version
        };

        DomainYaml.Save(model, path);

        Console.WriteLine($"✅ domain.yaml oluşturuldu/güncellendi: {path}");
        return 0;
    }
}