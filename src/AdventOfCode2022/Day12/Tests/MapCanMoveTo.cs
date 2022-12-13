using AdventOfCode2022.Day012;

namespace AdventOfCode2022.Day12.Tests
{
    public class MapCanMoveTo
    {
        [Theory]
        [InlineData('a')]
        [InlineData('b')]
        [InlineData('y')]
        [InlineData('z')]
        public void ReturnsTrueGivenSame(char input)
        {
            bool result = Map.CanMoveTo(input, input);

            Assert.True(result);
        }

        [Theory]
        [InlineData('b', 'a')]
        [InlineData('d', 'b')]
        [InlineData('y', 'n')]
        [InlineData('z', 'y')]
        public void ReturnsTrueGivenSmallerDestination(char from, char to)
        {
            bool result = Map.CanMoveTo(from, to);

            Assert.True(result);
        }

        [Theory]
        [InlineData('b', 'c')]
        [InlineData('d', 'e')]
        [InlineData('y', 'z')]
        [InlineData('m', 'n')]
        public void ReturnsTrueGivenDestinationOneHigher(char from, char to)
        {
            bool result = Map.CanMoveTo(from, to);

            Assert.True(result);
        }

        [Theory]
        [InlineData('a', 'c')]
        [InlineData('a', 'e')]
        [InlineData('a', 'z')]
        [InlineData('m', 'p')]
        public void ReturnsFalseGivenMoreThanOneHigher(char from, char to)
        {
            bool result = Map.CanMoveTo(from, to);

            Assert.False(result);
        }

        [Theory]
        [InlineData('a')]
        [InlineData('b')]
        [InlineData('c')]
        [InlineData('v')]
        public void ReturnsFalseGivenMoveToEFromNotz(char from)
        {
            bool result = Map.CanMoveTo(from, 'E');

            Assert.False(result);
        }

        [Fact]
        public void ReturnsTrueGivenzToE()
        {
            bool result = Map.CanMoveTo('z', 'E');

            Assert.True(result);
        }

        [Fact]
        public void ReturnsTrueGivenSToa()
        {
            bool result = Map.CanMoveTo('S', 'a');

            Assert.True(result);
        }
    }
}
