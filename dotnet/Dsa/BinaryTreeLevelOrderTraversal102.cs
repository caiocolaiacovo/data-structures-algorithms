
using Dsa;

public class BinaryTreeLevelOrderTraversal102
{
    public static void MainBinaryTreeLevelOrderTraversal()
    {
        // Input: root = [3,9,20,null,null,15,7]
        // Output: [[3],[9,20],[15,7]]
        var root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.right.left = new TreeNode(15);
        root.right.right = new TreeNode(7);

        var result = LevelOrder(root);
        Console.WriteLine(string.Join(", ", result.Select(x => $"[{string.Join(", ", x)}]")));

        // Input: root = [1]
        // Output: [[1]]
        var root2 = new TreeNode(1);

        var result2 = LevelOrder(root2);
        Console.WriteLine(string.Join(", ", result2.Select(x => $"[{string.Join(", ", x)}]")));

        // Input: root = []
        // Output: []
        var result3 = LevelOrder(null);
        Console.WriteLine(string.Join(", ", result3.Select(x => $"[{string.Join(", ", x)}]")));
    }
    public static IList<IList<int>> LevelOrder(TreeNode root)
    {
        IList<IList<int>> finalList = new List<IList<int>>();

        if (root == null)
        {
            return finalList;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count() > 0)
        {
            var levelList = new List<int>();
            var levelSize = queue.Count();

            while (levelSize > 0)
            {
                var current = queue.Dequeue();

                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }

                levelList.Add(current.val);
                levelSize--;
            }

            finalList.Add(levelList);
        }

        return finalList;
    }
}