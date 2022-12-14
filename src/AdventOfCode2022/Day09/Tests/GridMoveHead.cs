using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day09.Tests;

public class GridMoveHead
{
    [Theory]
    [InlineData('R', 3, 3, 0)]
    [InlineData('L', 3, -3, 0)]
    [InlineData('U', 3, 0, 3)]
    [InlineData('D', 3, 0, -3)]
    public void MovesHeadInCorrectDirection(char dir, int distance, int x, int y)
    {
        var grid = new Grid();
        grid.MoveHead(dir, distance);

        Assert.Equal(new Point(x, y), grid.Head);
    }

    [Theory]
    [InlineData('R', 3, 2, 0)]
    [InlineData('L', 3, -2, 0)]
    [InlineData('U', 3, 0, 2)]
    [InlineData('D', 3, 0, -2)]
    public void MovesTailInCorrectDirection(char dir, int distance, int x, int y)
    {
        var grid = new Grid();
        grid.MoveHead(dir, distance);

        Assert.Equal(new Point(x, y), grid.Tail);
    }

    [Fact]
    public void Visits13PositionsGivenSampleData()
    {
        var grid = new Grid();

        var commands = Input.SampleData.Split(Environment.NewLine);
        foreach (var command in commands)
        {
            char direction = char.Parse(command.Split(" ")[0]);
            int distance = int.Parse(command.Split(" ")[1]);
            grid.MoveHead(direction, distance);
        }

        Assert.Equal(13, grid.PointsVisited.Count);
    }

    [Fact]
    public void Visits13PositionsGivenRealData()
    {
        var grid = new Grid();

        var commands = Input.Data.Split(Environment.NewLine);
        foreach (var command in commands)
        {
            char direction = char.Parse(command.Split(" ")[0]);
            int distance = int.Parse(command.Split(" ")[1]);
            grid.MoveHead(direction, distance);
        }

        Assert.Equal(6337, grid.PointsVisited.Count);
    }

}
