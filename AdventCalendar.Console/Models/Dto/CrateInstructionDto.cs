namespace AdventCalendar.Console.Models.Dto
{
    public class CrateInstructionDto
    {
        public IEnumerable<CrateStack> Crates { get; set; }
        public IEnumerable<MoveCommand> Commands { get; set; }
    }
}
