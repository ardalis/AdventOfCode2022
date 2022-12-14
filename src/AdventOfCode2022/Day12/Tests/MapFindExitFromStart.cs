using AdventOfCode2022.Day012;
using Xunit.Abstractions;

namespace AdventOfCode2022.Day12.Tests
{
    public class MapFindExitFromStart
    {
        private readonly ITestOutputHelper _output;

        public MapFindExitFromStart(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void FindsExit()
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            var map = Map.Parse(Input.SampleData);
            _output.WriteLine($"Map parse done in {timer.ElapsedMilliseconds}ms");

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
