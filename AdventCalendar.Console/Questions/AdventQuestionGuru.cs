using AdventCalendar.Console.Interfaces;

namespace AdventCalendar.Console.Questions
{
    public class AdventQuestionGuru : IGuru
    {
        private readonly IAdventQuestionFactory _questionFactory;

        public AdventQuestionGuru(IAdventQuestionFactory questionFactory)
        {
            _questionFactory = questionFactory;
        }

        public async Task Go(int untill)
        {
            PrintHeader();

            for (int i = 1; i <= untill; i++)
            {
                var question = _questionFactory.CreateQuestion(i);

                var answer_1 = await question.GetFirstAnswer();
                ShowAnswer(answer_1, i, 1);

                try
                {
                    var answer_2 = await question.GetSecondAnswer();
                    ShowAnswer(answer_2, i, 2);
                }
                catch (NotImplementedException e)
                {
                    System.Console.WriteLine($"Second question is not yet implemented. " 
                        + $"Message: {e.Message}");
                }

                PrintIntermediateLine();
            }
        }

        public static void ShowAnswer<T>(T answer, int questionNumber, int subQuestion)
        {
            System.Console.WriteLine(
                $"The answer of day {questionNumber}.{subQuestion}: {answer}");
        }

        public static void PrintIntermediateLine()
        {
            System.Console.WriteLine("\n");
            System.Console.WriteLine(new String('=', 50));
            System.Console.WriteLine("\n");
        }

        public static void PrintHeader()
        {
            var header = @"
╔═╗┌┬┐┬  ┬┌─┐┌┐┌┌┬┐  ╔═╗ ┬ ┬┌─┐┌─┐┌┬┐┬┌─┐┌┐┌  ╔═╗┬ ┬┬─┐┬ ┬     
╠═╣ ││└┐┌┘├┤ │││ │   ║═╬╗│ │├┤ └─┐ │ ││ ││││  ║ ╦│ │├┬┘│ │     
╩ ╩─┴┘ └┘ └─┘┘└┘ ┴   ╚═╝╚└─┘└─┘└─┘ ┴ ┴└─┘┘└┘  ╚═╝└─┘┴└─└─┘     
                                                               
───────────────────────────────────────────────────────────────


";
            System.Console.Write(header);
        }
    }
}
