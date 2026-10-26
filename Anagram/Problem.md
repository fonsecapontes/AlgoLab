49. Group Anagrams (Medium)

Given an array of strings strs, group the anagrams together. You can return the answer in any order.

An anagram is a word formed by rearranging the letters of another word, using all the original letters exactly once.

Example 1:

Input:  strs = ["eat","tea","tan","ate","nat","bat"]
Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

Example 2:

Input:  strs = [""]
Output: [[""]]

Example 3:

Input:  strs = ["a"]
Output: [["a"]]

Constraints:

1 <= strs.length <= 10^4
0 <= strs[i].length <= 100
strs[i] consists of lowercase English letters.


##Solucao
1. Cria um dicionario de chave/list de string
1. Pra cada string transforma em um array de caracteres
1. Ordena o array por ordem alfabetica
1. Transforma em uma string de volta
1. Usa essa string como chave para o dicionario
    1. Valida se ja existe
        1. Se houver retorna a lista(value)
        1. Adiciona a string na lista
    1. Se nao existir cria uma lista nova
        1. Adiciona a key/lista no dicionario
        1. Adiciona a string na lista