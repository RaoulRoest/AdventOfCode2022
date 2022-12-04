using AdventCalendar.Console.Services.FileReaders;

namespace AdventCalendar.UnitTests.Services.FileReaders
{
    public class InputFileReaderTests
    {
        [Fact]
        public async Task GivenFileInputFileReaderShouldReturnCorrectResults()
        {
            // Arrange
            var inputFile = "Data\\InputFileReaderTests\\dummydata.txt";
            var sut = new EmptyStringCollectionReader();
            var expectedLists = BuildExpected();

            // Act
            var result = sut.ReadFileAsync(inputFile);

            // Assert
            var results = await result.ToListAsync();
            results.Should().BeEquivalentTo(expectedLists);
        }

        private IEnumerable<IEnumerable<string>> BuildExpected()
        {
            yield return new string[]
            {
                "2000",
                "3599",
                "5343",
            };

            yield return new string[]
            {
                "3934",
                "3594",
                "5535",
            };

            yield return new string[]
            {
                "3585",
                "3258",
                "3592",
                "350",
                "395",
            };
        }
    }
}
