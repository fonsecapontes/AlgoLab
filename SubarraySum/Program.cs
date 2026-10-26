namespace Algoritm;

public class Solution
{
    public int SubarraySum(int[] nums, int k)
    {
        var prefixCount = new Dictionary<int, int> { [0] = 1 };
        int sum = 0, count = 0;

        foreach (var num in nums)
        {
            sum += num;

            if (prefixCount.TryGetValue(sum - k, out int c))
                count += c;

            prefixCount[sum] = prefixCount.GetValueOrDefault(sum) + 1;
        }

        return count;
    }
}
