using AdventCalendar.Console.Interfaces;

namespace AdventCalendar.Console.Services.Factories
{
    public class AdventQuestionFactory : IAdventQuestionFactory
    {
        private readonly IEnumerable<IAdventQuestion> _adventQuestions;

        public AdventQuestionFactory(IEnumerable<IAdventQuestion> adventQuestions)
        {
            _adventQuestions = adventQuestions;
        }

        public IAdventQuestion CreateQuestion(int number)
        {
            return _adventQuestions.First(q => q.Number == number);
        }
    }
}
