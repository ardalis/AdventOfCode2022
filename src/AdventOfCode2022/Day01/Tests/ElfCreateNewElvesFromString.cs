namespace AdventOfCode2022.Day01.Tests;

public class ElfCreateNewElvesFromString
{
    [Fact]
    public void ReturnsOneElf()
    {
        string input = "1000";
        var elf = new Elf(input);

        var elf2 = Elf.CreateElvesFromString(input).First();

        Assert.Equal(elf.Total, elf2.Total);
    }
    [Fact]
    public void ReturnsTwoElves()
    {
        string input = "1000\n\n2000\n3000";
        var elf = new Elf("1000");
        var elf2 = new Elf("2000\n3000");

        var elf_ = Elf.CreateElvesFromString(input).First();
        var elf2_ = Elf.CreateElvesFromString(input).Last();

        Assert.Equal(elf.Total, elf_.Total);
        Assert.Equal(elf2.Total, elf2_.Total);
    }
}