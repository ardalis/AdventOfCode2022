namespace AdventOfCode2022.Day03.Tests;

public class RuckScoreServiceScore
{
    [Fact]
    public void ReturnsCorrectScoreInput()
    {
        var scorer = new RuckScoreService();

        var result = scorer.Score(Input.Data);

        Assert.Equal(7446, result);
    }
}

