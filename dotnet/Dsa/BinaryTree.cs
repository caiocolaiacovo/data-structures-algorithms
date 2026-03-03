using System.Linq;

namespace Dsa
{
    public class BinaryTree
    {
        public static void MainBinaryTree2()
        {
            var a = new Node("a");
            var b = new Node("b");
            var c = new Node("c");
            var d = new Node("d");
            var e = new Node("e");
            var f = new Node("f");
            var g = new Node("g");

            a.Left = b;
            a.Right = c;
            b.Left = d;
            b.Right = e;
            c.Right = f;
            e.Left = g;

            /*
                a
               / \
              b   c
             / \   \
            d   e   f
               /
              g

            expected output: a,b,d,e,g,c,f
            */
            Console.WriteLine(DFSStack(a));
        }

        public static string DFSStack(Node root)
        {
            var stack = new Stack<Node>();
            stack.Push(root);
            var result = new List<string>();

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                result.Add(current.SKey);

                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }
                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }
            }

            return string.Join(",", result);
        }

        // stack |
        // output: a,b,d,e,g,c,f

        public static void MainBinaryTree()
        {
            var a = new Node("a");
            var b = new Node("b");
            var c = new Node("c");
            var d = new Node("d");
            var e = new Node("e");
            var f = new Node("f");
            var g = new Node("g");

            a.Left = b;
            a.Right = c;
            b.Left = d;
            b.Right = e;
            c.Right = f;
            e.Left = g;

            var result = BreadthFirstValues(a);
            Console.WriteLine(string.Join(",", result));

            var found = TreeIncludesRecursive(a, "f");
            Console.WriteLine("Found? " + found);

            var a2 = new Node(3);
            var b2 = new Node(11);
            var c2 = new Node(4);
            var d2 = new Node(4);
            var e2 = new Node(-2);
            var f2 = new Node(1);

            a2.Left = b2;
            a2.Right = c2;
            b2.Left = d2;
            b2.Right = e2;
            c2.Right = f2;

            Console.WriteLine($"Sum recursive: {TreeSumRecursive(a2)}");
            Console.WriteLine($"Sum: {TreeSum(a2)}");

            var a3 = new Node(5);
            var b3 = new Node(11);
            var c3 = new Node(3);
            var d3 = new Node(4);
            var e3 = new Node(2);
            var f3 = new Node(1);

            a3.Left = b3;
            a3.Right = c3;
            b3.Left = d3;
            b3.Right = e3;
            c3.Right = f3;

            Console.WriteLine($"Max root to leaf path: {MaxRootToLeafPathSumRecursive(a3)}");

            var a4 = new Node(3);
            var b4 = new Node(11);
            var c4 = new Node(4);
            var d4 = new Node(4);
            var e4 = new Node(-2);
            var f4 = new Node(1);

            a4.Left = b4;
            a4.Right = c4;
            b4.Left = d4;
            b4.Right = e4;
            c4.Right = f4;

            Console.WriteLine($"Max root to leaf path: {MaxRootToLeafPathSumRecursive(a4)}");

            /*
                3
               / \
            1 9  20 3
                /  \
            1 15    7 2
                     \
                     18 1
            
            */
            var a5 = new Node(3);
            var b5 = new Node(9);
            var c5 = new Node(20);
            var d5 = new Node(15);
            var e5 = new Node(7);
            var f5 = new Node(18);

            a5.Left = b5;
            a5.Right = c5;
            c5.Left = d5;
            c5.Right = e5;
            e5.Right = f5;

            Console.WriteLine($"Is balanced: {TreeIsBalanced(a5)}");
        }

        // Depth-First Search (DFS) -> Busca em profundidade: caminha pela esquerda o mais fundo possível, volta node pai, direita
        // Complexidade de tempo:
        // n = número de nodes
        // O(n) -> cada node será visitado e adicionado uma única vez na stack (não teremos uma double visit)
        // Complexidade de espaço:
        // O(n) -> será criada uma stack com no máximo n nodes
        public static List<string> DepthFirstValues(Node root)
        {
            var stack = new Stack<Node>();
            stack.Push(root);
            var result = new List<string>();

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                result.Add(current.SKey);

                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }

                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }
            }

            return result;
        }

        /*
            a
           / \
          b   c
         / \   \
        d   e   f
           /
          g

        expected output: a,b,d,e,c,f
        */

        // Depth-First Search (DFS) -> Busca em profundidade: caminha pela esquerda o mais fundo possível, volta node pai, direita
        // Complexidade de tempo: 
        // n = número de nodes
        // O(n) -> cada node será visitado e adicionado a call stack apenas uma única vez (não teremos uma double visit)
        // Complexidade de espaço:
        // O(n) -> no pior caso, a stack de chamadas recursivas pode chegar a n, caso a árvore seja completamente desbalanceada
        public static List<string> DepthFirstValuesRecursive(Node? root)
        {
            if (root == null)
            {
                return new List<string>{};
            }

            var valuesLeft = DepthFirstValuesRecursive(root.Left);
            var valuesRight = DepthFirstValuesRecursive(root.Right);
            var final = new List<string> { root.SKey };
            final.AddRange(valuesLeft);
            final.AddRange(valuesRight);
            return final;
        }

        /*
            a
           / \
          b   c
         / \   \
        d   e   f
           /
          g
        
        expected output: a,b,c,d,e,f,g
        */
        // Breadth-First Search (BFS) -> Busca em largura: caminha por todos os nodes do mesmo nível antes de seguir para o próximo
        // Complexidade de tempo:
        // n = número de nodes
        // O(n) -> cada node será visitado e adicionado apenas uma única vez na queue (não teremos uma double visit)
        // Complexidade de espaço:
        // O(n) -> no pior caso, a queue pode conter n nodes, caso a árvore seja completamente desbalanceada
        public static List<string> BreadthFirstValues(Node? root)
        {
            if (root == null)
            {
                return new List<string>();
            }

            var result = new List<string>();
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }

                result.Add(current.SKey);
            }

            return result.ToList();
        }

        /*
            a
           / \
          b   c
         / \   \
        d   e   f
           /
          g
        
        expected output: a,b,c,d,e,f,g
        */
        // Faz a busca usando o Depth-First Traversal
        public static bool TreeIncludesRecursive(Node? root, string target)
        {
            if (root == null)
            {
                return false;
            }

            if (root.SKey == target)
            {
                return true;
            }

            var foundInLeft = TreeIncludesRecursive(root.Left, target);
            var foundInRight = TreeIncludesRecursive(root.Right, target);
            return foundInLeft || foundInRight;
        }
        //  <- <- <-
        //  
        //
        // out: a,b,c,d,e,f,g

        // Depth-First Traversal
        public static int TreeSumRecursive(Node? root)
        {
            if (root == null)
            {
                return 0;
            }

            var leftSum = TreeSumRecursive(root.Left);
            var rigthSum = TreeSumRecursive(root.Right);

            return root.IKey + leftSum + rigthSum;
        }

        // Depth-First Traversal
        // Complexidade de tempo:
        // n = número de nodes
        // O(n) -> cada node será visitado e adicionado apenas uma única vez na stack (não teremos uma double visit)
        // Complexidade de espaço:
        // O(n) -> no pior caso, a stack pode conter n nodes, caso a árvore seja completamente desbalanceada
        public static int TreeSum(Node? root)
        {
            if (root == null)
            {
                return 0;
            }

            var stack = new Stack<Node>();
            stack.Push(root);
            var totalSum = 0;

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                totalSum += current.IKey;

                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }

                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }
            }

            return totalSum;
        }

        // Max root to leaf path sum
        /*
            5
           / \
          11  3
         /  \  \
        4    2  1
         
        expected output: 20
        */
        public static int MaxRootToLeafPathSumRecursive(Node? root)
        {
            if (root == null)
            {
                return int.MaxValue * -1;
            }

            var sumLeft = MaxRootToLeafPathSumRecursive(root.Left);
            var sumRight = MaxRootToLeafPathSumRecursive(root.Right);

            if (sumLeft == sumRight)
            {
                return root.IKey;
            }

            if (sumLeft > sumRight)
            {
                return root.IKey + sumLeft;
            }

            return root.IKey + sumRight;
        }

        // Max root to leaf path sum
        /*
            3
           / \
        1 9  20 2
            /  \
         1 15   7 1
         
        
        */
        public static (bool, int) TreeIsBalanced(Node? root)
        {
            if (root == null)
            {
                return (true, 0);
            }

            (bool leftIsBalanced, int leftHeight) = TreeIsBalanced(root.Left);
            (bool rightIsBalanced, int rigthHeight) = TreeIsBalanced(root.Right);

            var diff = Math.Abs(leftHeight - rigthHeight);

            return (leftIsBalanced && rightIsBalanced && diff <= 1, Math.Max(leftHeight, rigthHeight) + 1);
        }
    }


    public class Node
    {
        public string SKey { get; }
        public int IKey { get; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public Node(string item)
        {
            SKey = item;
            IKey = 0;
            Left = null;
            Right = null;
        }

        public Node(int item)
        {
            SKey = string.Empty;
            IKey = item;
            Left = null;
            Right = null;
        }
    }
    
}