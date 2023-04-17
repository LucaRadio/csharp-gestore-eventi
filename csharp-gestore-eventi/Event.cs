using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace csharp_gestore_eventi
{
    internal class Event
    { 
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public int MaxSeats { get; }
        public int ReservedSeats { get; private set; }
        

        public Event(string title, DateTime date, int maxSeats, int reservedSeats=0)
        {
            Title = title;
            Date = date;
            MaxSeats = maxSeats;
            ReservedSeats = reservedSeats;
        }

        public int BookSeats(int seats)
        {
            int reserved=0;
            reserved += seats; 
            while (seats<0 || seats > (MaxSeats - ReservedSeats))
            {

                seats = Convert.ToInt32(Console.ReadLine());
                

                if (seats < 0 || seats > (MaxSeats - ReservedSeats))
                {
                    new ExceptionSeats();
                }
                else
                {
                    reserved = seats;
                }


            }
            return this.ReservedSeats =  reserved;
        }
        
        public int CancelSeats(int seatsToRemove)
        {
            this.ReservedSeats = this.ReservedSeats - seatsToRemove;
            return this.ReservedSeats ; 

        }

        public override string ToString()
        {
            return Date.ToString("dd/MM/yyyy")+ " - " + Title;
        }
    }
}
