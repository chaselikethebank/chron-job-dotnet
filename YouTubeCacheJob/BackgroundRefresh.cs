using YouTubeCacheJob;

public class BackgroundRefresh : IHostedService, IDisposable
{
    private Term? _term;
    private System.Threading.Timer _timer;
    private readonly StarterData _data;

    public BackgroundRefresh(StarterData data)
    {
        _data = data; 
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _term = new Term(); 
        _timer = new Timer(AddToCache, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        return Task.CompletedTask;
    }

    private void AddToCache(object? state)
    {
        if (_data != null)
        {
            _data.Data.Add($"The data was added: {DateTime.Now.ToLongTimeString()}");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
