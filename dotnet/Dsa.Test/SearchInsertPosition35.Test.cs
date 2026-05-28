namespace Dsa.Test;

public class SearchInsertPosition35Test
{
    [Fact]
    public void TestSearchInsertPosition35Success1()
    {
        var nums = new int[] { 1, 3, 5, 6 };
        var target = 5;
        var expectedPosition = 2;

        var position = SearchInsertPosition35.SearchInsert(nums, target);

        Assert.Equal(expectedPosition, position);
    }

    [Fact]
    public void TestSearchInsertPosition35Success2()
    {
        var nums = new int[] { 1, 3, 5, 6 };
        var target = 2;
        var expectedPosition = 1;

        var position = SearchInsertPosition35.SearchInsert(nums, target);

        Assert.Equal(expectedPosition, position);
    }

    [Fact]
    public void TestSearchInsertPosition35Success3()
    {
        var nums = new int[] { 1, 3, 5, 6 };
        var target = 7;
        var expectedPosition = 4;

        var position = SearchInsertPosition35.SearchInsert(nums, target);

        Assert.Equal(expectedPosition, position);
    }
}