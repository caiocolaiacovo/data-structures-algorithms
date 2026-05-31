namespace Dsa.Test;

public class CountPathsDpTest
{
    public static IEnumerable<object[]> CountPathsData =>
    [
        [
            new string[][]
            {
                ["O","O"],
                ["O","O"]
            },
            2
        ],
        [
            new string[][]
            {
                ["O","O","X"],
                ["O","O","O"],
                ["O","O","O"]
            },
            5
        ],
        [
            new string[][]
            {
                ["O","O","O"],
                ["O","O","X"],
                ["O","O","O"]
            },
            3
        ],
        [
            new string[][]
            {
                ["O","O","O"],
                ["O","X","X"],
                ["O","O","O"]
            },
            1
        ],
        [
            new string[][]
            {
                ["O","O","X","O","O","O"],
                ["O","O","X","O","O","O"],
                ["X","O","X","O","O","O"],
                ["X","X","X","O","O","O"],
                ["O","O","O","O","O","O"],
            },
            0
        ],
        [
            new string[][]
            {
                ["O","O","X","O","O","O"],
                ["O","O","O","O","O","X"],
                ["X","O","O","O","O","O"],
                ["X","X","X","O","O","O"],
                ["O","O","O","O","O","O"],
            },
            42
        ],
        [
            new string[][]
            {
                ["O","O","X","O","O","O"],
                ["O","O","O","O","O","X"],
                ["X","O","O","O","O","O"],
                ["X","X","X","O","O","O"],
                ["O","O","O","O","O","X"],
            },
            0
        ],
        [
            new string[][]
            {
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
            },
            40116600
        ],
        [
            new string[][]
            {
                ["O","O","X","X","O","O","O","X","O","O","O","O","O","O","O"],
                ["O","O","X","X","O","O","O","X","O","O","O","O","O","O","O"],
                ["O","O","O","X","O","O","O","X","O","O","O","O","O","O","O"],
                ["X","O","O","O","O","O","O","X","O","O","O","O","O","O","O"],
                ["X","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","X","X","O"],
                ["O","O","O","O","O","O","O","X","O","O","O","O","O","X","O"],
                ["O","O","O","O","O","O","O","O","X","O","O","O","O","O","O"],
                ["X","X","X","O","O","O","O","O","O","X","O","O","O","O","O"],
                ["O","O","O","O","X","X","O","O","O","O","X","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","X","X","O","O","O","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","X","O","O","O","O","O","O"],
                ["O","O","O","O","O","O","O","O","X","O","O","O","O","O","O"],
            },
            3190434
        ],
    ];

    [Theory]
    [MemberData(nameof(CountPathsData))]
    public void Should_count_paths(string[][] grid, int expectedCount)
    {
        var count = CountPathsDp.CountPathsWithDp(grid);

        Assert.Equal(expectedCount, count);
    }
}
