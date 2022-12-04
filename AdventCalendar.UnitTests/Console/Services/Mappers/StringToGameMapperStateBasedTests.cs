using AdventCalendar.Console.Services.Mappers;

namespace AdventCalendar.UnitTests.Services.Mappers
{
    public class StringToGameMapperStateBasedTests
    {
        [Theory]
        [InlineData("A Y", "A", "X")]
        [InlineData("B X", "B", "X")]
        [InlineData("C Z", "C", "X")]
        public void GivenInputString_MapperShouldReturnCorrectGame(
            string handline, string handOne, string handTwo)
        {
            // Arrange
            var sut = new StringToGameMapperStateBased();

            // Act
            var result = sut.Map(handline);

            // Assert
            result.HandOne.Should().Be(handOne);
            result.HandTwo.Should().Be(handTwo);
        }
    }
}
