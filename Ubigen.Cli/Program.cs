using Spectre.Console.Cli;
using Ubigen.Cli.Commands;

var app = new CommandApp();

app.Configure(config =>
{
    config.SetApplicationName("ubigen");

    config.AddCommand<HelloCommand>("hello")
        .WithDescription("Merhaba komutu -> ubigen hello --name World");
    
    config.AddCommand<InitDomainCommand>("init-domain")
        .WithDescription("Servisin domain.yaml iskeletini oluşturur");
    
    config.AddCommand<InitServiceCommand>("init-service")
        .WithDescription("service.yaml dosyası oluşturur");
});

return app.Run(args);