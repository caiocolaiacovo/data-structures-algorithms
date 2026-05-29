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

    // Time complexity: O(n) -> need to traverse all the nodes
    // Space complexity: O(n) -> the array needs to store all the values
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

    // Time complexity: O(n) -> need to traverse all the nodes
    // Space complexity: O(2n) -> O(n) (big-o drops constants) -> all the calls are in the stack + the result array
    public static IList<string> PrintAllValuesRecursive(Node? head)
    {
        // Note: risk of StackOverflowException
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

    // Time complexity: 
    // O(min(n, m)) -> where n = list1 size, m = list2 size -> once any list reach null, we can adjust the rest of the list (tail.Next = rest)
    // Space complexity: O(1) -> no extra space is being created
    public static Node ZipperLists(Node head1, Node head2)
    {
        var tail = head1;
        var current1 = head1.Next;
        var current2 = head2;
        var count = 0;

        while (current1 != null && current2 != null)
        {
            if (count % 2 == 0)
            {
                tail.Next = current2;
                current2 = current2.Next;
            }
            else
            {
                tail.Next = current1;
                current1 = current1.Next;
            }

            tail = tail.Next;
            count++;
        }

        if (current1 != null)
        {
            tail.Next = current1;
        }
        if (current2 != null)
        {
            tail.Next = current2;
        }

        return head1;
    }
}

// 
//                t   c1
// a -> b -> c -> d -> e -> f
// 
//              c2
// x -> y -> z

// a -> x -> b -> y -> c -> z -> d