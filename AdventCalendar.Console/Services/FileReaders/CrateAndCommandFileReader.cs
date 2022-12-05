using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Models;
using AdventCalendar.Console.Models.Dto;

namespace AdventCalendar.Console.Services.FileReaders
{
    public class CrateAndCommandFileReader : IDependendFileReader<CrateInstructionDto>
    {
        private readonly IAsyncFileReader<string> _fileReader;
        private readonly IStringToCrateMapper _stringToCrateMapper;
        private readonly IStringMapper<MoveCommand> _commandMapper;

        public CrateAndCommandFileReader(
            IAsyncFileReader<string> fileReader,
            IStringToCrateMapper stringToCrateMapper,
            IStringMapper<MoveCommand> commandMapper)
        {
            _fileReader = fileReader;
            _stringToCrateMapper = stringToCrateMapper;
            _commandMapper = commandMapper;
        }

        public async Task<CrateInstructionDto> ReadDependendAsync(string filePath)
        {
            var crateLines = new List<string>();
            var commandList = new List<MoveCommand>();
            await foreach (var line in _fileReader.ReadFileAsync(filePath))
            {
                if (line.StartsWith('['))
                    crateLines.Add(line);
                else if (line.StartsWith(' '))
                    continue;
                else if (line.StartsWith("move"))
                    commandList.Add(_commandMapper.Map(line));
            }

            return new CrateInstructionDto()
            {
                Crates = _stringToCrateMapper.Map(crateLines),
                Commands = commandList,
            };
        }
    }
}
