namespace Dsa;

// https://leetcode.com/problems/path-sum/description/
public static class PathSum112
{
    public static void MainPathSum()
    {
        // Input: root = [5,4,8,11,null,13,4,7,2,null,null,null,1], targetSum = 22
        // Output: true
        var root = new TreeNode(5);
        root.left = new TreeNode(4);
        root.right = new TreeNode(8);
        root.left.left = new TreeNode(11);
        root.left.left.left = new TreeNode(7);
        root.left.left.right = new TreeNode(2);
        root.right.left = new TreeNode(13);
        root.right.right = new TreeNode(4);
        root.right.right.right = new TreeNode(1);

        var result = Dfs(root, 22, 0);
        Console.WriteLine(result);

        // Input: root = [1,2,3], targetSum = 5
        // Output: false
        var root2 = new TreeNode(1);
        root2.left = new TreeNode(2);
        root2.right = new TreeNode(3);

        var result2 = Dfs(root2, 5, 0);
        Console.WriteLine(result2);

        // Input: root = [1,2], targetSum = 0
        // Output: false
        var root3 = new TreeNode(1);
        root3.left = new TreeNode(2);

        var result3 = Dfs(root3, 0, 0);
        Console.WriteLine(result3);
    }

    // Time complexity: O(n) where n is the number of nodes in the tree. We visit each node once.
    // Space complexity: O(h) where h is the height of the tree.
    //                   In the worst case (a completely unbalanced tree), the height of the tree is equal to the number of nodes, so the space complexity is O(n) on the call stack.
    //                   In the best case (a completely balanced tree), the height of the tree is log(n), so the space complexity is O(log(n)).

    public static bool Dfs(TreeNode root, int target, int sum)
    {
        if (root == null)
        {
            return false;
        }

        var newSum = root.val + sum;

        if (root.left == null && root.right == null)
        {
            if (newSum == target)
            {
                return true;
            }
        }

        return Dfs(root.left, target, newSum) || Dfs(root.right, target, newSum);
    }
}