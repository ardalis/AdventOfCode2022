namespace AdventOfCode2022.Day04.Tests;

public class IdRangeExtensionsOverlaps
{
    [Fact]
    public void ReturnsFalseWhenRangeIsLessThanSource()
    {
        var range1 = new IdRange(5, 10);
        var range2 = new IdRange(1, 4);

        Assert.False(range1.Overlaps(range2));
    }

    [Fact]
    public void ReturnsFalseWhenRangeIsGreaterThanSource()
    {
        var range1 = new IdRange(5, 10);
        var range2 = new IdRange(11, 14);

        Assert.False(range1.Overlaps(range2));
    }

    [Fact]
    public void ReturnsTrueWhenRangeIsOverlapsStartOfSource()
    {
        var range1 = new IdRange(5, 10);
        var range2 = new IdRange(1, 5);

        Assert.True(range1.Overlaps(range2));
    }

    [Fact]
    public void ReturnsTrueWhenRangeIsOverlapsEndOfSource()
    {
        var range1 = new IdRange(5, 10);
        var range2 = new IdRange(10, 15);

        Assert.True(range1.Overlaps(range2));
    }

}

