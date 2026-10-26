public class LruCache<TKey, TValue> where TKey : notnull
{
    private readonly int _capacity;
    private readonly Dictionary<TKey, LinkedListNode<(TKey Key, TValue Value)>> _map;
    private readonly LinkedList<(TKey Key, TValue Value)> _list = new(); // front = most recent

    public LruCache(int capacity)
    {
        if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
        _capacity = capacity;
        _map = new(capacity);
    }

    public bool TryGet(TKey key, out TValue value)
    {
        if (!_map.TryGetValue(key, out var node))
        {
            value = default!;
            return false;
        }

        MoveToFront(node);
        value = node.Value.Value;
        return true;
    }

    public void Put(TKey key, TValue value)
    {
        if (_map.TryGetValue(key, out var existing))
        {
            existing.Value = (key, value);
            MoveToFront(existing);
            return;
        }

        if (_map.Count == _capacity)
        {
            var lru = _list.Last!;
            _map.Remove(lru.Value.Key);
            _list.RemoveLast();
        }

        var node = _list.AddFirst((key, value));
        _map[key] = node;
    }

    private void MoveToFront(LinkedListNode<(TKey Key, TValue Value)> node)
    {
        _list.Remove(node);
        _list.AddFirst(node);
    }
}