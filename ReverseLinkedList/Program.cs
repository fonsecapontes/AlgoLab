namespace Algoritm;

public class Solution
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;

        while (curr != null)
        {
            ListNode next = curr.next; // 1. salva o resto
            curr.next = prev;          // 2. vira a seta
            prev = curr;               // 3. avança prev
            curr = next;               // 4. avança curr
        }

        return prev; // nova cabeça
    }
}