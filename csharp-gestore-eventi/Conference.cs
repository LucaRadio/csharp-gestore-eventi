using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Conference : Event
    {
        public string Relator { get; set; }
        public double Price { get ; set; }
        public Conference(string title, DateTime date, int maxSeats, string relator, double price) : base(title, date, maxSeats)
        {
            
            this.Relator = relator;
            this.Price =price ;
        }
        public override string ToString()
        {
            return $"{Date.ToString("dd/MM/yyyy")} - {Title} - {Relator} - {Price.ToString("0.00")}";
        }
    }
}
