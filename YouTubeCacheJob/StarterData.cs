using System;
namespace YouTubeCacheJob;

public class StarterData
{
    // ConcurrentBag = access multiple threads, same time, no blocking
    public System.Collections.Concurrent.ConcurrentBag<string> Data { get; set; } = new();
}

