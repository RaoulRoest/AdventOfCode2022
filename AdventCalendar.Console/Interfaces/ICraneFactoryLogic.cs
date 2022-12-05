namespace AdventCalendar.Console.Interfaces
{
    public interface ICraneLogicFactory
    {
        ICrateCrane GetCrateCrane(int serial);
    }
}
