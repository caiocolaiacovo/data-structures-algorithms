namespace Dsa;

public class LinkedList
{
    public class Node
    {
        public string Value { get; init; }
        public Node? Next { get; set; }
        public Node(string value)
        {
            Value = value;
            Next = null;
        }
    }

    public static IList<string> PrintAllValuesIterative(Node? head)
    {
        var result = new List<string>();
        var current = head;

        while (current != null)
        {
            result.Add(current.Value);
            current = current.Next;
        }

        return result;
    }

    public static IList<string> PrintAllValuesRecursive(Node? head)
    {
        var result = new List<string>();
        static IList<string> func(Node? head, IList<string> result)
        {
            if (head == null)
                return result;

            result.Add(head.Value);
            return func(head.Next, result);
        }

        return func(head, result);
    }
}