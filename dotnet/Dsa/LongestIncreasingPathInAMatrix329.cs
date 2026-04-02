namespace Dsa;

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

        var result = LongestIncreasingPath(matrix);
        Console.WriteLine($"Longest Increasing Path: {result}");
    }
    public static int LongestIncreasingPath(int[][] matrix)
    {
        var maxCount = 0;

        for (int r = 0; r < matrix.Length; r++)
        {
            for (int c = 0; c < matrix[0].Length; c++)
            {
                var count = Dfs(matrix, r, c, -1);

                if (count > maxCount)
                {
                    maxCount = count;
                }
            }
        }

        return maxCount;
    }

    public static int LongestIncreasingPathInterative(int[][] matrix)
    {
        //TODO: implement it
        return 0;
    }

    public static int Dfs(int[][] matrix, int r, int c, int previous)
    {
        var current = matrix[r][c];
        if (current <= previous)
        {
            return 0;
        }

        var sizeRight = 0;
        var sizeBottom = 0;
        var sizeLeft = 0;
        var sizeUp = 0;

        //can move right?
        if (c < matrix[r].Length - 1)
        {
            sizeRight = Dfs(matrix, r, c + 1, current);
        }

        //can move bottom?
        if (r < matrix.Length - 1)
        {
            sizeBottom = Dfs(matrix, r + 1, c, current);
        }

        //can move left?
        if (c > 0)
        {
            sizeLeft = Dfs(matrix, r, c - 1, current);
        }

        //can move up?
        if (r > 0)
        {
            sizeUp = Dfs(matrix, r - 1, c, current);
        }

        return 1 + Math.Max(sizeRight, Math.Max(sizeBottom, Math.Max(sizeLeft, sizeUp)));
    }
}