namespace AdventCalendar.Console.Interfaces
{
    public interface IAsyncFileReader<T>
    {
        IAsyncEnumerable<T> ReadFileAsync(string filePath);
    }
}
