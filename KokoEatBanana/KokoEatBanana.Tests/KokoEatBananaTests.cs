using Algoritm;
using Xunit;

namespace KokoEatBanana.Tests;

public class KokoEatBananaTests
{
    [Fact]
    public void Exemplo1_retorna_4()
    {
        // k = 4 termina em 1 + 2 + 2 + 3 = 8 horas
        var solution = new Solution();

        var result = solution.MinEatingSpeed([3, 6, 7, 11], 8);

        Assert.Equal(4, result);
    }
}
