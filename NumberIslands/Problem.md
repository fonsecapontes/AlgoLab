200. Number of Islands (Medium)

Given an m x n grid where '1' is land and '0' is water, return the number of islands. An island is a group of '1's connected horizontally or vertically (not diagonally). Assume the grid is surrounded by water.

Example 1:

Input:
  1 1 1 1 0
  1 1 0 1 0
  1 1 0 0 0
  0 0 0 0 0
Output: 1

Example 2:

Input:
  1 1 0 0 0
  1 1 0 0 0
  0 0 1 0 0
  0 0 0 1 1
Output: 3

Constraints:

1 <= m, n <= 300
grid[i][j] is '0' or '1' (note: char, not int).