namespace AdventOfCode2022.Day01.Tests;

public class NewElf
{
    [Fact]
    public void PopulatesNumbers()
    {
        string input = "1000";
        var elf = new Elf(input);

        Assert.Equal(input, elf.Numbers);
    }

    [Fact]
    public void PopulatesFoodItemCalories()
    {
        string input = "1000\n2000";
        var elf = new Elf(input);

        Assert.Equal(2, elf.FoodItemCalories.Count);
        Assert.Equal(3000, elf.FoodItemCalories.Sum());
        Assert.Equal(3000, elf.Total);
    }
}
