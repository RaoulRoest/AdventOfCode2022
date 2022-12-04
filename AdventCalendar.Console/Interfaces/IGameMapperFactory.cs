using AdventCalendar.Console.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.Console.Interfaces
{
    public interface IGameMapperFactory
    {
        IGameMapper Create(InputOrientation orientation);
    }
}
