namespace Algoritm;

public class Solution
{
    //Input:  piles = [3, 6, 7, 11], h = 8
    public int MinEatingSpeed(int[] piles, int h)
    {
        int lo = 1, hi = piles.Max();

        while (lo < hi)
        {
            int mid = lo + (hi - lo) / 2;

            if (CanFinish(piles, mid, h))
                hi = mid;
            else
                lo = mid + 1;
        }

        return lo;
    }

    private bool CanFinish(int[] piles, int k, int h)
    {
        //k = 6
        long hours = 0;
        foreach (var p in piles)
            hours += (p + k - 1) / k;

        return hours <= h;
    }
}