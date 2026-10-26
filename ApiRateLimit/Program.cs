public class RateLimiter
{
    private readonly int _maxRequests;
    private readonly TimeSpan _window;
    private readonly Dictionary<string, Queue<DateTime>> _requests = new();
    private readonly object _lock = new();

    public RateLimiter(int maxRequests, TimeSpan window)
    {
        if (maxRequests <= 0) throw new ArgumentOutOfRangeException(nameof(maxRequests));
        if (window <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(window));

        _maxRequests = maxRequests;
        _window = window;
    }

    public bool AllowRequest(string clientId)
    {
        ArgumentException.ThrowIfNullOrEmpty(clientId);
        var now = DateTime.UtcNow;

        lock (_lock)
        {
            if (!_requests.TryGetValue(clientId, out var timestamps))
            {
                timestamps = new Queue<DateTime>();
                _requests[clientId] = timestamps;
            }

            // drop requests outside the window
            while (timestamps.Count > 0 && timestamps.Peek() <= now - _window)
                timestamps.Dequeue();

            if (timestamps.Count >= _maxRequests)
                return false; // rejected: not counted

            timestamps.Enqueue(now);
            return true;
        }
    }
}