namespace AdventOfCode2022.Day04.Tests;

public class IdRangePairFactoryFromString
{
    [Theory]
    [InlineData("1-1,1-3", 1, 1, 1, 3)]
    [InlineData("1-3,4-8", 1, 3, 4, 8)]
    public void ProducesCorrectIdRange(string input, int r1Start,
        int r1End, int r2Start, int r2End)
    {
        var idRangePair = IdRangePairFactory.FromString(input);
        var expectedRange1 = new IdRange(r1Start, r1End);
        var expectedRange2 = new IdRange(r2Start, r2End);
        var expectedPair = new IdRangePair(expectedRange1, expectedRange2);
        Assert.Equal(expectedPair, idRangePair);
    }
}

