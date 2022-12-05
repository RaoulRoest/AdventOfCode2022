using AdventCalendar.Console.Models;
using AdventCalendar.Console.Services.Mappers;

namespace AdventCalendar.UnitTests.Console.Services.Mappers
{
    public class StringToMoveCommandMapperTests
    {
        [Fact]
        public void StringToMoveCommandShouldYieldACorrectMoveCommand()
        {
            // Arrange
            var move = "move 2 from 1 to 7";
            var sut = new StringToMoveCommandMapper();
            var expected = new MoveCommand()
            {
                Amount = 2,
                From = 1,
                To = 7,
            };

            // Act
            var result = sut.Map(move);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
