using AdventOfCode2022.Day012;

namespace AdventOfCode2022.Day12.Tests
{
    public class MapFindExitFromStart
    {
        [Fact]
        public void FindsExit()
        {
            var map = Map.Parse(Input.SampleData);

            var exitCell = Map.FindExitFromStart(map);

            Assert.Equal('E', exitCell.Value);
            Assert.Equal(31, exitCell.PathToGetHere.Count);
        }

        [Fact]
        public void FindsExitForReal()
        {
            var map = Map.Parse(Input.Data);

            var exitCell = Map.FindExitFromStart(map);

            Assert.Equal('E', exitCell.Value);
            Assert.Equal(31, exitCell.PathToGetHere.Count);
        }
    }
}
