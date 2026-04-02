public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}

// https://leetcode.com/problems/clone-graph/description/
public static class CloneGraph133
{
    public static void MainCloneGraph()
    {
        var node1 = new Node(1);
        var node2 = new Node(2);
        var node3 = new Node(3);
        var node4 = new Node(4);

        node1.neighbors.Add(node2);
        node1.neighbors.Add(node4);

        node2.neighbors.Add(node1);
        node2.neighbors.Add(node3);

        node3.neighbors.Add(node2);
        node3.neighbors.Add(node4);

        node4.neighbors.Add(node1);
        node4.neighbors.Add(node3);

        // compare copy and its neighbors with the original graph
        var copy = CloneGraph(node1);
        Console.WriteLine($"Copy Node Value: {copy.val}");
        Console.WriteLine($"Copy Neighbors: {string.Join(", ", copy.neighbors.Select(n => n.val))}");
        foreach (var neighbor in copy.neighbors)        {
            Console.WriteLine($"Neighbor {neighbor.val} Neighbors: {string.Join(", ", neighbor.neighbors.Select(n => n.val))}");
        }
    }
    public static Node CloneGraph(Node node)
    {
        if (node == null)
            return null;

        var visited = new HashSet<int>();
        var copies = new Dictionary<int, Node>();
        Node rootNodeCopy = null;
        var queue = new Queue<Node>();
        queue.Enqueue(node);

        while (queue.Count() > 0)
        {
            var current = queue.Dequeue();
            if (visited.Contains(current.val))
            {
                continue;
            }

            visited.Add(current.val);

            Node currentCopy;
            if (!copies.ContainsKey(current.val))
            {
                currentCopy = new Node(current.val);
                copies.Add(currentCopy.val, currentCopy);
            }
            else
            {
                currentCopy = copies[current.val];
            }

            if (rootNodeCopy == null)
            {
                rootNodeCopy = currentCopy;
            }

            //copy neighbors
            foreach (var n in current.neighbors)
            {
                Node nCopy;
                if (copies.ContainsKey(n.val))
                {
                    nCopy = copies[n.val];
                }
                else
                {
                    nCopy = new Node(n.val);
                    copies.Add(nCopy.val, nCopy);
                }

                currentCopy.neighbors.Add(nCopy);
                queue.Enqueue(n);
            }
        }

        return rootNodeCopy;
    }
}

// cp: 1
// current: 2
// visited: 1