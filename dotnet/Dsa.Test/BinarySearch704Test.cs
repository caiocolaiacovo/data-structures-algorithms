namespace Dsa.Test;

public class BinarySearch704Test
{
    [Fact]
    public void TestBinarySearchSuccess1()
    {
        var nums = new int[] { -1, 0, 3, 5, 9, 12 };
        int target = 9;
        int expectedPosition = 4;

        var result = BinarySearch704.Search(nums, target);

        Assert.Equal(expectedPosition, result);
    }

    [Fact]
    public void TestBinarySearchSuccess2()
    {
        var nums = new int[] { -12, -5, -1, 0, 1, 99 };
        int target = -12;
        int expectedPosition = 0;

        var result = BinarySearch704.Search(nums, target);

        Assert.Equal(expectedPosition, result);
    }

    [Fact]
    public void TestBinarySearchFail()
    {
        var nums = new int[] { -1, 0, 3, 5, 9, 12 };
        var target = 2;
        var expectedPosition = -1;

        var result = BinarySearch704.Search(nums, target);

        Assert.Equal(expectedPosition, result);
    }
}