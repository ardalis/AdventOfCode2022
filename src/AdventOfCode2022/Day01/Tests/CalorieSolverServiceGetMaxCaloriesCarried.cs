namespace AdventOfCode2022.Day01.Tests;

public class CalorieSolverServiceGetMaxCaloriesCarried
{
    [Fact]
    public void ReturnsCorrectAnswer()
    {
        var result = new CalorieSolverService().GetMaxCaloriesCarried();

        Assert.Equal(71300, result);
    }
}
