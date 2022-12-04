using AdventCalendar.Console.Models;

namespace AdventCalendar.UnitTests.Console.Models
{
    public class ElfCleaningDuoModelTests
    {
        [Theory]
        [MemberData(nameof(DataContainedTest))]
        public void IfOneOfTheElfsIsFullyContained_ScheduleNeedsReconsideration(
            ElfCleaningModel elf1, ElfCleaningModel elf2, bool expected)
        {
            // Arrange
            var sut = new ElfCleaningDuoModel(elf1, elf2);

            // Act
            var result = sut.NeedsReconsideration();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(DataOverlapTest))]
        public void IfOneOfTheElfsDoesOverlap_ShouldIndicateOverlapp(
            ElfCleaningModel elf1, ElfCleaningModel elf2, bool expected)
        {
            // Arrange
            var sut = new ElfCleaningDuoModel(elf1, elf2);

            // Act
            var result = sut.DoOverlap();

            // Assert
            result.Should().Be(expected);
        }

        //  2-4,6-8
        //  2-3,4-5
        //  5-7,7-9
        //  2-8,3-7
        //  6-6,4-6
        //  2-6,4-8
        public static IEnumerable<object[]> DataContainedTest()
        {
            yield return new object[]
            {
                new ElfCleaningModel("2-4"), new ElfCleaningModel("6-8"), false,
            };

            yield return new object[]
            {
                new ElfCleaningModel("2-3"), new ElfCleaningModel("4-5"), false,
            };

            yield return new object[]
            {
                new ElfCleaningModel("5-7"), new ElfCleaningModel("7-9"), false,
            };

            yield return new object[]
            {
                new ElfCleaningModel("2-8"), new ElfCleaningModel("3-7"), true,
            };

            yield return new object[]
            {
                new ElfCleaningModel("6-6"), new ElfCleaningModel("4-6"), true,
            };

            yield return new object[]
            {
                new ElfCleaningModel("2-6"), new ElfCleaningModel("4-8"), false,
            };
        }

        //  2-4,6-8
        //  2-3,4-5
        //  5-7,7-9
        //  2-8,3-7
        //  6-6,4-6
        //  2-6,4-8
        public static IEnumerable<object[]> DataOverlapTest()
        {
            yield return new object[]
            {
                new ElfCleaningModel("2-4"), new ElfCleaningModel("6-8"), false,
            };

            yield return new object[]
            {
                new ElfCleaningModel("2-3"), new ElfCleaningModel("4-5"), false,
            };

            yield return new object[]
            {
                new ElfCleaningModel("5-7"), new ElfCleaningModel("7-9"), true,
            };

            yield return new object[]
            {
                new ElfCleaningModel("2-8"), new ElfCleaningModel("3-7"), true,
            };

            yield return new object[]
            {
                new ElfCleaningModel("6-6"), new ElfCleaningModel("4-6"), true,
            };

            yield return new object[]
            {
                new ElfCleaningModel("2-6"), new ElfCleaningModel("4-8"), true,
            };
        }
    }
}
