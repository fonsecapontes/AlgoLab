public class Trie
{
    private class Node
    {
        public Dictionary<char, Node> Children { get; } = new();
        public bool IsEndOfWord { get; set; }
    }

    private readonly Node _root = new();

    public void Insert(string word)
    {
        var node = _root;
        foreach (var c in word)
        {
            if (!node.Children.TryGetValue(c, out var next))
            {
                next = new Node();
                node.Children[c] = next;
            }
            node = next;
        }
        node.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        var node = FindNode(word);
        return node != null && node.IsEndOfWord;
    }

    public bool StartsWith(string prefix) => FindNode(prefix) != null;

    // desce pelo caminho; retorna null se ele não existir
    private Node? FindNode(string s)
    {
        var node = _root;
        foreach (var c in s)
        {
            if (!node.Children.TryGetValue(c, out node))
                return null;
        }
        return node;
    }
}