namespace Dsa
{
    // https://leetcode.com/problems/invert-binary-tree/description/
    public class InvertBinaryTree226
    {
        public static void MainInvertBinaryTree()
        {
            /*
                  4
                /   \
              2      7
             / \    / \
            1   3  6   9

                  4
                /   \
              7      2
             / \    / \
            9   6  3   1
            
            expected output: 4,7,2,9,6,3,1
            */

            var a6 = new Node("4");
            var b6 = new Node("2");
            var c6 = new Node("7");
            var d6 = new Node("1");
            var e6 = new Node("3");
            var f6 = new Node("6");
            var g6 = new Node("9");

            a6.Left = b6;
            a6.Right = c6;
            b6.Left = d6;
            b6.Right = e6;
            c6.Left = f6;
            c6.Right = g6;
            InvertBinaryTree(a6);
            var result2 = BinaryTree.BreadthFirstValues(a6);
            Console.WriteLine(string.Join(",", result2));
        }

        // Complexidade de tempo
        // n = número de nodes
        // O(n) -> cada node será visitado e adicionado apenas uma única vez na stack (não teremos uma double visit)
        // Complexidade de espaço:
        // O(n) -> no pior caso, a stack pode conter n nodes, caso a árvore seja completamente desbalanceada
        public static void InvertBinaryTree(Node? root)
        {
            if (root == null)
            {
                return;
            }

            var oldLeftNode = root.Left;
            root.Left = root.Right;
            root.Right = oldLeftNode;

            InvertBinaryTree(root.Left);
            InvertBinaryTree(root.Right);
        }
    }
}