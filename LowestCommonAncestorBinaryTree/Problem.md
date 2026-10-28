236. Lowest Common Ancestor of a Binary Tree (Medium)

Given a binary tree and two nodes p and q that exist in it, find their lowest common ancestor (LCA): the deepest node that has both p and q as descendants. A node counts as a descendant of itself.

Example tree:

            3
          /   \
         5     1
        / \   / \
       6   2 0   8
          / \
         7   4

Example 1:

Input:  p = 5, q = 1
Output: 3
Explanation: 5 is in the left subtree and 1 is in the right, so they meet at 3.

Example 2:

Input:  p = 5, q = 4
Output: 5
Explanation: 4 is below 5, and a node can be its own ancestor.

Constraints:

The number of nodes is in the range [2, 10^5].
All values are unique.
p != q, and both exist in the tree.