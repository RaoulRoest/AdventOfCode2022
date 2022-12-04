using AdventCalendar.Console.Services.Mappers;

namespace AdventCalendar.UnitTests.Services.Mappers
{
    public class StringToGameMapperTests
    {
        [Theory]
        [InlineData("A X", "A", "X")]
        [InlineData("B Z", "B", "Z")]
        public void GivenInputValues_GameShouldBeCreated(
            string hands, string handOne, string handTwo)
        {
            // Arrange
            var sut = new StringToGameMapper();

            // Act
            var result = sut.Map(hands);

            // Assert
            result.HandOne.Should().Be(handOne);
            result.HandTwo.Should().Be(handTwo);
        }
    }
}
