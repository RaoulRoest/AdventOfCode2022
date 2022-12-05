namespace AdventCalendar.Console.Interfaces
{
    public interface IAdventQuestion
    {
        public int Number { get; }

        Task<object> GetFirstAnswer();
        Task<object> GetSecondAnswer();
    }
}
