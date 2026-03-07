using System.Collections;

namespace Dsa;

public class Graph
{
    public static void MainGraph()
    {
        /*
            a -> c
            |    |
            v    v
            b    e
            |
            v
            d -> f

            output: a,b,d,f,c,e
        */
        Hashtable graph;
        
        graph = new Hashtable
        {
            {"a", new List<string>{"c", "b"} },
            {"b", new List<string>{"d"} },
            {"c", new List<string>{"e"} },
            {"d", new List<string>{"f"} },
            {"e", new List<string>{} },
            {"f", new List<string>{} },
        };

        // DepthFirstPrint(graph, "a");
        DepthFirstPrintRecursive(graph, "a"); //output: a,c,d,b,d,f

        graph = new Hashtable
        {
            {"f", new List<string>{"g", "i"} },
            {"g", new List<string>{"h"} },
            {"h", new List<string>{} },
            {"i", new List<string>{"g", "k"} },
            {"j", new List<string>{"i"} },
            {"k", new List<string>{} },
        };

        /*
            f -> g -> h
            |  /
            v /
            i <- j
            |
            v
            k

            output: true
        */

        Console.WriteLine("has path? " + HasPathDepthFirst(graph, "f", "k"));
        Console.WriteLine("(recursive) has path? " + HasPathDepthFirstRecursive(graph, "f", "k"));
        Console.WriteLine("has path breadth? " + HasPathBreadthFirst(graph, "f", "k"));


        List<List<string>> list;

        list = new List<List<string>>
        {
            new List<string>{"i", "j"},
            new List<string>{"k", "i"},
            new List<string>{"m", "k"},
            new List<string>{"k", "l"},
            new List<string>{"o", "n"}
        };

        graph = BuildGraph(list);
        Console.WriteLine("undirect path? " + UndirectPath(graph, "j", "m", new HashSet<string>()));
    }

    public static void DepthFirstPrint(Hashtable graph, string source)
    {
        var stack = new Stack<string>();
        stack.Push(source);

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            Console.WriteLine(current);

            var neighbors = (List<string>)graph[current]!;

            foreach (var n in neighbors)
            {
                stack.Push(n);
            }
        }
    }

    public static void DepthFirstPrintRecursive(Hashtable graph, string source)
    {
        Console.WriteLine(source);
        var neighbors = graph[source] as List<string>;

        foreach(var n in neighbors!)
        {
            DepthFirstPrintRecursive(graph, n);
        }
    }

    // n = number of nodes
    // e = number of edges
    // time complexity: O(e) -> we need to travel to every single edge on the graph
    // space complexity: O(n) -> in the worst case scenario, we are going to have every single node on the stack
    public static bool HasPathDepthFirst(Hashtable graph, string source, string dest)
    {
        var stack = new Stack<string>();
        stack.Push(source);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            if (current == dest)
            {
                return true;
            }

            foreach(var n in (List<string>)graph[current]!)
            {
                stack.Push(n);
            }
        }

        return false;
    }

    // n = number of nodes
    // e = number of edges
    // time complexity: O(e) -> we need to travel to every single edge on the graph
    // space complexity: O(n) -> in the worst case scenario, we are going to have every single node on the call stack
    public static bool HasPathDepthFirstRecursive(Hashtable graph, string source, string dest)
    {
        if (source == dest)
        {
            return true;
        }
        
        foreach(var n in (graph[source] as List<string>)!)
        {
            if (HasPathDepthFirstRecursive(graph, n, dest))
            {
                return true;
            }
        }

        return false;
    }

    // n = number of nodes
    // e = number of edges
    // time complexity: O(e) -> we need to travel to every single edge on the graph
    // space complexity: O(n) -> in the worst case scenario, we are going to have every single node on the queue
    public static bool HasPathBreadthFirst(Hashtable graph, string source, string dest)
    {
        var queue = new Queue<string>();
        queue.Enqueue(source);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current == dest)
            {
                return true;
            }

            foreach(var n in (List<string>)graph[current]!)
            {
                queue.Enqueue(n);
            }
        }

        return false;
    }

    public static Hashtable BuildGraph(List<List<string>> edges)
    {
        var graph = new Hashtable();

        foreach(var e in edges)
        {
            var a = e.First();
            var b = e.Last();

            if (!graph.ContainsKey(a))
            {
                graph[a] = new List<string>();
            }
            if (!graph.ContainsKey(b))
            {
                graph[b] = new List<string>();
            }

            ((List<string>)graph[a]!).Add(b);
            ((List<string>)graph[b]!).Add(a);
        }

        return graph;
    }

    public static bool UndirectPath(Hashtable graph, string source, string dest, HashSet<string> visited)
    {
        if (source == dest)
        {
            return true;
        }
        if (visited.Contains(source))
        {
            return false;
        }

        visited.Add(source);

        foreach(var n in (List<string>)graph[source]!)
        {
            if (UndirectPath(graph, n, dest, visited))
            {
                return true;
            }
        }

        return false;
    }
}