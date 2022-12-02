namespace AdventOfCode2022.Day03.Tests;

public class TournamentServiceScoreEntireTournament
{
    [Fact]
    public void ReturnsXGivenInput()
    {
        var service = new TournamentService();

        var result = service.ScoreEntireTournament(Input.Data);

        Assert.Equal(14069, result);
    }
}
