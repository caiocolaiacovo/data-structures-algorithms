namespace Dsa;

// https://leetcode.com/problems/number-of-islands/description/
public class NumberOfIslands200
{
    // Time complexity: O(r*c) where r is the number of rows and c is the number of columns in the grid.
    // Space complexity: O(r*c) in the worst case when the whole grid is filled with land, we will have to visit all cells and store them in the visited set.
    public int NumIslands(char[][] grid)
    {
        var visited = new HashSet<string>();
        var count = 0;

        for (int r = 0; r < grid.Length; r++)
        {
            for (int c = 0; c < grid[0].Length; c++)
            {
                if (Dfs(grid, r, c, visited) != 0)
                {
                    count++;
                }
            }
        }
        return count;
    }

    public int Dfs(char[][] grid, int r, int c, HashSet<string> visited)
    {
        var current = grid[r][c];

        if (current == '0') //water
        {
            return 0;
        }

        //land
        var key = $"{r}:{c}";
        if (visited.Contains(key))
        {
            return 0;
        }

        visited.Add(key);
        //can move up?
        if (r > 0)
        {
            Dfs(grid, r - 1, c, visited);
        }

        //can move right?
        if (c < grid[r].Length - 1)
        {
            Dfs(grid, r, c + 1, visited);
        }

        // can move bottom?
        if (r < grid.Length - 1)
        {
            Dfs(grid, r + 1, c, visited);
        }

        // can move left?
        if (c >= 1)
        {
            Dfs(grid, r, c - 1, visited);
        }

        return 1;
    }
}

// [
//     ["1","0","1","1","1"],
//     ["1","0","1","0","1"],
//     ["1","1","1","0","1"]
// ]