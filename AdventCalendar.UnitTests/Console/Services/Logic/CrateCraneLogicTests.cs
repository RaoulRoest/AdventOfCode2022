using AdventCalendar.Console.Models;
using AdventCalendar.Console.Services.Logic;

namespace AdventCalendar.UnitTests.Console.Services.Logic
{
    public class CrateCraneLogicTests
    {
        [Fact]
        public void CraneShouldMoveInCorrectOrder()
        {
            // Arrange
            var crates = new List<CrateStack>()
            {
                new CrateStack(1, "NZ"),
                new CrateStack(2, "DCM"),
                new CrateStack(3, "P"),
            };

            var commands = new List<MoveCommand>()
            {
                new MoveCommand()
                {
                    Amount = 1,
                    From = 2,
                    To = 1,
                },

                new MoveCommand()
                {
                    Amount = 3,
                    From = 1,
                    To = 3,
                },

                new MoveCommand()
                {
                    Amount = 2,
                    From = 2,
                    To = 1,
                },

                new MoveCommand()
                {
                    Amount = 1,
                    From = 1,
                    To = 2,
                },
            };

            var expected = new List<CrateStack>()
            {
                new CrateStack(1, "C"),
                new CrateStack(2, "M"),
                new CrateStack(3, "ZNDP"),
            };

            var sut = new CrateCraneLogic();

            // Act
            var result = sut.MoveCrates(crates, commands);

            // Assert
            result.Should().BeEquivalentTo(expected);

        }
    }
}
