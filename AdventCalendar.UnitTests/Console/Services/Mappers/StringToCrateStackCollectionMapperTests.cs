using AdventCalendar.Console.Models;
using AdventCalendar.Console.Services.Mappers;

namespace AdventCalendar.UnitTests.Console.Services.Mappers
{
    public class StringToCrateStackCollectionMapperTests
    {
        [Fact]
        public void StringMapperShouldConvertHappyFlowStringLine()
        {
            // Arrange
            var oneLineInput = "[C] [H] [F] [Z] [G] [L] [V] [Z] [H]";
            var sut = new StringToCrateStackCollectionMapper();

            var expected = new Dictionary<int, char>
            {
                {1, 'C' },
                {2, 'H' },
                {3, 'F' },
                {4, 'Z' },
                {5, 'G' },
                {6, 'L' },
                {7, 'V' },
                {8, 'Z' },
                {9, 'H' },
            };

            // Act
            var result = sut.Map(oneLineInput);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void StringMapperShouldConvertNonHappyFlowStringLine()
        {
            // Arrange
            var multipleLineInput = new List<string>()
            {
                "[M] [C]     [F] [N]     [G] [W] [G]",
                "[B] [W] [J] [H] [L]     [R] [B] [C]",
                "[N] [R] [R] [W] [W] [W] [D] [N] [F]",
            };
            var sut = new StringToCrateStackCollectionMapper();

            var expected = new List<CrateStack>
            {
                new CrateStack(1, "MBN"),
                new CrateStack(2, "CWR") ,
                new CrateStack(3, "JR") ,
                new CrateStack(4, "FHW") ,
                new CrateStack(5, "NLW") ,
                new CrateStack(6, "W") ,
                new CrateStack(7, "GRD") ,
                new CrateStack(8, "WBN") ,
                new CrateStack(9, "GCF") ,
            };

            // Act
            var result = sut.Map(multipleLineInput);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
