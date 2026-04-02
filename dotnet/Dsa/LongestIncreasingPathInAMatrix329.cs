namespace Dsa;

// https://leetcode.com/problems/longest-increasing-path-in-a-matrix/description/
public static class LongestIncreasingPathInAMatrix329
{
    public static void MainLongestIncreasingPath()
    {
        var matrix = new int[][]
        {
            new int[]{7,7,5},
            new int[]{2,4,6},
            new int[]{8,2,0}
        };

        var result = LongestIncreasingPathRecursive(matrix);
        Console.WriteLine($"Longest Increasing Path: {result}");
    }

    // Time Complexity: O(m*n) where m is the number of rows and n is the number of columns in the matrix
    // Space Complexity: O(m*n) where m is the number of rows and n is the number of columns in the matrix
    public static int LongestIncreasingPathRecursive(int[][] matrix)
    {
        var dp = new Dictionary<string, int>();
        var maxCount = 0;

        for (int r = 0; r < matrix.Length; r++)
        {
            for (int c = 0; c < matrix[0].Length; c++)
            {
                var count = Dfs(matrix, dp, r, c, -1);

                if (count > maxCount)
                {
                    maxCount = count;
                }
            }
        }

        return maxCount;
    }

    public static int Dfs(int[][] matrix, Dictionary<string, int> dp, int r, int c, int previous)
    {
        if (r < 0 || r == matrix.Length ||
            c < 0 || c == matrix[0].Length ||
            matrix[r][c] <= previous)
        {
            return 0;
        }
        var key = $"{r}:{c}";
        if (dp.ContainsKey(key))
        {
            return dp[key];
        }

        var current = matrix[r][c];
        var size = 1;
        
        size = Math.Max(size, 1 + Dfs(matrix, dp, r + 1, c, current));
        size = Math.Max(size, 1 + Dfs(matrix, dp, r - 1, c, current));
        size = Math.Max(size, 1 + Dfs(matrix, dp, r, c + 1, current));
        size = Math.Max(size, 1 + Dfs(matrix, dp, r, c - 1, current));
        dp.Add(key, size);

        return size;
    }
}