namespace Algoritm;

public int LongestConsecutive(int[] nums)
{
    var s = new HashSet<int>(nums);
    int result;

    foreach (var num in nums)
    {
        if (s.Contains(num - 1)) continue;

        var length = 1;
        while (s.Contains(num + length))
            length++;

        result = result > length ? result : length;
    }

    return result;
}
