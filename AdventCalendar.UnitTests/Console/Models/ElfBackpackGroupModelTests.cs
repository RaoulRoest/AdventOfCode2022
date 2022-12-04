using AdventCalendar.Console.Models;

namespace AdventCalendar.UnitTests.Models
{
    public class ElfBackpackGroupModelTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void GivenThreeElfsWithBackPacks_CommenElementShouldBeKnown(
            List<string> input, char expected)
        {
            // Arrange
            var sut = new ElfBackpackGroupModel(input);

            // Act
            var result = sut.FindBatch();

            // Assert
            result.Should().Be(expected);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { new List<string>()
                    {
                        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                        "ttgJtRGJQctTZtZT",
                        "CrZsJsPPZsGzwwsLwLmpwMDw",
                    },
                    'Z',
                },
                new object[] { new List<string>()
                    {
                        "vJrwpWtwJgWrhcsFMMfFFhFp",
                        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                        "PmmdzqPrVvPwwTWBwg",
                    },
                    'r',
                },
            };
    }
}
