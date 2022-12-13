using AdventOfCode2022.Day012;

namespace AdventOfCode2022.Day12.Tests
{
    public class MapParse
    {
        [Fact]
        public void ReturnsCorrectSampleMap()
        {
            var map = Map.Parse(Input.SampleData);

            Assert.Equal('S', map.Cells[0].Value);
        }

        [Fact]
        public void AddingChars()
        {
            var letter_a = 'a';

            Assert.Equal('b', letter_a + 1);
        }
    }
}
