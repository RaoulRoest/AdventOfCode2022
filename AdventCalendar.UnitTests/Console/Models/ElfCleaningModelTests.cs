using AdventCalendar.Console.Models;

namespace AdventCalendar.UnitTests.Console.Models
{
    public class ElfCleaningModelTests
    {
        [Theory]
        [InlineData("2-4", "6-8", false)]
        [InlineData("6-6", "4-6", true)]
        public void ElfCleaningModelShouldIndicateContainment(
            string firstSections, string secondSections, bool expected)
        {
            // Arrange
            var sut = new ElfCleaningModel(firstSections);
            var comparer = new ElfCleaningModel(secondSections);

            // Act
            var result = sut.IsContainedIn(comparer);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("2-4", "6-8", false)]
        [InlineData("6-6", "4-6", true)]
        [InlineData("2-3", "4-5", false)]
        [InlineData("2-8", "3-7", true)]
        [InlineData("5-7", "7-9", true)]
        [InlineData("2-6", "4-8", true)]
        public void ElfCleaningModelShouldIndicateOverlap(
            string firstSections, string secondSections, bool expected)
        {
            // Arrange
            var sut = new ElfCleaningModel(firstSections);
            var comparer = new ElfCleaningModel(secondSections);

            // Act
            var result = sut.DoesOverlap(comparer);

            // Assert
            result.Should().Be(expected);
        }
    }
}
