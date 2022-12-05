using AdventCalendar.Console.Models;

namespace AdventCalendar.UnitTests.Console.Models
{
    public class CrateStackTests
    {
        [Theory]
        [InlineData('A', 'A')]
        public void CrateStackShouldConvertCrateToStackItem(char input, char expected)
        {
            // Arrange
            var sut = new CrateStack(1);

            // Act
            sut.AddCrate(input);
            var result = sut.GetTopCrate();

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void CrateStackShouldStackMultipleCratesToStackItem()
        {
            // Arrange
            var crates = new List<char>()
            {
                'A', 'B', 'C', 'D'
            };
            var sut = new CrateStack(1);

            foreach (var crate in crates)
            {
                sut.AddCrate(crate);
            }

            var expected = 'D';

            // Act
            var result = sut.GetTopCrate();

            // Assert
            result.Should().Be(expected);
        }
    }
}
