namespace Dsa.Test;

public class BacktrackingTest
{
    [Theory]
    [InlineData(2, new string[] { "AA", "AB", "BA", "BB" })]
    [InlineData(3, new string[] { "AAA", "AAB", "ABA", "ABB", "BAA", "BAB", "BBA", "BBB" })]
    public void Should_pass(int n, IList<string> expectedResult)
    {
        var letters = new string[] { "A", "B" };
        
        var result = Backtracking.GenerateStrings(n, letters);

        Assert.Equal(expectedResult, result);
    }
}


