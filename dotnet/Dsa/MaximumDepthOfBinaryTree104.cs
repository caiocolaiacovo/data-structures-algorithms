namespace Dsa;

// https://leetcode.com/problems/maximum-depth-of-binary-tree/
public static class MaximumDepthOfBinaryTree104
{
    public static void MainMaximumDepthOfBinaryTree()
    {
        // Input: root = [3,9,20,null,null,15,7]
        // Output: 3
        var root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.right.left = new TreeNode(15);
        root.right.right = new TreeNode(7);

        var result = MaxDepth(root);
        Console.WriteLine(result);

        // Input: root = [1,null,2]
        // Output: 2
        var root2 = new TreeNode(1);
        root2.right = new TreeNode(2);

        var result2 = MaxDepth(root2);
        Console.WriteLine(result2);
    }

    // Time complexity: O(n) where n is the number of nodes in the tree. We visit each node once.
    // Space complexity: O(h) where h is the height of the tree.
    //                   In the worst case (a completely unbalanced tree), the height of the tree is equal to the number of nodes, so the space complexity is O(n) on the call stack.
    //                   In the best case (a completely balanced tree), the height of the tree is log(n), so the space complexity is O(log(n)).
    public static int MaxDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        var leftHeight = MaxDepth(root.left);
        var rightHeight = MaxDepth(root.right);

        if (leftHeight > rightHeight)
        {
            return 1 + leftHeight;
        }
        return 1 + rightHeight;
    }
}