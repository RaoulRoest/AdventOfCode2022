using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Services.Logic;

namespace AdventCalendar.Console.Services.Factories
{
    public class CraneLogicFactory : ICraneLogicFactory
    {
        public ICrateCrane GetCrateCrane(int serial)
        {
            if (serial == 9000)
                return new CrateCraneLogic();

            if (serial == 9001)
                return new CrateCrane9001Logic();

            throw new ArgumentException("Only got two! 9000 or 9001");
        }
    }
}
