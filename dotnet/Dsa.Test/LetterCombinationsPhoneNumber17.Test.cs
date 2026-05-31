namespace Dsa.Test;

public class LetterCombinationsPhoneNumber17Test
{
    [Theory]
    [InlineData("23", new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
    [InlineData("2", new string[] { "a", "b", "c" })]
    [InlineData("79", new string[] { "pw", "px", "py", "pz", "qw", "qx", "qy", "qz", "rw", "rx", "ry", "rz", "sw", "sx", "sy", "sz" })]
    public void Should_combine_letters(string digits, string[] expectedOutput)
    {
        var output = LetterCombinationsPhoneNumber17.LetterCombinations(digits);

        Assert.Equal(expectedOutput, output);
    }
}