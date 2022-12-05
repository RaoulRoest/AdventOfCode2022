using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.Console.Models
{
    public class MoveCommand
    {
        public int Amount { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }
}
