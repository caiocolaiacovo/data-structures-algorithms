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

    // Time complexity: O(n) -> it needs to go thru the entire list
    // Space complexity: O(1) -> no extra space is allocated
    public static int SumListIterative(Node? head)
    {
        var current = head;
        var total = 0;

        while (current != null)
        {
            total += Convert.ToInt32(current.Value);
            current = current.Next;
        }

        return total;
    }

    // Time complexity: O(n) -> it needs to go thru the entire list
    // Space complexity: O(n) -> every call needs to be added on the stack
    public static int SumListRecursive(Node? head)
    {
        static int func(Node? head)
        {
            if (head == null)
            {
                return 0;
            }

            return Convert.ToInt32(head.Value) + func(head.Next);
        }

        return func(head);
    }

    // Time complexity: O(n)
    // Space complexity: O(1)
    public static Node ReverseListIterative(Node head)
    {
        Node? previous = null;
        var current = head;

        while (current != null)
        {
            var next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }

        return previous!;
    }
    //  <- a <- b <- c <- d
    //                    p    c    n

    // Time complexity: O(n)
    // Space complexity: O(n) -> all calls are on the stack
    public static Node? ReverseListRecursive(Node head)
    {
        static Node? func(Node? previous, Node? current)
        {
            if (current == null)
            {
                return previous;
            }

            var next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;

            return func(previous, current);
        }

        return func(null, head);
    }

    // Not optimal for performance, and the constraint is that the list can't have duplicated values
    // Time complexity: O(n) -> it needs to go tru all the nodes to find the loop
    // Space complexity: O(n + n) -> O(n) -> stores all the nodes on the call stack + the visited hashset
    public static bool HasCycle(Node head)
    {
        var visited = new HashSet<string>();

        bool cycle(Node node)
        {
            if (node == null)
            {
                return false;
            }

            if (visited.Contains(node.Value))
            {
                return true;
            }

            visited.Add(node.Value);
            return cycle(node.Next);
        }

        return cycle(head);
    }

    public static bool HasCycleFastSlow(Node? head)
    {
        var slow = head;
        var fast = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
            if (slow == fast)
            {
                return true;
            }
        }

        return false;
    }
}