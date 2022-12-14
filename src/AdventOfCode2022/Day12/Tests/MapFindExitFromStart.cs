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
        public void FindsExitWithSampleData()
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            var map = Map.Parse(Input.SampleData);
            _output.WriteLine($"Map parse done in {timer.ElapsedMilliseconds}ms");

            var result = Map.FindStepsToExitFromStart(map);

            Assert.Equal(31, result);
        }

        [Fact]
        public void FindsExitFromAnyaHeightWithSampleData()
        {
            var map = Map.Parse(Input.SampleData);

            var aIndexes = map.Cells
                            .Where(m => m.Value == 'a' || m.Value == 'S')
                            .Select(m => m.Location)
                            .ToList();

            var shortestPath = aIndexes
                            .Select(i => Map.FindStepsToExitFromStart(map, i))
                            .Min();

            Assert.Equal(29, shortestPath);
        }

        [Fact]
        public void FindsExitForReal()
        {
            var map = Map.Parse(Input.Data);

            var result = Map.FindStepsToExitFromStart(map);

            //Assert.Equal('E', exitCell.Value);
            Assert.Equal(380, result);
        }

        [Fact]
        public void FindsExitFromAnyaHeightWithRealData()
        {
            var map = Map.Parse(Input.Data);

            var aIndexes = map.Cells
                            .Where(m => m.Value == 'a' || m.Value == 'S')
                            .Select(m => m.Location)
                            .ToList(); // 1339 a's and S

            var shortestPath = aIndexes
                            .Select(i => Map.FindStepsToExitFromStart(map, i))
                            .ToList();

            var minPath = shortestPath
                            .Min();

            Assert.Equal(200, minPath);
        }

    }
}
