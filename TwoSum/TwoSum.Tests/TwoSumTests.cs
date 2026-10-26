using Algoritm;
using Xunit;

namespace TwoSum.Tests;

public class TwoSumTests
{
    private readonly Solution _solution = new();

    // A ordem dos índices não importa (Problem.md), então comparamos ordenado.
    private static int[] Sorted(int[] indices)
    {
        var copy = (int[])indices.Clone();
        Array.Sort(copy);
        return copy;
    }

    [Fact]
    public void Exemplo1_retorna_0_e_1()
    {
        var result = _solution.TwoSum([2, 7, 11, 15], 9);

        Assert.Equal(new[] { 0, 1 }, Sorted(result));
    }

    [Fact]
    public void Exemplo2_retorna_1_e_2()
    {
        var result = _solution.TwoSum([3, 2, 4], 6);

        Assert.Equal(new[] { 1, 2 }, Sorted(result));
    }

    [Fact]
    public void Exemplo3_valores_iguais()
    {
        var result = _solution.TwoSum([3, 3], 6);

        Assert.Equal(new[] { 0, 1 }, Sorted(result));
    }

    [Fact]
    public void Par_no_fim_do_array()
    {
        var result = _solution.TwoSum([1, 2, 3, 4, 5, 9], 14);

        Assert.Equal(new[] { 4, 5 }, Sorted(result));
    }

    [Fact]
    public void Numeros_negativos()
    {
        var result = _solution.TwoSum([-3, 4, 3, 90], 0);

        Assert.Equal(new[] { 0, 2 }, Sorted(result));
    }

    [Fact]
    public void Target_negativo()
    {
        var result = _solution.TwoSum([-1, -2, -3, -4, -5], -8);

        Assert.Equal(new[] { 2, 4 }, Sorted(result));
    }

    [Fact]
    public void Zero_com_zero()
    {
        var result = _solution.TwoSum([0, 4, 3, 0], 0);

        Assert.Equal(new[] { 0, 3 }, Sorted(result));
    }

    [Fact]
    public void Nao_reutiliza_o_mesmo_elemento()
    {
        // 1 + 1 == 2, mas só existe um 1: não é uma solução válida.
        var result = _solution.TwoSum([1, 5], 2);

        Assert.Empty(result);
    }

    [Fact]
    public void Sem_solucao_retorna_vazio()
    {
        var result = _solution.TwoSum([1, 2, 3], 100);

        Assert.Empty(result);
    }

    [Fact]
    public void Valores_extremos_dos_constraints()
    {
        var result = _solution.TwoSum([-1_000_000_000, 1_000_000_000], 0);

        Assert.Equal(new[] { 0, 1 }, Sorted(result));
    }

    [Fact]
    public void Entrada_grande_sem_overflow()
    {
        // nums.Length = 10^4, par no final
        var nums = Enumerable.Range(0, 10_000).ToArray();
        int target = nums[9_998] + nums[9_999];

        var result = _solution.TwoSum(nums, target);

        Assert.Equal(new[] { 9_998, 9_999 }, Sorted(result));
    }
}
