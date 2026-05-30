namespace Dsa.Test;

public class FibonacciDpTest
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    [InlineData(5, 5)]
    [InlineData(35, 9_227_465)]
    //VERY SLOW for the naive solution, moved to the next test
    // [InlineData(46, 1_836_311_903)]
    public void Should_get_sequence(int pos, int expectedValue)
    {
        var value = FibonacciDp.Fibonacci(pos);
        var valueDp = FibonacciDp.FibonacciWithDp(pos);

        Assert.Equal(expectedValue, value);
        Assert.Equal(expectedValue, valueDp);
    }

    [Fact]
    public void Should_get_sequence_dp()
    {
        var expectedValue = 1_836_311_903;

        var value = FibonacciDp.FibonacciWithDp(46);

        Assert.Equal(expectedValue, value);
    }
}

//0 1 1 2 3 5 8 13 21