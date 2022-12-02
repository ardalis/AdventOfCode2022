namespace AdventOfCode2022.Day01;

public class Elf
{
    public static IEnumerable<Elf> CreateElvesFromString(string input)
    {
        var elfStrings = input.Split(Environment.NewLine + Environment.NewLine);

        foreach (string elfString in elfStrings)
        {
            yield return new Elf(elfString);
        }
    }

    public Elf(string numbersString)
    {
        Numbers = numbersString;
        try
        {
            FoodItemCalories = Numbers
                .Split(Environment.NewLine)
                .Select(n => int.Parse(n))
                .ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Couldn't parse {numbersString}", ex);
        }
    }
    public string Numbers { get; }
    public List<int> FoodItemCalories { get; set; } = new List<int>();
    public int Total => FoodItemCalories.Sum();
}
