using AdventCalendar.Console.Interfaces;

namespace AdventCalendar.Console.Services.FileReaders
{
    public class EmptyStringCollectionReader : IAsyncFileReader<List<string>>
    {
        public async IAsyncEnumerable<List<string>> ReadFileAsync(string filePath)
        {
            using var streamReader = new StreamReader(filePath);
            var newRowList = new List<string>();
            while (!streamReader.EndOfStream)
            {
                var row = await streamReader.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(row))
                {
                    yield return newRowList;
                    newRowList = new List<string>();
                    continue;
                }

                newRowList.Add(row);
            }

            // Also return last one. 
            yield return newRowList;
        }
    }
}
