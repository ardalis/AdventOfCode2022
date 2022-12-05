namespace AdventOfCode2022.Day03.Tests;

public class RuckScoreServiceScorePart2
{
    [Fact]
    public void ReturnsCorrectScoreInput()
    {
        var scorer = new RuckScoreService();

        var result = scorer.ScorePart2(Input.Data);

        Assert.Equal(2646, result);
    }
}

