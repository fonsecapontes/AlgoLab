public class Solution
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;
        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

    public Node CopyRandomList(Node head)
    {
        if (head == null) return null;

        var map = new Dictionary<Node, Node>();

        // 1ª passada: cria todas as cópias (ainda sem ligar)
        for (var curr = head; curr != null; curr = curr.next)
            map[curr] = new Node(curr.val);

        // 2ª passada: liga next e random usando o mapa
        for (var curr = head; curr != null; curr = curr.next)
        {
            map[curr].next = curr.next == null ? null : map[curr.next];
            map[curr].random = curr.random == null ? null : map[curr.random];
        }

        return map[head];
    }
}