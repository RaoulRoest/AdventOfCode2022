using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Models.Dto;
using AdventCalendar.Console.Questions.Base;

namespace AdventCalendar.Console.Questions
{
    public class AdventQuestionFive : AdventQuestionBase
    {
        public override int Number => 5;

        private readonly IDependendFileReader<CrateInstructionDto> _reader;
        private readonly ICraneLogicFactory _craneLogicFactory;

        public AdventQuestionFive(
            IDependendFileReader<CrateInstructionDto> reader,
            ICraneLogicFactory craneLogicFactory)
        {
            _reader = reader;
            _craneLogicFactory = craneLogicFactory;
        }

        public override async Task<object> GetFirstAnswer()
        {
            var crane = _craneLogicFactory.GetCrateCrane(9000);
            return await DoWorkWithCrane(crane);
        }

        public override async Task<object> GetSecondAnswer()
        {
            var crane = _craneLogicFactory.GetCrateCrane(9001);
            return await DoWorkWithCrane(crane);
        }

        private async Task<object> DoWorkWithCrane(ICrateCrane crane)
        {
            var path = GetFilePath();
            var result = await _reader.ReadDependendAsync(path);
            var work = crane.MoveCrates(result.Crates, result.Commands);
            var topCrates = work.OrderBy(w => w.Number).Select(w => w.GetTopCrate());

            return new string(topCrates.ToArray());
        }
    }
}
