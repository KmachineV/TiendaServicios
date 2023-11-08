using System.Diagnostics;

namespace TiendaServicios.Api.Gateway.MessageHandler;

public class LibroHandler : DelegatingHandler
{
    private readonly ILogger<LibroHandler> _logger;

    public LibroHandler(ILogger<LibroHandler> logger)
    {
        _logger = logger;
    }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var tiempo = Stopwatch.StartNew();
        _logger.LogInformation("Inicia el request");

        var response = await base.SendAsync(request, cancellationToken);

        _logger.LogInformation($"Se tardo {tiempo.Elapsed.Milliseconds} ms"); 
        return response;
    }
}