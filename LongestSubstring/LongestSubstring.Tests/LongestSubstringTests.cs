using Xunit;

namespace LongestSubstring.Tests;

public class LongestSubstringTests
{
    [Fact]
    public void abcabcbb_retorna_3()
    {
        // Maior substring sem repetição: "abc"
        var solution = new Solution();

        var result = solution.LengthOfLongestSubstring("abcabcbb");

        Assert.Equal(3, result);
    }
}
