namespace AdventOfCode2022.Day03.Tests;

public class RPCGameScore
{
    [Theory]
    [InlineData("A Z", 3)]
    [InlineData("B X", 1)]
    [InlineData("C Y", 2)]
    public void ReturnsHandScoreGivenLoss(string input, int handScore)
    {
        var game = RPCGame.FromString(input);

        Assert.Equal(handScore, game.Score());
    }
}
