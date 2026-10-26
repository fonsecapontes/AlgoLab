Longest Substring Without Repeating Characters (Medium)

Given a string s, find the length of the longest substring without repeating characters.

A substring is a contiguous, non-empty sequence of characters within a string.

Example 1:

Input:  s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with length 3.

Example 2:

Input:  s = "bbbbb"
Output: 1
Explanation: The answer is "b".

Example 3:

Input:  s = "pwwkew"
Output: 3
Explanation: The answer is "wke". Note that "pwke" is a subsequence, not a substring.

Constraints:

0 <= s.length <= 5 * 10^4
s consists of English letters, digits, symbols and spaces.

## Solution
1. Crio um dicionario<char, int>
1. instancio left e longest com 0
1. percorro toda string no for right
1. para cada caracter
1. Verifico se existe no dicionario e se o indice dele e maior que left
    1. se for left recebe o indice do dicionario +1
1. salvo no dicionario o right
1. longest recebe o maior entre ele e (right - left +1)
1. No fim retorno longest