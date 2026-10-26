namespace Algoritmo;

public int Search(int[] nums, int target)
{
    int lo = 0, high = nums.Length - 1;

    while (lo <= high)
    {
        int mid = lo + (high - lo) / 2;

        if (nums[mid] == target) return mid;
        if (nums[mid] < target) lo = mid + 1;
        high = mid - 1;
    }

    return -1;
}