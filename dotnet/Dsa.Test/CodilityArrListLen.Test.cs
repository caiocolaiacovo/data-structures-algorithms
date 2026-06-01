namespace Dsa.Test;

public class CodilityArrListLenTest
{
    [Theory]
    [InlineData(4, new int[] { 1, 4, -1, 3, 2 })]
    [InlineData(9, new int[] { 9, 7, 1, 2, 11, 12, -1, 8, 10, 3, 6 })]
    public void Should_get_linked_list_length(int expected, int[] array)
    {
        var result = CodilityArrListLen.Solution(array);

        Assert.Equal(expected, result);
    }
}