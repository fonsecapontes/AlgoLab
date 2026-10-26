public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        var lastSeen = new Dictionary<char, int>(); // char -> último índice
        int left = 0, longest = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];

            if (lastSeen.TryGetValue(c, out int prev) && prev >= left)
                left = prev + 1;

            lastSeen[c] = right;
            longest = Math.Max(longest, right - left + 1);
        }

        return longest;
    }
}
