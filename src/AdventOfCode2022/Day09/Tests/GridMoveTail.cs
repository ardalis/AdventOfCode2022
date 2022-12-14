using System.Drawing;

namespace AdventOfCode2022.Day09.Tests;

public class GridMoveTail
{
    [Theory]
    [InlineData(0, 0, 0, 0)]
    [InlineData(1, 0, 1, 0)]
    public void DoesNothingWhenHeadAndTailTogether(int x, int y, int x1, int y1)
    {
        var grid = new Grid();
        grid.Rope[0] = new Point(x, y);
        grid.Rope[1] = new Point(x1, y1);

        grid.MoveTail();

        Assert.Equal(grid.Head, grid.Tail);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(1, 0)]
    [InlineData(1, -1)]
    [InlineData(0, -1)]
    [InlineData(-1, -1)]
    [InlineData(-1, 0)]
    [InlineData(-1, 1)]
    public void DoesNothingWhenHeadAndTailAdjacent(int tailX, int tailY)
    {
        var grid = new Grid();
        grid.Rope[1] = new Point(tailX, tailY);

        grid.MoveTail();

        Assert.Equal(tailX, grid.Tail.X);
        Assert.Equal(tailY, grid.Tail.Y);
    }

    [Theory]
    [InlineData(0, 2, 0, 1)]
    [InlineData(2, 2, 1, 1)]
    [InlineData(2, 0, 1, 0)]
    [InlineData(2, -2, 1, -1)]
    [InlineData(0, -2, 0, -1)]
    [InlineData(-2, -2, -1, -1)]
    [InlineData(-2, 0, -1, 0)]
    [InlineData(-2, 2, -1, 1)]
    [InlineData(-2, 1, -1, 0)]
    public void MovesTailTowardHead(int tailX, int tailY, int newX, int newY)
    {
        var grid = new Grid();
        grid.Rope[1] = new Point(tailX, tailY);

        grid.MoveTail();

        Assert.Equal(newX, grid.Tail.X);
        Assert.Equal(newY, grid.Tail.Y);
    }

}
