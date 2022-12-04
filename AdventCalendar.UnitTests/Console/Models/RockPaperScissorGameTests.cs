using AdventCalendar.Console.Enums;
using AdventCalendar.Console.Models;

namespace AdventCalendar.UnitTests.Models
{
    public class RockPaperScissorGameTests
    {
        [Theory]
        [InlineData("A", "Y", 8)]
        [InlineData("B", "X", 1)]
        [InlineData("C", "Z", 6)]
        public void GivenDifferentHands_RockPaperScissorsShouldHaveGivenOutcome(
            string handOne, string handTwo, int expected)
        {
            // Arrange
            var sut = new RockPaperScissorGame(handOne, handTwo);

            // Act
            var result = sut.CalculatePoints();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("A", GameStates.Lose, "Z")]
        [InlineData("A", GameStates.Win, "Y")]
        [InlineData("C", GameStates.Draw, "Z")]
        public void GivenGameState_CorrectSecondHandShouldBeFound(
            string handOne, GameStates state, string handTwo)
        {
            // Act
            var result = RockPaperScissorGame.FindSecondHandBasedOnGameState(state, handOne);

            // Assert
            result.Should().Be(handTwo);
        }

        [Theory]
        [InlineData("A", GameStates.Draw, 4)]
        [InlineData("B", GameStates.Lose, 1)]
        [InlineData("C", GameStates.Win, 7)]
        public void GivenGameState_RockPaperScissorsShouldHaveGivenOutcome(
            string handOne, GameStates state, int expected)
        {
            // Arrange
            var sut = new RockPaperScissorGame(handOne, state);

            // Act
            var result = sut.CalculatePoints();

            // Assert
            result.Should().Be(expected);
        }
    }
}
