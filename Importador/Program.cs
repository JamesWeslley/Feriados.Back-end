using Importador;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHttpClient<FeriadoOrigemHttpClient>(client =>
        {
            client.BaseAddress = new Uri("https://dadosbr.github.io/feriados/nacionais.json");
        });
        services.AddHttpClient<FeriadoDestinoHttpClient>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:5001/feriados/bulk");
        });
    })
    .Build();

await host.RunAsync();
