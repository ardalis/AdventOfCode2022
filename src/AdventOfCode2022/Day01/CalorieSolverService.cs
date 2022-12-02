namespace AdventOfCode2022.Day01;
public class CalorieSolverService
{
    public int GetMaxCaloriesCarried()
    {
        string input = Input.Data;

        var elves = Elf.CreateElvesFromString(input);

        return elves.Max(e => e.Total);
    }
}
