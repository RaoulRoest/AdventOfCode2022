using AdventCalendar.Console.Interfaces;

namespace AdventCalendar.Console.Questions.Base
{
    public abstract class AdventQuestionBase : IAdventQuestion
    {
        public abstract int Number { get; }
        public abstract Task<object> GetFirstAnswer();
        public abstract Task<object> GetSecondAnswer();

        protected string GetFilePath()
        {
            return $"Data\\Day_{Number}\\input_data.txt";
        }
    }
}
