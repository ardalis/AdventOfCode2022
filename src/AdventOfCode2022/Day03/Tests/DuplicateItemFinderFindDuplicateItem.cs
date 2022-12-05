namespace AdventOfCode2022.Day03.Tests;

public class DuplicateItemFinderFindDuplicateItem
{
    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
    [InlineData("PmmdzqPrVvPwwTWBwg", 'P')]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v')]
    [InlineData("ttgJtRGJQctTZtZT", 't')]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", 's')]
    public void FindExpectedDuplicate (string input, char expectedResult)
    {
        var finder = new DuplicateItemFinder();

        var result = finder.FindDuplicateItem(input);
        Assert.Equal(expectedResult, result);
    }
}

public class CharExtensionsGetScore
{
    [Theory]
    [InlineData('a', 1)]
    [InlineData('b', 2)]
    [InlineData('c', 3)]
    [InlineData('z', 26)]
    [InlineData('A', 27)]
    [InlineData('Z', 52)]
    public void ReturnsCorrectScoreForCharacter(char input, int expected)
    {
        var result = input.ToScore();

        Assert.Equal(expected, result);
    }
}

