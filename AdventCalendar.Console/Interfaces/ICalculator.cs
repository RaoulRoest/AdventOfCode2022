namespace AdventCalendar.Console.Interfaces
{
    public interface ICalculator<T>
    {
        T Calculate(IEnumerable<T> input);
    }
}
