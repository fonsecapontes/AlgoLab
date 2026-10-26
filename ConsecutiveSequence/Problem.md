Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.

You must write an algorithm that runs in O(n) time.

Example 1:

Input:  nums = [100, 4, 200, 1, 3, 2]
Output: 4
Explanation: The longest consecutive sequence is [1, 2, 3, 4].

Example 2:

Input:  nums = [0, 3, 7, 2, 5, 8, 4, 6, 0, 1]
Output: 9

Example 3:

Input:  nums = [1, 0, 1, 2]
Output: 3

1. Cria um Hashset<int>(nums)
1. Para cada nums
    1. verifica se nums[i] - 1 existe na lista (Nao e inicio)
        1. continua
    1. Enquanto nums[i] + x existir na lista vai incrementando o x
    1. Compara o contador com o contador universal de maior
    1. Atribui ao contador universal o maior contador entre os dois