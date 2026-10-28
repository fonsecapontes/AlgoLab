public int[] TopKFrequent(int[] nums, int k)
{
    var freq = new Dictionary<int, int>();
    foreach (var n in nums)
        freq[n] = freq.GetValueOrDefault(n) + 1;

    var heap = new PriorityQueue<int, int>(); // min-heap por prioridade (frequência)

    foreach (var (num, count) in freq)
    {
        heap.Enqueue(num, count);
        if (heap.Count > k)
            heap.Dequeue(); // remove o menos frequente
    }

    var result = new int[k];
    for (int i = 0; i < k; i++)
        result[i] = heap.Dequeue();

    return result;
}