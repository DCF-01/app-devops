namespace app2;

public sealed class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Task.Run(() =>
        {
            while (true)
            {
                try
                {
                    using var client = new HttpClient();
                    var pingUri = "http://localhost:5000";

                    client.BaseAddress = new Uri(pingUri);
                    var res = client.GetAsync("/api/ping");
                    Console.WriteLine(
                        $"App2 pinged {pingUri}, response: {(int)res.Result.StatusCode} {res.Result.StatusCode}");
                    Thread.Sleep(1500);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Could not ping destination. Error: {e.Message}");
                }
            }
        }, stoppingToken);
    }
}