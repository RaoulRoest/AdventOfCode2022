using AdventCalendar.Console.Interfaces;

namespace AdventCalendar.Console.Questions.Base
{
    public abstract class AdventQuestionBase : IAdventQuestion
    {
        public abstract int Number { get; }
        public abstract Task<int> GetFirstAnswer();
        public abstract Task<int> GetSecondAnswer();

        protected string GetFilePath()
        {
            return $"Data\\Day_{Number}\\input_data.txt";
        }
    }
}
