using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class ExceptionTitle :Exception
    {
        public ExceptionTitle() {
            Console.WriteLine("Insert a valid event's name");
            
        }
        
    }
    internal class ExceptionDate : Exception
    {
        public ExceptionDate()
        {
            Console.WriteLine("Insert a valid event's date");

        }
    }
    internal class ExceptionSeats : Exception
    {
        public ExceptionSeats()
        {
            Console.WriteLine("Insert a valid number of seats");

        }
    }
}
