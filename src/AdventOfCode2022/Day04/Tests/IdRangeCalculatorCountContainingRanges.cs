namespace AdventOfCode2022.Day04.Tests;

public class IdRangeCalculatorCountContainingRanges
{
    [Fact]
    public void ProducesExpectedCountForSampleInput()
    {
        string input = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";

        var result = IdRangeCalculator.CountFullyContainedRanges(input);

        Assert.Equal(2, result);
    }
    [Fact]
    public void ProducesExpectedCountForRealInput()
    {
        var result = IdRangeCalculator.CountFullyContainedRanges(Input.Data);

        Assert.Equal(515, result);
    }
}

public class IdRangeCalculatorCountOverlappingRanges
{
    [Fact]
    public void ProducesExpectedCountForSampleInput()
    {
        string input = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";

        var result = IdRangeCalculator.CountOverlappingRanges(input);

        Assert.Equal(4, result);
    }

    [Fact]
    public void ProducesExpectedCountForRealInput()
    {
        var result = IdRangeCalculator.CountOverlappingRanges(Input.Data);

        Assert.Equal(883, result);
    }
}

