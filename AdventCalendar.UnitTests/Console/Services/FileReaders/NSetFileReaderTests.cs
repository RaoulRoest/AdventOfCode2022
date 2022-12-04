using AdventCalendar.Console.Services.FileReaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.UnitTests.Console.Services.FileReaders
{
    public class NSetFileReaderTests
    {
        private readonly string _filePath = $"Data\\{nameof(NSetFileReaderTests)}\\dummydata.txt";
        
        [Fact]
        public async Task GivenTextFileAndNIsThree_FileShouldBeGivenInChunksOfThree()
        {
            // Arrange
            var sut = new NSetFileReader(3);

            // Act
            var result = sut.ReadFileAsync(_filePath);

            // Assert
            (await result.CountAsync()).Should().Be(4);
        }

        [Fact]
        public async Task GivenTextFileAndNIsThree_FileShouldBeGivenAsExpected()
        {
            // Arrange
            var sut = new NSetFileReader(3);
            var expected = GetExpected();

            // Act
            var result = sut.ReadFileAsync(_filePath);

            // Assert
            var resultList = await result.ToListAsync();
            resultList.Should().BeEquivalentTo(expected);
        }

        private IEnumerable<List<string>> GetExpected()
        {
            yield return new List<string>()
            {
                "LLBPGtltrGPBMMsLcLMMVMpVRhhfCDTwRwRdTfwDllRRRDhC",
                "gNFJHJFgtZFJjZJHNNFWZWZwwDjCwSDhfCDbdwjfwDTTDT",
                "gmQNZnZNHWnqmQpLtVLMBsPpBqrL",
            };

            yield return new List<string>()
            {
                "HlHldQtHlctzppdQtjdczHhJRnnhGNVmVRJmVjCVFCNh",
                "LgWNgggZJZGFhCZr",
                "DbqPswwMvDPqzlBNHtzfHdwd",
            };

            yield return new List<string>()
            {
                "tJgtJwwCtNvPHHPtHzDsdRTsBRDDWgWTgT",
                "QhLQjLGjZQFlFZmnmGLDrzWfRldrTrzTBRWTzs",
                "bFFmFZjhSFHvBCvCvJpb",
            };

            yield return new List<string>()
            {
                "MSGcvnvMGMJgWJDpdndZwBnppfCp",
                "VPVfQQVbshZNZwdNDwNs",
                "LtLbjmQRLmVhQtTbfgWjJgFFcrqqrGSqWg",
            };
        }
    }
}
