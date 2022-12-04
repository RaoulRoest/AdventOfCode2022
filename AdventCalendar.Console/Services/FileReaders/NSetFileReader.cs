using AdventCalendar.Console.Interfaces;

namespace AdventCalendar.Console.Services.FileReaders
{
    public class NSetFileReader : IAsyncFileReader<List<string>>
    {
        private readonly int _listSize;

        public NSetFileReader(int listSize)
        {
            _listSize = listSize;
        }

        public async IAsyncEnumerable<List<string>> ReadFileAsync(string filePath)
        {
            using var streamReader = new StreamReader(filePath);
            var newRowList = new List<string>();
            while (!streamReader.EndOfStream)
            {
                var row = await streamReader.ReadLineAsync();
                newRowList.Add(row);
                if (newRowList.Count == _listSize)
                {
                    yield return newRowList;
                    newRowList = new List<string>();
                }
            }
        }
    }
}
