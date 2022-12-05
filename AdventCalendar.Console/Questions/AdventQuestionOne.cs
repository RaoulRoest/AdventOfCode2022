using AdventCalendar.Console.Enums;
using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Questions.Base;

namespace AdventCalendar.Console.Questions
{
    public class AdventQuestionOne : AdventQuestionBase
    {
        private readonly IFileReaderFactory _readerFactory;
        private readonly IStringMultiMapper<int> _mapper;
        private readonly ICalculatorFactory _calculatorFactory;

        public AdventQuestionOne(
            IFileReaderFactory inputFileReaderFactory,
            IStringMultiMapper<int> mapper,
            ICalculatorFactory calculatorFactory)
        {
            _readerFactory = inputFileReaderFactory;
            _mapper = mapper;
            _calculatorFactory = calculatorFactory;
        }

        public override int Number => 1;

        public override async Task<object> GetFirstAnswer()
        {
            var cumSums = await ComputeCumulativeElfLoads();
            var maxCalculator = _calculatorFactory.CreateCalculator(CalculatorType.Maximum);
            return maxCalculator.Calculate(cumSums);
        }

        public override async Task<object> GetSecondAnswer()
        {
            var cumSums = await ComputeCumulativeElfLoads();
            return cumSums.OrderByDescending(x => x).Take(3).Sum();
        }

        private async Task<List<int>> ComputeCumulativeElfLoads()
        {
            var fileInput = GetFilePath();
            var reader = _readerFactory.GetEmptyStringReader();

            var input = reader.ReadFileAsync(fileInput);
            var cumCalculator = _calculatorFactory
                .CreateCalculator(CalculatorType.CumulativeSum);

            var cumSums = new List<int>();
            await foreach (var stringListLoad in input)
            {
                var calloryLoad = _mapper.Map(stringListLoad);
                var cumSum = cumCalculator.Calculate(calloryLoad);
                cumSums.Add(cumSum);
            }

            return cumSums;
        }
    }
}
