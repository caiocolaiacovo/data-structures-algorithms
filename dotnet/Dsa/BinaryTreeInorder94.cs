namespace Dsa;

// https://leetcode.com/problems/binary-tree-inorder-traversal/description/
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class BinaryTreeInorder94
{
    public static void MainBinaryTreeInorder()
    {
        // Input: root = [1,null,2,3]
        // Output: [1, 3, 2]
        var root = new TreeNode(1);
        root.right = new TreeNode(2);
        root.right.left = new TreeNode(3);

        var result = new BinaryTreeInorder94().InorderTraversal(root);
        Console.WriteLine(string.Join(", ", result));

        // Input: root = [1,2,3,4,5,null,8,null,null,6,7,9]
        // Output: [4, 2, 6, 5, 7, 1, 3, 9, 8]
        var root2 = new TreeNode(1);
        root2.left = new TreeNode(2);
        root2.right = new TreeNode(3);
        root2.left.left = new TreeNode(4);
        root2.left.right = new TreeNode(5);
        root2.right.right = new TreeNode(8);
        root2.left.right.left = new TreeNode(6);
        root2.left.right.right = new TreeNode(7);
        root2.right.right.left = new TreeNode(9);

        var result2 = new BinaryTreeInorder94().InorderTraversal(root2);
        Console.WriteLine(string.Join(", ", result2));

    }

    // n = number of nodes in the tree
    // h = height of the tree
    // Time complexity: O(n) -> we need to visit all the nodes in the tree
    // Space complexity: O(n) -> in the worst case, the tree is completely unbalanced, and we need to store all the nodes in the stack.
    //                   O(h) -> in the best case, the tree is completely balanced, and we need to store only the nodes in the current path from the root to the leaf.
    public IList<int> InorderTraversal(TreeNode root)
    {
        IList<int> output = new List<int>();
        Dfs(root, output);
        return output;
    }

    public void Dfs(TreeNode root, IList<int> output)
    {
        if (root == null)
        {
            return;
        }

        Dfs(root.left, output);
        output.Add(root.val);
        Dfs(root.right, output);
    }
}