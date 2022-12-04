namespace AdventCalendar.Console.Interfaces
{
    public interface IStringMultiMapper<T> : IStringMapper<T>
    {
        IEnumerable<T> Map(IEnumerable<string> values);
    }

    public interface IStringMapper<T>
    {
        T Map(string value);
    }
}
