namespace Dsa.Test;

public class FindPeakElement162Test
{
    [Fact]
    public void TestFindPeakElement162Success1()
    {
        var nums = new int[] { 1, 2, 3, 1 };
        var expectedPosition = 2;

        var position = FindPeakElement162.FindPeakElement(nums);

        Assert.Equal(expectedPosition, position);
    }

    [Fact]
    public void TestFindPeakElement162Success2()
    {
        var nums = new int[] { 1, 2, 1, 3, 5, 6, 4 };
        var expectedPosition = 5;

        var position = FindPeakElement162.FindPeakElement(nums);

        Assert.Equal(expectedPosition, position);
    }
}