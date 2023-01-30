using importador;

namespace Importador;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly FeriadoOrigemHttpClient _feriadoOrigemClient;
    private readonly FeriadoDestinoHttpClient _feriadoDestinoClient;

    public Worker(ILogger<Worker> logger, FeriadoOrigemHttpClient feriadoOrigemClient, FeriadoDestinoHttpClient feriadoDestinoClient)
    {
        _logger = logger;
        _feriadoOrigemClient = feriadoOrigemClient;
        _feriadoDestinoClient = feriadoDestinoClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try {
                _logger.LogInformation("Obtendo dados de feriados.");
                var feriados = (await _feriadoOrigemClient.ObterFeriadosAsync())
                    .Select(feriadoOrigem => feriadoOrigem.AsFeriadoDestinoDto());

                _logger.LogInformation("Enviando dados de feriados para a API realizar a persistência.");
                await _feriadoDestinoClient.EnviarFeriadosAsync(feriados);
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
            }

            _logger.LogInformation("Aguardando o próximo ciclo de execução.");
            await Task.Delay(5000, stoppingToken);
        }
    }
}
