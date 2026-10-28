208. Implement Trie (Prefix Tree) (Medium)

A trie is a tree that stores strings character by character, so words that share a prefix share the same path. Implement a Trie class with:

Insert(string word): inserts the word.
Search(string word): returns true if the exact word was inserted.
StartsWith(string prefix): returns true if any inserted word starts with this prefix.

Example:

Insert("apple")
Search("apple")    → true
Search("app")      → false   (only "apple" was inserted)
StartsWith("app")  → true
Insert("app")
Search("app")      → true

Constraints:

1 <= word.length, prefix.length <= 2000
Only lowercase English letters.