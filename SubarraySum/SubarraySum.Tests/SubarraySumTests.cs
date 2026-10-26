using Algoritm;
using Xunit;

namespace SubarraySum.Tests;

public class SubarraySumTests
{
    [Fact]
    public void Exemplo1_retorna_2()
    {
        // [1,1] nos índices 0–1 e 1–2
        var solution = new Solution();

        var result = solution.SubarraySum([1, 1, 1], 2);

        Assert.Equal(2, result);
    }
}
