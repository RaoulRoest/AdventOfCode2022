namespace AdventCalendar.Console.Interfaces
{
    public interface IDependendFileReader<T>
    {
        Task<T> ReadDependendAsync(string filePath);
    }
}
