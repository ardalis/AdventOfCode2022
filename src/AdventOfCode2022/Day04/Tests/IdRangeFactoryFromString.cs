namespace AdventOfCode2022.Day04.Tests;

public class IdRangeFactoryFromString
{
    [Theory]
    [InlineData("1-1", 1, 1)]
    [InlineData("1-3", 1, 3)]
    [InlineData("4-8", 4, 8)]
    public void ProducesCorrectIdRange(string idRangeString, int start, int end)
    {
        var idRange = IdRangeFactory.FromString(idRangeString);
        var expectedRange = new IdRange(start, end);
        Assert.Equal(expectedRange, idRange);
    }
}

