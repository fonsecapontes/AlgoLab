141. Linked List Cycle (Easy)

Given head, the head of a linked list, determine if the linked list has a cycle in it.

There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer.

Return true if there is a cycle in the linked list. Otherwise, return false.

Example 1:

Input:  3 → 2 → 0 → -4
            ↑         |
            └─────────┘
Output: true
Explanation: The tail connects back to the second node.

Example 2:

Input:  1 → 2
        ↑   |
        └───┘
Output: true

Example 3:

Input:  1 → null
Output: false

Constraints:

The number of nodes in the list is in the range [0, 10^4].
-10^5 <= Node.val <= 10^5

Follow-up: Can you solve it using O(1) memory?