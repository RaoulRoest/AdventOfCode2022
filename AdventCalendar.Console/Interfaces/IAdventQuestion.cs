namespace AdventCalendar.Console.Interfaces
{
    public interface IAdventQuestion
    {
        public int Number { get; }

        Task<int> GetFirstAnswer();
        Task<int> GetSecondAnswer();
    }
}
