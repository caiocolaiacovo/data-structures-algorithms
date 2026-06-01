namespace Dsa.Test;

public class CodilityCountBoundedSlicesTest
{
    [Fact]
    public void Should_count_bounded_slices()
    {
        var k = 2;
        var array = new int[] { 3, 5, 7, 6, 3 };
        var expected = 9;

        var result = CodilityCountBoundedSlices.Solution(k, array);

        Assert.Equal(expected, result);
    }
}