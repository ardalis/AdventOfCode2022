namespace AdventOfCode2022.Day02.Tests;

public class CalorieSolverServiceGetMaxCaloriesCarriedByTop3Elves
{
    [Fact]
    public void ReturnsCorrectAnswer()
    {
        var result = new CalorieSolverService().GetMaxCaloriesCarriedByTop3Elves();

        Assert.Equal(209691, result);
    }
}
