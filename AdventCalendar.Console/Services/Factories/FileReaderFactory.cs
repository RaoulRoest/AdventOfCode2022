using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Services.FileReaders;

namespace AdventCalendar.Console.Services.Factories
{
    public class FileReaderFactory : IFileReaderFactory
    {
        public IAsyncFileReader<List<string>> GetEmptyStringReader()
        {
            return new EmptyStringCollectionReader();
        }

        public IAsyncFileReader<List<string>> GetNCollectionFileReader(int n)
        {
            return new NSetFileReader(n);
        }
    }
}
