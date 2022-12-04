using AdventCalendar.Console.Services.Mappers;

namespace AdventCalendar.UnitTests.Services.Mappers
{
    public class CharToIntMapperTests
    {
        [Theory]
        // Lower case checks.
        [InlineData('a', 1)]
        [InlineData('n', 14)]
        [InlineData('t', 20)]
        [InlineData('y', 25)]
        [InlineData('z', 26)]
        // Upper case checks.
        [InlineData('A', 27)]
        [InlineData('N', 40)]
        [InlineData('T', 46)]
        [InlineData('Y', 51)]
        [InlineData('Z', 52)]
        public void GivenChar_IndexationShouldBePrioritized(char input, int expected)
        {
            // Arrange
            var sut = new CharToIntMapper();

            // Act
            var result = sut.Map(input);

            // Assert
            result.Should().Be(expected);
        }
    }
}
