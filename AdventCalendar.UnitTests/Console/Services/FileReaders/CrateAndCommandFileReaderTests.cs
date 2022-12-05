using AdventCalendar.Console.Models;
using AdventCalendar.Console.Models.Dto;
using AdventCalendar.Console.Services.FileReaders;
using AdventCalendar.Console.Services.Mappers;

namespace AdventCalendar.UnitTests.Console.Services.FileReaders
{
    public class CrateAndCommandFileReaderTests
    {
        [Fact]
        public async Task CrateAndCommandFileReaderShouldReadInputFile()
        {
            // Arrange
            var filepath = $"Data\\{nameof(CrateAndCommandFileReaderTests)}\\dummydata.txt";
            var fileReader = new TextFileLineReaderAsync();
            var crateMapper = new StringToCrateStackCollectionMapper();
            var commandMapper = new StringToMoveCommandMapper();
            var sut = new CrateAndCommandFileReader(fileReader, crateMapper, commandMapper);

            var expected = new CrateInstructionDto()
            {
                Commands = new List<MoveCommand>()
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
                },
                Crates = new List<CrateStack>()
                {
                    new CrateStack(1, "NZ"),
                    new CrateStack(2, "DCM"),
                    new CrateStack(3, "P"),
                },

            };

            // Act
            var result = await sut.ReadDependendAsync(filepath);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
