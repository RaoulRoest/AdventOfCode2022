using AdventCalendar.Console.Interfaces;

namespace AdventCalendar.Console.Services.FileReaders
{
    public class TextFileLineReaderAsync : IAsyncFileReader<string>
    {
        public async IAsyncEnumerable<string> ReadFileAsync(string filePath)
        {
            using var streamReader = new StreamReader(filePath);
            while (!streamReader.EndOfStream)
                yield return await streamReader.ReadLineAsync();
        }
    }
}
