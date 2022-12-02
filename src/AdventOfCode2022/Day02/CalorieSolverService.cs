namespace AdventOfCode2022.Day02;
public class CalorieSolverService
{
    public int GetMaxCaloriesCarried()
    {
        string input = Input.Data;

        var elves = Elf.CreateElvesFromString(input);

        return elves.Max(e => e.Total);
    }

    public int GetMaxCaloriesCarriedByTop3Elves()
    {
        string input = Input.Data;

        var elves = Elf.CreateElvesFromString(input);

        return elves
            .OrderByDescending(e => e.Total)
            .Take(3)
            .Sum(e => e.Total);
    }

}
