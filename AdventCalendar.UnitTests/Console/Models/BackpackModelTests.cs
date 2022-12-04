using AdventCalendar.Console.Models;

namespace AdventCalendar.UnitTests.Models
{
    public class BackpackModelTests
    {
        [Theory]
        [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", "vJrwpWtwJgWr", "hcsFMMfFFhFp")]
        [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL")]
        public void FillBackPackShouldDivideOverTwoCompartments(
            string content, string firstCompartment, string secondCompartment)
        {
            // Arrange
            var expectedFirst = firstCompartment.ToCharArray();
            var expectedSecond = secondCompartment.ToCharArray();
            var sut = new BackpackModel(content);

            // Act
            var resultFirst = sut.FirstCompartment;
            var resultSecond = sut.SecondCompartment;

            // Assert
            resultFirst.Should().BeEquivalentTo(expectedFirst);
            resultSecond.Should().BeEquivalentTo(expectedSecond);
        }

        [Theory]
        [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
        [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
        public void FillBackPackShouldFindCorrespondingItem(
            string content, char expected)
        {
            // Arrange
            var sut = new BackpackModel(content);

            // Act
            var result = sut.FindDoublePacked();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("vJrwpWtwJgWr", "hcsFMMfFFhFp", new char[] {'p'})]
        [InlineData("jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL", new char[] {'L'})]
        public void FillBackPackShouldFindCommonItemOverDifferentContents(
            string first, string second, char[] expected)
        {
            // Arrange
            var sut = new BackpackModel(first);

            // Act
            var result = sut.FindCommon(second);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
