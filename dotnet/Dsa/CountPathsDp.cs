namespace Dsa;

public class CountPathsDp
{
    // r = number of rows
    // c = number of columns
    // Time complexity: O(r*c) -> it will have the r * c different call numbers (0,0 - 0,1 - 1,0...) so once it is stored there is no need to recompute it
    // Space complexity: O(r*c) -> the memoization will contain r * c different entries (0,0 - 0,1 - 1,0...)
    public static int CountPathsWithDp(string[][] grid)
    {
        var memo = new Dictionary<string, int>();

        static int func(string[][] grid, int r, int c, Dictionary<string, int> memo)
        {
            if (grid[r][c] == "X") //Wall, stop
            {
                return 0;
            }

            if (r == grid.Length - 1 && c == grid[0].Length - 1) //bottom-right
            {
                return 1;
            }

            var key = $"{r},{c}";
            if (memo.TryGetValue(key, out var value))
            {
                return value;
            }

            var totalRight = 0;
            var totalDown = 0;

            if (c < grid[0].Length - 1)
            {
                totalRight = func(grid, r, c + 1, memo);
            }

            if (r < grid.Length - 1)
            {
                totalDown = func(grid, r + 1, c, memo);
            }
            
            value =  totalRight + totalDown;
            memo.Add(key, value);

            return value;
        }

        return func(grid, 0, 0, memo);
    }
}