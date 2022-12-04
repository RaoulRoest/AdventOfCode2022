using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Models;

namespace AdventCalendar.Console.Services.Mappers
{
    public class StringToElfCleaningModelMapper : IStringMapper<ElfCleaningDuoModel>
    {
        private readonly string _sep = ",";

        public ElfCleaningDuoModel Map(string value)
        {
            var split = value.Split(_sep);
            var elf1 = new ElfCleaningModel(split[0]);
            var elf2 = new ElfCleaningModel(split[1]);

            return new ElfCleaningDuoModel(elf1, elf2);
        }
    }
}
