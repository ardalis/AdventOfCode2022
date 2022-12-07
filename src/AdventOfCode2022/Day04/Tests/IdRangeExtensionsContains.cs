using AdventOfCode2022.Day04;

namespace AdventOfCode2022.Day04.Tests;

public class IdRangeExtensionsContains
{
    [Fact]
    public void ReturnsFalseGivenDifferentSingleIdRanges()
    {
        var range1 = new IdRange(1, 1);
        var range2 = new IdRange(2, 2);

        Assert.False(range1.Contains(range2));
    }

    [Fact]
    public void ReturnsFalseGivenSmallerSourceContainsLargerRange()
    {
        var range1 = new IdRange(1, 1);
        var range2 = new IdRange(1, 3);

        Assert.False(range1.Contains(range2));

    }

    [Fact]
    public void ReturnsFalseGivenSmallerSourceContainsLargerRange2()
    {
        var range1 = new IdRange(3, 3);
        var range2 = new IdRange(2, 4);

        Assert.False(range1.Contains(range2));

    }

    [Fact]
    public void ReturnsTrueGivenRangeIncludesItself()
    {
        var range1 = new IdRange(1, 1);

        Assert.True(range1.Contains(range1));

    }

    [Fact]
    public void ReturnsTrueGivenRangeStartingOnStartEndingBeforeEnd()
    {
        var range1 = new IdRange(1, 5);
        var range2 = new IdRange(1, 3);

        Assert.True(range1.Contains(range2));

    }
}

