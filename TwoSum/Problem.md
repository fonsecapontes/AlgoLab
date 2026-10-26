1. Two Sum (Easy)

Given an array of integers nums and an integer target, return the indices of the two numbers that add up to target.

You may assume that each input has exactly one solution, and you may not use the same element twice. You can return the answer in any order.

Example 1:

Input:  nums = [2, 7, 11, 15], target = 9
Output: [0, 1]
Explanation: nums[0] + nums[1] == 9

Example 2:

Input:  nums = [3, 2, 4], target = 6
Output: [1, 2]

Example 3:

Input:  nums = [3, 3], target = 6
Output: [0, 1]

Constraints:

2 <= nums.length <= 10^4
-10^9 <= nums[i] <= 10^9
-10^9 <= target <= 10^9
Only one valid answer exists.

Follow-up: Can you come up with an algorithm that is better than O(n²) time complexity?

##Solution
1. Cria um dicionario de <int, int>
1. Percorre o array item por item
1. Substrai o target do item[i]
1. Procura a diferenca no dicionario como key ([i])
1. Se nao houver salva o item[i] como key e o value o indice dele [i]
1. Se houver retorna o value do dicionario e o indice atual [i]